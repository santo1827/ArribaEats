namespace ArribaEats.Models
{
    public class Review
    {
        public int OrderNumber { get; }
        public string RestaurantName { get; }
        public string CustomerName { get; }
        public string Comment { get; }
        public int StarRating { get; }

        public Review(int orderNumber, string restaurantName, string customerName, string comment, int starRating)
        {
            OrderNumber = orderNumber;
            RestaurantName = restaurantName;
            CustomerName = customerName;
            Comment = comment;
            StarRating = starRating;
        }
    }
}
