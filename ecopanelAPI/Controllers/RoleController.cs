using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ecopanelAPI.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleDomainService;
        private readonly ILogger _logger;

        public RoleController(IRoleService roleDomainService, ILogger logger)
        {
            _roleDomainService = roleDomainService;
            _logger = logger;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllRoles()
        {
            try
            {
                var result = await _roleDomainService.GetAllRoles();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("error in UsersController -> GetUserById: ", ex);
                return BadRequest(ex.Message);
            }
        }
    }
}