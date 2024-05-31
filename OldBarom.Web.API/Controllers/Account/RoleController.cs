using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using OldBarom.Infra.Data.Identity;
using OldBarom.Web.API.Models;
using Microsoft.AspNetCore.Authorization;

namespace OldBarom.Web.API.Controllers.Account{
        [Route("api/[controller]")]
        [ApiController]
        public class RoleController : ControllerBase{
        public readonly RoleManager<IdentityRole> _roleManager;
        public readonly UserManager<ApplicationUser> _userManager;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpPost("CreateRole")]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> CreateRole([FromBody] string roleName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var role = new IdentityRole
            {
                Name = roleName
            };

            var result = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
            {
                return Ok(role);
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("AddUserRole")]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> AddUserRole([FromBody] UserRoleModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return BadRequest("User not found.");
            }

            var result = await _userManager.AddToRoleAsync(user, model.Role);

            if (result.Succeeded)
            {
                return Ok(user);
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("RemoveUserRole")]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> RemoveUserRole([FromBody] UserRoleModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return BadRequest("User not found.");
            }

            var result = await _userManager.RemoveFromRoleAsync(user, model.Role);

            if (result.Succeeded)
            {
                return Ok(user);
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("DeleteRole")]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> DeleteRole([FromBody] string roleName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var role = await _roleManager.FindByNameAsync(roleName);

            if (role == null)
            {
                return BadRequest("Role not found.");
            }

            var result = await _roleManager.DeleteAsync(role);

            if (result.Succeeded)
            {
                return Ok(role);
            }

            return BadRequest(result.Errors);
        }

        [HttpGet("GetAllRoles")]
        [Authorize(Roles="Admin")]
        public IActionResult GetAllRoles()
        {
            var roles = _roleManager.Roles;

            return Ok(roles);
        }

        
    }
}