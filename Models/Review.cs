namespace ArribaEats.Models
{
    public class Review
    {
        public int OrderNumber { get; set; }
        public string RestaurantName { get; set; }
        public string ReviewerName { get; set; }
        public int Rating { get; set; } // 1-5
        public string Comment { get; set; }

        public Review(int orderNumber, string restaurantName, string reviewerName, int rating, string comment)
        {
            OrderNumber = orderNumber;
            RestaurantName = restaurantName;
            ReviewerName = reviewerName;
            Rating = rating;
            Comment = comment;
        }
    }
}