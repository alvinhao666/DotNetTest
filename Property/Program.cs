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
            car.a = 5; 
            #endregion

            Console.WriteLine(car.c); //当用到时 才会触发get属性 抛出异常
            Console.ReadKey();
        }
    }
    
    public class CCar
    {
        public int a { get; set; }

        public int b { get; set; }

        public string c
        { 
            get
            {
                string d = "";
                if (a > 0) d += a ;
                if (b > 0) d += b;
                throw new Exception("sdfsf");
                return d;
            }
        }
    }
}