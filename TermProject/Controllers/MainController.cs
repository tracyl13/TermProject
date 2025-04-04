using Microsoft.AspNetCore.Mvc;

namespace TermProject.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Main()
        {
            return View();
        }
    }
}
