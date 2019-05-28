using Domain.Services.Interfaces;
using Infrastructure.DataModel;
using Infrastructure.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            this._roleRepository = roleRepository;
        }

        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            var roles = await this._roleRepository.GetAllRoles();

            return roles;
        }
    }
}
