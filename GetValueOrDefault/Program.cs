using System;

namespace GetValueOrDefault
{
    class Program
    {
        static void Main(string[] args)
        {
            int? a = 1;

            int? b = null;

            Console.WriteLine(a.GetValueOrDefault());
            Console.WriteLine(b.GetValueOrDefault());
            Console.ReadKey();
        }
    }
}
