using Platinus.Application.DTOs.Requests;
using Platinus.Application.DTOs.Response;

namespace Platinus.Application.Interfaces
{
    public interface IAuthService
    {
        Task<ResponseAuthUser> Auth(RequestAuthUser request);
    }
}
