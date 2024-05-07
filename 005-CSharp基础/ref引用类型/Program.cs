using System.Runtime.InteropServices;

namespace ref引用类型
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<string> list = new List<string> { "a", "ab", "aaa", "bc" };
            Console.WriteLine(getMemory(list));
            TestList(ref list);
            Console.WriteLine("Main方法里的list现在有{0}个元素", list.Count());
        }
        public static void TestList(ref List<string> list)
        {
            Console.WriteLine(getMemory(list));
            list = list.Where(p => p.Contains("a")).ToList();
            Console.WriteLine(getMemory(list));
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

        //获取引用类型的内存地址方法
        public static string getMemory(object obj)
        {
            GCHandle handle = GCHandle.Alloc(obj, GCHandleType.WeakTrackResurrection);
            IntPtr addr = GCHandle.ToIntPtr(handle);
            return $"0x{addr.ToString("X")}";
        }

    }
}
