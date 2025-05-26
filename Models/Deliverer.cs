using ArribaEats.Models;

namespace ArribaEats.Models
{
    public class Deliverer : User
    {
        public string LicencePlate { get; set; }
        public int? CurrentOrderNumber { get; set; } = null;

        public Deliverer(string name, byte age, string email, string phone, string password, string licencePlate)
            : base(name, age, email, phone, password)
        {
            LicencePlate = licencePlate;
        }

        public override string UserType => "Deliverer";
    }
}
