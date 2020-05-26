using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace 草根专栏Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Point[] aPoint = new Point[1000];
            //int aX = aPoint[500].X; //抛出nullexception

            Console.WriteLine(-1.0 / 0.0); // -Infinity 负无穷
            Console.WriteLine(1.0 / 0.0); // double.PositiveInfinity 正无穷

            var c = 1E06; // c是int类型（错误）
            Console.WriteLine(c);
            Console.WriteLine(c.GetType()); //c是double类型


            var d = 0b1100_0101;
            Console.WriteLine(d);
            Console.WriteLine(d.GetType()); //int类型

            Console.WriteLine(object.Equals(0.0 / 0.0, double.NaN)); // true

            //在浮点数计算中，0除以0将得到NaN，正数除以0将得到PositiveInfinity,负数除以0将得到NegativeInfinity。 浮点数运算从不引发异常。

            int a = 100000001;
            float f = a;
            int b = (int)f;
            Console.WriteLine(b);  // 其中b一定等于a （错误）


            // ==操作符作用于两个操作数，其返回值一定是bool类型 （错误）

            // float f = 0.1; //这句话编译会报错（对）

            // int a = 14 / 0;在运行时会抛出divideByZeroException （错） 根本无法运行 编译阶段报错


            // decimal x = 1.234; //编译报错，无法将double类型隐式转换为decimal类型，请加后缀m

            //float 和double之间可以隐式转换 （错误）


            // 隐式转化中可以有数据损失 (错误)  隐式转换:一般是低类型向高类型转化,能够保证值不发生变化

            // C#里 ，所有关键字都是保留的 （错误） 所有的关键字在 C# 程序的任何部分都是保留标识符

            //decimal是原始类型 （错误）

            //System.Decimal是非常特殊的类型。在CLR中，Decimal类型不是基元类型。这就意味着CLR没有知道如何处理Decimal的IL指令。

            //在文档中查看Decimal类型，可以看到它提供了一系列的public static方法，包括Add、Subtract、Multiply、Divide等。此外Decimal类型还为加减乘除提供了操作符重载方法。

            //编译使用了Decimal值的程序时，编译器会生成代码来调用Decimal的成员，并通过这些成员来执行实际的运算。

            //这意味着，Decimal值的处理速度慢于CLR基元类型的值。另外，由于没有相应的IL指令来处理Decimal值，所以checked、unchecked操作符、语句以及编译器开关都失去了作用。

            //如果对Decimal值执行的运算是不安全的，肯定会抛出OverflowException异常。

            //decimal默认是开启checked 溢出检查 （对）

            //checked操作符对float和double不起作用 （对）

            //引用类型所占的内存大小等于其字段所占内存大小的总和 （错误）

            //值类型所占的内存大小等于其字段所占内存大小的总和 （对）

            // char 是值类型 （对）

            //char是System.Char的一个别名

            char[] arr = new char[100];
            Console.WriteLine(arr[25]==default(char)); //其输出为0 （错误） 
            Console.WriteLine(arr[25] == '\0');

            var x = new[] { '\u00AF', 0b0 };

            Console.WriteLine(x.GetType()); //int[]类型

            Console.WriteLine(Foo.X); //输出0


            //int num = 9;
            //object obj = num;
            //long y = (long)obj; //System.InvalidCastException:“Unable to cast object of type 'System.Int32' to type 'System.Int64'.”
            //object > long > int



            //try
            //{
            //    Console.WriteLine("Try");
            //    return;
            //}
            //finally 
            //{
            //    Console.WriteLine("Finally");
            //}
            //Console.WriteLine("Complete"); //输出try,finally

            foreach(string s in Test())
            {
                Console.WriteLine(s);
            }

            var a1 = new { X = 2, Y = 4 };
            var a2 = new { X = 2, Y = 4 };
            Console.WriteLine(a1.GetType());
            Console.WriteLine(a1.GetType() == a2.GetType()); //true
            Console.WriteLine(a1 == a2);//false


            //var dudes = new[] { 
            //    new { Name="Bob",Age=30},
            //    new { Name="Tom", Age=40,Length=4}
            //};  (错误)

            //var dudes2 = new[] {
            //    new { Name="Bob",Age=30},
            //    new { Name="Tom", Age=40}
            //};（正确）

            //Console.WriteLine(typeof(dynamic) == typeof(object)); (编译报错)
            Console.WriteLine(typeof(List<dynamic>) == typeof(List<object>)); //true
            Console.WriteLine(typeof(dynamic[]) == typeof(object[])); //true

            dynamic xx = "hello";
            Console.WriteLine(xx.GetType().Name); //String 
            xx = 123;
            Console.WriteLine(xx.GetType().Name); //Int32


            dynamic xxx = "hello";
            int i = xxx;
            Console.WriteLine(i); //编译不报错，运行报错

            Console.ReadKey();
        }


        //dynamic Test2() => new { Name = "Tom", Age = 40 };（正确）
        //var Test3() => new { Name = "Tom", Age = 40 }; （错误）

        //static IEnumerable<string> Test()  //报错
        //{
        //    yield return "1";
        //    yield return "2";
        //    return;
        //    yield return "3";
        //}

        //static IEnumerable<string> Test()
        //{
        //    try
        //    {
        //        yield return "1";
        //        yield break;
        //        yield return "2";
        //    }
        //    finally
        //    {
        //        yield return "3";  //报错 无法在finally子句体中生成
        //    }
        //    yield return "4";
        //}

        static IEnumerable<string> Test()  //输出 One,1,Two,2,Three,3
        {
            yield return "One";
            Console.WriteLine(1);
            yield return "Two";
            Console.WriteLine(2);
            yield return "Three";
            Console.WriteLine(3);
        }
    }


   public class Point { public int X, Y; }


    public class Rectangle
    {
        public readonly float Width;  // A

        public Rectangle(float width)  //B 
        {
            Width = width;
        }

        public readonly float Height; // C


        // 执行顺序 ACB


        //静态构造函数没有修饰符修饰(public,private),因为静态构造函数不是我们程序员调用的，是由.net 框架在合适的时机调用的。
        //静态构造函数没有参数，因为框架不可能知道我们需要在函数中添加什么参数，所以规定不能使用参数。
        //静态构造函数前面必须是static 关键字。如果不加这个关键字，那就是普通的构造函数了。
        //静态构造函数中不能实例化实例变量。（变量可以分为类级别和实例级别的变量，其中类级别的有static关键字修饰）。
        //静态函数的调用时机，是在类被实例化或者静态成员被调用的时候进行调用，并且是由.net框架来调用静态构造函数来初始化静态成员变量。
        //一个类中只能有一个静态构造函数。
        //无参数的静态构造函数和无参数的构造函数是可以并存的。因为他们一个属于类级别，一个属于实例级别，并不冲突。
        //静态构造函数只会被执行一次。并且是在特点5中的调用时机中进行调用。
        //就像如果没有在类中写构造函数，那么框架会为我们生成一个构造函数，那么如果我们在类中定义了静态变量，但是又没有定义静态构造函数，那么框架也会帮助我们来生成一个静态构造函数来让框架自身来调用。

        static Rectangle()
        {

        }

        //sealed 修饰方法或属性 //sealed是对虚方法或虚属性，也就是同override一起使用，如果不是虚方法或虚属性会报出错误：cannot be sealed because it is not an override
        //public sealed string GetName()
        //{
        //    return "dove";
        //}

        //当对一个类应用 sealed 修饰符时，此修饰符会阻止其他类从该类继承。类似于Java中final关键字。



        // 静态类可以有子类 （错误）
    }


    class Foo
    {
        public static int X = Y;
        public static int Y = 3;
    }
}
