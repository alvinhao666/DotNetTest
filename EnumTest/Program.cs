using System;
using System.Collections.Generic;

namespace EnumTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new List<User>() { new User() { type = Type.typeX } };

            int d = (int)Type.typeY;

            Array arrays = Enum.GetValues(typeof(Type));
            Console.WriteLine(arrays.GetValue(0).ToString());

            User s = new User() { type = Type.typeX };
            User ss = new User() { type = Type.typeY };
            Console.WriteLine(string.Format("{0} {1}", s.type, ss.type));
        }
    }

    public class User
    {
        public Type type { get; set; }
    }

    public enum Type
    {
        typeX,
        typeY
    }
}
