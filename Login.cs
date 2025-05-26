using System;
using System.Linq;
using ArribaEats.Models;
using ArribaEats.Repository;

namespace ArribaEats
{
    public static class Login
    {
        public static void LoginUser()
        {
            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            var user = UserRepository.Users.FirstOrDefault(u =>
                u.Email.Equals(email, StringComparison.OrdinalIgnoreCase) &&
                u.Password == password);

            if (user == null)
            {
                Console.WriteLine("Invalid email or password.");
                return;
            }

            // Dispatch to the correct role menu
            if (user is Client client)
            {
                ClientMenu.Show(client);
            }
            else if (user is Customer customer)
            {
                CustomerMenu.Show(customer);
            }
            else if (user is Deliverer deliverer)
            {
                DelivererMenu.Show(deliverer);
            }
        }
    }
}
