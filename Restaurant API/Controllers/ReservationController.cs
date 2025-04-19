using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using System.Data;
using System.Data.SqlClient;
using Restaurant_API.Models; //Used to access classes in Model



namespace Restaurant_API.Controllers
{
    [Produces("application/json")]
    [Route("api/Reservation")]
    [ApiController]
    public class ReservationController : ControllerBase
    {

        [HttpGet("GetReservations/{RestaurantID}")] //Get api/Reservation/GetReservations/restaurantID
        public List<Reservation> GetReservation ([FromRoute] int RestaurantID) 
        {
            List<Reservation> reservationList = new List<Reservation>();
            Reservation reservation = new Reservation();
            reservation.RestaurantID = RestaurantID;

            ReservationManagement reservationManagement = new ReservationManagement();
            DataSet dsReservation = reservationManagement.GetReservation(reservation);
            DataTable dtReservation = dsReservation.Tables[0];

            foreach (DataRow row in dtReservation.Rows)
            {
                reservationList.Add(new Reservation
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

            return reservationList;
        }

        [HttpPost("CreateReservation")]
        public Boolean CreateReservation([FromBody]Reservation reservation)
        {
            if (reservation != null)
            {
                ReservationManagement reservationManagement = new ReservationManagement();
                int status = reservationManagement.CreateReservation(reservation);

                if (status > 0)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
                
        }

        
        [HttpPut("ModifyReservation")]
        public Boolean ModifyReservation([FromBody]Reservation reservation)
        {
            if (reservation != null)
            {
                ReservationManagement reservationManagement = new ReservationManagement();
                int status = reservationManagement.ModifyReservation(reservation);

                if (status > 0)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        [HttpDelete("DeleteReservation/{ReservationID}")]
        public Boolean DeleteReservation([FromRoute] int ReservationID)
        {
            Reservation reservation = new Reservation();
            reservation.ReservationID = ReservationID;

            if (reservation.ReservationID > 0)
            {
                ReservationManagement reservationManagement = new ReservationManagement();
                int status = reservationManagement.DeleteReservation(reservation);

                if (status > 0)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }
    }
 }
