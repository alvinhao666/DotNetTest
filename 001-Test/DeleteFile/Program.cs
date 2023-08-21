using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleteFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileInfo file = new FileInfo(@"C:\Users\rongguohao\Desktop\Test"); //文件夹

            file.Attributes = FileAttributes.Directory;

            DeleteAPI.Delete(@"C:\Users\rongguohao\Desktop\Test");

            Console.WriteLine("结束");

            Console.ReadKey();
        }
    }
}
