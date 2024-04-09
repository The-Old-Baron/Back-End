using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OldBarom.Core.Domain.Entities.Basic;
using OldBarom.Infra.Data.Identity;

namespace OldBarom.Web.Principal.Areas.Identity.Pages.Account
{
    public class Profile : PageModel
    {
        public ModelData? Data { get; set; }
        private readonly UserManager<ApplicationUser> _userManager;

        public Profile(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task OnGetAsync()
        {
            ModelData modelData = new ModelData();

            var user = await _userManager.GetUserAsync(User);

            if(user == null)
            {
                return;
            }

            modelData.Name = user.UserName;
            modelData.SecondName = user.NormalizedUserName;
            modelData.UserName = user.UserName;
            modelData.Email = user.Email;
            modelData.PhoneNumber = user.PhoneNumber;
            modelData.Bio = "I am a developer";
            modelData.Address = user.Address;

            Data = modelData;
            
        }
        public class ModelData
        {
            public string? Name { get; set; }
            public string? SecondName { get; set; }

            public string? UserName { get; set; }
            public string? Email { get; set; }
            public string? PhoneNumber { get; set; }
            public string? Bio { get; set; }
            public Address? Address { get; set; }
        }
    }

}
