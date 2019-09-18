using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace 建议14_正确实现浅拷贝和深拷贝
{

    //为对象创建副本的技术称为拷贝（也叫克隆）。我们将拷贝分为浅拷贝和深拷贝。

    //浅拷贝 将对象中的所有字段复制到新的对象（副本）中。其中，值类型字段的值被复制到副本中后，在副本中的修改不会影响到源对象对应的值。而引用类型的字段被复制到副本中的是引用类型的引用，而不是引用的对象，在副本中对引用类型的字段值做修改会影响到源对象本身。
    //深拷贝 同样，将对象中的所有字段复制到新的对象中。不过，无论是对象的值类型字段，还是引用类型字段，都会被重新创建并赋值，对于副本的修改，不会影响到源对象本身。

    //无论是浅拷贝还是深拷贝，微软都建议用类型继承ICloneable接口的方式明确告诉调用者：该类型可以被拷贝。当然，ICloneable接口 只提供了一个声明为Clone的方法，我们可以根据需求在Clone方法内实现浅拷贝或深拷贝。一个简单的浅拷贝的实现代码如下所示：
    class Program
    {
        //注意到Employee的IDCode属性是string类型。理论上string类型是引用类型，但是由于该引用类型的特殊性（无论是实现还是语义），Object.MemberwiseClone方法仍旧为其创建了副本。也就是说，在浅拷贝过程，我们应该将字符串看成是值类型。 

        //Employee的Department属性是一个引用类型，所以，如果改变了源对象mike中的值，副本rose中的值也会随之一起变动。
        static void Main(string[] args)
        {
            Employee mike = new Employee() { IDCode = "NB123", Age = 30, Department = new Department() { Name = "Dep1" } };
            Employee rose = mike.Clone() as Employee;
            Console.WriteLine(rose.IDCode);
            Console.WriteLine(rose.Age);
            Console.WriteLine(rose.Department);
            Console.WriteLine("开始改变mike的值：");
            mike.IDCode = "NB456";
            mike.Age = 60;
            mike.Department.Name = "Dep2";
            Console.WriteLine(rose.IDCode);
            Console.WriteLine(rose.Age);
            Console.WriteLine(rose.Department);
            //NB123
            //30
            //Dep1
            //开始改变mike的值：
            //NB123
            //30
            //Dep2
            Console.ReadKey();
        }
    }

    [Serializable]
    class Employee : ICloneable
    {
        public string IDCode { get; set; }
        public int Age { get; set; }
        public Department Department { get; set; }

        #region ICloneable 成员  

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion

        public Employee DeepClone()
        {
            using (Stream objectStream = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(objectStream, this);
                objectStream.Seek(0, SeekOrigin.Begin);
                return formatter.Deserialize(objectStream) as Employee;
            }
        }

        public Employee ShallowClone()
        {
            return Clone() as Employee;
        }
    }

    class Department
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
