using System;
using System.Linq;
using ArribaEats.Models;
using ArribaEats.Repositories;

namespace ArribaEats.Menus
{
    public static class OrderViewer
    {
        public static void ShowCustomerOrders(Customer customer)
        {
            var orders = OrderRepository.GetByCustomer(customer.Email);
            if (!orders.Any())
            {
                Console.WriteLine("You have not placed any orders.");
                return;
            }

            foreach (var order in orders.OrderBy(o => o.OrderNumber))
            {
                Console.WriteLine($"Order #{order.OrderNumber} from {order.RestaurantName}: {order.Status}");

                if (order.Status == "Delivered" && !string.IsNullOrEmpty(order.DeliveredBy))
                {
                    var deliverer = UserRepository.GetByEmail(order.DeliveredBy) as Deliverer;
                    if (deliverer != null)
                    {
                        Console.WriteLine($"This order was delivered by {deliverer.Name} (licence plate: {deliverer.LicencePlate})");
                    }
                }

                foreach (var item in order.Items.OrderBy(i => i.Key))
                    Console.WriteLine($"{item.Value} x {item.Key}");

                Console.WriteLine();
            }
        }
    }
}
