using Microsoft.AspNetCore.Identity;
using OldBarom.Core.Domain.Interface.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBarom.Infra.Data.Identity
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public SeedUserRoleInitial(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public void SeedRole()
        {
            if (!_roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                role.NormalizedName = "USER";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                role.NormalizedName = "ADMIN";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
        }

        public void SeedUser()
        {
            if(_userManager.FindByEmailAsync("ROOT@ROOT").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "ROOT@ROOT";
                user.Email = "ROOT@ROOT";
                user.EmailConfirmed = true;

                IdentityResult result = _userManager.CreateAsync(user, "ROOT@ROOT").Result;
                
            }
        }
    }
}
