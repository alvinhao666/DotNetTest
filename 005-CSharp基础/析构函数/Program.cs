using System;

namespace 析构函数
{
    //    C#如何立即回收内存

    //1.把对象赋值为null

    //2.立即调用GC.Collect();

    //注意：这个也只是强制垃圾回收器去回收，但具体什么时候执行不确定。
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now + "     初始化对象");
            Person p1 = new Person() { Name = "张三" };
            Person p2 = new Person() { Name = "李四" };
            Person p3 = new Person() { Name = "王五" };
            p1 = null;
            p2 = null;
            //手动调用GC垃圾回收
            Console.WriteLine("手动触发垃圾回收");
            GC.Collect(); //释放内存操作，是异步执行的
            GC.WaitForPendingFinalizers();
            //Console.ReadKey();

            var tmp = p3;


            AA aa1 = new AA("1");
            AA aa2 = new AA("2");
            AA aa3 = new AA("3");
            aa1 = null;
            aa2 = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            var tmp1 = aa3;

            Console.ReadKey();
        }
    }


    public class Person
    {
        public string Name { get; set; }

        ~Person()
        {
            Console.WriteLine(DateTime.Now + $"     {Name}析构函数被调用");
        }

        //public void Dispose()
        //{
        //    Console.WriteLine(DateTime.Now + "     Dispose函数被调用");
        //    Dispose();
        //}
    }

    public class AA
    {
        public string id = "";
        public AA(string s)
        {
            id = s;
            Console.WriteLine("对象AA_" + s + "被创建了");
        }
        ~AA()
        {
            Console.WriteLine(id + " 析构函数被执行了");
        }
    }
}
