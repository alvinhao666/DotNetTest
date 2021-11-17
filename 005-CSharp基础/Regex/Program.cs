using System;
using System.Text.RegularExpressions;

namespace RegexDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var str= Regex.Split("ffgdsGSDF".ToString(), "G", RegexOptions.IgnoreCase);//忽略大小写
            Console.WriteLine(str[0]);
            Console.ReadKey();
        }
    }
}
