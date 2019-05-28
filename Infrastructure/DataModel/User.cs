using System;
using System.Collections.Generic;

namespace Infrastructure.DataModel
{
    public partial class User
    {
        public User()
        {
            UsersRoles = new HashSet<UsersRoles>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string UserPassword { get; set; }

        public ICollection<UsersRoles> UsersRoles { get; set; }
    }
}
