using System;

namespace 希尔排序
{
    //希尔排序(Shell's Sort)是插入排序的一种又称“缩小增量排序”（Diminishing Increment Sort），是直接插入排序算法的一种更高效的改进版本。希尔排序是非稳定排序算法
    //最坏情况时间复杂度为：O(n^1.5),平均时间复杂度为O(nlogn)


    //平均时间复杂度从高到低依次是：

    //     冒泡排序（o(n2)），选择排序（o(n2)），插入排序（o(n2)），堆排序（o(nlogn)），

    //     归并排序（o(nlogn)），快速排序（o(nlogn)）， 希尔排序（o(n1.25)），基数排序（o(n)）
    //    这些平均时间复杂度是参照维基百科排序算法罗列的。

    //是计算的理论平均值，并不意味着你的代码实现能达到这样的程度。

    //例如希尔排序，时间复杂度是由选择的步长决定的。基数排序时间复杂度最小，

    //但我实现的基数排序的速度并不是最快的，后面的结果测试图可以看
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
            int a;
            for (a = 1; a <= list.Length / 9; a = 3 * a + 1) ;
            for (; a > 0; a /= 3)
            {
                for (int i = a + 1; i <= list.Length; i += a)
                {
                    int t = list[i - 1];
                    int j = i;
                    while ((j > a) && (list[j - a - 1] > t))
                    {
                        list[j - 1] = list[j - a - 1];
                        j -= a;
                    }
                    list[j - 1] = t;
                }
            }
        }
    }
}
