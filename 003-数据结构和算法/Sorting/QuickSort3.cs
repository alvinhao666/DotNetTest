using System;

namespace Sorting
{
    //三向切分的快速排序
    public class QuickSort3
    {
        private static Random rd = new Random();

        public static void Sort(int[] arr)
        {
            int n = arr.Length;
            Sort(arr, 0, n - 1);
        }

        private static void Sort(int[] arr, int l, int r)
        {
            //对小规模的数组使用插入排序，避免频繁的递归调用
            if (r - l + 1 <= 15)
            {
                InsertSort.Sort1(arr, l, r);
                return;
            }

            //随机化处理，对排序有序性很强的数组会得到很大的优化
            int p = l + rd.Next(r - l + 1);

            Swap(arr, l, p);

            int v = arr[l];    //标定元素v

            int lt = l;        // arr[l+1...lt] < v
            int gt = r + 1;    // arr[gt...r] > v
            int i = l + 1;     // arr[lt+1...i-1] == v

            //往三个区间填充元素
            while (i < gt)
            {
                if (arr[i] < v)
                {
                    lt++;
                    Swap(arr, i, lt);
                    i++;
                }
                else if (arr[i] > v)
                {
                    gt--;
                    Swap(arr, i, gt);
                }
                else //arr[i]==v
                {
                    i++;
                }
            }

            //跳出while循环填充完毕后，把标定元素放到合适位置
            Swap(arr, l, lt);

            Sort(arr, l, lt - 1);  //将左半部分arr[l...lt-1]排序
            Sort(arr, gt, r);      //将右半部分arr[gt...r]排序

        }

        private static void Swap(int[] arr, int i, int j)
        {
            int e = arr[i];
            arr[i] = arr[j];
            arr[j] = e;
        }
    }
}
