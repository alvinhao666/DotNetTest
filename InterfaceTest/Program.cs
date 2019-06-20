using System;

namespace InterfaceTest
{
    class Program
    {
        static void Main(string[] args)
        {

            IPerson p1 = new Person1();

            IPerson p2 = new Person2();

            Console.WriteLine(p1.GetType().Name);
            Console.WriteLine(p2.GetType().FullName);

            Console.ReadKey();
        }
    }


    public interface IPerson
    {
        int PersonType { get; set; }
    }

    public class Person1 : IPerson
    {
        public int PersonType { get; set; }
    }

    public class Person2 : IPerson
    {
        public int PersonType { get; set; }
    }
}
