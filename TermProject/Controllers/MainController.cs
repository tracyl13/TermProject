using Microsoft.AspNetCore.Mvc;
using System.Data;
using TermProject.Models;

namespace TermProject.Controllers
{
    public class MainController : Controller
    {
        //Helper method to fill the cuisine check select list.
        public void PopulateCuisineList()
        {
            MainManagement mainManagement = new MainManagement();
            DataSet dsCuisine = mainManagement.GetCuisine();

            List<string> cuisines = new List<string>();
            foreach (DataRow row in dsCuisine.Tables[0].Rows)
            {
                cuisines.Add(row["Cuisine"].ToString());
            }

            ViewBag.Cuisines = cuisines;
        }

        //Helper method to fill the city dropdown list.
        public void PopulateCityList()
        {
            MainManagement restaurantSearch = new MainManagement();
            DataSet dsCity = restaurantSearch.GetCity();

            List<string> cities = new List<string>();
            foreach (DataRow row in dsCity.Tables[0].Rows)
            {
                cities.Add(row["City"].ToString());
            }

            ViewBag.Cities = cities;
        }

        private List<Restaurant> GetRestaurantSummery(DataTable restaurant)
        {
            List<Restaurant> restaurants = new List<Restaurant>();

                foreach (DataRow row in restaurant.Rows)
                {
                    restaurants.Add(new Restaurant
                    {
                        RestaurantID = Convert.ToInt32(row["RestaurantID"]),
                        Name = row["Name"].ToString(),
                        City = row["City"].ToString(),
                        State = row["State"].ToString(),
                        Cuisine = row["Cuisine"].ToString(),
                        LogoPhoto = row["LogoPhoto"].ToString(),
                        AverageFoodQuality = Convert.ToDecimal(row["AverageFoodQuality"]),
                        OverallRating = Convert.ToDecimal(row["OverallRating"])
                    }
                    );
                }

            return restaurants;
        }

        public IActionResult Main()
        {
            MainManagement restaurantSummery = new MainManagement();
            DataSet dsRestaurant = restaurantSummery.GetRestaurantSummery();

            List<Restaurant> restaurants = GetRestaurantSummery(dsRestaurant.Tables[0]);
            PopulateCuisineList();
            PopulateCityList();

            return View(restaurants);
        }

        /*The view groups all checkboxes selected into the array list called selectedCuisines, and passes it to the server by model binder. We use the controller to use the data that 
         * was passes here to know what has been selected, and use that data to perform the filter. City also follows the same logic, except it to a string called city. The cusine and
         city is populated at the start of the search, and the if statment is to handel a attempted search when nothing has been selected.*/
        [HttpPost]
        public  IActionResult SearchRestaurant(List<string> selectedCuisines, string city)
        {
            MainManagement mainManagement = new MainManagement();
            DataSet restaurant = mainManagement.GetRestaurantSummery();

            PopulateCuisineList();
            PopulateCityList();

            if (selectedCuisines == null || selectedCuisines.Count == 0 || string.IsNullOrEmpty(city))
            {
                ViewBag.SearchValidation = "You must select a city and at least 1 cuisine to search.";
                List<Restaurant> restaurants = GetRestaurantSummery(restaurant.Tables[0]);
                return View("Main", restaurants);
            }

            DataTable originalData = restaurant.Tables[0];
            DataView filterView = new DataView(originalData);

            string cuisineFilter = string.Join(" OR ", selectedCuisines.Select(cuisine => $"Cuisine = '{cuisine.Replace("'", "''")}'"));
            cuisineFilter = $"({cuisineFilter})";
            string cityFilter = $"City = '{city.Replace("'", "''")}'";

            string filterExpression = $"{cuisineFilter} AND {cityFilter}";
            filterView.RowFilter = filterExpression;

            List<Restaurant> filteredRestaurants = GetRestaurantSummery(filterView.ToTable());

            return View("Main", filteredRestaurants);
        }

        /*The profile is triggered when a restaurant is selected, directing them to the main page of the restaurant. Needs to be worked on. */
        public IActionResult Profile(int ID)
        {
            return View();
        }


       
    }
}
