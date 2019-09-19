using System;

namespace 建议33_避免在泛型类型中声明静态成员
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list1 = new MyList<int>();
            MyList<int> list2 = new MyList<int>();
            MyList<string> list3 = new MyList<string>();
            Console.WriteLine(MyList<int>.Count); //2
            Console.WriteLine(MyList<string>.Count); //1

            //实际上，随着你为T指定不同的数据类型，MyList<T> 相应地也变成不同的数据类型，它们之间是不共享静态成员的。

            //若T所指定的数据类型一致，那么两个泛型对象之间还是可以共享静态成员的，如上文中的list1和list2。但是为了避免因此引起的混淆，仍旧建议在实际编码过程中，尽量避免声明泛型类型的静态成员。
            Console.ReadKey();
        }
    }

    class MyList<T>
    {
        public static int Count { get; set; }
        public MyList()
        {
            Count++;
        }
    }

}
