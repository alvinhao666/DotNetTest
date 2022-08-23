using System;

namespace 建议8_避免给枚举类型的元素提供显式的值
{

    //很遗憾，我们明明为Week赋值为ValueTemp，可是得到的结果却是Wednesday。

    //事实上，如果为枚举类型显式地赋过值，那么很有可能在下个版本中，你为了某些增加的需要，会为枚举添加元素，在这个时候，就像我们为Week增加元素ValueTemp一样，极有可能会一不小心增加一个无效值。

    //上一个建议中已经讲到如果没有为元素显式赋值，编译器会逐个为元素的值+1。当编译器发现元素ValueTemp的时候，它会自动在Tuesday = 2的基础上+1，所以，实际ValueTemp的值和Wednesday的值都是3。
    class Program
    {
        static void Main(string[] args)
        {
            Week week = Week.ValueTemp;
            Console.WriteLine(week);
            Console.WriteLine(week == Week.Wednesday);
        }
    }


    enum Week
    {
        Monday = 1,
        Tuesday = 2,
        ValueTemp,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
        Sunday = 7
    }

}
