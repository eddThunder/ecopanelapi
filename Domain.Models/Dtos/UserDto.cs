using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<RoleDto> Roles { get; set; }
    }
}
