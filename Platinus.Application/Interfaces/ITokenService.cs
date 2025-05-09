using Platinus.Domain.Entities;

namespace Platinus.Application.Interfaces
{
    public interface ITokenService
    {
        string Generate(User user);
    }
}
