﻿using System;
using System.Collections.Generic;

namespace Infrastructure.DataModel
{
    public partial class UsersRoles
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public Role Role { get; set; }
        public User User { get; set; }
    }
}
