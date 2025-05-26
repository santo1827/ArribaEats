using System;
using ArribaEats.Models;

namespace ArribaEats
{
    public static class CustomerMenu
    {
        public static void Show(Customer customer)
        {
            bool firstEntry = true;

            while (true)
            {
                if (firstEntry)
                {
                    Console.WriteLine($"\nWelcome back, {customer.Name}!");
                    firstEntry = false;
                }

                Console.WriteLine("Please make a choice from the menu below:");
                Console.WriteLine("1: Display your user information");
                Console.WriteLine("2: Select a list of restaurants to order from");
                Console.WriteLine("3: See the status of your orders");
                Console.WriteLine("4: Rate a restaurant you've ordered from");
                Console.WriteLine("5: Log out");
                Console.Write("Please enter a choice between 1 and 5: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        DisplayUserInfo(customer);
                        break;

                    case "2":
                        Console.WriteLine("TODO: List available restaurants to order from.");
                        break;

                    case "3":
                        Console.WriteLine("TODO: Show status of your previous orders.");
                        break;

                    case "4":
                        Console.WriteLine("TODO: Rate a restaurant from a delivered order.");
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

        private static void DisplayUserInfo(Customer customer)
        {
            Console.WriteLine("Your user details are as follows:");
            Console.WriteLine($"Name: {customer.Name}");
            Console.WriteLine($"Age: {customer.Age}");
            Console.WriteLine($"Email: {customer.Email}");
            Console.WriteLine($"Mobile: {customer.PhoneNumber}");
            Console.WriteLine($"Location: {customer.Location}");
            Console.WriteLine($"You've made {customer.OrdersPlaced} order(s) and spent a total of {customer.TotalSpent:C2} here.");
        }
    }
}
