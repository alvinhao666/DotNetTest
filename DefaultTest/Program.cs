using System;
using System.Collections.Generic;

namespace DefaultTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(default(List<string>) == null);
            Console.WriteLine(default(long?) == null);

            int? a = 1;

            int? b = null;

            Console.WriteLine(a.GetValueOrDefault());
            Console.WriteLine(b.GetValueOrDefault());

            Console.WriteLine(null is Student);
            Console.ReadKey();
        }
    }

    public class Student
    {
        public string Name { get; set; }
    }
}
