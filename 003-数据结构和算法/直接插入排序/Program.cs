using System;

namespace 直接插入排序
{
    //直接插入排序属于稳定的排序，时间复杂性为o(n^2)，空间复杂度为O(1)。
    //直接插入排序是一个稳定的排序
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 23, 15, 27, 90, 69, 66, 158, 45, 32, 1 };
            Console.WriteLine("before insert sort");
            foreach (int i in array)
            {
                Console.Write(i + "->");
            }
            Console.WriteLine();
            InsertSort<int>(array);
            Console.WriteLine("after insert sort");
            foreach (int i in array)
            {
                Console.Write(i + "->");
            }
            Console.WriteLine();
            Console.ReadKey();
        }

        public static void InsertSort<T>(T[] array) where T : IComparable
        {
            int length = array.Length;
            for (int i = 1; i < length; i++)
            {
                T temp = array[i];
                if (temp.CompareTo(array[i - 1]) < 0)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (temp.CompareTo(array[j]) < 0)
                        {
                            temp = array[j];
                            array[j] = array[i];
                            array[i] = temp;
                        }
                    }
                }
            }
        }
    }
}
