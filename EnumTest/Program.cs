using Sino.CapacityCloud.Core;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace EnumTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new List<User>() { new User() { type = Type.typeX } };

            Type d = (Type)4;

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

            //FieldInfo[] fields = typeof(VehicleClassDetail).GetFields();
            //for (int i = 0; i < fields.Length; i++)
            //{
            //    if (i > 0)
            //        Console.WriteLine(fields[i] + "--->" + (int)fields[i].GetValue(null));
            //    else
            //        Console.WriteLine(fields[i]);
            //}


            System.Array values = System.Enum.GetValues(typeof(VehicleClassDetail));
            foreach (var value in values)
            {
                Console.WriteLine(value + "--" + (int)value);//获取名称和值
            }

            //Type? ssss = null;

            //int i = (int)ssss;

            CarType result;
            Console.WriteLine(Enum.TryParse("C1", out result)); //true
            Console.WriteLine(Enum.TryParse("C5", out result)); //false
            Console.WriteLine(Enum.TryParse("0", out result)); //true
            Console.WriteLine(Enum.TryParse("10", out result)); //true

            Console.WriteLine(Enum.IsDefined(typeof(CarType), "C1")); //true
            Console.WriteLine(Enum.IsDefined(typeof(CarType), "0")); //false
            Console.WriteLine(Enum.IsDefined(typeof(CarType), 0)); //true
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


    public enum CarType
    { 
        C1,
        C2,
        C3
    }
}
