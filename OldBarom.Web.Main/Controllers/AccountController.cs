using Microsoft.AspNetCore.Mvc;
using OldBarom.Core.Domain.Account;
using OldBarom.Web.Main.ViewModel;

namespace OldBarom.Web.Main.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticate _authenticateService;
        public AccountController(IAuthenticate authenticateService)
        {
            _authenticateService = authenticateService;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }
    }
}
