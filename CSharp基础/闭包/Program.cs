using System;

namespace 闭包
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(GetClosureFunction()(30)); //30+ 30 60
        }

        static Func<int, int> GetClosureFunction()
        {
            int val = 10;
            Func<int, int> internalAdd = x => x + val;

            Console.WriteLine(internalAdd(10)); // 10 +10 20

            val = 30;
            Console.WriteLine(internalAdd(10)); //10 +30  40

            return internalAdd;
        }
    }

     //上述代码的执行流程是Main函数调用GetClosureFunction函数，GetClosureFunction返回了委托internalAdd并被立即执行了。
     
     //输出结果依次为20、40、60
     
     //对应到一开始提出的闭包的概念。这个委托internalAdd就是一个闭包，引用了外部函数GetClosureFunction作用域中的变量val。
     
     //注意：internalAdd有没有被当做返回值和闭包的定义无关。就算它没有被返回到外部，它依旧是个闭包。
}
