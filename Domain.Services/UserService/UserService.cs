﻿using Domain.Models.Dtos;
using Domain.Services.Interfaces;
using Domain.Services.Mappings.Infrastructure.Mappers;
using Infrastructure.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
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

            return UserRolesFactoryMapper.MapToDto(userList.ToList());
        }

        public async Task<UserDto> GetById(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            return UserRolesFactoryMapper.MapToDtoWithPassword(user);
        }

        public async Task<int> Insert(UserDto user)
        {
            var entity = UserRolesFactoryMapper.MapToEntity(user);

            return await _userRepository.Insert(entity);
        }

        public async Task<int> Update(UserDto user)
        {
            var entity = UserRolesFactoryMapper.MapToEntity(user);

            return await _userRepository.Update(entity);
        }

        public async Task<int> Delete(int userId)
        {
            return await _userRepository.Delete(userId);
        }

        public async Task<UserDto> GetByCredentials(string username, string password)
        {
            var user = await _userRepository.GetByCredentials(username, password);

            return UserRolesFactoryMapper.MapToDto(user);
        }
    }
}
