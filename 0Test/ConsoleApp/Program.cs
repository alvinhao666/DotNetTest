using Dapper;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

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

        static void Main(string[] args)
        {
            var timestamp = DateTime.Now.Ticks.ToString();
            string signature = MD5HASH("000694EFB5B9656EB9F8C3482CBEF32520D069A9" + timestamp);

            List<Person> persons = new List<Person>();
            Person p1 = new Person() { Name = "张三" };
            persons.Add(p1);
            p1.Name = "王五"; 

            Console.ReadKey();
        }


        /// <summary>
        /// md5校验
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string MD5HASH(string input)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
                var strResult = BitConverter.ToString(result);
                return strResult.Replace("-", "");
            }
        }


        public class Person
        { 
            /// <summary>
            /// 张三
            /// </summary>
            public string Name { get; set; }
        }
    }
}
