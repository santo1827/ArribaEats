using ArribaEats.Models;

namespace ArribaEats.Models
{
    public class Deliverer : User
    {
        public string LicencePlate { get; }
        public Order? CurrentOrder { get; set; }

        public Deliverer(string name, byte age, string email, string phoneNumber, string password, string licencePlate)
            : base(name, age, email, phoneNumber, password)
        {
            LicencePlate = licencePlate;
            CurrentOrder = null;
        }

        public override string UserType => "Deliverer";
    }
}
