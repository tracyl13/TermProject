using Microsoft.AspNetCore.Mvc;

namespace TermProject.Controllers
{
    public class RestaurantController : Controller
    {
        public IActionResult CreateRestaurant()
        {
            return View();
        }

        public IActionResult ModifyRestaurant()
        {
            return View();
        }

        public IActionResult RestaurantProfile()
        {
            return View();
        }
    }
}
