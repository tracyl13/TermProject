using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermProject.Models
{
    public class Restaurant
    {
        private int restaurantID;
        private int representativeID;
        private String name;
        private String owner;
        private String buildingNumber;
        private String streetName;
        private String city;
        private String state;
        private String zipCode;
        private String cuisine;
        private TimeSpan openTime;
        private TimeSpan closingTime;
        private String phoneNumber;
        private String email;
        private String profilePhoto;
        private String photoCaption;
        private String logoPhoto;
        private String description;
        private String websiteURL;
        private String instagram;
        private String twitter;
        private decimal averageFoodQuality;
        private decimal overallRating;

        public int RestaurantID
        {
            get { return restaurantID; }
            set { restaurantID = value; }
        }
        public int RepresentativeID
        {
            get { return representativeID; }
            set { representativeID = value; }
        }
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public String Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        public String BuildingNumber
        {
            get { return buildingNumber; }
            set { buildingNumber = value; }
        }

        public String StreetName
        {
            get { return streetName; }
            set { streetName = value; }
        }

        public String City
        {
            get { return city; }
            set { city = value; }
        }

        public String State
        {
            get { return state; }
            set { state = value; }
        }

        public String ZipCode
        {
            get { return zipCode; }
            set { zipCode = value; }
        }

        public string Cuisine
        {
            get { return cuisine; }
            set { cuisine = value; }
        }

        public TimeSpan OpenTime
        {
            get { return openTime; }
            set { openTime = value; }
        }

        public TimeSpan ClosingTime
        {
            get { return closingTime; }
            set { closingTime = value; }
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

        public string ProfilePhoto
        {
            get { return profilePhoto; }
            set { profilePhoto = value; }
        }

        public string PhotoCaption
        {
            get { return photoCaption; }
            set { photoCaption = value; }
        }

        public string LogoPhoto
        {
            get { return logoPhoto; }
            set { logoPhoto = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string WebsiteURL
        {
            get { return websiteURL; }
            set { websiteURL = value; }
        }

        public string Instagram
        {
            get { return instagram; }
            set { instagram = value; }
        }

        public string Twitter
        {
            get { return twitter; }
            set { twitter = value; }
        }

        public decimal AverageFoodQuality
        {
            get { return averageFoodQuality; }
            set { averageFoodQuality = value; }
        }

        public decimal OverallRating
        {
            get { return overallRating; }
            set { overallRating = value; }
        }
    }
}
