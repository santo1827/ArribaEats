using System;
using System.Linq;
using ArribaEats.Models;
using ArribaEats.Repositories;

namespace ArribaEats.Menus
{
    public static class RestaurantMenu
    {
        public static void Show(Customer customer, Restaurant restaurant)
        {
            Console.WriteLine($"Placing order from {restaurant.Name}.");

            while (true)
            {
                Console.WriteLine("1: See this restaurant's menu and place an order");
                Console.WriteLine("2: See reviews for this restaurant");
                Console.WriteLine("3: Return to main menu");
                Console.Write("Please enter a choice between 1 and 3: ");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        OrderMenu(customer, restaurant);
                        break;
                    case "2":
                        ReviewMenu.ShowRestaurantReviews(restaurant);
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private static void OrderMenu(Customer customer, Restaurant restaurant)
        {
            var orderItems = new System.Collections.Generic.Dictionary<string, int>();
            decimal total = 0;

            while (true)
            {
                Console.WriteLine($"Current order total: ${total:F2}");

                int i = 1;
                foreach (var item in restaurant.Menu)
                {
                    Console.WriteLine($"{i}: {item.Value.ToString("C").PadLeft(7)}  {item.Key}");
                    i++;
                }

                Console.WriteLine($"{i}: Complete order");
                Console.WriteLine($"{i + 1}: Cancel order");
                Console.Write($"Please enter a choice between 1 and {i + 1}: ");

                string choice = Console.ReadLine();
                if (!int.TryParse(choice, out int selected) || selected < 1 || selected > i + 1)
                {
                    Console.WriteLine("Invalid choice.");
                    continue;
                }

                if (selected == i + 1) return; // cancel
                if (selected == i)
                {
                    if (!orderItems.Any())
                    {
                        Console.WriteLine("You must add at least one item before completing.");
                        continue;
                    }

                    int orderNo = OrderRepository.NextOrderNumber();
                    var order = new Order(orderNo, customer.Email, restaurant.Name, orderItems);
                    OrderRepository.Add(order);
                    Console.WriteLine($"Your order has been placed. Your order number is #{orderNo}.");
                    return;
                }

                var itemName = restaurant.Menu.Keys.ElementAt(selected - 1);
                Console.Write("Please enter quantity (0 to cancel): ");
                string qtyInput = Console.ReadLine();
                if (!int.TryParse(qtyInput, out int qty) || qty < 0)
                {
                    Console.WriteLine("Invalid quantity.");
                    continue;
                }

                if (qty == 0) continue;

                if (orderItems.ContainsKey(itemName))
                    orderItems[itemName] += qty;
                else
                    orderItems[itemName] = qty;

                total += restaurant.Menu[itemName] * qty;
                Console.WriteLine($"Added {qty} x {itemName} to order.");
            }
        }
    }
}
