using System;
using System.Text.RegularExpressions;

namespace 正则Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Regex.IsMatch("s21312", "^[a-zA-Z]+$"));

            Console.WriteLine(Regex.IsMatch("ssdf", "^[a-zA-Z0-9]+$"));
            Console.ReadKey();
        }
    }
}
