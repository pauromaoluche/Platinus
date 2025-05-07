using Platinus.Application.DTOs.Requests;
using Platinus.Application.DTOs.Response;

namespace Platinus.Application.Interfaces.User
{
    public interface IUserService
    {
        Task<ResponseAllUser> GetAll();
        Task<ResponseShortUser> CreateUser(RequestUser dto);
    }
}
