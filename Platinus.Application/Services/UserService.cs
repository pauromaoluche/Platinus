using Microsoft.EntityFrameworkCore;
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

        public async Task<List<User>> GetAll()
        {
            var users = await _db.Users.ToListAsync();

            return users;
        }
    }
}
