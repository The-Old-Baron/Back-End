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
                return Ok(user);
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
                return Ok(user);
            }

            return BadRequest("Invalid Login attempt.");
        }

        [HttpPost("ExternalLogin")]
        public virtual async Task<IActionResult> ExternalLogin([FromBody] ExternalLoginModel model)
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

            return Ok(user);
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
                return Ok(user);
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

        [HttpGet("GetUserRoles")]
        public virtual async Task<IActionResult> GetUserRoles()
        {
            var userRoles = _userManager.Users.Select(user => new UserRoleModel
            {
                Email = user.Email,
                Role = _userManager.GetRolesAsync(user).Result.FirstOrDefault()
            }).ToList();

            return Ok(userRoles);
        }
    }
}