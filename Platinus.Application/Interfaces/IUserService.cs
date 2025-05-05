using Platinus.Domain.Entities;

namespace Platinus.Application.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAll();
    }
}
