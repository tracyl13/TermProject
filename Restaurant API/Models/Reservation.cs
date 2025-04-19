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

        
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        
        public TimeSpan Time
        {
            get { return time; }
            set { time = value; }
        }

        
        public string PartySize
        {
            get { return partySize; }
            set { partySize = value; }
        }

        
        public string SpecialRequest
        {
            get { return specialRequest; }
            set { specialRequest = value; }
        }
    }
}
