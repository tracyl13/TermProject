using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using System.Data;
using System.Data.SqlClient;
using Restaurant_API.Models; //Used to access classes in Model

//using Utilities;

namespace Restaurant_API.Controllers
{
    [Produces("application/json")]
    [Route("api/Reservation")]
    [ApiController]
    public class ReservationController : ControllerBase
    {

        [HttpGet("GetReservations")] //GET api/Reservation/GetReservations
        public List<Reservation> GetReservation ([FromBody] Reservation reservation) 
        {
            List<Reservation> reservationList = new List<Reservation>();

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

    }
 }
