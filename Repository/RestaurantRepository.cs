using System.Collections.Generic;
using System.Linq;
using ArribaEats.Models;

namespace ArribaEats.Repositories
{
    public static class RestaurantRepository
    {
        private static List<Restaurant> restaurants = new();

        public static void Add(Restaurant restaurant)
        {
            restaurants.Add(restaurant);
        }

        public static Restaurant GetByName(string name)
        {
            return restaurants.FirstOrDefault(r => r.Name == name);
        }

        public static List<Restaurant> GetAll()
        {
            return restaurants;
        }

        public static bool HasReviewed(string customerEmail, string restaurantName)
        {
            var restaurant = GetByName(restaurantName);
            if (restaurant == null) return false;

            return restaurant.Reviews.Any(r => r.CustomerEmail == customerEmail);
        }

        public static void AddReview(string restaurantName, Review review)
        {
            var restaurant = GetByName(restaurantName);
            if (restaurant != null)
            {
                restaurant.AddReview(review);
            }
        }
    }
}
