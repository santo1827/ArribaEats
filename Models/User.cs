using System;

namespace ArribaEats.Models
{
    public abstract class User
    {
        public string Name { get; set; }
        public byte Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        protected User(string name, byte age, string email, string phoneNumber, string password)
        {
            Name = name;
            Age = age;
            Email = email;
            PhoneNumber = phoneNumber;
            Password = password;
        }

        public abstract string UserType { get; }
    }
}