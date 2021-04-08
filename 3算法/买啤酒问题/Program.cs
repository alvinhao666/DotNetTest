using System;

namespace 买啤酒问题
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://www.jianshu.com/p/721fd3250ee7
            int money = 10; //钱的数目
            int bottle = 0;  //当前的瓶子数
            int bottleGap = 0; //当前的瓶盖数
            int count = 0; //喝酒的瓶数
            while (money >= 2 || bottle >= 2 || bottleGap >= 4)
            {
                if (bottleGap >= 4)
                {
                    bottleGap -= 4;
                    bottle += 1;
                    bottleGap += 1;
                    count += 1;
                    Print(count, money, bottle, bottleGap);
                    continue;
                }
                if (bottle >= 2)
                {
                    bottle -= 2;
                    bottle += 1;
                    bottleGap += 1;
                    count += 1;
                    Print(count, money, bottle, bottleGap);
                    continue;
                }
                if (money >= 2)
                {
                    money -= 2;
                    bottle += 1;
                    bottleGap += 1;
                    count += 1;
                    Print(count, money, bottle, bottleGap);
                    continue;
                }
            }
            Print(count, money, bottle, bottleGap);
            Console.Read();
        }

        public static void Print(int count, int money, int bottle, int bottleGap)
        {
            Console.WriteLine("瓶数：" + count + "  钱数：" + money + "   瓶子数目：" + bottle + "  盖子数：" + bottleGap);
        }
    }
}
