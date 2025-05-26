using System;
using System.Collections.Generic;
using System.Linq;
using ArribaEats.Models;
using ArribaEats.Repositories;

namespace ArribaEats.Menus
{
    public static class ReviewMenu
    {
        public static void ShowRestaurantReviews(Restaurant restaurant)
        {
            var reviews = RestaurantRepository.GetReviews(restaurant.Name);
            if (!reviews.Any())
            {
                Console.WriteLine("No reviews have been left for this restaurant.");
                return;
            }

            foreach (var review in reviews)
            {
                Console.WriteLine($"Reviewer: {review.CustomerName}");
                Console.WriteLine($"Rating: {new string('*', review.StarRating)}");
                Console.WriteLine($"Comment: {review.Comment}");
                Console.WriteLine();
            }
        }

        public static void LeaveReview(Customer customer)
        {
            var orders = OrderRepository.GetDeliveredOrdersByCustomer(customer.Email)
                .Where(o => !RestaurantRepository.HasReviewed(customer.Name, o.OrderNumber))
                .ToList();

            if (!orders.Any())
            {
                Console.WriteLine("You have no orders eligible for review.");
                return;
            }

            Console.WriteLine("Select a previous order to rate the restaurant it came from:");
            for (int i = 0; i < orders.Count; i++)
            {
                var o = orders[i];
                Console.WriteLine($"{i + 1}: Order #{o.OrderNumber} from {o.RestaurantName}");
            }
            Console.WriteLine($"{orders.Count + 1}: Return to the previous menu");
            Console.Write($"Please enter a choice between 1 and {orders.Count + 1}: ");

            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int choice) && choice >= 1 && choice <= orders.Count + 1)
                {
                    if (choice == orders.Count + 1) return;

                    SubmitReview(customer, orders[choice - 1]);
                    return;
                }

                Console.WriteLine("Invalid choice.");
                Console.Write($"Please enter a choice between 1 and {orders.Count + 1}: ");
            }
        }

        private static void SubmitReview(Customer customer, Order order)
        {
            Console.WriteLine($"You are rating order #{order.OrderNumber} from {order.RestaurantName}:");
            foreach (var item in order.Items)
                Console.WriteLine($"{item.Value} x {item.Key}");

            int stars;
            while (true)
            {
                Console.Write("Please enter a rating for this restaurant (1-5, 0 to cancel): ");
                if (int.TryParse(Console.ReadLine(), out stars) && stars >= 0 && stars <= 5)
                    break;
                Console.WriteLine("Invalid rating.");
            }

            if (stars == 0) return;

            Console.Write("Please enter a comment to accompany this rating: ");
            string comment = Console.ReadLine();

            var review = new Review(customer.Name, order.RestaurantName, stars, comment, order.OrderNumber);
            RestaurantRepository.AddReview(order.RestaurantName, review);

            Console.WriteLine($"Thank you for rating {order.RestaurantName}.");
        }
    }
}
