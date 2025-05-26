using System;
using ArribaEats.Models;
using ArribaEats.Repositories;
using ArribaEats.Menus;

namespace ArribaEats
{
    public static class Login
    {
        public static void HandleLogin()
        {
            Console.WriteLine("Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Password: ");
            string password = Console.ReadLine();

            var user = UserRepository.GetByEmail(email);
            if (user == null || user.Password != password)
            {
                Console.WriteLine("Invalid email or password.");
                return;
            }

            Console.WriteLine($"\nWelcome back, {user.Name}!");

            switch (user)
            {
                case Customer c:
                    CustomerMenu.Show(c);
                    break;
                case Deliverer d:
                    DelivererMenu.Show(d);
                    break;
                case Client cl:
                    ClientMenu.Show(cl);
                    break;
            }
        }
    }
}