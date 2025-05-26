using System;
using System.Collections.Generic;
using System.Linq;
using ArribaEats.Models;
using ArribaEats.Repositories;

namespace ArribaEats.Menus
{
    public static class RestaurantSelector
    {
        public static void Show(Customer customer)
        {
            while (true)
            {
                Console.WriteLine("How would you like the list of restaurants ordered?");
                Console.WriteLine("1: Sorted alphabetically by name");
                Console.WriteLine("2: Sorted by distance");
                Console.WriteLine("3: Sorted by style");
                Console.WriteLine("4: Sorted by average rating");
                Console.WriteLine("5: Return to the previous menu");
                Console.Write("Please enter a choice between 1 and 5: ");

                string input = Console.ReadLine();

                if (input == "5") return;

                var restaurants = RestaurantRepository.GetAll();

                switch (input)
                {
                    case "1":
                        restaurants = restaurants.OrderBy(r => r.Name).ToList();
                        break;
                    case "2":
                        restaurants = restaurants.OrderBy(r => Distance(customer.Location, r.Location))
                                                 .ThenBy(r => r.Name).ToList();
                        break;
                    case "3":
                        restaurants = restaurants.OrderBy(r => r.Style)
                                                 .ThenBy(r => r.Name).ToList();
                        break;
                    case "4":
                        restaurants = restaurants.OrderByDescending(r => r.GetAverageRating())
                                                 .ThenBy(r => r.Name).ToList();
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        continue;
                }

                ShowRestaurantList(customer, restaurants);
            }
        }

        private static void ShowRestaurantList(Customer customer, List<Restaurant> restaurants)
        {
            if (!restaurants.Any())
            {
                Console.WriteLine("No restaurants available.");
                return;
            }

            Console.WriteLine("You can order from the following restaurants:");
            Console.WriteLine("   Restaurant Name       Loc    Dist  Style       Rating");

            for (int i = 0; i < restaurants.Count; i++)
            {
                var r = restaurants[i];
                int dist = Distance(customer.Location, r.Location);
                string rating = r.GetAverageRating() == -1 ? "-" : r.GetAverageRating().ToString("0.0");

                Console.WriteLine($"{i + 1}: {r.Name,-20} {r.Location,-6} {dist,-5} {r.Style,-10} {rating}");
            }

            Console.WriteLine($"{restaurants.Count + 1}: Return to the previous menu");
            Console.Write($"Please enter a choice between 1 and {restaurants.Count + 1}: ");

            while (true)
            {
                string choice = Console.ReadLine();
                if (int.TryParse(choice, out int index) && index >= 1 && index <= restaurants.Count + 1)
                {
                    if (index == restaurants.Count + 1) return;

                    RestaurantMenu.Show(customer, restaurants[index - 1]);
                    return;
                }
                Console.WriteLine("Invalid choice.");
                Console.Write($"Please enter a choice between 1 and {restaurants.Count + 1}: ");
            }
        }

        private static int Distance(string locA, string locB)
        {
            var a = locA.Split(',').Select(int.Parse).ToArray();
            var b = locB.Split(',').Select(int.Parse).ToArray();
            return Math.Abs(a[0] - b[0]) + Math.Abs(a[1] - b[1]);
        }
    }
}
