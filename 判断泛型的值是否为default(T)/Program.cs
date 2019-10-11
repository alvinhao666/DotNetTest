using System;
using System.Collections.Generic;

namespace 判断泛型的值是否为default_T_
{
    //    如果用==直接判断(default(T) == value)，编译时会提示错误：Error CS0019: 运算符“==”无法应用于“T”和“T”类型的操作数 (CS0019)。

  //      2. object.Equals的问题

  //  object提供了一个静态方法，可用于比较两个对象是否相等：

  //public static bool Equals(object objA, object objB)
  //{
  //    if (objA == objB)
  //    {
  //        return true;
  //    }
  //    if (objA == null || objB == null)
  //    {
  //        return false;
  //    }
  //    return objA.Equals(objB);
  //}

  // 但是该方法接收的是引用类型的实例，如果传入的是值类型(譬如int、enum、struct等)，则会对值类型进行装箱(boxing)。
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }


    }

    public static class Extensions
    {
        public static bool IsDefault<T>(this T value)
        {
            return EqualityComparer<T>.Default.Equals(value, default(T));
        }
    }
}
