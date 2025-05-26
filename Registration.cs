using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using ArribaEats.Models;
using ArribaEats.Repositories;

namespace ArribaEats
{
    public static class Registration
    {
        public static void HandleRegistration()
        {
            Console.WriteLine("Which type of user would you like to register as?");
            Console.WriteLine("1: Customer");
            Console.WriteLine("2: Deliverer");
            Console.WriteLine("3: Client");
            Console.WriteLine("4: Return to the previous menu");
            Console.WriteLine("Please enter a choice between 1 and 4: ");

            string userType = "";
            while (true)
            {
                string choice = Console.ReadLine();
                if (choice == "1") { userType = "Customer"; break; }
                if (choice == "2") { userType = "Deliverer"; break; }
                if (choice == "3") { userType = "Client"; break; }
                if (choice == "4") return;
                Console.WriteLine("Invalid choice.");
                Console.WriteLine("Please enter a choice between 1 and 4: ");
            }

            string name;
            while (true)
            {
                Console.WriteLine("Please enter your name: ");
                name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name) && name.All(c => char.IsLetter(c) || c == ' ' || c == '-' || c == '\'')) break;
                Console.WriteLine("Invalid name.");
            }

            byte age;
            while (true)
            {
                Console.WriteLine("Please enter your age (18-100): ");
                if (byte.TryParse(Console.ReadLine(), out age) && age >= 18 && age <= 100) break;
                Console.WriteLine("Invalid age.");
            }

            string email;
            while (true)
            {
                Console.WriteLine("Please enter your email address: ");
                email = Console.ReadLine();
                if (!email.Contains('@') || email.Count(c => c == '@') != 1 || email.StartsWith("@") || email.EndsWith("@"))
                {
                    Console.WriteLine("Invalid email address.");
                    continue;
                }
                if (UserRepository.EmailExists(email))
                {
                    Console.WriteLine("This email address is already in use.");
                    continue;
                }
                break;
            }

            string phone;
            while (true)
            {
                Console.WriteLine("Please enter your mobile phone number: ");
                phone = Console.ReadLine();
                if (Regex.IsMatch(phone ?? "", @"^0\d{9}$")) break;
                Console.WriteLine("Invalid phone number.");
            }

            string password;
            while (true)
            {
                Console.WriteLine("Your password must:");
                Console.WriteLine("- be at least 8 characters long");
                Console.WriteLine("- contain a number");
                Console.WriteLine("- contain a lowercase letter");
                Console.WriteLine("- contain an uppercase letter");
                Console.WriteLine("Please enter a password: ");
                password = Console.ReadLine() ?? "";

                if (!(password.Length >= 8 && password.Any(char.IsDigit) && password.Any(char.IsLower) && password.Any(char.IsUpper)))
                {
                    Console.WriteLine("Invalid password.");
                    continue;
                }

                Console.WriteLine("Please confirm your password: ");
                if ((Console.ReadLine() ?? "") != password)
                {
                    Console.WriteLine("Passwords do not match.");
                    continue;
                }
                break;
            }

            if (userType == "Customer")
            {
                string location;
                while (true)
                {
                    Console.WriteLine("Please enter your location (in the form of X,Y): ");
                    location = Console.ReadLine();
                    if (Regex.IsMatch(location ?? "", @"^-?\d+,-?\d+$")) break;
                    Console.WriteLine("Invalid location.");
                }
                var customer = new Customer(name, age, email, phone, password, location);
                UserRepository.Add(customer);
                Console.WriteLine($"You have been successfully registered as a customer, {name}!");
                return;
            }
            else if (userType == "Deliverer")
            {
                string plate;
                while (true)
                {
                    Console.WriteLine("Please enter your licence plate: ");
                    plate = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(plate) && Regex.IsMatch(plate, @"^[A-Z0-9 ]{1,8}$") && plate.Trim().Length > 0) break;
                    Console.WriteLine("Invalid licence plate.");
                }
                var deliverer = new Deliverer(name, age, email, phone, password, plate);
                UserRepository.Add(deliverer);
                Console.WriteLine($"You have been successfully registered as a deliverer, {name}!");
            }
            else if (userType == "Client")
            {
                string rName;
                while (true)
                {
                    Console.WriteLine("Please enter your restaurant's name: ");
                    rName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(rName)) break;
                    Console.WriteLine("Invalid restaurant name.");
                }

                Console.WriteLine("Please select your restaurant's style:");
                Console.WriteLine("1: Italian");
                Console.WriteLine("2: French");
                Console.WriteLine("3: Chinese");
                Console.WriteLine("4: Japanese");
                Console.WriteLine("5: American");
                Console.WriteLine("6: Australian");

                int style;
                while (true)
                {
                    Console.WriteLine("Please enter a choice between 1 and 6: ");
                    if (int.TryParse(Console.ReadLine(), out style) && style >= 1 && style <= 6) break;
                    Console.WriteLine("Invalid choice.");
                }

                string styleName = style switch
                {
                    1 => "Italian",
                    2 => "French",
                    3 => "Chinese",
                    4 => "Japanese",
                    5 => "American",
                    6 => "Australian",
                    _ => "Unknown"
                };

                string rLoc;
                while (true)
                {
                    Console.WriteLine("Please enter your location (in the form of X,Y): ");
                    rLoc = Console.ReadLine();
                    if (Regex.IsMatch(rLoc ?? "", @"^-?\d+,-?\d+$")) break;
                    Console.WriteLine("Invalid location.");
                }

                var client = new Client(name, age, email, phone, password, rName, style, rLoc);
                var restaurant = new Restaurant(rName, styleName, email, rLoc, rLoc, new Dictionary<string, decimal>());
                UserRepository.Add(client);
                RestaurantRepository.Add(restaurant);
                Console.WriteLine($"You have been successfully registered as a client, {name}!");
            }
        }
    }
}
