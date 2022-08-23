using System;

namespace 选择排序
{
    //选择排序是不稳定的。算法复杂度O(N²)

    //选择排序是我觉得最简单暴力的排序方式了。

    //以前刚接触排序算法的时候，感觉算法太多搞不清，唯独记得选择排序的做法及实现。

    //原理：找出参与排序的数组最大值，放到末尾（或找到最小值放到开头
    class Program
    {
        static void Main(string[] args)
        {
            int[] iArrary = new int[] { 1, 5, 3, 6, 10, 55, 9, 2, 87, 12, 34, 75, 33, 47 };
            Sort(iArrary);
            for (int m = 0; m <= 13; m++)
                Console.WriteLine("{0}", iArrary[m]);

            Console.ReadKey();
        }


        public static void Sort(int[] list)
        {
            int min;
            for (int i = 0; i < list.Length - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < list.Length; ++j)
                {
                    if (list[j] < list[min])
                        min = j;
                }
                int t = list[min];
                list[min] = list[i];
                list[i] = t;
            }
        }
    }
}
