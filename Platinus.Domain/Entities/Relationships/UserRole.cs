﻿namespace Platinus.Domain.Entities.Relationships
{
    public class UserRole : EntityBase
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
