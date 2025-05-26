using System.Collections.Generic;

namespace ArribaEats.Models
{
    public enum OrderStatus
    {
        Ordered,
        Cooking,
        Cooked,
        BeingDelivered,
        Delivered
    }

    public class Order
    {
        public int OrderNumber { get; set; }
        public string RestaurantName { get; set; }
        public string CustomerEmail { get; set; }
        public string DelivererEmail { get; set; } = null;
        public string RestaurantLocation { get; set; }
        public string CustomerName { get; set; }
        public string CustomerLocation { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Ordered;
        public Dictionary<string, int> Items { get; set; } = new();

        public Order(
            int orderNumber,
            string restaurantName,
            string restaurantLocation,
            string customerEmail,
            string customerName,
            string customerLocation)
        {
            OrderNumber = orderNumber;
            RestaurantName = restaurantName;
            RestaurantLocation = restaurantLocation;
            CustomerEmail = customerEmail;
            CustomerName = customerName;
            CustomerLocation = customerLocation;
        }
        public decimal TotalPrice()
        {
            decimal total = 0;
            foreach (var item in Items)
            {
                total += item.Value * 10.00m; // Replace with actual pricing logic later
            }
            return total;
        }

    }
}