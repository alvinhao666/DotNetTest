using System.Collections.Generic;

namespace 协变和逆变
{
    //协变(covariant)和逆变(contravariant)是C#4.0新增的概念。
    //在我们自己的代码中，如果要编写泛型接口，除非确定该接口中的泛型参数不涉及变体，否则都建议加上out关键字。协变增大了接口的使用范围，而且几乎没有带来什么副作用
    class Program
    {
        static void Main(string[] args)
        {
            //声明Human，和Chinese类，不会有问题
            Human human = new Human();
            Chinese chinese = new Chinese();

            //Chinese是Human的子类，所以声明不会有问题
            Human shuman = new Chinese();

            //声明List
            List<Human> listHuman = new List<Human>();
            List<Chinese> listChinese = new List<Chinese>();

            //在这里，会出现错误,这里的Human虽然是Chinese的父类，但是如果将Human，和Chinese当做List类型来用，那么这里的2个List就不再有继承关系。没有继承关系在声明的时候就会出错。
            //这时候就需要使用协变：
            //List<Human> list = new List<Chinese>();
            IEnumerable<Human> List1 = new List<Chinese>();
            //可以看到协变类似于一个泛型接口，但是不同的是在泛型接口的T前面有一个out关键字修饰(这里的out不是ref的那个out)，
            //这就是协变，协变的定义为左边声明的是基类，右边可以声明基类以及基类的子类。协变可以直白的理解为string->object，out关键字可以单纯的理解为输出，作为返回值

            ICustomCovariant<Human> custom = new CustomCovariant<Chinese>();

            //逆变可以直白的看为object->string，协变的关键字是out，逆变的关键字是in，在你变种in只能作为传入值不能作为返回值。
            ICustomContravariant<Chinese> custom2 = new CustomContravariant<Human>();
        }
    }



    public class Human
    {
        public string Name { get; set; }
    }

    public class Chinese : Human
    {
        public string age { get; set; }
    }

    public interface ICustomCovariant<out T>
    {
        T Get();
    }

    public class CustomCovariant<T> : ICustomCovariant<T>
    {
        public T Get()
        {
            return default(T);
        }
    }

    public interface ICustomContravariant<in T>
    {
        void Get(T t);
    }

    public class CustomContravariant<T> : ICustomContravariant<T>
    {
        public void Get(T t)
        {
        }
    }
}
