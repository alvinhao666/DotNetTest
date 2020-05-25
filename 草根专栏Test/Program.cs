using System;

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


            Console.ReadKey();
        }
    }


    public class Point { public int X, Y; }

}
