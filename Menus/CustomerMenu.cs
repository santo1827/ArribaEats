using System;
using System.Collections.Generic;
using System.Linq;
using ArribaEats.Models;
using ArribaEats.Repositories;

namespace ArribaEats.Menus
{
    public static class CustomerMenu
    {
        public static void Show(Customer customer)
        {
            Console.WriteLine($"Welcome back, {customer.Name}!");

            while (true)
            {
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
                        ShowInfo(customer);
                        break;
                    case "2":
                        RestaurantSelector.Show(customer);
                        break;
                    case "3":
                        OrderViewer.ShowCustomerOrders(customer);
                        break;
                    case "4":
                        ReviewMenu.LeaveReview(customer);
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

        private static void ShowInfo(Customer customer)
        {
            Console.WriteLine("Your user details are as follows:");
            Console.WriteLine($"Name: {customer.Name}");
            Console.WriteLine($"Age: {customer.Age}");
            Console.WriteLine($"Email: {customer.Email}");
            Console.WriteLine($"Mobile: {customer.Phone}");
            Console.WriteLine($"Location: {customer.Location}");

            var orders = OrderRepository.GetByCustomer(customer.Email);
            int totalOrders = orders.Count;
            decimal totalSpent = orders.Sum(o => o.TotalPrice());

            Console.WriteLine($"You've made {totalOrders} order(s) and spent a total of ${totalSpent:F2} here.");
            Console.WriteLine();
        }
    }
}
