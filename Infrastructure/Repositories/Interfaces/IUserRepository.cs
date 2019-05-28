using Infrastructure.DataModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetByIdAsync(int userId);
        Task<User> GetByCredentials(string username, string password);
        Task<int> Insert(User user);
        Task<int> Update(User user);
        Task<int> Delete(int id);
    }
}
