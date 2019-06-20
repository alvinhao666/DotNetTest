using Example02Lib;
using System;

namespace Readonly
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestReadonly item = new TestReadonly();
            //int x=item.GetX();

 
            //修改Example02中Class1的strConst初始值后，只编译Example02Lib项目            
            //然后到资源管理器里把新编译的Example02Lib.dll拷贝Example02.exe所在的目录，执行Example02.exe            
            //切不可在IDE里直接调试运行因为这会重新编译整个解决方案！！             
            //可以看到strConst的输出没有改变，而strStaticReadonly的输出已经改变            
            //表明Const变量是在编译期初始化并嵌入到客户端程序，而StaticReadonly是在运行时初始化的            
            Console.WriteLine("strConst : {0}", Class1.strConst);
            Console.WriteLine("strStaticReadonly : {0}", Class1.strStaticReadonly);
            Console.ReadKey();
            Console.WriteLine("strConst : {0}", Class1.strConst);
            Console.WriteLine("strStaticReadonly : {0}", Class1.strStaticReadonly);
            Console.ReadKey();

        }
    }


    public class TestReadonly
    {
        private  readonly int x; //X是只读字段
        public TestReadonly()
        {
            // 只能在初始化时，构造函数里面，对只读字段赋值
            x = 100;
        }

        public int GetX()
        {
            //这个语句是错误的，因为x不能被再次赋值，x是只读的(readonly)，而
            //下面的语句试图改变x的值。
            //x = x +100;


            //这个语句是正确的，因为语句执行后，x的值没有变
            int x1 = x + 100;
            return x1;
        }
    }

    class TestClass
    {
        private readonly TestClass2 tc; // 注意此处tc是readonly的

        public TestClass()
        {
            tc = new TestClass2();
        }

        public void ChangeTCValue(int value)
        {
            tc.ChangeValue(value);
        }

        public void Show()
        {
            Console.WriteLine("{0}", tc.ShowValue());
        }
    }

    class TestClass2
    {
        private int someValue; 

        public void ChangeValue(int newValue) //eadonly修饰的字段，其初始化仅是固定了其引用（地址不能修改），但它引用的对象的属性是可以更改的。
        {
            someValue = newValue;
        }

        public int ShowValue()
        {
            return someValue;
        }
    }
}
