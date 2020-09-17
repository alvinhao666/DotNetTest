using System;
using System.Collections.Generic;
using System.Text;

namespace 闭包
{
    class Program2
    {
        /// <summary>
        /// 首先是这个经典闭包示例，认为结果是0,1,2,3,4,5,6,7,8,9的统统出去抽自己10个耳光  https://zhuanlan.zhihu.com/p/31616347?from_voters_page=true
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Action[] actions = new Action[10];


            for (int i = 0; i < 10; i++)
            {
                actions[i] = () =>
                {
                    Console.WriteLine(i);
                };
            }

            foreach (var action in actions)
            {
                action();
            }

            //反编译生成的
            ////生成一个闭包对象（产生额外堆内存分配）
            //AnonymousClass anonymous = new AnonymousClass();
            ////闭包里使用到的外部变量全部替换成这个闭包对象的属性，这就是一般说的值对象装箱
            //anonymous.i = 0;
            //while (anonymous.i < 10)
            //{
            //    this.actions[anonymous.i] = new Action(anonymous.Action);
            //    int i = anonymous.i;
            //    anonymous.i = i + 1;
            //}
            //foreach (Action action in this.actions)
            //{
            //    action();
            //}

            //正常写法
            for (int i = 0; i < 10; i++)
            {
                int j = i;//不同之处就是将i先存到另一个变量中，再在闭包引用这个值
                actions[i] = () =>
                {
                    Console.WriteLine(j);
                };
            }

            foreach (var action in actions)
            {
                action();
            }

            //正常写法 反编译生成的
            //for (int i = 0; i < 10; i++)
            //{
            //    AnonymousClass anonymous = new AnonymousClass();
            //    //闭包对象每个循环都创建了一次
            //    anonymous.j = i;
            //    this.actions[i] = new Action(anonymous.Action);
            //}
            //foreach (Action action in this.actions)
            //{
            //    action();
            //}

            //虽然闭包对象还是以前的样子，但是却一共创建了10个，GC也就变成了10倍。当然，也因为这个原因能够打印出正确的结果了。
        }


        //反编译生成的类
        private sealed class AnonymousClass
        {
            public int i;

            internal void Action()
            {
                Console.WriteLine((this.i));
            }
        }
    }
}
