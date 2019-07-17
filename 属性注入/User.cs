using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace 属性注入
{

    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int enabled { get; set; }
    }

    public interface IUserService
    {
        IList<User> GetUsers();
    }

    public class UserService : IUserService
    {
        public IList<User> GetUsers()
        {
            return new List<User>
            {
                new User
                {
                    id = 1,
                    username = "fanqi",
                    password = "admin",
                    enabled = 1
                }
            };
        }
    }
}
