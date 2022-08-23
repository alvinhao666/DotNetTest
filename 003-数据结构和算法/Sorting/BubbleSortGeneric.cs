using System;

namespace Sorting
{
    class BubbleSortGeneric
    {
        public static void Sort<E>(E[] arr) where E : IComparable<E>
        {
            int n = arr.Length;

            //外层循环控制冒泡次数
            for (int i = 0; i < n; i++)
            {
                //减去i 不需要对已经排好序的元素再次进行比较
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (arr[j].CompareTo(arr[j + 1]) > 0)
                        Swap(arr, j, j + 1);
                }
            }
        }

        private static void Swap<E>(E[] arr, int i, int j)
        {
            E t = arr[i];
            arr[i] = arr[j];
            arr[j] = t;
        }
    }
}
