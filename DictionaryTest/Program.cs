using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace DictionaryTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var dic = new Dictionary<string, string>();
            dic.Add("1", "Test1");
            dic.Add("2", "Test2");
            dic.Add("3", "Test3");
            var body = dic.Select(pair => pair.Key + "=" + WebUtility.UrlEncode(pair.Value))
                          .DefaultIfEmpty("") //如果是空 返回 new List<string>(){""};
                          .Aggregate((a, b) => a + "&" + b);

            Console.WriteLine(body);
            Console.ReadKey();

        }
    }
}
