using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class UserStorage
    {
        public static List<User> Users = new List<User>()
        {
            new User{ account = "DuyLong", password = "123"}
        };
    }
    public class User
    {
        public string account { get; set; }
        public string password { get; set; }
    }
}
