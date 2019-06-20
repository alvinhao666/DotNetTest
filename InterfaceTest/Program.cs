using System;

namespace InterfaceTest
{
    class Program
    {
        static void Main(string[] args)
        {

            IPerson p1 = new Person1();

            IPerson p2 = new Person2();

            var t = p1.GetType();
            Console.WriteLine(t.GetFields()[0]); //Fields字段
            Console.WriteLine(t.GetProperties()[0]);
            Console.WriteLine(t.GetNestedTypes()[0]);
            Console.WriteLine(t.IsGenericType);
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
        public int Name;//Fields字段
        public int PersonType { get; set; }
        

        public class Classes
        {
            public string Name { get; set; }
        }
    }

    public class Person2 : IPerson
    {
        public int PersonType { get; set; }
    }
}
