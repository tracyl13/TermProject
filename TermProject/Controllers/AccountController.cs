using Microsoft.AspNetCore.Mvc;

namespace TermProject.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult CreateAccount()
        {
            return View();
        }


        public IActionResult Login()
        {
            return View();
        }
    }
}
