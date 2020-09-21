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

            Console.WriteLine(typeof(string).GetTypeInfo().IsClass); //string是引用类型
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
    }
}
