using System;
using System.Collections.Generic;
using System.Linq;

namespace Except
{
    //https://www.cnblogs.com/sdner/p/8390732.html
    class Program
    {
        static void Main(string[] args)
        {
            List<int> allItem = new List<int>();
            allItem.Add(1);
            allItem.Add(2);
            allItem.Add(3);
            allItem.Add(4);
            allItem.Add(3);
            allItem.Add(2);

            List<int> removedItems = new List<int>();
            removedItems.Add(1);
            removedItems.Add(2);

            var result = allItem.Except(removedItems).ToList(); //把一个列表中，去除另外一个列表的元素，C#提供了很好的方法，Except。 剩下元素中的重复的项也去除了

            Console.WriteLine("count：" + allItem.Count);

            Console.WriteLine("items：");

            foreach (int item in result)
            {
                Console.WriteLine(item);
            }


            result = removedItems.Except(allItem).ToList();
            Console.WriteLine("count2：" + removedItems.Count);

            Console.WriteLine("items2：");

            foreach (int item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
