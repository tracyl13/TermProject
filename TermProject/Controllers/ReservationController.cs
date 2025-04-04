using Microsoft.AspNetCore.Mvc;

namespace TermProject.Controllers
{
    public class ReservationController : Controller
    {
        public IActionResult CreateReservation()
        {
            return View();
        }

        public IActionResult ManageReservation()
        {
            return View();
        }

        public IActionResult ModifyReservation()
        {
            return View();
        }
    }
}
