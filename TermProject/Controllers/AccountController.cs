using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TermProject.Models;

namespace TermProject.Controllers
{
    public class AccountController : Controller
    {
        
        public IActionResult CreateAccount()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult CreateAccountSubmit(Account account)
        {
            /*List<Account> accountType = new List<Account>
            {
                new Account { AccountType = "Represenative"},
                new Account { AccountType = "Reviewer"},
            };

            ViewBag.AccountType = new SelectList(accountType, "AccountType");

            account.Email = Request.Form["Email"].ToString();
            account.Password = Request.Form["Password"].ToString();
            //Account.CreateAccount(Account);
            return View("~/Views/Account/CreateAccount.cshtml");*/
            return RedirectToAction("Login");
        }

        public IActionResult ReturnToLogin()
        {
            return RedirectToAction("Login");
        }


        public IActionResult Login()
        {
            return View();
        }
    }
}
