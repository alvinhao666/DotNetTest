using System;

namespace String
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "aaaa";

            string s2 = s1;

            Console.WriteLine("s1:" + s1);

            Console.WriteLine("s2:" + s2);

            s1 = "bbbb";

            Console.WriteLine("s1:" + s1);

            Console.WriteLine("s2:" + s2);

        }

        //输出结果：

        //s1: aaaa

        //s2: aaaa

        //s1: bbbb

        //s2: aaaa

        //改变s1的值对s2没有影响，这与引用类型的操作相反，当用"aaaa"初始化s1时，就在堆上分配了一个新的string对象。在初始化s2时，引用也指向这个对象，所以s2的值也是"aaaa"，
        // 但是当改变s1的值时，并不会替换原来的值，堆上会为新值分配一个新的string对象，s2扔指向原来的对象，所以它的值没有变。这实际上是运算符重载的结果。
    }


}
