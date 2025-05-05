using Platinus.Application.DTOs.Response;

namespace Platinus.Application.Interfaces
{
    public interface IUserService
    {
        Task<ResponseAllUser> GetAll();
    }
}
