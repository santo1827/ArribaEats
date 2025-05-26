using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using ArribaEats.Repository;
using ArribaEats.Models;


public static class Registration
{
    public static void RegisterUser()
    {
        Console.WriteLine("Which type of user would you like to register as:");
        Console.WriteLine("1: Customer");
        Console.WriteLine("2: Deliverer");
        Console.WriteLine("3: Client");
        Console.WriteLine("4: Return to the previous menu");
        Console.Write("Please enter a choice between 1 and 4: ");

        string typeInput;
        string userType = "";
        while (true)
        {
            typeInput = Console.ReadLine();
            switch (typeInput)
            {
                case "1": userType = "Customer"; break;
                case "2": userType = "Deliverer"; break;
                case "3": userType = "Client"; break;
                case "4": return;
                default:
                    Console.WriteLine("Invalid choice.");
                    Console.Write("Please enter a choice between 1 and 4: ");
                    continue;
            }
            break;
        }

        string name;
        while (true)
        {
            Console.Write("Please enter your name: ");
            name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name) && name.All(c => char.IsLetter(c) || c == ' ' || c == '-' || c == '\''))
                break;

            Console.WriteLine("Invalid name.");
        }

        byte age;
        while (true)
        {
            Console.Write("Please enter your age (18-100): ");
            string input = Console.ReadLine();

            if (!byte.TryParse(input, out age) || age < 18 || age > 100)
            {
                Console.WriteLine("Invalid age.");
                continue;
            }

            break;
        }


        string email;
        var emailValidator = new EmailAddressAttribute();

        while (true)
        {
            Console.Write("Please enter your email address: ");
            email = Console.ReadLine();

            if (!emailValidator.IsValid(email))
            {
                Console.WriteLine("Invalid email address.");
                continue;
            }

            if (UserRepository.Users.Any(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("This email address is already in use.");
                continue;
            }

            break;
        }


        string phone;
        while (true)
        {
            Console.Write("Please enter your mobile phone number: ");
            phone = Console.ReadLine();

            if (phone.Length == 10 && phone.StartsWith("0") && phone.All(char.IsDigit))
                break;

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
            Console.Write("Please enter a password: ");
            password = Console.ReadLine();

            if (!IsValidPassword(password))
            {
                Console.WriteLine("Invalid password.");
                continue;
            }

            Console.Write("Please confirm your password: ");
            string confirm = Console.ReadLine();
            if (password != confirm)
            {
                Console.WriteLine("Passwords do not match.");
                continue;
            }
            break;
        }



        switch (userType)
    {
        case "Customer":
            string customerLocation;
            while (true)
            {
                Console.Write("Please enter your location (in the form of X,Y): ");
                customerLocation = Console.ReadLine();
                if (Regex.IsMatch(customerLocation, @"^-?\d+,-?\d+$"))
                    break;
                Console.WriteLine("Invalid location.");
            }

            var customer = new Customer(name, age, email, phone, password, customerLocation);
            UserRepository.Users.Add(customer);

            Console.WriteLine($"You have been successfully registered as a customer, {name}!");
            break;

        case "Deliverer":
            string licencePlate;
            while (true)
            {
                Console.Write("Please enter your licence plate: ");
                licencePlate = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(licencePlate) && Regex.IsMatch(licencePlate, @"^[A-Z0-9 ]{1,8}$") && licencePlate.Trim().Length > 0)
                    break;
                Console.WriteLine("Invalid licence plate.");
            }

            var deliverer = new Deliverer(name, age, email, phone, password, licencePlate);
            UserRepository.Users.Add(deliverer);

            Console.WriteLine($"You have been successfully registered as a deliverer, {name}!");
            break;

        case "Client":
            string restaurantName;
            while (true)
            {
                Console.Write("Please enter your restaurant's name: ");
                restaurantName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(restaurantName)) break;
                Console.WriteLine("Invalid restaurant name.");
            }

            int style;
            Console.WriteLine("Please select your restaurant's style:");
            Console.WriteLine("1: Italian");
            Console.WriteLine("2: French");
            Console.WriteLine("3: Chinese");
            Console.WriteLine("4: Japanese");
            Console.WriteLine("5: American");
            Console.WriteLine("6: Australian");
            Console.Write("Please enter a choice between 1 and 6: ");
            while (true)
            {
                string styleInput = Console.ReadLine();
                if (int.TryParse(styleInput, out style) && style >= 1 && style <= 6) break;
                Console.WriteLine("Invalid choice.");
                Console.Write("Please enter a choice between 1 and 6: ");
            }

            string clientLocation;
            while (true)
            {
                Console.Write("Please enter your location (in the form of X,Y): ");
                clientLocation = Console.ReadLine();
                if (Regex.IsMatch(clientLocation, @"^-?\d+,-?\d+$")) break;
                Console.WriteLine("Invalid location.");
            }

            var client = new Client(name, age, email, phone, password, restaurantName, style, clientLocation);
            UserRepository.Users.Add(client);

            Console.WriteLine($"You have been successfully registered as a client, {name}!");
            break;
    }

        Console.WriteLine("You can now log in with your new account.");
        Console.WriteLine();

    }

    private static bool IsValidPassword(string pwd) =>
        pwd.Length >= 8 && pwd.Any(char.IsDigit) && pwd.Any(char.IsLower) && pwd.Any(char.IsUpper);
}
