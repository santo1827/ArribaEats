namespace ArribaEats.Models
{
    public class Customer : User
    {
        public string Location { get; }
        public int OrdersPlaced { get; set; }
        public decimal TotalSpent { get; set; }

        public Customer(string name, byte age, string email, string phoneNumber, string password, string location)
            : base(name, age, email, phoneNumber, password)
        {
            Location = location;
        }

        public override string UserType => "Customer";
    }
}
