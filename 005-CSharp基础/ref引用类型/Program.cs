using System.Runtime.InteropServices;

namespace ref引用类型
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<string> list = new List<string> { "a", "ab", "aaa", "bc" };
            TestList(ref list);
            Console.WriteLine("Main方法里的list现在有{0}个元素", list.Count());
        }
        public static void TestList(ref List<string> list)
        {
            list = list.Where(p => p.Contains("a")).ToList();
            Console.WriteLine("TestList方法里的list现在有{0}个元素", list.Count());
        }

        //static void Main(string[] args)
        //{
        //    List<string> list = new List<string> { "a", "ab", "aaa", "bc" };
        //    Console.WriteLine(getMemory(list));
        //    TestList(list);
        //    Console.WriteLine("Main方法里的list现在有{0}个元素", list.Count());
        //}
        //public static void TestList(List<string> list)
        //{
        //    Console.WriteLine(getMemory(list));
        //    list = list.Where(p => p.Contains("a")).ToList();
        //    Console.WriteLine(getMemory(list));
        //    Console.WriteLine("TestList方法里的list现在有{0}个元素", list.Count());
        //}
    }
}
