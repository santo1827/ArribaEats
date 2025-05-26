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

        public static List<Restaurant> GetAll()
        {
            return restaurants;
        }

        public static Restaurant GetByName(string name)
        {
            return restaurants.FirstOrDefault(r => r.Name == name);
        }

        public static Restaurant GetByOwner(string ownerEmail)
        {
            return restaurants.FirstOrDefault(r => r.OwnerEmail == ownerEmail);
        }

        public static void AddReview(string restaurantName, Review review)
        {
            var restaurant = GetByName(restaurantName);
            if (restaurant != null)
            {
                restaurant.AddReview(review);
            }
        }

        public static bool HasReviewed(string restaurantName, string customerEmail)
        {
            var restaurant = GetByName(restaurantName);
            if (restaurant != null)
            {
                return restaurant.Reviews.Any(r => r.CustomerEmail == customerEmail);
            }
            return false;
        }
    }
}
