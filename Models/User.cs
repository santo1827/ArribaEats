namespace ArribaEats.Models
{
    public abstract class User
    {
        public string Name { get; }
        public byte Age { get; }
        public string Email { get; }
        public string PhoneNumber { get; }
        public string Password { get; }

        public User(string name, byte age, string email, string phoneNumber, string password)
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
