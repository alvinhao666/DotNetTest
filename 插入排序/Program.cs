using System;

namespace 插入排序
{
    class Program
    {
        //插入排序是把无序列的数一个一个插入到有序的数
        //插入排序的基本操作就是将一个数据插入到已经排好序的有序数据中，从而得到一个新的、个数加一的有序数据，算法适用于少量数据的排序，时间复杂度为O(n^2)。是稳定的排序方法。
        static void Main(string[] args)
        {
            int[] iArrary = new int[] { 3, 5, 1, 6, 10, 55, 9, 2, 87, 12, 34, 75, 33, 47 };
            Sort(iArrary);
            for (int m = 0; m <= 13; m++)
                Console.WriteLine("{0}", iArrary[m]);
            Console.ReadKey();
        }

        public static void Sort(int[] arr)
        {

            //先默认下标为0这个数已经是有序
            for (int i = 1; i < arr.Length; i++)
            {
                int insertVal = arr[i];  //首先记住这个预备要插入的数
                int insertIndex = i - 1; //找出它前一个数的下标（等下 准备插入的数 要跟这个数做比较）

                //如果这个条件满足，说明，我们还没有找到适当的位置
                while (insertIndex >= 0 && insertVal < arr[insertIndex])   //这里小于是升序，大于是降序
                {
                    arr[insertIndex + 1] = arr[insertIndex];   //同时把比插入数要大的数往后移
                    insertIndex--;      //指针继续往后移，等下插入的数也要跟这个指针指向的数做比较         
                }
                //插入(这时候给insertVal找到适当位置)
                arr[insertIndex + 1] = insertVal;
            }
        }
    }
}
