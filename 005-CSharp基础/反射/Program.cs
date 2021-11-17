using System;
using System.Linq;
using System.Reflection;

namespace 反射
{
    //C#主要支持 5 种动态创建对象的方式： 
    //            1. Type.InvokeMember 
    //            2. ContructorInfo.Invoke 
    //            3. Activator.CreateInstance(Type) 
    //            4. Activator.CreateInstance(assemblyName, typeName) 
    //            5. Assembly.CreateInstance(typeName)
    //            最快的是方式 3 ，与 Direct Create 的差异在一个数量级之内，约慢 7 倍的水平。其他方式，至少在 40 倍以上，最慢的是方式 4 ，要慢三个数量级。 
    class Program
    {
        static void Main(string[] args)
        {
            var demo = (Demo1)Activator.CreateInstance(typeof(Demo1));
            demo.Name = "demo1";
            Console.WriteLine(demo.Name);

            Console.WriteLine(typeof(string).GetTypeInfo().IsClass); //string是引用类型  IsClass是否是类或者委托


            typeof(DeA).IsSubclassOf(typeof(Delegate)); //判断一个 Type 是否为委托类型
            typeof(DeA).IsSubclassOf(typeof(MulticastDelegate)); //判断是否多播委托

            // 普通委托
            Type typeA = typeof(DeA);
            Console.WriteLine("类型名称：" + typeA.Name);
            Console.WriteLine("是否为类或委托：" + typeA.IsClass);
            Console.WriteLine("是否为泛型：" + typeA.IsGenericType);
            Console.WriteLine("是否已绑定参数类型：" + typeA.IsGenericTypeDefinition);
            Console.WriteLine("可以用此 Type 创建实例：" + typeA.IsConstructedGenericType);


            // 泛型委托，不绑定参数类型
            Type typeB = typeof(DeB<>);
            Console.WriteLine("\n\n类型名称：" + typeB.Name);
            Console.WriteLine("是否为类或委托：" + typeB.IsClass);
            Console.WriteLine("是否为泛型：" + typeB.IsGenericType);
            Console.WriteLine("是否已绑定参数类型：" + typeB.IsGenericTypeDefinition);
            Console.WriteLine("可以用此 Type 创建实例：" + typeB.IsConstructedGenericType);

            // 泛型委托，绑定参数类型
            Type typeBB = typeof(DeB<int>);
            Console.WriteLine("\n\n类型名称：" + typeBB.Name);
            Console.WriteLine("是否为类或委托：" + typeBB.IsClass);
            Console.WriteLine("是否为泛型：" + typeBB.IsGenericType);
            Console.WriteLine("是否已绑定参数类型：" + typeBB.IsGenericTypeDefinition);
            Console.WriteLine("可以用此 Type 创建实例：" + typeBB.IsConstructedGenericType);

            // 泛型类，未绑定参数
            Type typeC = typeof(ClassC<>);
            Console.WriteLine("\n\n类型名称：" + typeC.Name);
            Console.WriteLine("是否为类或委托：" + typeC.IsClass);
            Console.WriteLine("是否为泛型：" + typeC.IsGenericType);
            Console.WriteLine("是否已绑定参数类型：" + typeC.IsGenericTypeDefinition);
            Console.WriteLine("可以用此 Type 创建实例：" + typeC.IsConstructedGenericType);

            // 泛型类型，已绑定参数
            Type typeD = typeof(ClassC<int>);
            Console.WriteLine("\n\n类型名称：" + typeD.Name);
            Console.WriteLine("是否为类或委托：" + typeD.IsClass);
            Console.WriteLine("是否为泛型：" + typeD.IsGenericType);
            Console.WriteLine("是否已绑定参数类型：" + typeD.IsGenericTypeDefinition);
            Console.WriteLine("可以用此 Type 创建实例：" + typeD.IsConstructedGenericType);

            // 反射获取某个属性名 对应的value值
            Cftea cftea = new Cftea();
            cftea.SiteName = "dfgdfg";
            string siteName = Convert.ToString(cftea.GetType().GetProperty("SiteName").GetValue(cftea, null));
            Console.WriteLine(siteName);

            Console.ReadKey();
        }



        static void SetValue(Object newObj, Object srcObj)
        {
            var newProperties = newObj.GetType().GetProperties();

            var oldProperties = srcObj.GetType().GetProperties();

            foreach (var n in newProperties)
            {
                var o = oldProperties.Where(a => a.Name == n.Name).FirstOrDefault();
                if (o != null && n.Name == o.Name)
                {
                    n.SetValue(newObj, o.GetValue(srcObj), null);
                }
            }
        }


        public class Cftea
        {
            public string SiteName { get; set; }
            public string Domain { get; set; }

            //public string GetValue(string name)
            //{
            //    return Convert.ToString(this.GetType().GetProperty(name).GetValue(this, null));
            //}
        }
    }
}
