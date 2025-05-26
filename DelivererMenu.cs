using System;
using ArribaEats.Models;

namespace ArribaEats
{
    public static class DelivererMenu
    {
        public static void Show(Deliverer deliverer)
        {
            bool firstEntry = true;
            
            

            while (true)
            {
                if (firstEntry)
                {
                    Console.WriteLine($"\nWelcome back, {deliverer.Name}!");
                    firstEntry = false;
                }

                Console.WriteLine("Please make a choice from the menu below:");
                Console.WriteLine("1: Display your user information");
                Console.WriteLine("2: List orders available to deliver");
                Console.WriteLine("3: Arrived at restaurant to pick up order");
                Console.WriteLine("4: Mark this delivery as complete");
                Console.WriteLine("5: Log out");
                Console.Write("Please enter a choice between 1 and 5: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DisplayUserInfo(deliverer);
                        break;

                    case "2":
                        Console.WriteLine("TODO: Show list of available orders to deliver.");
                        break;

                    case "3":
                        Console.WriteLine("TODO: Mark as arrived at restaurant.");
                        break;

                    case "4":
                        Console.WriteLine("TODO: Mark delivery as complete.");
                        break;

                    case "5":
                        Console.WriteLine("You are now logged out.");
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

            }
        }

        private static void DisplayUserInfo(Deliverer deliverer)
        {
            Console.WriteLine("Your user details are as follows:");
            Console.WriteLine($"Name: {deliverer.Name}");
            Console.WriteLine($"Age: {deliverer.Age}");
            Console.WriteLine($"Email: {deliverer.Email}");
            Console.WriteLine($"Mobile: {deliverer.PhoneNumber}");
            Console.WriteLine($"Licence plate: {deliverer.LicencePlate}");

            if (deliverer.CurrentOrder != null)
            {
                Console.WriteLine("Current delivery:");
                Console.WriteLine($"Order #{deliverer.CurrentOrder.OrderNumber} from {deliverer.CurrentOrder.RestaurantName} at {deliverer.CurrentOrder.RestaurantLocation}.");
                Console.WriteLine($"To be delivered to {deliverer.CurrentOrder.CustomerName} at {deliverer.CurrentOrder.CustomerLocation}.");
            }
        }
    }
}
