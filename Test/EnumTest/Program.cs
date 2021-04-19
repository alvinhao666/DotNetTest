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
            var users = new List<User>() { new User() { type = UserType.typeX } };

            UserType d = (UserType)4;

            Array arrays = Enum.GetValues(typeof(UserType));
            Console.WriteLine(arrays.GetValue(0).ToString());

            User s = new User() { type = UserType.typeX };
            User ss = new User() { type = UserType.typeY };
            var sss = s.type.ToString();
            s.type = (UserType)4;
            Console.WriteLine(string.Format("{0} {1}", s.type, ss.type));

            UserType? sa = null;
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


            var car1 = Parse<CarType>("2");

            Console.WriteLine(d is Enum);

            Console.ReadKey();
        }

        /// <summary>
        /// 获取枚举实例
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <param name="member">成员名或值,范例:Enum1枚举有成员A=0,则传入"A"或"0"获取 Enum1.A</param>
        public static TEnum Parse<TEnum>(object member)
        {
            string value = member?.ToString().Trim() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(value))
            {
                if (typeof(TEnum).IsGenericType)
                    return default(TEnum);
                throw new ArgumentNullException(nameof(member));
            }
            return (TEnum)Enum.Parse(GetType(typeof(TEnum)), value, true);
        }

        /// <summary>
        /// 获取类型
        /// </summary>
        /// <param name="type">类型</param>
        public static Type GetType(Type type)
        {
            var underType = Nullable.GetUnderlyingType(type);

            return underType ?? type;
        }

    }

    public class User
    {
        public UserType type { get; set; }
    }

    public enum UserType
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
