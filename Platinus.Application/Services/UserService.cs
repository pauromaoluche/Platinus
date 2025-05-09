using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Platinus.Application.DTOs.Requests;
using Platinus.Application.DTOs.Response;
using Platinus.Application.Interfaces;
using Platinus.Domain.Entities;
using Platinus.Domain.Exceptions;
using Platinus.Infrastructure.Context;

namespace Platinus.Application.Services
{
    public class UserService : IUserService
    {
        private AppDbContext _db;
        private IMapper _mapper;

        public UserService(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ResponseShortUser> CreateUser(RequestUser dto)
        {
            await ValidateAsync(dto);

            var user = _mapper.Map<User>(dto);
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            return _mapper.Map<ResponseShortUser>(user);
        }

        public async Task<ResponseAllUser> GetAll()
        {
            var users = await _db.Users.ToListAsync();

            var userDtos = _mapper.Map<List<ResponseShortUser>>(users);

            return new ResponseAllUser
            {
                Users = userDtos
            };
        }

        private async Task ValidateAsync(RequestUser request)
        {
            var validator = new UserValidator(_db);

            var result = await validator.ValidateAsync(request);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
