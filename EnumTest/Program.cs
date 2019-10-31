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
            var sss = s.type.ToString();
            s.type = (Type)4;
            Console.WriteLine(string.Format("{0} {1}", s.type, ss.type));

            Type? sa = null;
            Console.WriteLine(1);
            Console.WriteLine(sa.GetValueOrDefault()); //getvalueordefault

            Console.ReadKey();
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
