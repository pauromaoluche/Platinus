using Microsoft.EntityFrameworkCore;
using Platinus.Application.DTOs.Response;
using Platinus.Application.Interfaces;
using Platinus.Domain.Entities;
using Platinus.Infrastructure.Context;

namespace Platinus.Application.Services
{
    public class UserService : IUserService
    {
        private AppDbContext _db;

        public UserService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<ResponseAllUser> GetAll()
        {
            var users = await _db.Users.ToListAsync();

            return new ResponseAllUser
            {
                Users = users.Select(user => new ResponseShortUser
                {
                    Id = user.Id,
                    Nick = user.Nick,
                    Name = user.Name,
                    Url = user.Url
                }).ToList()
            };
        }
    }
}
