using System;
using System.Collections.Generic;

namespace Yield
{
    //https://www.cnblogs.com/hulizhong/p/11763956.html
    //yield return 返回集合不是一次性返回所有集合元素，而是一次调用返回一个元素。
    class Program
    {
        static private List<int> _numArray; //用来保存1-100 这100个整数

        Program() //构造函数。我们可以通过这个构造函数往待测试集合中存入1-100这100个测试数据
        {
            _numArray = new List<int>(); //给集合变量开始在堆内存上开内存，并且把内存首地址交给这个_numArray变量

            for (int i = 1; i <= 100; i++)
            {
                _numArray.Add(i);  //把1到100保存在集合当中方便操作
            }
        }

        static void Main(string[] args)
        {
            new Program();

            TestMethod();


        }

        //测试求1到100之间的全部偶数
        static public void TestMethod()
        {
            foreach (var item in GetAllEvenNumberOld())
            {
                Console.WriteLine(item); //输出偶数测试
            }
        }

        /// <summary>
        /// 使用平常返回集合方法
        /// </summary>
        /// <returns></returns>
        static IEnumerable<int> GetAllEvenNumberOld()
        {
            var listNum = new List<int>();
            foreach (int num in _numArray)
            {
                if (num % 2 == 0) //判断是不是偶数
                {
                    listNum.Add(num); //返回当前偶数

                }
            }
            return listNum;
        }


        //使用Yield Return情况下的方法
        static IEnumerable<int> GetAllEvenNumber()
        {

            foreach (int num in _numArray)
            {
                if (num % 2 == 0) //判断是不是偶数
                {
                    yield return num; //返回当前偶数

                }
            }
            yield break;  //当前集合已经遍历完毕，我们就跳出当前函数，其实你不加也可以
            //这个作用就是提前结束当前函数，就是说这个函数运行完毕了。
        }

        //通过上面的案例我们可以发现，yield return 并不是等所有执行完了才一次性返回的。而是调用一次就返回一次结果的元素。这也就是按需供给。
    }
}
