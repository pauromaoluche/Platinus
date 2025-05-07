using Platinus.Domain.Entities;
using Platinus.Domain.Entities.Enums;

namespace Platinus.Application.DTOs.Requests
{
    public class RequestUser
    {
        public string Name { get; set; } = string.Empty;
        public string Nick { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public UserRoleEnum Role { get; set; } = UserRoleEnum.User;
    }
}
