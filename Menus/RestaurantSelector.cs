using System;
using System.Linq;
using ArribaEats.Models;
using ArribaEats.Repositories;

namespace ArribaEats.Menus
{
    public static class RestaurantSelector
    {
        public static void Show(Customer customer)
        {
            var restaurants = RestaurantRepository.GetAll();
            if (restaurants.Count == 0)
            {
                Console.WriteLine("No restaurants are currently available.");
                return;
            }

            Console.WriteLine("Available Restaurants:");

            for (int i = 0; i < restaurants.Count; i++)
            {
                var restaurant = restaurants[i];
                double rating = restaurant.GetAverageRating();
                Console.WriteLine($"{i + 1}. {restaurant.Name} ({restaurant.CuisineType}) - {rating:F1}⭐");
            }

            Console.Write("Enter the number of the restaurant you want to order from: ");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int index) || index < 1 || index > restaurants.Count)
            {
                Console.WriteLine("Invalid restaurant selection.");
                return;
            }

            var selected = restaurants[index - 1];
            var order = OrderRepository.Create(
                selected.Name,
                customer.Email,
                customer.Name,
                customer.Location,
                selected.Location
            );

            while (true)
            {
                Console.Write("Enter item name to add (or press Enter to finish): ");
                string item = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(item)) break;

                Console.Write($"Enter quantity of {item}: ");
                string qtyInput = Console.ReadLine();
                if (int.TryParse(qtyInput, out int qty) && qty > 0)
                {
                    if (order.Items.ContainsKey(item))
                        order.Items[item] += qty;
                    else
                        order.Items[item] = qty;
                }
                else
                {
                    Console.WriteLine("Invalid quantity.");
                }
            }

            Console.WriteLine($"Order #{order.OrderNumber} placed with {selected.Name}.");
        }
    }
}
