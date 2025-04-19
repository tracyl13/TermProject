using System.ComponentModel.DataAnnotations;


namespace TermProject.Models
{
    public class Reviews
    {
        private int reviewID;
        private int restaurantID;
        private int reviewerID;
        private DateTime date;
        private TimeSpan time;
        private int foodQuality;
        private int service;
        private int atmosphere;
        private int price;
        private string comment;

        public int ReviewID
        {
            get { return reviewID; }
            set { reviewID = value; }
        }

        public int RestaurantID
        {
            get { return restaurantID; }
            set { restaurantID = value; }
        }

        public int ReviewerID
        {
            get { return reviewerID; }
            set { reviewerID = value; }
        }

        [Required(ErrorMessage = "Date cannot be empty")]
        [Display(Name = "Date")]
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        [Required(ErrorMessage = "Time cannot be empty")]
        [Display(Name = "Time")]
        public TimeSpan Time
        {
            get { return time; }
            set { time = value; }
        }

        [Required(ErrorMessage = "FoodQuality cannot be empty")]
        [Display(Name = "Food Quality")]
        public int FoodQuality
        {
            get { return foodQuality; }
            set { foodQuality = value; }
        }

        [Required(ErrorMessage = "Service cannot be empty")]
        [Display(Name = "Service")]
        public int Service
        {
            get { return service; }
            set { service = value; }
        }

        [Required(ErrorMessage = "Atmosphere cannot be empty")]
        [Display(Name = "Atmosphere")]
        public int Atmosphere
        {
            get { return atmosphere; }
            set { atmosphere = value; }
        }

        [Required(ErrorMessage = "Price cannot be empty")]
        [Display(Name = "Price")]
        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        [Required(ErrorMessage = "Comment cannot be empty")]
        [Display(Name = "Comment")]
        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }
    }
}
