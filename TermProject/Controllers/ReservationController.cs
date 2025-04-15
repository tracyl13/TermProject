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
            // Get restaurant ID from session
            int restaurantId = HttpContext.Session.GetInt32("ManageAccount") ?? 0;

            if (restaurantId == 0)
            {
                // Handle case where session is not set
                return RedirectToAction("Login", "Account");
            }

            // Get reservations for this restaurant
            Reservation reservation = new Reservation
            {
                RestaurantID = restaurantId
            };

            ReservationModify reservationModify = new ReservationModify();
            List<Reservation> reservations = reservationModify.GetReservation(reservation);

            return View(reservations);
        }

        public IActionResult ModifyReservation()
        {
            return View();
        }
    }
}
