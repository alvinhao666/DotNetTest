using System;

namespace Dynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Sample
    {
        public string Name { get; set; }

        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}