using System.Collections.Generic;
using System.Linq;
using ArribaEats.Models;

namespace ArribaEats.Repositories
{
    public static class UserRepository
    {
        private static List<User> users = new List<User>();

        public static void Add(User user) => users.Add(user);

        public static User GetByEmail(string email) =>
            users.FirstOrDefault(u => u.Email.Equals(email, System.StringComparison.OrdinalIgnoreCase));

        public static bool EmailExists(string email) =>
            users.Any(u => u.Email.Equals(email, System.StringComparison.OrdinalIgnoreCase));

        public static IEnumerable<User> AllUsers => users;
    }
}