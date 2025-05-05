using System.ComponentModel;

namespace Platinus.Domain.Entities.Enums
{
    public enum UserRoleEnum
    {
        [Description("Usuario")]
        User = 1,

        [Description("Administrador")]
        Admin = 2,

    }
}
