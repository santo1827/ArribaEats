using System.Collections.Generic;

namespace ArribaEats.Models
{
    public class Restaurant
    {
        public string Name { get; set; }
        public string OwnerEmail { get; set; }
        public int Style { get; set; } // 1-6
        public string Location { get; set; }
        public Dictionary<string, decimal> Menu { get; set; } = new();

        public Restaurant(string name, string ownerEmail, int style, string location)
        {
            Name = name;
            OwnerEmail = ownerEmail;
            Style = style;
            Location = location;
        }
    }
}