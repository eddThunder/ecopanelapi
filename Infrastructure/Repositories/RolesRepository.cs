using Infrastructure.DataModel;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RolesRepository : IRoleRepository
    {
        public RolesRepository() { }

        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            using (var ctx = new ecopanelDBContext())
            {
                var roles = await ctx.Role.ToListAsync();
                return roles;
            }
        }
    }
}
