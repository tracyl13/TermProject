using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TermProject.Models;

namespace TermProject.Controllers
{
    public class AccountController : Controller
    {
        
        public IActionResult CreateAccount(AccountModel Account)
        {
            List<AccountModel> accountType = new List<AccountModel>
            {
                new AccountModel { AccountType = "Represenative"},
                new AccountModel { AccountType = "Reviewer"},
            };

            ViewBag.AccountType = new SelectList(accountType, "AccountType");

            Account.Email = Request.Form["Email"].ToString();
            Account.Password = Request.Form["Password"].ToString();
            Account.CreateAccount(Account);
            return View("~/Views/Account/CreateAccount.cshtml");
        }

        
        public IActionResult Login()
        {
            return View();
        }
    }
}
