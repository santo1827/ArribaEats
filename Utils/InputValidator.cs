using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace ArribaEats.Utils
{
    public static class InputValidator
    {
        public static bool IsValidName(string name) =>
            !string.IsNullOrWhiteSpace(name) && name.All(c => char.IsLetter(c) || c == ' ' || c == '-' || c == '\'');

        public static bool IsValidAge(string input, out byte age) =>
            byte.TryParse(input, out age) && age >= 18 && age <= 100;

        public static bool IsValidEmail(string email) =>
            new EmailAddressAttribute().IsValid(email);

        public static bool IsValidPhoneNumber(string phone) =>
            Regex.IsMatch(phone, @"^0\d{9}$");

        public static bool IsValidPassword(string password) =>
            password.Length >= 8 && password.Any(char.IsDigit) && password.Any(char.IsLower) && password.Any(char.IsUpper);

        public static bool IsValidLocation(string input) =>
            Regex.IsMatch(input, @"^-?\d+,-?\d+$");

        public static bool IsValidLicencePlate(string plate) =>
            !string.IsNullOrWhiteSpace(plate) && Regex.IsMatch(plate, @"^[A-Z0-9 ]{1,8}$") && plate.Trim().Length > 0;
    }
}
