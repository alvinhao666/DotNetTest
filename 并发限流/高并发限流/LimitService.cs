using System;
using System.Collections.Generic;
using System.Text;

namespace 高并发限流
{
    public class LimitService
    {
        /// <summary>
        /// 当前指针位置
        /// </summary>
        public int currentIndex = 0;

        //限制的时间的秒数，即：x秒允许多少请求
        public int limitTimeSencond = 1;

        /// <summary>
        /// 请求环的数组容器
        /// </summary>
        public DateTime?[] requstRing { get; set; } = null;

        /// <summary>
        /// 容器改变或者移动指针时的锁；
        /// </summary>
        object obj = new object();

        public LimitService(int countPerSecond, int _limitTimeSencond)
        {
            limitTimeSencond = _limitTimeSencond;
            requstRing = new DateTime?[countPerSecond];
        }

        /// <summary>
        /// 程序是否可以继续
        /// </summary>
        /// <returns></returns>
        public bool IsContinue()
        {
            lock (obj)
            { 
                if(currentIndex==999)
                {

                }



                //当前节点设置为当前时间
                requstRing[currentIndex] = DateTime.Now;
                //指针移动一个位置
                MoveNextIndex(ref currentIndex);
            }

            return true;
        }

        /// <summary>
        /// 改变每秒可以通过的请求数
        /// </summary>
        /// <param name="countPerSecond"></param>
        /// <returns></returns>
        public bool ChangeCountPerSecond(int countPerSecond)
        {
            lock (obj)
            {
                requstRing = new DateTime?[countPerSecond];

                currentIndex = 0;
            }

            return true;
        }

        /// <summary>
        /// 指针往前移动一个位置
        /// </summary>
        /// <param name="currentIndex"></param>
        public void MoveNextIndex(ref int currentIndex)
        {
            if (currentIndex != requstRing.Length - 1)
            {
                currentIndex = currentIndex + 1;
            }
            else
            {
                currentIndex = 0;
            }
        }
    }
}
