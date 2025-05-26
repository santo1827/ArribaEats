using System.Collections.Generic;
using System.Linq;

namespace ArribaEats.Models
{
    public class Restaurant
    {
        public string Name { get; set; }
        public string CuisineType { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
        public string OwnerEmail { get; set; }  // Required for GetByOwner
        public Dictionary<string, decimal> Menu { get; set; }
        public List<Review> Reviews { get; set; }

        public Restaurant(string name, string cuisineType, string ownerEmail, string location, string address, Dictionary<string, decimal> menu)

        {
            Name = name;
            CuisineType = cuisineType;
            Location = location;
            Address = address;
            OwnerEmail = ownerEmail;
            Menu = menu;
            Reviews = new List<Review>();
        }

        public void AddReview(Review review)
        {
            Reviews.Add(review);
        }

        public double GetAverageRating()
        {
            if (Reviews.Count == 0)
                return 0;

            return Reviews.Average(r => r.StarRating);
        }
    }
}
