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
    [Route("api/Reviews")]
    [ApiController]
    public class ReviewsController : Controller
    {
        [HttpGet("GetReviews/{ReviewerID}")] //Get api/Reservation/GetReservations/restaurantID
        public List<Reviews> GetReviews([FromRoute] int ReviewerID)
        {
            List<Reviews> reviewList = new List<Reviews>();
            Reviews reviews = new Reviews();
            reviews.ReviewerID = ReviewerID;

            ReviewsManagement reviewsManagement = new ReviewsManagement();
            DataSet dsReviews = reviewsManagement.GetReviews(reviews);
            DataTable dtReviews = dsReviews.Tables[0];

            foreach (DataRow row in dtReviews.Rows)
            {
                reviewList.Add(new Reviews
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

            return reviewList;
        }

        [HttpPost("CreateReview")]
        public Boolean CreateReview([FromBody] Reviews review)
        {
            if (review != null)
            {
                ReviewsManagement reviewsManagement = new ReviewsManagement();
                int status = reviewsManagement.CreateReview(review);

                if (status > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            return false;
        }

        [HttpPut("ModifyReview")]
        public Boolean ModifyReview([FromBody] Reviews review)
        {
            if (review != null)
            {
                ReviewsManagement reviewsManagement = new ReviewsManagement();
                int status = reviewsManagement.ModifyReview(review);

                if (status > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        [HttpDelete("DeleteReview/{ReviewID}")]
        public Boolean DeleteReservation([FromRoute] int ReviewID)
        {
            Reviews reviews = new Reviews();
            reviews.ReviewID = ReviewID;

            if (reviews.ReviewID > 0)
            {
                ReviewsManagement reviewsManagement = new ReviewsManagement();
                int status = reviewsManagement.DeleteReview(reviews);

                if (status > 0)
                {
                    return true;
                }
                    
                else
                {
                    return false;
                }
                    
            }
            else
            {
                return false;
            }
        }

    }
}
