using System;

namespace String.Formate
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(string.Format("{0:D4}", 1)); //0001
            Console.WriteLine(string.Format("{0:D4}", "1")); //1

            Console.WriteLine(1223.234323423.ToString("#0.####")); //1223.2343
            Console.WriteLine(1223.2000.ToString("#0.####")); //1223.2
            Console.WriteLine(1223.0000.ToString("#0.####")); //1223
            Console.ReadKey();
        }
    }
}
