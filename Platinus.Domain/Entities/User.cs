using Platinus.Domain.Entities.Enums;

namespace Platinus.Domain.Entities
{
    public class User : EntityBase
    {
        public string Name { get; set; } = String.Empty;
        public string Nick { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string Url { get; set; } = String.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public UserRoleEnum Role { get; set; } = UserRoleEnum.User;
    }
}
