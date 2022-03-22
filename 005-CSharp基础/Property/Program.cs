using System;
using System.Collections.Generic;

namespace Property
{
    class Program
    {

        static void Main(string[] args)
        {

            #region
            CCar car = new CCar() { a = 1 };
            //car.b = 2;
            //Console.WriteLine(CCar.x); // 5
            //car.a = 5; 
            #endregion
            if (car.c > 0)
            {
                Console.WriteLine(car.c); //当用到时 才会触发get属性  10
                Console.WriteLine(car.c);
            }
    
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
                string a = "111";

                List<string> list = new List<string>() ;

                Console.WriteLine(a+ "   "+ a.GetHashCode() + " " + list.GetHashCode());

                x = 8;
                return b + x;
            }
        }
    }
}