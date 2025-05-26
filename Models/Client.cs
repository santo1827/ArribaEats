namespace ArribaEats.Models
{
    public class Client : User
    {
        public string RestaurantName { get; set; }
        public int Style { get; set; } // 1-6
        public string Location { get; set; }

        public Client(string name, byte age, string email, string phone, string password,
                       string restaurantName, int style, string location)
            : base(name, age, email, phone, password)
        {
            RestaurantName = restaurantName;
            Style = style;
            Location = location;
        }

        public override string UserType => "Client";
    }
}