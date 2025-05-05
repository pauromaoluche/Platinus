using System.ComponentModel;

namespace Platinus.Domain.Entities.Enums
{
    public enum UserRoleEnum
    {
        [Description("Administrador")]
        Admin = 1,

        [Description("Usuario")]
        User = 2,
    }
}
