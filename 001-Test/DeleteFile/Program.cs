using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleteFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileOperateProxy.Delete(@"C:\Users\rongguohao\Desktop\a.txt");

            Console.ReadKey();
        }
    }
}
