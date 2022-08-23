using Mapster;
using System;


namespace MapsterTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new User { Name = "张三", Age = 10 };

            var input = new User { Name = "张三3", Age = 11 };


            var user2 = input.Adapt(user);


            Console.WriteLine(user.Name + "  " + user.Age);

            Console.WriteLine(user2.Name + "  " + user2.Age);

            Console.WriteLine(user2 == user);

            var userNew = user.Adapt<User>();

            Console.WriteLine(userNew == user);

            Console.ReadKey();
        }
    }


    public class User
    {
        public string Name { get; set; }


        public string Password { get; set; }


        public int Age { get; set; }
    }
}
