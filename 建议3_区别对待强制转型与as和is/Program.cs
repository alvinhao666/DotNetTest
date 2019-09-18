using System;

namespace 建议3_区别对待强制转型与as和is
{
    /// <summary>
    /// explicit和implicit关键字分别表示显式的类型转换和隐式的类型转换。
    /// explicit 和 implicit 属于转换运算符，如用这两者可以让我们自定义的类型支持相互交换。
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            #region 两者存在转换操作符,在这种情况下，如果想转型成功则必须使用强制转型，而不是使用as操作符
            FirstType firstType = new FirstType() { Name = "First Type" };
            SecondType secondType = (SecondType)firstType;         //转型成功  
            //secondType = firstType as SecondType;     //编译期转型失败，编译通不过
            #endregion

        }
    }


    /// <summary>
    /// 强制转型可能意味着两件不同的事情：

    /// 1）FirstType和SecondType彼此依靠转换操作符来完成两个类型之间的转型。

    /// 2）FirstType是SecondType的基类。 在这种情况下，既可以使用强制转型，也可以使用as操作符
    /// </summary>
    public class FirstType
    {
        public string Name { get; set; }
    }

    public class  SecondType
    {
        public string Name { get; set; }

        public static explicit operator SecondType(FirstType firstType)  //转换操作符
        {
            SecondType secondType = new SecondType() { Name = "转型自：" + firstType.Name };
            return secondType;
        }
    }
}
