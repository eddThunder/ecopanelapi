using Domain.Models.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetById(int userId);
        Task<UserDto> GetByCredentials(string username, string password);
        Task<int> Insert(UserDto user);
        Task<int> Update(UserDto user);
        Task<int> Delete(int EmployeeID);
    }
}
