using System.Collections.Generic;
using System.Linq;
using ArribaEats.Models;

namespace ArribaEats.Repositories
{
    public static class RestaurantRepository
    {
        private static List<Restaurant> restaurants = new();
        private static List<Review> reviews = new();

        public static void Add(Restaurant r) => restaurants.Add(r);

        public static Restaurant GetByName(string name) =>
            restaurants.FirstOrDefault(r => r.Name == name);

        public static List<Restaurant> All => restaurants;

        public static void AddReview(Review review) => reviews.Add(review);

        public static List<Review> GetReviews(string restaurant) =>
            reviews.Where(r => r.RestaurantName == restaurant).ToList();

        public static double? GetAverageRating(string restaurant)
        {
            var rs = GetReviews(restaurant);
            return rs.Count == 0 ? null : rs.Average(r => r.Rating);
        }
    }
}