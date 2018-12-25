using System.Collections.Generic;

namespace Core
{
    public class User
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
    }

    public class Users
    {
        public List<User> AllUsers { get; set; }
    }
}
