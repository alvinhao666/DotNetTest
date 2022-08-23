
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Property
{
    class Program
    {

        static void Main(string[] args)
        {

            //CCar car = new CCar() { a = 1 };
            //car.b = 2;
            //Console.WriteLine(CCar.x); // 5
            //car.a = 5; 
            //if (car.c > 0)
            //{
            //    Console.WriteLine(car.c); //当用到时 才会触发get属性  10
            //    Console.WriteLine(car.c);
            //}

            Person p = new Person() { GivenNames = "1" };
            p.PropertyChanged += Dc_PropertyChanged;
            p.GivenNames = "2";


            Console.ReadKey();
        }

        static void Dc_PropertyChanged(object sender,
 System.ComponentModel.PropertyChangedEventArgs e)
        {
            Console.WriteLine($"{e.PropertyName} Changed");
        }

    }


    //[AddINotifyPropertyChangedInterface]
    public class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string GivenNames { get; set; }
        public string FamilyName { get; set; }

        public string FullName => string.Format("{0} {1}", GivenNames, FamilyName);
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

                List<string> list = new List<string>();

                Console.WriteLine(a + "   " + a.GetHashCode() + " " + list.GetHashCode());

                x = 8;
                return b + x;
            }
        }
    }
}