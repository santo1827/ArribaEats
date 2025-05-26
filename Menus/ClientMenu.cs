using System;
using ArribaEats.Models;

namespace ArribaEats
{
    public static class ClientMenu
    {
        public static void Show(Client client)
        {
            bool firstEntry = true;

            while (true)
            {
                if (firstEntry)
                {
                    Console.WriteLine($"\nWelcome back, {client.Name}!");
                    firstEntry = false;
                }

                Console.WriteLine("Please make a choice from the menu below:");
                Console.WriteLine("1: Display your user information");
                Console.WriteLine("2: Add item to restaurant menu");
                Console.WriteLine("3: See current orders");
                Console.WriteLine("4: Start cooking order");
                Console.WriteLine("5: Finish cooking order");
                Console.WriteLine("6: Handle deliverers who have arrived");
                Console.WriteLine("7: Log out");
                Console.Write("Please enter a choice between 1 and 7: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DisplayUserInfo(client);
                        break;
                    case "2":
                        Console.WriteLine("TODO: Add item to restaurant menu.");
                        break;
                    case "3":
                        Console.WriteLine("TODO: Show current orders.");
                        break;
                    case "4":
                        Console.WriteLine("TODO: Start cooking an order.");
                        break;
                    case "5":
                        Console.WriteLine("TODO: Mark an order as cooked.");
                        break;
                    case "6":
                        Console.WriteLine("TODO: Handle driver pickup.");
                        break;
                    case "7":
                        Console.WriteLine("You are now logged out.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private static void DisplayUserInfo(Client client)
        {
            Console.WriteLine("Your user details are as follows:");
            Console.WriteLine($"Name: {client.Name}");
            Console.WriteLine($"Age: {client.Age}");
            Console.WriteLine($"Email: {client.Email}");
            Console.WriteLine($"Mobile: {client.PhoneNumber}");
            Console.WriteLine($"Restaurant name: {client.RestaurantName}");
            Console.WriteLine($"Restaurant style: {StyleToString(client.Style)}");
            Console.WriteLine($"Restaurant location: {client.Location}");
        }

        private static string StyleToString(int style) => style switch
        {
            1 => "Italian",
            2 => "French",
            3 => "Chinese",
            4 => "Japanese",
            5 => "American",
            6 => "Australian",
            _ => "Unknown"
        };
    }
}
