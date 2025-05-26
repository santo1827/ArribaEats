using System;

namespace ArribaEats
{
    public static class Menu
    {
        public static void ShowStartupMenu()
        {
            Console.WriteLine("Welcome to Arriba Eats!");
            while (true)
            {
                Console.WriteLine("Please make a choice from the menu below:");
                Console.WriteLine("1: Login as a registered user");
                Console.WriteLine("2: Register as a new user");
                Console.WriteLine("3: Exit");
                Console.WriteLine("Please enter a choice between 1 and 3: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Login.HandleLogin();
                        break;
                    case "2":
                        Registration.HandleRegistration();
                        break;
                    case "3":
                        Console.WriteLine("Thank you for using Arriba Eats!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}