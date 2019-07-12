﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{    ////////////////////////////////////////////////////////////////////
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
        static void Main(string[] args)
        {
            #region 小数点默认类型double

            var a = 3.24; //小数默认double类型
            Console.WriteLine(a.GetType());
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
            ints.ForEach(x=> {
               x= x + 1;
            }); //没变化

            List<String> intss = new List<String>() { "1", "1", "1" };
            intss.ForEach(x => {
                x = x + 1;
            });//没变化

            #endregion


            Console.ReadKey();
        }
    }

    class Person
    {
       public int Age { get; set; }
    }
}
