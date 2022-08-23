using System;
using System.Collections.Generic;

namespace 建议12_重写Equals时也要重写GetHashCode
{
    //除非考虑到自定义类型会被用作基于散列的集合的键值；否则，不建议重写Equals方法，因为这会带来一系列的问题。

    //如果编译上一个建议中的Person这个类型，编译器会提示这样一个信息：

    //“重写 Object.Equals(object o)但不重写 Object.GetHashCode()”

    //如果重写Equals方法的时候不重写GetHashCode方法，在使用如FCL中的Dictionary类时，可能隐含一些潜在的Bug。还是针对上一个建议中的Person进行编码，代码如下所示：
    class Program
    {

        static Dictionary<Person, PersonMoreInfo> PersonValues = new Dictionary<Person, PersonMoreInfo>();
        static void Main(string[] args)
        {
            AddAPerson();
            Person mike = new Person("NB123");
            //Console.WriteLine(mike.GetHashCode());  
            Console.WriteLine(PersonValues.ContainsKey(mike)); //false
            //理论上来说，在上一个建议中我们已经重写了Person的Equals方法；也就是说，在AddAPerson方法中的mike和Main方法中的 mike属于“值相等”。
            //于是，将该“值”作为key放入Dictionary中，再在某处根据mike将mikeValue取出来，这会是理所当然的事 情。
            //可是，从上面的代码段中我们发现，针对同一个示例，这种结论是正确的，若是针对不同的mike示例，这种结果就有问题了

            //基于键值的集合（如上面的Dictionary）会根据Key值来查找Value值。CLR内部会优化这种查找，实际上，最终是根据Key值的 HashCode来查找Value值。
            //代码运行的时候，CLR首先会调用Person类型的GetHashCode，由于发现Person没有实现 GetHashCode，所以CLR最终会调用Object的GetHashCode方法。将上面代码中的两行注释代码去掉，运行程序得到输出，我们会发 现，Main方法和AddAPerson方法中的两个mike的HashCode是不同的。
            //这里需要解释为什么两者实际对应调用的 Object.GetHashCode会不相同。

            //Object为所有的CLR类型都提供了GetHashCode的默认实现。每new一个对象，CLR都会为该对象生成一个固定的整型值，该整型值 在对象的生存周期内不会改变，而该对象默认的GetHashCode实现就是对该整型值求HashCode。
            //所以，在上面代码中，两个mike对象虽然属 性值都一致，但是它们默认实现的HashCode不一致，这就导致Dictionary中出现异常的行为。若要修正该问题，就必须重写 GetHashCode方法。Person类的一个简单的重写可以是如下的形式：


            //GetHashCode方法还存在另外一个问题，它永远只返回一个整型类型，而整型类型的容量显然无法满足字符串的容量，以下的例子就能产生两个同样的HashCode。
            //string str1 = "NB0903100006";
            //string str2 = "NB0904140001";
            //Console.WriteLine(str1.GetHashCode());
            //Console.WriteLine(str2.GetHashCode());


            Console.ReadKey();
        }

        static void AddAPerson()
        {
            Person mike = new Person("NB123");
            PersonMoreInfo mikeValue = new PersonMoreInfo() { SomeInfo = "Mike's info" };
            PersonValues.Add(mike, mikeValue);
            //Console.WriteLine(mike.GetHashCode());  
            Console.WriteLine(PersonValues.ContainsKey(mike)); // true
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

        //public override int GetHashCode()
        //{
        //    return this.IDCode.GetHashCode();
        //}
        //为了减少两个不同类型之间根据字符串产生相同的HashCode的几率，一个稍作改进版本的GetHashCode方法如下：
        public override int GetHashCode()
        {
            return (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName + "#" + this.IDCode).GetHashCode();
        }
    }

    class PersonMoreInfo
    {
        public string SomeInfo { get; set; }
    }
}
