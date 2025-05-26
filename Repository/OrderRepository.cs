using System.Collections.Generic;
using System.Linq;
using ArribaEats.Models;

namespace ArribaEats.Repositories
{
    public static class OrderRepository
    {
        private static List<Order> orders = new();
        private static int currentOrderId = 1;
        public static int NextOrderNumber => currentOrderId;

        public static Order Create(
            string restaurantName,
            string restaurantLocation,
            string customerName,
            string customerLocation,
            string customerEmail)
        {
            var order = new Order(
                currentOrderId++,
                restaurantName,
                restaurantLocation,
                customerName,
                customerLocation,
                customerEmail
            );
            orders.Add(order);
            return order;
        }
        public static void Add(Order order)
        {
            orders.Add(order);
        }


                public static Order GetById(int id) => orders.FirstOrDefault(o => o.OrderNumber == id);

                public static List<Order> GetByCustomer(string email) =>
                    orders.Where(o => o.CustomerEmail == email).ToList();
                public static List<Order> GetDeliveredOrdersByCustomer(string customerEmail)
                {
                    return orders
                        .Where(o => o.CustomerEmail == customerEmail && o.Status == OrderStatus.Delivered)
                        .ToList();
                }

        public static List<Order> GetByRestaurant(string name) =>
            orders.Where(o => o.RestaurantName == name).ToList();

        public static List<Order> All => orders;
    }
}