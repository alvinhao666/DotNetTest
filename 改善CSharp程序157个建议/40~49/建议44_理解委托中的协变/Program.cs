using System;

namespace 建议44_理解委托中的协变
{
    //委托中的泛型变量天然是部分支持协变的。为什么是“部分支持协变”？看下面示例：
    //协变委托方法的优点是：使得创建可被类和派生类同时使用的委托方法成为可能。
    class Program
    {
        public delegate T GetEmployeeHanlder<T>(string name);
        static void Main(string[] args)
        {
            GetEmployeeHanlder<Manager> getAManager = GetAManager;
            GetEmployeeHanlder<Employee> getAEmployee = GetAManager;


            Employee e = getAEmployee("Mike");
            Console.ReadKey();
        }

        static Manager GetAManager(string name)
        {
            Console.WriteLine("我是经理: " + name);
            return new Manager() { Name = name };
        }

        static Employee GetAEmployee(string name)
        {
            Console.WriteLine("我是雇员: " + name);
            return new Employee() { Name = name };
        }
    }
    interface ISalary<T>
    {
        void Pay();
    }

    class BaseSalaryCounter<T> : ISalary<T>
    {
        public void Pay()
        {
            Console.WriteLine("Pay base salary");
        }
    }

    class Employee
    {
        public string Name { get; set; }
    }
    class Programmer : Employee
    {
    }
    class Manager : Employee
    {
    }
}
