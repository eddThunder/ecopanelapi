using Infrastructure.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAllRoles();
    }
}
