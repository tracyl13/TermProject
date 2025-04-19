using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Text.Json;
using System.IO;                        // needed for Stream and Stream Reader
using System.Net;                       // needed for the Web Request
using System.Data;                      // needed for DataSet class
using TermProject.Models;               // needed for the reservation class
using System.Diagnostics;

namespace TermProject.Controllers
{
    public class ReviewController : Controller
    {
        private List<Reviews> GetReviews(DataTable Reviews)
        {
            List<Reviews> reviews = new List<Reviews>();

            foreach (DataRow row in Reviews.Rows)
            {
                reviews.Add(new Reviews
                {
                    ReviewID = Convert.ToInt32(row["ReviewID"]),
                    RestaurantID = Convert.ToInt32(row["RestaurantID"]),
                    Date = (DateTime)row["Date"],
                    Time = (TimeSpan)row["Time"],
                    FoodQuality = Convert.ToInt32(row["FoodQuality"]),
                    Service = Convert.ToInt32(row["Service"]),
                    Atmosphere = Convert.ToInt32(row["Atmosphere"]),
                    Price = Convert.ToInt32(row["Price"]),
                    Comment = row["Comment"].ToString()

                }
                );
            }

            return reviews;
        }

        public IActionResult CreateReview()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateReviewSubmit(Reviews reviews)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateReview", reviews);
            }

            //Set RestaurantID to restuarnt session, and ReviewID to the userID session:
            reviews.RestaurantID = 1;
            reviews.ReviewerID = 4;

            //Change this when publishing
            //String url = "https://cis-iis2.temple.edu/Spring2025/CIS3342_tug19492/Restaurant_API/api/Reviews/CreateReview";
            String url = "https://localhost:7056/api/Reviews/CreateReview";

            var json = JsonSerializer.Serialize(reviews);

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
                {
                    ViewBag.Status = "Review was not made successfully. Please try again.";
                }

            }

            catch (Exception ex)
            {
                Debug.WriteLine("Error:" + ex.Message);
            }

            return RedirectToAction("Main", "Main");
        }

        /*
         * Uses to populate the gridview all the reviews made by the reviewer without using a API call
        public IActionResult ManageReviews()
        {
            Reviews reviews = new Reviews();
            reviews.ReviewerID = 4;

            ReviewsManagement reviewsManagement = new ReviewsManagement();
            DataSet dsReviews = reviewsManagement.GetReviews(reviews);

            List<Reviews> reviewList = GetReviews(dsReviews.Tables[0]);

            return View(reviewList);
        }*/

        public IActionResult ManageReviews()
        {
            Reviews reviews = new Reviews();
            reviews.ReviewerID = 4;

            //Change this when publishing
            //String url = $"https://cis-iis2.temple.edu/Spring2025/CIS3342_tug19492/Restaurant_API/api/Reservation/GetReservations/{reviews.ReviewerID}";
            String url = $"https://localhost:7056/api/Reviews/GetReviews/{reviews.ReviewerID}";

            var json = JsonSerializer.Serialize(reviews);
            List<Reviews> reviewList = new List<Reviews>();

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

                reviewList = JsonSerializer.Deserialize<List<Reviews>>(data);

                if (reviewList != null && reviewList.Any())
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
                var text = "Eror:" + ex.Message;
                ViewBag.TestingMessage = text;
            }
            
            return View(reviewList);
        }

        public IActionResult ModifyReview()
        {
            Reviews reviews = new Reviews();
            ReviewsManagement reviewsManagement = new ReviewsManagement();

            //set review id to the ReviewID session.
            reviews.ReviewID = 16;

            DataSet dsReview = reviewsManagement.GetReviewModify(reviews);

            reviews.Date = (DateTime)dsReview.Tables[0].Rows[0]["Date"];
            reviews.Time = (TimeSpan)dsReview.Tables[0].Rows[0]["Time"];
            reviews.FoodQuality = Convert.ToInt32(dsReview.Tables[0].Rows[0]["FoodQuality"]);
            reviews.Service = Convert.ToInt32(dsReview.Tables[0].Rows[0]["Service"]);
            reviews.Atmosphere = Convert.ToInt32(dsReview.Tables[0].Rows[0]["Atmosphere"]);
            reviews.Price = Convert.ToInt32(dsReview.Tables[0].Rows[0]["Price"]);
            reviews.Comment = dsReview.Tables[0].Rows[0]["Comment"].ToString();

            return View(reviews);
        }
       
        public IActionResult ModifyReviewSubmit(Reviews reviews)
        {
            if(!ModelState.IsValid)
            {
                return View("ModifyReview", reviews);
            }

            reviews.ReviewID = 16;

            //Change this when publishing
            //String url = "https://cis-iis2.temple.edu/Spring2025/CIS3342_tug19492/Restaurant_API/api/Reviews/ModifyReview";
            String url = "https://localhost:7056/api/Reviews/ModifyReview";
            var json = JsonSerializer.Serialize(reviews);

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

            return RedirectToAction("ManageReviews", "Review");
        }

        public IActionResult DeleteReview(int ReviewID)
        {
            Reviews reviews = new Reviews();
            reviews.ReviewID = ReviewID;

            //Change this when publishing
            //String url = $"https://cis-iis2.temple.edu/Spring2025/CIS3342_tug19492/Restaurant_API/api/Reviews/DeleteReview/{reviews.ReviewID}";
            String url = $"https://localhost:7056/api/Reviews/DeleteReview/{reviews.ReviewID}";

            var json = JsonSerializer.Serialize(reviews);

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
                    Debug.WriteLine("Delete Successful");
                }

            }

            catch (Exception ex)
            {
                string message = "Error:" + ex.Message;
                Debug.WriteLine($"API Error: {message}");
            }

            return RedirectToAction("ManageReviews");
        }
    }
}
