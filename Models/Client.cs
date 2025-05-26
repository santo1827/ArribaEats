namespace ArribaEats.Models
{
    public class Client : User
    {
        public string RestaurantName { get; }
        public int Style { get; }
        public string Location { get; }

        public Client(string name, byte age, string email, string phoneNumber, string password,
                      string restaurantName, int style, string location)
            : base(name, age, email, phoneNumber, password)
        {
            RestaurantName = restaurantName;
            Style = style;
            Location = location;
        }

        public override string UserType => "Client";
    }
}
