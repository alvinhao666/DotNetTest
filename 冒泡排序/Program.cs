using System;

namespace 冒泡排序
{
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


        public static void Sort(int[] arr)
        {
            int temp = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                for(int j = i + 1; j < arr.Length; j++)
                {
                    if(arr[i]>arr[j])
                    {
                        temp = arr[j];
                        arr[j] = arr[i];
                        arr[i] = temp;
                    }
                }
            }
        }
    }
}
