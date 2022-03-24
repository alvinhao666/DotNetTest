using System;

namespace TypeTest
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(typeof(int)); //System.Int32
            Console.WriteLine(typeof(int?)); //System.Nullable`1[System.Int32]

            Console.WriteLine(typeof(int).Namespace); //System
            Console.WriteLine(typeof(int?).Namespace); //System
            Console.WriteLine(typeof(int).Name); //Int32
            Console.WriteLine(typeof(int?).Name); //Nullable`1

            Console.WriteLine(typeof(uint));//System.UInt32
            Console.WriteLine(typeof(uint?));//System.Nullable`1[System.UInt32]

            Console.WriteLine(typeof(uint).Name); //UInt32
            Console.WriteLine(typeof(uint?).Name); //Nullable`1

            Console.WriteLine(typeof(string));

            var p1 = new Person { Name = "1" };

            var p2 = new Person { Name = "2" };

            Console.WriteLine(p1.GetType().GetHashCode());
            Console.WriteLine(p2.GetType().GetHashCode());

            Console.ReadKey();

        }
    }



    public class Person
    {
        public string Name { get; set; }
    }
}
