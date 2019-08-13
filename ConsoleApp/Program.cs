using Dapper;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp3
{
    ////////////////////////////////////////////////////////////////////
    //                          _ooOoo_                               //
    //                         o8888888o                              //
    //                         88" . "88                              //
    //                         (| ^_^ |)                              //
    //                         O\  =  /O                              //
    //                      ____/`---'\____                           //
    //                    .'  \\|     |//  `.                         //
    //                   /  \\|||  :  |||//  \                        //
    //                  /  _||||| -:- |||||-  \                       //
    //                  |   | \\\  -  /// |   |                       //
    //                  | \_|  ''\---/''  |   |                       //
    //                  \  .-\__  `-`  ___/-. /                       //
    //                ___`. .'  /--.--\  `. . ___                     //
    //              ."" '<  `.___\_<|>_/___.'  >'"".                  //
    //            | | :  `- \`.;`\ _ /`;.`/ - ` : | |                 //
    //            \  \ `-.   \_ __\ /__ _/   .-` /  /                 //
    //      ========`-.____`-.___\_____/___.-`____.-'========         //
    //                           `=---='                              //
    //      ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^        //
    //                   佛祖保佑       永不宕机     永无BUG            //
    ////////////////////////////////////////////////////////////////////
    class Program
    {
        delegate int MyDelegate(int x, int y);
        static void Main(string[] args)
        {

            for (var i = 0.1; i <= 1.0001; i = i + 0.05)
            {
                
                Console.WriteLine(i);
            }

            #region 属性get方法会重新执行
            CCar car = new CCar() { a = 1 };
            car.b = 2;  
            car.a = 5;
            #endregion


            #region 小数点默认类型double

            var a = 3.24; //小数默认double类型
            Console.WriteLine(a.GetType());


            Console.WriteLine(long.MaxValue);//9223372036854775807  19位   负号- 20位

            Console.WriteLine(ulong.MaxValue);//18446744073709551615 20位 


            //Console.WriteLine(Convert.ToInt64(Math.Pow(2, 64))); //报错

            Console.WriteLine(Convert.ToUInt64(Math.Pow(2, 63))); //9223372036854775808 19位

            //Console.WriteLine(Convert.ToUInt64(Math.Pow(2, 64))); //报错

            Console.WriteLine(Math.Pow(2, 64));//18446744073709551616 20位

            ulong sum = Convert.ToUInt64(Math.Pow(2, 0));
            for (int i = 1; i <= 63; i++) 
            {
                sum= sum | Convert.ToUInt64(Math.Pow(2, i));
            }
            Console.WriteLine(sum); //18446744073709551615 一共64个
            Console.WriteLine(18446744073709551615 & 2); //18446744073709551615 一共64个
            #endregion

            #region Foreach
            List<Person> lstInt = new List<Person>() { new Person() { Age = 1 }, new Person() { Age = 2 } };
            lstInt.ForEach(b =>
            {
                b.Age = b.Age + 1;
            });//有变化


            foreach (var b in lstInt)
            {
                b.Age = b.Age + 1;
            }//有变化

            lstInt.ForEach(b =>
            {
                b = new Person();
            });//没变化

            var s = lstInt;


            List<int> ints = new List<int>() { 1, 2, 3 };
            ints.ForEach(x => {
                x = x + 1;
            }); //没变化

            List<String> intss = new List<String>() { "1", "1", "1" };
            intss.ForEach(x => {
                x = x + 1;
            });//没变化

            #endregion

            Test t = new Test();
            t.x = 100;
            object tt = t;//装箱
            ((Test)tt).test(300);//x还是100不变，为什么

            Console.WriteLine(decimal.MinValue);

            Console.WriteLine(default(List<string>)==null);

            Console.ReadKey();
        }


        static int Sum(int x ,int y)
        {
            return x + y;
        }

        static List<string> GetParameters(string text)
        {
            var matchVale = new List<string>();
            string Reg = @"(?<={)[^{}]*(?=})";
            string key = string.Empty;
            foreach (Match m in Regex.Matches(text, Reg))
            {
                matchVale.Add(m.Value);
            }
            return matchVale;
        }
    
    }
    class Person
    {
        public int Age { get; set; }
    }

    public class CCar
    {
        public int a { get; set; }

        public int b { get; set; }

        public string c
        { get
            {
                string d = "";
                if (a > 0) d += a ;
                if (b > 0) d += b;
                return d;
            }
        }
    }

    struct Test
    {
        public int x;
        public void test(int x)
        {
            this.x = x;
        }
    }

}
