using System;

namespace BoolTest
{
    class Program
    {
        static void Main(string[] args)
        {
            bool a = bool.Parse("true"); //可以转化 

            bool b = bool.Parse("1"); //"1"不可以

            Console.ReadKey();
        }
    }
}
