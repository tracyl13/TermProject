using Microsoft.AspNetCore.Mvc;

namespace Restaurant_API.Controllers
{
    public class ReviewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
