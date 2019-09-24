using System;
using System.IO;
using System.Net;

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
            Console.ReadKey();
        }
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