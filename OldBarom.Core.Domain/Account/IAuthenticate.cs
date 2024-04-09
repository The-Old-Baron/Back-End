using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
namespace OldBarom.Core.Domain.Account
{
    public interface IAuthenticate
    {
        Task<SignInResult> Authenticate(string email, string password);
        Task<SignInResult> Authenticate(string email, string password, bool rememberMe, bool lockoutOnFailure);
        Task<bool> RegisterUser(string email, string password);
        Task<bool> ExternalLogin(string returnUrl, string email);
        Task<List<AuthenticationScheme>> GetExternalLogin();
        Task Logout();
    }
}
