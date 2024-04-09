using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using OldBarom.Core.Domain.Account;
using System.Text;
using System.Diagnostics;

namespace OldBarom.Infra.Data.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthenticateService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<SignInResult> Authenticate(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, false, false);
            return result;
        }
        public async Task<SignInResult> Authenticate(string email, string password, bool rememberMe, bool lockoutOnFailure)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return SignInResult.Failed;
            }

            var result = await _signInManager.PasswordSignInAsync(user, password, rememberMe, lockoutOnFailure);
            return result;
        }
        public async Task<List<AuthenticationScheme>> GetExternalLogin()
        {
            var result = await _signInManager.GetExternalAuthenticationSchemesAsync();
            return result.ToList();
        }
        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> RegisterUser(string email, string password)
        {
            var applicationUser = new ApplicationUser()
            {
                UserName = email,
                Email = email
            };
            var result = await _userManager.CreateAsync(applicationUser, password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(applicationUser, false);
            }

            return result.Succeeded;
        }
        public async Task<bool> ExternalLogin(string email, string returnUrl = null)
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return false;
            }

            var user = new ApplicationUser { UserName = email, Email = email };

            var result = await _userManager.CreateAsync(user);

            if (result.Succeeded)
            {
                result = await _userManager.AddLoginAsync(user, info);
                if (result.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    // Aqui você precisa implementar a lógica para gerar a URL de confirmação de e-mail.
                    // A linha abaixo é apenas um exemplo e precisa ser substituída pela sua lógica.
                    var callbackUrl = $"https://yourwebsite.com/Account/ConfirmEmail?userId={userId}&code={code}";

                    // Aqui você precisa implementar a lógica para enviar o e-mail.
                    // A linha abaixo é apenas um exemplo e precisa ser substituída pela sua lógica.
                    // await _emailSender.SendEmailAsync(email, "Confirm your email", $"Please confirm your account by <a href='{callbackUrl}'>clicking here</a>.");

                    // If account confirmation is required, we need to show the link if we don't have a real email sender
                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return true;
                    }

                    await _signInManager.SignInAsync(user, isPersistent: false, info.LoginProvider);
                    return true;
                }
            }
            foreach (var error in result.Errors)
            {
                Debug.WriteLine(error.Description);
            }

            return false;
        }

        internal ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the external login page in /Areas/Identity/Pages/Account/ExternalLogin.cshtml");
            }
        }
    }

}

