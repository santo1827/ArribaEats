using System;

namespace ArribaEats.Models
{
    public class Customer : User
    {
        public string Location { get; set; } // format "X,Y"
        public int TotalOrders { get; set; } = 0;
        public decimal TotalSpent { get; set; } = 0;

        public Customer(string name, byte age, string email, string phone, string password, string location)
            : base(name, age, email, phone, password)
        {
            Location = location;
        }

        public override string UserType => "Customer";
    }
}