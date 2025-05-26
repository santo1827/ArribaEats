using System;
using System.Linq;
using ArribaEats.Models;
using ArribaEats.Repositories;

namespace ArribaEats.Menus
{
    public static class ReviewMenu
    {
        public static void LeaveReview(Customer customer)
        {
            var deliveredOrders = OrderRepository.GetDeliveredOrdersByCustomer(customer.Email);
            var notReviewed = deliveredOrders
                .Where(o => !RestaurantRepository.HasReviewed(o.RestaurantName, customer.Email))
                .ToList();

            if (!notReviewed.Any())
            {
                Console.WriteLine("There are no restaurants eligible for review.");
                return;
            }

            Console.WriteLine("Restaurants you can leave a review for:");
            for (int i = 0; i < notReviewed.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {notReviewed[i].RestaurantName}");
            }

            Console.WriteLine("Enter the number of the restaurant to review: ");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int index) || index < 1 || index > notReviewed.Count)
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

            var order = notReviewed[index - 1];
            Console.WriteLine("Leave a short review comment: ");
            string comment = Console.ReadLine() ?? "";

            Console.WriteLine("Give a star rating (1-5): ");
            string ratingInput = Console.ReadLine();
            if (!int.TryParse(ratingInput, out int rating) || rating < 1 || rating > 5)
            {
                Console.WriteLine("Invalid rating.");
                return;
            }

            var review = new Review(order.OrderNumber, order.RestaurantName, customer.Name, comment, rating);
            RestaurantRepository.AddReview(order.RestaurantName, review);

            Console.WriteLine("Your review has been submitted. Thank you!");
        }
    }
}
