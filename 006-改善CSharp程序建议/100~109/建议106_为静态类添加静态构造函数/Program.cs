using System;
using System.IO;

namespace 建议106_为静态类添加静态构造函数
{

    //    静态类可以拥有构造方法，这就是静态构造方法。静态构造方法与实例构造方法比较有几个自己的特点：
    //
    //    只被执行一次，且在第一次调用类成员之前被运行时执行。
    //    代码无法调用它，不像实例构造方法使用new关键字就可以被执行。
    //    没有访问标识符。
    //    不能带任何参数。
    //
    //    使用静态构造方法的好处是，可以初始化静态成员并捕获在这过程中发生的异常。而使用静态成员初始化器则不能在类型内部捕获异常了。查看下面代码：
    class Program
    {
        static void Main(string[] args)
        {
            SampleClass.SampleMethod();

            var user1 = new User() { Name = "张三" };
            User.Value = 2;
            //user1.
            //静态变量只能通过“类.静态变量名”调用，类的实例不能调用；
            //            被 static 关键字修饰的字段，叫做“静态字段”。
            //静态字段不属于任何对象，只属于类，必须要用 类名.静态字段名 进行访问，反过来通过 对象名.静态字段名 的方式是访问不到静态字段的。

            //            被 static 关键字修饰的属性，叫做“静态属性”。
            //静态属性用于对静态字段进行封装，并保证静态字段值的合法性；
            //静态属性使用 类名.静态属性名 进行访问；

            var user2 = new User() { Name = "王五" };

            Console.ReadKey();
        }
    }

    public class User
    {
        public static int Value { get; set; } = 1;


        public static int Value2 = 1;


        public string Name { get; set; }
    }


    static class SampleClass
    {
        private static FileStream fileStream = File.Open(@"c:\temp.txt", FileMode.Open);

        public static void SampleMethod()
        {
        }
    }

    static class SampleClassNew
    {
        private static FileStream fileStream;

        static SampleClassNew()
        {
            try
            {
                fileStream = File.Open(@"c:\temp.txt", FileMode.Open);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //异常处理
            }
        }

        public static void SampleMethod() { }
    }
}