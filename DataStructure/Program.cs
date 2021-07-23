using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sorting;

namespace DataStructure
{
    class Program
    {
        //在100W个元素中，找出最小的前十个元素。（Top M）
        static void Main(string[] args)
        {
            //第一种：排序算法
            int[] a = TestSearch.ReadFile("测试文件3/TopM.txt");
            QuickSort3.Sort(a);
            for (int i = 0; i < 10; i++)
                Console.Write(a[i]+", ");

            Console.WriteLine();

            //第二种：优先队列
            MaxPQ<int> pq = new MaxPQ<int>(10);
            FileStream fs = new FileStream("测试文件3/TopM.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            while (!sr.EndOfStream)
            {
                int value = int.Parse(sr.ReadLine());
                if (pq.Count < 10)
                    pq.Enqueue(value);
                else if(value < pq.Peek())
                {
                    pq.Dequeue();
                    pq.Enqueue(value);
                }
            }
            Console.WriteLine(pq);

            //同理也可以使用最小优先队列。找出最大的前十个元素。
            //最小优先队列和最大优先队列都是C#中没有提供，但是却很实用的数据结构。


            Console.Read();

        }

    }
}
