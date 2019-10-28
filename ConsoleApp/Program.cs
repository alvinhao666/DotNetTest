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

            //浮点型， 由于计算机表达十进制小数时有误差，控制循环次数可能会有误差，但也不一定。为保险起见，能用整型，则用整型。
            for (var i = 0.1; i <= 1.0001; i = i + 0.05)
            {
                Console.WriteLine(i);
            }

            
            #region 小数点默认类型double

            var a = 3.24; //小数默认double类型
            Console.WriteLine(a.GetType());
            #endregion

            #region long类型
            
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



            Test t = new Test();
            t.x = 100;
            object tt = t;//装箱
            ((Test)tt).test(300);//x还是100不变，为什么

            Console.WriteLine(decimal.MinValue);

            Console.WriteLine(default(List<string>)==null);

            Console.WriteLine(new Student().Sta);
            
            DervEmployee objDervEmployee = new DervEmployee();
            objDervEmployee.EmpInfo();
            Student aaa = new Student();

            Student bbb = new Student();

            Console.WriteLine(aaa == bbb);
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


    struct Test
    {
        public int x;
        public void test(int x)
        {
            this.x = x;
        }
    }


    public class Student
    {
        public Status? Sta { get; set; } = Status.X;
    }

    public enum Status
    {
        X,
        Y
    }
    
    class Employee
    {
        public virtual void EmpInfo()
        {
            Console.WriteLine("用virtual关键字修饰的方法是虚拟方法");
        }
    }
    class DervEmployee : Employee
    {
        public override void EmpInfo()
        {
            base.EmpInfo();//base关键字将在下面拓展中提到
            Console.WriteLine("该方法重写base方法");
        }
    }

}
