using System;
using System.Collections.Generic;
using ArribaEats.Models;
using ArribaEats.Repositories;

namespace ArribaEats.Menus
{
    public static class RestaurantMenu
    {
        public static void Show(Client client)
        {
            Console.WriteLine($"Welcome back, {client.Name}!");

            var restaurant = RestaurantRepository.GetByOwner(client.Email);

            if (restaurant == null)
            {
                Console.WriteLine("No restaurant found for this account.");
                return;
            }

            while (true)
            {
                Console.WriteLine("Please make a choice from the menu below:");
                Console.WriteLine("1: Display your restaurant details");
                Console.WriteLine("2: View orders");
                Console.WriteLine("3: Create a mock order (for testing)");
                Console.WriteLine("4: Log out");
                Console.WriteLine("Please enter a choice between 1 and 4: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine($"Restaurant Name: {restaurant.Name}");
                        Console.WriteLine($"Cuisine Type: {restaurant.CuisineType}");
                        Console.WriteLine($"Location: {restaurant.Location}");
                        Console.WriteLine();
                        break;

                    case "2":
                        var orders = OrderRepository.GetByRestaurant(restaurant.Name);
                        if (orders.Count == 0)
                        {
                            Console.WriteLine("There are currently no orders for your restaurant.");
                        }
                        else
                        {
                            foreach (var order in orders)
                            {
                                Console.WriteLine($"Order #{order.OrderNumber}: {order.Status} for {order.CustomerName}");
                            }
                        }
                        break;

                    case "3":
                        Console.WriteLine("Enter mock customer email: ");
                        var customerEmail = Console.ReadLine();

                        Console.WriteLine("Enter mock customer name: ");
                        var customerName = Console.ReadLine();

                        Console.WriteLine("Enter mock customer location: ");
                        var customerLocation = Console.ReadLine();

                        int nextId = OrderRepository.NextOrderNumber;

                        var mockOrder = new Order(
                            nextId,
                            restaurant.Name,
                            customerEmail ?? "",
                            customerName ?? "",
                            customerLocation ?? "",
                            restaurant.Location
                        );

                        mockOrder.Items.Add("Mock Burger", 2);
                        mockOrder.Items.Add("Mock Fries", 1);

                        OrderRepository.Add(mockOrder);
                        Console.WriteLine($"Mock order #{mockOrder.OrderNumber} created.");
                        break;

                    case "4":
                        Console.WriteLine("You are now logged out.");
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
