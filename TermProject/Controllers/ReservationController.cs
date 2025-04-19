using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;

//using System.Web.Script.Serialization; // needed for JSON serializers
using System.Text.Json;
using System.IO;                        // needed for Stream and Stream Reader
using System.Net;                       // needed for the Web Request
using System.Data;                      // needed for DataSet class
using TermProject.Models;               // needed for the reservation class
using System.Diagnostics;

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


        /*
         * This code does not used API to get the reservation. Keep here in case API does not work.
        //Used to test if page load works
        public IActionResult ManageReservation()
        {
            // Get restaurant ID from session using testing value of restruant id 1
            //int restaurantId = HttpContext.Session.GetInt32("ManageAccount") ?? 0;

            Reservation reservation = new Reservation();
            reservation.RestaurantID = 1;

            ReservationManagement reservationManagement = new ReservationManagement();
            DataSet dsReservation = reservationManagement.GetReservation(reservation);


            List<Reservation> reservationList = GetReservations(dsReservation.Tables[0]);

            return View(reservationList);
        }*/


        public IActionResult ManageReservation()
        {
            //Change 1 to a session ID
            Reservation reservation = new Reservation();
            reservation.RestaurantID = 1;

            //Change this when publishing
            //String url = $"https://cis-iis2.temple.edu/Spring2025/CIS3342_tug19492/Restaurant_API/api/Reservation/GetReservations/{reservation.RestaurantID}";
            String url = $"https://localhost:7056/api/Reservation/GetReservations/{reservation.RestaurantID}";

            var json = JsonSerializer.Serialize(reservation);
            List<Reservation> reservations = new List<Reservation>();

            try
            {
                // Send the object to the Web API that will be used to get data from the database
                // Setup an HTTP GET Web Request and get the HTTP Web Response from the server.
                WebRequest request = WebRequest.Create(url);
                WebResponse response = request.GetResponse();

                // Read the data from the Web Response, which requires working with streams.
                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();

                reservations = JsonSerializer.Deserialize<List<Reservation>>(data);
                ViewBag.TestingMessage = "API return success";

                if (reservations != null && reservations.Any())
                {
                    ViewBag.TestingMessage = "API returned a valid list.";
                }
                else
                {
                    ViewBag.TestingMessage = "API returned an empty list.";
                }
            }

            catch (Exception ex)
            {
                var text = "Error: " + ex.Message;
                ViewBag.TestingMessage = text;
            }

            return View(reservations);
        }

        
        public IActionResult CreateReservation()
        {
            return View();
        }
        
        /*
         * Create Reservation but without API. Keep in case API does not work.
        [HttpPost]
        public IActionResult CreateReservationSubmit(Reservation reservation)
        {
           
           if (!ModelState.IsValid)
            {
                return View("CreateReservation", reservation);
            }

           ReservationManagement reservationManagement = new ReservationManagement();
           reservation.RestaurantID = 1;
           reservationManagement.CreateReservation(reservation);
            return View();
            //return RedirectToAction("Main", "Main");
        }*/

        [HttpPost]
        public IActionResult CreateReservationSubmit(Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateReservation", reservation);
            }

            //Set RestaurantID the session.
            ReservationManagement reservationManagement = new ReservationManagement();
            reservation.RestaurantID = 1;

            //Change this when publishing
            //String url = "https://cis-iis2.temple.edu/Spring2025/CIS3342_tug19492/Restaurant_API/api/Reservation/CreateReservation";
            String url = "https://localhost:7056/api/Reservation/CreateReservation";

            var json = JsonSerializer.Serialize(reservation);

            try
            {

                WebRequest request = WebRequest.Create(url);
                request.Method = "POST";
                request.ContentLength = json.Length;
                request.ContentType = "application/json";

                StreamWriter writer = new StreamWriter(request.GetRequestStream());
                writer.Write(json);
                writer.Flush();
                writer.Close();

                WebResponse response = request.GetResponse();
                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();

                if (data == "false")
                    ViewBag.Status = "Reservation not made successfully. Please try again.";

            }
            catch (Exception ex)
            {
                ViewBag.TestingMessage = "Error:" + ex.Message;
            }

            return RedirectToAction("Main", "Main");
            
        }

        
        public IActionResult ModifyReservation()
        {

            Reservation reservation = new Reservation();
            ReservationManagement reservationManagement = new ReservationManagement();
            //Change to the ID that was selected from the reservation management page
            reservation.ReservationID = 1;

            DataSet dsReservation = reservationManagement.GetReservationModify(reservation);
            
            reservation.FirstName = dsReservation.Tables[0].Rows[0]["FirstName"].ToString();
            reservation.LastName = dsReservation.Tables[0].Rows[0]["LastName"].ToString();
            reservation.PhoneNumber = dsReservation.Tables[0].Rows[0]["PhoneNumber"].ToString();
            reservation.Email = dsReservation.Tables[0].Rows[0]["Email"].ToString();
            reservation.Date = (DateTime)dsReservation.Tables[0].Rows[0]["Date"];
            reservation.Time = (TimeSpan)dsReservation.Tables[0].Rows[0]["Time"];
            reservation.PartySize = dsReservation.Tables[0].Rows[0]["PartySize"].ToString();
            reservation.SpecialRequest = dsReservation.Tables[0].Rows[0]["SpecialRequest"].ToString();


            return View(reservation);
        }

        /* 
         * Modify reservation with an api call. Keep here in case API does not work.
        public IActionResult ModifyReservationSubmit(Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                return View("ModifyReservation", reservation);
            }

            ReservationManagement reservationManagement = new ReservationManagement();
            //Change it to the reservationID session.
            reservation.ReservationID = 1;
            reservationManagement.ModifyReservation(reservation);
            //return RedirectToAction("Main", "Main");
            return View();
        }*/


        //MAKE SURE TO CHANGE THE VIEW SO IT RETURNS TO RESERVATION MANAGEMENT!!!
        public IActionResult ModifyReservationSubmit(Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                return View("ModifyReservation", reservation);
            }

            //ReservationManagement reservationManagement = new ReservationManagement();
            //Change it to the reservationID session.
            reservation.ReservationID = 1;

            //Change this when publishing
            //String url = "https://cis-iis2.temple.edu/Spring2025/CIS3342_tug19492/Restaurant_API/api/Reservation/ModifyReservation";
            String url = "https://localhost:7056/api/Reservation/ModifyReservation";
            var json = JsonSerializer.Serialize(reservation);

            try
            {

                WebRequest request = WebRequest.Create(url);
                request.Method = "PUT";
                request.ContentLength = json.Length;
                request.ContentType = "application/json";

                StreamWriter writer = new StreamWriter(request.GetRequestStream());
                writer.Write(json);
                writer.Flush();
                writer.Close();

                WebResponse response = request.GetResponse();
                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();

                if (data == "false")
                    ViewBag.Status = "Something went wrong. Please try again.";

            }
            catch (Exception ex)
            {
                ViewBag.TestingMessage = "Error:" + ex.Message;
            }

            return RedirectToAction("ManageReservation", "Reservation");

        }

        /*Deletes a reservation, without using a API, here in case we API does not work.
        public IActionResult DeleteReservation(int ReservationID)
        {
            Reservation reservation = new Reservation();
            ReservationManagement reservationManagement = new ReservationManagement();

            reservation.ReservationID = ReservationID;
           

            reservationManagement.DeleteReservation(reservation);

            return RedirectToAction("ManageReservation");
        }*/

        public IActionResult DeleteReservation(int ReservationID)
        {
            Reservation reservation = new Reservation();
            reservation.ReservationID = ReservationID;


            //Change this when publishing
            //String url = $"https://cis-iis2.temple.edu/Spring2025/CIS3342_tug19492/Restaurant_API/api/Reservation/DeleteReservation/{reservation.ReservationID}";
            String url = $"https://localhost:7056/api/Reservation/DeleteReservation/{reservation.ReservationID}";
            var json = JsonSerializer.Serialize(reservation);

            try
            {
                // Send the object to the Web API that will be used to get data from the database
                // Setup an HTTP GET Web Request and get the HTTP Web Response from the server.
                WebRequest request = WebRequest.Create(url);
                request.Method = "DELETE";
                WebResponse response = request.GetResponse();

                // Read the data from the Web Response, which requires working with streams.
                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();


                int result = JsonSerializer.Deserialize<int>(data);

                if (result > 0)
                {
                    //*ADD EMAIL HERE LATER
                    ViewBag.TestingMessage = "Delete Successful";
                }

            }

            catch (Exception ex)
            {
                string message = "Error:" + ex.Message;
                Debug.WriteLine($"API Error: {message}");
            }

            return RedirectToAction("ManageReservation");
        }
    }
}
