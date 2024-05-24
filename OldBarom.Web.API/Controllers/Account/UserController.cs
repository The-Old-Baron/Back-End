using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OldBarom.Infra.Data.Identity;
using OldBarom.Web.API.Models;

namespace OldBarom.Web.API.Controllers.Account{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase{
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;   

        public UserController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost("Register")]
        public virtual async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                return Ok();
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("Login")]
        public virtual async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return BadRequest("Invalid Login attempt.");
            }

            var result = await _userManager.CheckPasswordAsync(user, model.Password);

            if (result)
            {
                return Ok();
            }

            return BadRequest("Invalid Login attempt.");
        }

        [HttpPost("ChangePassword")]
        public virtual async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return BadRequest("Invalid Login attempt.");
            }

            var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);
        }

        [HttpGet("{email}")]
        public virtual async Task<IActionResult> GetUserByName(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("GetAllUsers")]
        [Authorize(Roles = "Admin")]
        public virtual async Task<IActionResult> GetAllUsers()
        {
            var users = _userManager.Users.ToList();

            return Ok(users);
        }

        [HttpPost("AddRole")]
        //[Authorize(Roles = "Admin")]
        public virtual async Task<IActionResult> AddRole([FromBody] AddRoleModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return BadRequest("Invalid Login attempt.");
            }

            var result = await _userManager.AddToRoleAsync(user, model.Role);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("RemoveRole")]   
        //[
        //Authorize(Roles = "Admin")]
        public virtual async Task<IActionResult> RemoveRole([FromBody] AddRoleModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return BadRequest("Invalid Login attempt.");
            }

            var result = await _userManager.RemoveFromRoleAsync(user, model.Role);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);
        }

        [HttpGet("GetRoles")]
        public virtual async Task<IActionResult> GetRoles()
        {
            var roles = _roleManager.Roles.ToList();

            return Ok(roles);
        }

        [HttpPost("CreateRole")]
        public virtual async Task<IActionResult> CreateRole([FromBody] CreateRoleModel model)
        {
            var role = new IdentityRole
            {
                Name = model.Role
            };

            var result = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("DeleteRole")]
        public virtual async Task<IActionResult> DeleteRole([FromBody] CreateRoleModel model)
        {
            var role = await _roleManager.FindByNameAsync(model.Role);

            if (role == null)
            {
                return BadRequest("Invalid Login attempt.");
            }

            var result = await _roleManager.DeleteAsync(role);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);
        }
    }
}