using System;
using System.Collections.Generic;
using System.Linq;

namespace ListTest
{
    class Program
    {
        static void Main(string[] args)
        {
            #region List分组
            List<string> lst = new List<string>() { "1", "2", "3", "4", "5", "6" };

            List<List<string>> listGroup = new List<List<string>>();
            int j = 3;
            for (int i = 0; i < lst.Count; i += 3)
            {
                Console.WriteLine(i);
                List<string> cList = new List<string>();
                cList = lst.Take(j).Skip(i).ToList();
                j += 3;
                listGroup.Add(cList);
            }
            #endregion

            Console.ReadKey();
        }
    }
}
