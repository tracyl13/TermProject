using Microsoft.AspNetCore.Mvc;

namespace TermProject.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult CreateReview()
        {
            return View();
        }

        public IActionResult ManageReviews()
        {
            return View();
        }

        public IActionResult ModifyReview()
        {
            return View();
        }
    }
}
