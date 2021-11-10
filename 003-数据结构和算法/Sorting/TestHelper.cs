using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class TestHelper
    {
        // 生成有n个元素的随机数组,每个元素的随机范围为[0, maxValue]
        public static int[] RandomArray(int n, int maxValue)
        {
            Random r = new Random();
            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
                arr[i] = r.Next(maxValue + 1);

            return arr;
        }

        //生成有n个元素的近乎有序数组
        public static int[] NearlyOrderedArray(int n, int swapTimes)
        {

            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
                arr[i] = i;

            Random r = new Random();

            for (int i = 0; i < swapTimes; i++)
            {
                int a = r.Next(n + 1);
                int b = r.Next(n + 1);

                int t = arr[a];
                arr[a] = arr[b];
                arr[b] = t;
            }

            return arr;
        }

        // 判断arr数组是否有序(从小到大)
        private static void IsSorted(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
                if (arr[i] > arr[i + 1])
                    throw new ArgumentException("排序失败");
        }

        //拷贝arr数组的所有内容得到相同的数组并返回
        public static int[] CopyArray(int[] arr)
        {
            int n = arr.Length;
            int[] temp = new int[n];

            for (int i = 0; i < n; i++)
                temp[i] = arr[i];

            return temp;
        }

        // 测试sortClassName所对应的排序算法排序arr数组所得到结果的正确性和算法运行时间
        public static void TestSort(string sortClassName, int[] arr)
        {
            Type type = Type.GetType("Sorting." + sortClassName);
            MethodInfo sortMethod = type.GetMethod("Sort");
            object[] paramsarr = new object[] { arr };
            Stopwatch sw = new Stopwatch();
            sw.Start();
            sortMethod.Invoke(null, paramsarr);
            sw.Stop();
            IsSorted(arr);
            Console.WriteLine(type.Name + " : " + sw.ElapsedMilliseconds + "ms");
        }

        //打印数组
        public static void Show(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }

    }
}
