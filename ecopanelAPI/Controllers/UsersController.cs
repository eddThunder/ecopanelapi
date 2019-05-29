using Domain.Models.Dtos;
using Domain.Services.Interfaces;
using ecopanelAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ecopanelAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    //[Authorize]
    //[RoutePrefix("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userDomainService;
        private readonly IRoleService _roleDomainService;
        private readonly ILogger _logger;

        public UsersController(IUserService userDomainService, ILogger<UsersController> logger, IRoleService roleDomainService)
        {
            _userDomainService = userDomainService;
            _roleDomainService = roleDomainService;
            _logger = logger;
        }

        [HttpGet("all")]
        // [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                return Ok(await _userDomainService.GetAllUsersAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError("error in UsersController -> GetAllUsersAsync: ", ex);
                return BadRequest();
            }
        }

        [HttpGet("{userId}")]
        // [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            try
            {
                var user = await _userDomainService.GetById(userId);

                if (user != null)
                {
                    return Ok(user);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError("error in UsersController -> GetUserById: ", ex);
                return NotFound();
            }
        }


        [HttpPut("add")]
        // [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> InsertUser(UserDto user)
        {
            try
            {
                var result = await _userDomainService.Insert(user);
                if (result != 0)
                {
                    return Ok(result);
                }
                else
                {
                    return Ok(HttpStatusCode.Conflict);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("error in UsersController -> InsertUser: ", ex);
                return Conflict();
            }
        }

        [HttpPost("update")]
        // [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> UpdateUserAsync(UserDto user)
        {
            try
            {
                var result = await _userDomainService.Update(user);

                if (result != 0)
                {
                    return Ok(result);
                }
                else
                {
                    return Ok(HttpStatusCode.Conflict);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("error in UsersController -> UpdateUserAsync: ", ex);
                return Conflict();
            }
        }

        // [HttpDelete]
        [HttpDelete("delete/{userId}")]
        // [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            try
            {
                var result = await _userDomainService.Delete(userId);

                if (result != 0)
                {
                    return Ok(result);
                }
                else
                {
                    return Ok(HttpStatusCode.Conflict);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("error in UsersController -> DeleteUser: ", ex);
                return Conflict();
            }
        }

        [HttpGet]
        [Route("claims")]
        public async Task<UserViewModel> GetUserClaims()
        {
            try
            {
                var identity = (ClaimsIdentity)User.Identity;

                var allRoles = await _roleDomainService.GetAllRoles();

                var userRolesClaims = identity.FindAll(ClaimTypes.Role).ToList();

                var roles = new List<RoleDto>();

                userRolesClaims.ForEach(claim => roles.Add(new RoleDto
                {
                    Id = allRoles.Where(x => x.RoleName == claim.Value).First().Id,
                    RoleName = claim.Value
                }));

                UserViewModel userInfo = new UserViewModel
                {
                    Id = int.Parse(identity.FindFirst("Id").Value),
                    UserName = identity.FindFirst("UserName").Value,
                    Roles = roles
                };

                return userInfo;
            }
            catch (Exception ex)
            {
                _logger.LogError("error in UsersController -> GetUserClaims: ", ex);
                throw;
            }
        }
    }
}
