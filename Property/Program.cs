using System;

namespace Property
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 属性get方法会重新执行
            CCar car = new CCar() { a = 1 };
            car.b = 2;  
            car.a = 5;
            #endregion
            
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
                return d;
            }
        }
    }
}