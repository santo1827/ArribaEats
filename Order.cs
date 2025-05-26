namespace ArribaEats.Models
{
    public class Order
    {
        public int OrderNumber { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantLocation { get; set; }
        public string CustomerName { get; set; }
        public string CustomerLocation { get; set; }

        public Order(int number, string restaurantName, string restaurantLoc, string customerName, string customerLoc)
        {
            OrderNumber = number;
            RestaurantName = restaurantName;
            RestaurantLocation = restaurantLoc;
            CustomerName = customerName;
            CustomerLocation = customerLoc;
        }
    }
}
