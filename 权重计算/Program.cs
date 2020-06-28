using System;
using System.Collections.Generic;
using System.Linq;

namespace 权重计算
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Demo>() {
                new Demo{Name="张三",HitRate=1 },
                new Demo{Name="李四",HitRate=5 },
                new Demo{Name="王五",HitRate=4 },
            };
            var currentIndex = GetRandomIndex(list.ToDictionary(it => list.IndexOf(it), it => it.HitRate));

            Console.WriteLine(currentIndex);
            Console.WriteLine(list[currentIndex].Name);

            Console.ReadKey();
        }


        /// <summary>
        /// 根据权重值，计算获取随机索引下标值
        /// </summary>
        /// <param name="pars">key:索引下标值, value:权重值</param>
        /// <returns></returns>
        public static int GetRandomIndex(Dictionary<int, int> pars)
        {
            var maxValue = pars.Sum(a => a.Value); //总权重

            var num = new Random().Next(1, maxValue);//1到总权重之间随机个权重数字
            var result = 0;
            var endValue = 0;
            foreach (var item in pars)
            {
                var index = pars.ToList().IndexOf(item);  //0
                var beginValue = index == 0 ? 0 : pars[index - 1]; //0
                endValue += item.Value;  //1
                result = item.Key; //0
                if (num >= beginValue && num <= endValue)
                    break;
            }
            return result;
        }
    }

    class Demo
    {
        public string Name { get; set; }

        public int HitRate { get; set; }
    }
}
