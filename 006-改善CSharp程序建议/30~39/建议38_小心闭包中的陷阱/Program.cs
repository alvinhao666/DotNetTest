using System;
using System.Collections.Generic;

namespace 建议38_小心闭包中的陷阱
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Action> lists = new List<Action>();
            for (int i = 0; i < 5; i++)
            {
                Action t = () =>
                {
                    Console.WriteLine(i.ToString());
                };
                lists.Add(t);

                //int temp = i;
                //Action t = () =>
                //{
                //    Console.WriteLine(temp.ToString());
                //};
                //lists.Add(t);
            }
            foreach (Action t in lists)
            {
                t();
            }
            Console.ReadKey();
        }

        //这段代码演示的就是闭包对象
        //static void Main(string[] args)
        //{
        //    List<Action> lists = new List<Action>();
        //    TempClass tempClass = new TempClass();
        //    for (tempClass.i = 0; tempClass.i < 5; tempClass.i++)
        //    {
        //        Action t = tempClass.TempFuc;
        //        lists.Add(t);
        //    }
        //    foreach (Action t in lists)
        //    {
        //        t();
        //    }
        //}

        //class TempClass
        //{
        //    public int i;
        //    public void TempFuc()
        //    {
        //        Console.WriteLine(i.ToString());
        //    }
        //}
    }
}
