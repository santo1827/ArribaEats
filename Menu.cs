using System;

namespace ArribaEats
{
    public static class Menu
    {
        public static void DisplayStartupMenu()
        {
            Console.WriteLine("Welcome to Arriba Eats!");
            Console.WriteLine("Please make a choice from the menu below:");
            Console.WriteLine("1: Login as a registered user");
            Console.WriteLine("2: Register as a new user");
            Console.WriteLine("3: Exit");
            Console.Write("Please enter a choice between 1 and 3: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Login.LoginUser();
                    break;
                case "2":
                    Registration.RegisterUser();
                    break;
                case "3":
                    Console.WriteLine("Thank you for using Arriba Eats!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
