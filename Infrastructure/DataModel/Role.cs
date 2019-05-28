using System;
using System.Collections.Generic;

namespace Infrastructure.DataModel
{
    public partial class Role
    {
        public Role()
        {
            UsersRoles = new HashSet<UsersRoles>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; }

        public ICollection<UsersRoles> UsersRoles { get; set; }
    }
}
