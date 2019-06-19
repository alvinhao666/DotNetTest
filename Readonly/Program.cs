using System;

namespace Readonly
{
    class Program
    {
        static void Main(string[] args)
        {
            TestReadonly item = new TestReadonly();
            int x=item.GetX();

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
