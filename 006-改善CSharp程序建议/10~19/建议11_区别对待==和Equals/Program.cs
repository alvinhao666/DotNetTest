using System;

namespace 建议11_区别对待__和Equals
{
    //在开始本建议之前，首先要明确概念“相等性”。CLR中将“相等性”分为两类：“值相等性”和“引用相等性”。如果用来比较的两个变量所包含的数值相等，那么将其定义为“值相等性”；如果比较的两个变量引用的是内存中的同一个对象，那么将其定义为“引用相等性”。

    //无论是操作符“==”还是方法“Equals”，都倾向于表达这样一个原则：

    //对于值类型，如果类型的值相等，就应该返回True。
    //对于引用类型，如果类型指向同一个对象，则返回True。

    //但是，我们同时也要了解，无论是操作符“==”还是“Equals”方法都是可以被重载的。比如，对于string这样一个特殊的引用类型，微软觉 得它的现实意义更接近于值类型，
    //所以，在FCL中，string的比较被重载为针对“类型的值”的比较，而不是针对“引用本身”的比较。
    class Program
    {
        static void Main(string[] args)
        {
            object a = new Person("NB123");
            object b = new Person("NB123");
            //False  
            Console.WriteLine(a == b);
            // True  
            Console.WriteLine(a.Equals(b));

            //这里，再引出操作符“==”和“Equals”方法之间的一点区别。一般来说，对于引用类型，我们要定义“值相等性”，应该仅仅去重载Equals方法，同时让“==”表示“引用相等性”。

            //注意 由于操作符“==”和“Equals”方法从语法实现上来说，都可以被重载为表示“值相等性”和“引用相等性”。所以，为了明确有一种方法肯 定比较的是“引用相等性”，
            //FCL中提供了Object.ReferenceEquals方法。该方法比较的是：两个示例是否是同一个示例。


        }

        static void ValueTypeOPEquals()
        {
            int i = 1;
            int j = 1;
            //True  
            Console.WriteLine(i == j);
            j = i;
            //True  
            Console.WriteLine(i == j);
        }

        static void ReferenceTypeOPEquals()
        {
            object a = 1;
            object b = 1;
            //False  
            Console.WriteLine(a == b);
            b = a;
            //True  
            Console.WriteLine(a == b);
        }

        static void ValueTypeEquals()
        {
            int i = 1;
            int j = 1;
            //True  
            Console.WriteLine(i.Equals(j));
            j = i;
            //True  
            Console.WriteLine(i.Equals(j));
        }

        static void ReferenceTypeEquals()
        {
            object a = new Person("NB123");
            object b = new Person("NB123");
            //False  
            Console.WriteLine(a.Equals(b));
            b = a;
            //True  
            Console.WriteLine(a.Equals(b));
        }
    }

    class Person
    {
        public string IDCode { get; private set; }

        public Person(string idCode)
        {
            this.IDCode = idCode;
        }

        public override bool Equals(object obj)
        {
            return IDCode == (obj as Person).IDCode;
        }
    }
}
