using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;

//using System.Web.Script.Serialization;  // needed for JSON serializers
using System.IO;                        // needed for Stream and Stream Reader
using System.Net;                       // needed for the Web Request
using System.Data;                      // needed for DataSet class
using TermProject.Models;               // needed for the reservation class

namespace TermProject.Controllers
{
    public class ReservationController : Controller
    {
        private List<Reservation> GetReservations(DataTable Reservations)
        {
            List<Reservation> reservations = new List<Reservation>();

            foreach (DataRow row in Reservations.Rows)
            {
                reservations.Add(new Reservation
                {
                    ReservationID = Convert.ToInt32(row["ReservationID"]),
                    FirstName = row["FirstName"].ToString(),
                    LastName = row["LastName"].ToString(),
                    PhoneNumber = row["PhoneNumber"].ToString(),
                    Email = row["Email"].ToString(),
                    Date = (DateTime)row["Date"],
                    Time = (TimeSpan)row["Time"],
                    PartySize = row["PartySize"].ToString(),
                    SpecialRequest = row["SpecialRequest"].ToString()

                }
                );
            }

            return reservations;
        }

        public IActionResult CreateReservation()
        {
            return View();
        }

        //Used to test if page load works
        public IActionResult ManageReservation()
        {
            /*
             * Handle case where session is not set, change restruantID to if Session Restaurant ID Does not exect ect
            if (restaurantID == 0)
            {
                return RedirectToAction("Login", "Account");
            }*/

            // Get restaurant ID from session using testing value of restruant id 1
            //int restaurantId = HttpContext.Session.GetInt32("ManageAccount") ?? 0;

            Reservation reservation = new Reservation();
            reservation.RestaurantID = 1;

            ReservationManagement reservationManagement = new ReservationManagement();
            DataSet dsReservation = reservationManagement.GetReservation(reservation);


            List<Reservation> reservationList = GetReservations(dsReservation.Tables[0]);

            return View(reservationList);
        }

        public IActionResult ModifyReservation()
        {
            return View();
        }
    }
}
