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
        public OrderStatus Status { get; set; } = OrderStatus.Ordered;
        public Dictionary<string, int> Items { get; set; } = new();

        public Order(int orderNumber, string restaurantName, string customerEmail)
        {
            OrderNumber = orderNumber;
            RestaurantName = restaurantName;
            CustomerEmail = customerEmail;
        }
    }
}