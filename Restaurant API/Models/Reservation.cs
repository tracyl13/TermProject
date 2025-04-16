using System.ComponentModel.DataAnnotations;

namespace Restaurant_API.Models
{
    public class Reservation
    {
        private int reservationID;
        private int restaurantID;
        private string firstName;
        private string lastName;
        private string phoneNumber;
        private string email;
        private DateTime date;
        private TimeSpan time;
        private string partySize;
        private string specialRequest;

        public int ReservationID
        {
            get { return reservationID; }
            set { reservationID = value; }
        }
        public int RestaurantID
        {
            get { return restaurantID; }
            set { restaurantID = value; }
        }

        [Required(ErrorMessage = "First Name cannot be empty")]
        [Display(Name = "First Name")]
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        [Required(ErrorMessage = "Last Name cannot be empty")]
        [Display(Name = "Last Name")]
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        [Required(ErrorMessage = "Phone Number cannot be empty")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        [Required(ErrorMessage = "Email cannot Be empty")]
        [Display(Name = "Email")]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        [Required(ErrorMessage = "Date cannot Be empty")]
        [Display(Name = "Date")]
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        [Required(ErrorMessage = "Time cannot Be Empty")]
        [Display(Name = "Time")]
        public TimeSpan Time
        {
            get { return time; }
            set { time = value; }
        }

        [Required(ErrorMessage = "Party Size cannot Be Empty")]
        [Display(Name = "Party Size")]
        public string PartySize
        {
            get { return partySize; }
            set { partySize = value; }
        }

        [Required(ErrorMessage = "Special Request cannot be empty")]
        [Display(Name = "Special Request")]
        public string SpecialRequest
        {
            get { return specialRequest; }
            set { specialRequest = value; }
        }
    }
}
