using System;

namespace 建议7_将0值作为枚举默认值
{
    //允许使用的枚举类型有byte、sbyte、short、ushort、int、uint、long和ulong。应该始终将0值作为枚举类型的默认值。不过，这样做不是因为允许使用的枚举类型在声明时的默认值是0值，而是有工程上的意义。
    class Program
    {   
        //那么，你一不小心编写了如下的代码，它的输出会是什么呢？
        static Week week;
        static void Main(string[] args)
        {
            Console.WriteLine(week);

            week = (Week)9;   //controller 枚举须定义可为空 即不存在这两种情况

            Console.WriteLine(week);

            Console.ReadKey();
        }
    }

    enum Week
    {
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
        Sunday = 7
    }
}
