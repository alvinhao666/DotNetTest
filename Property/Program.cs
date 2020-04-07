using System;

namespace Property
{
    class Program
    {

        static void Main(string[] args)
        {

            #region
            CCar car = new CCar() { a = 1 };
            car.b = 2;
            Console.WriteLine(CCar.x); // 5
            car.a = 5; 
            #endregion

            Console.WriteLine(car.c); //当用到时 才会触发get属性  10
            Console.ReadKey();
        }
    }
    
    public class CCar
    {
        public static int x = 5;
        public int a { get; set; }

        public int b { get; set; }

        public int c
        { 
            get
            {
                x = 8;
                return b + x;
            }
        }
    }
}