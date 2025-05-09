using Microsoft.EntityFrameworkCore;
using Platinus.Application.DTOs.Requests;
using Platinus.Application.DTOs.Response;
using Platinus.Application.Interfaces;
using Platinus.Domain.Exceptions;
using Platinus.Infrastructure.Context;

namespace Platinus.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _db;
        private readonly ITokenService _tokenService;

        public AuthService(AppDbContext db, ITokenService tokenService)
        {
            _db = db;
            _tokenService = tokenService;
        }

        public async Task<ResponseAuthUser> Auth(RequestAuthUser request)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == request.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                throw new NotFoundException("Login ou senha inválidos.");
            }

            var token = _tokenService.Generate(user);
            return new ResponseAuthUser { Token = token };
        }
    }
}
