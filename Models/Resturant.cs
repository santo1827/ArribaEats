using System.Collections.Generic;

namespace ArribaEats.Models
{
    public class Restaurant
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public Dictionary<string, decimal> Menu { get; set; }
        public List<Review> Reviews { get; set; }

        public Restaurant(string name, string address, Dictionary<string, decimal> menu)
        {
            Name = name;
            Address = address;
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

            double totalStars = 0;
            foreach (var review in Reviews)
                totalStars += review.StarRating;

            return totalStars / Reviews.Count;
        }
    }
}
