using Domain.Models.Dtos;
using Domain.Services.Interfaces;
using Domain.Services.Mappings.Infrastructure.Mappers;
using Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {

            var userList = await _userRepository.GetAllUsersAsync();

            return FactoryMapper.MapToDto(userList.ToList());
        }

        public async Task<UserDto> GetById(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            return FactoryMapper.MapToDtoWithPassword(user);
        }

        public async Task<int> Insert(UserDto user)
        {
            var entity = FactoryMapper.MapToEntity(user);

            return await _userRepository.Insert(entity);
        }

        public async Task<int> Update(UserDto user)
        {
            var entity = FactoryMapper.MapToEntity(user);

            return await _userRepository.Update(entity);
        }

        public async Task<int> Delete(int userId)
        {
            return await _userRepository.Delete(userId);
        }

        public async Task<UserDto> GetByCredentials(string username, string password)
        {
            var user = await _userRepository.GetByCredentials(username, password);

            return FactoryMapper.MapToDto(user);
        }
    }
}
