using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class InsertSort
    {
        public static void Sort(int[] arr)
        {
            int n = arr.Length;

            for (int i = 1; i < n; i++)
            {
                int e = arr[i];
                int j;
                for (j = i; j > 0; j--)
                {
                    if (e < arr[j - 1])
                        arr[j] = arr[j - 1];
                    else
                        break;
                }
                arr[j] = e;
            }
        }

        //对arr[l...r]的范围使用插入排序
        public static void Sort1(int[] arr,int l,int r)
        {
            for (int i = l+1; i <= r; i++)
            {
                int e = arr[i];
                int j;
                for (j = i; j > l; j--)
                {
                    if (e < arr[j - 1])
                        arr[j] = arr[j - 1];
                    else
                        break;
                }
                arr[j] = e;
            }
        }
    }
}
