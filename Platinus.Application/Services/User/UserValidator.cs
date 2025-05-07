using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Platinus.Application.DTOs.Requests;
using Platinus.Infrastructure.Context;

namespace Platinus.Application.Services.User
{
    public class UserValidator : AbstractValidator<RequestUser>
    {
        public UserValidator(AppDbContext db)
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MaximumLength(100).WithMessage("O nome pode ter no máximo 100 caracteres.");

            RuleFor(x => x.Nick)
                .NotEmpty().WithMessage("O nick é obrigatório.")
                .MustAsync(async (nick, cancellation) =>
                {
                    return !await db.Users.AnyAsync(u => u.Nick == nick, cancellationToken: cancellation);
                }).WithMessage("Este nick já está em uso.");

            RuleFor(x => x.Email)
                 .NotEmpty().WithMessage("O e-mail é obrigatório.")
                 .EmailAddress().WithMessage("Formato de e-mail inválido.")
                 .MustAsync(async (email, cancellation) =>
                 {
                     return !await db.Users.AnyAsync(u => u.Email == email, cancellationToken: cancellation);
                 }).WithMessage("Este e-mail já está em uso.");

            RuleFor(x => x.Description)
                .MaximumLength(250).WithMessage("A descrição pode ter no máximo 250 caracteres.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("A senha é obrigatória.")
                .MinimumLength(6).WithMessage("A senha deve ter pelo menos 6 caracteres.");

            RuleFor(x => x.Role)
                .IsInEnum().WithMessage("Rota informado é inválido.");
        }
    }
}
