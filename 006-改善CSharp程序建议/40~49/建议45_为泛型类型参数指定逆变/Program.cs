using System;

namespace 建议45_为泛型类型参数指定逆变
{
    class Program
    {
        static void Main(string[] args)
        {
            Programmer p = new Programmer { Name = "Mike" };
            Manager m = new Manager { Name = "Steve" };
            Test(p, m);
            Console.ReadKey();
        }

        static void Test<T>(IMyComparable<T> t1, T t2)
        {
            //省略
        }
    }

    public interface IMyComparable<in T>
    {
        int Compare(T other);
    }

    public class Employee : IMyComparable<Employee>
    {
        public string Name { get; set; }
        public int Compare(Employee other)
        {
            return Name.CompareTo(other.Name);
        }
    }

    public class Programmer : Employee, IMyComparable<Programmer>
    {
        public int Compare(Programmer other)
        {
            return Name.CompareTo(other.Name);
        }
    }

    public class Manager : Employee
    {
    }
}
