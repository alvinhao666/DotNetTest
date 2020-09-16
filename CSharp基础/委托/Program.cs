using System;

namespace 委托
{
    //委托从字面上理解就是一种代理，类似于房屋中介，由租房人委托中介为其租赁房屋。

    //在 C# 语言中，委托则委托某个方法来实现具体的功能。

    //从数据结构来讲，委托是和类一样是一种用户自定义类型。

    //委托分为命名方法委托、多播委托、匿名委托，其中命名方法委托是使用最多的一种委托。

    //多播委托是指在一个委托中注册多个方法，在注册方法时可以在委托中使用加号运算符或者减号运算符来实现添加或撤销方法。

    class Program
    {
        public delegate void AreaDelegate(double length, double width);

        public delegate void MyDelegate();
        static void Main(string[] args)
        {
            Console.WriteLine("请输入长方形的长：");
            double length = double.Parse(Console.ReadLine());
            Console.WriteLine("请输入长方形的宽：");
            double width = double.Parse(Console.ReadLine()); 

            AreaDelegate areaDelegate = new AreaDelegate(Handle);

            areaDelegate(length, width);

            AreaDelegate areaDelegate2 = delegate (double a,double b)  //匿名委托
            {
                Console.WriteLine("长方形的面积为：" + a * b);
            };

            areaDelegate2(length, width);

            AreaDelegate areaDelegate3 = (double a, double b) =>  //Lambda表达式  Lambda表达式主要用来简化匿名方法的语法
            {
                Console.WriteLine("长方形的面积为：" + a * b);
            };

            areaDelegate3(length, width);

            AreaDelegate areaDelegate4 = (a,b) =>  //简写的Lambda表达式
            {
                Console.WriteLine("长方形的面积为：" + a * b);
            };

            areaDelegate4(length, width);


            MyDelegate myDelegate = new MyDelegate(SayHello);  //命名方法委托
        }

        public static void Handle(double length, double width)
        {
            Console.WriteLine("长方形的面积为：" + length * width);
        }

        public static void SayHello()
        {
            Console.WriteLine("Hello Delegate!");
        }
    }
}
