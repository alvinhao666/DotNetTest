using System;
using System.Linq;

namespace SelectAndSelectMany
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = { "Albert was here", "Burke slept late", "Connor is happy" };
            var tokens = text.Select(s => s.Split(" "));
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (string[] line in tokens)
            {
                foreach (string token in line)
                {
                    Console.WriteLine("{0}", token);
                }
            }


            string[] text2 = { "Albert was here", "Burke slept late", "Connor is happy" };
            Console.ForegroundColor = ConsoleColor.Red;
            var tokens2 = text2.SelectMany(s => s.Split(' '));
            foreach (string token in tokens2)
            {
                Console.WriteLine("{0}", token);
            }
            Console.ReadKey();
        }
    }
}
