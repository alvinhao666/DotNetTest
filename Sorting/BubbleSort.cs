using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    //冒泡排序 O（n²）
    class BubbleSort
    {
        public static void Sort(int[] arr)
        {
            int n = arr.Length;

            //外层循环控制冒泡次数
            for (int i = 0; i < n; i++)
            {
                //减去i 不需要对已经排好序的元素再次进行比较
                //内层循环在数组[0...n-1-i]范围内冒泡最大值
                //j取值范围[0...n-1-i)  j+1取值范围[1...n-1-i]
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                        Swap(arr, j, j + 1);
                }
            }
        }

        //交换数组中索引i和j对应元素的位置
        private static void Swap(int[] arr,int i,int j)
        {
            int t = arr[i];
            arr[i] = arr[j];
            arr[j] = t;
        }
    }
}
