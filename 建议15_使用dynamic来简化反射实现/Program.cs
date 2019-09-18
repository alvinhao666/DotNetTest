using System;
using System.Diagnostics;

namespace 建议15_使用dynamic来简化反射实现
{
    //dynamic是Framework 4.0的新特性。dynamic的出现让C#具有了弱语言类型的特性。编译器在编译的时候不再对类型进行检查，编译器默认dynamic对象支持开发者想要的任何特性。
    //比如，即使你对GetDynamicObject方法返回的对象一无所知，也可以像如下这样进行代码的调用，编译器不会报错：
    //dynamic dynamicObject = GetDynamicObject();
    //Console.WriteLine(dynamicObject.Name);
    //Console.WriteLine(dynamicObject.SampleMethod());
    class Program
    {
        static void Main(string[] args)
        {
            DynamicSample dynamicSample = new DynamicSample();  //为了代码简洁简写了，没有写反射 Assembly.Load(AssemblyPath).CreateInstance(classNamespace)，详细反射代码见文章结尾，实际开发中是要用反射生成实例的
            var addMethod = typeof(DynamicSample).GetMethod("Add");
            int re = (int)addMethod.Invoke(dynamicSample, new object[] { 1, 2 });

            // 在使用dynamic后，代码看上去更简洁了，并且在可控的范围内减少了一次拆箱的机会，代码如下所示：
            dynamic dynamicSample2 = new DynamicSample(); //为了代码简洁简写了，没有写反射 Assembly.Load(AssemblyPath).CreateInstance(classNamespace)，详细反射代码见文章结尾，实际开发中是要用反射生成实例的 
            int re2 = dynamicSample2.Add(1, 2);

            Console.WriteLine(re2);


            int times = 1000000;
            DynamicSample reflectSample = new DynamicSample();
            var addMethod1 = typeof(DynamicSample).GetMethod("Add");
            Stopwatch watch1 = Stopwatch.StartNew();
            for (var i = 0; i < times; i++)
            {
                addMethod1.Invoke(reflectSample, new object[] { 1, 2 });
            }
            Console.WriteLine(string.Format("反射耗时：{0} 毫秒", watch1.ElapsedMilliseconds));
            dynamic dynamicSample1 = new DynamicSample();
            Stopwatch watch2 = Stopwatch.StartNew();
            for (int i = 0; i < times; i++)
            {
                dynamicSample1.Add(1, 2);
            }
            Console.WriteLine(string.Format("dynamic耗时：{0} 毫秒",
                watch2.ElapsedMilliseconds));

            //可以看到，没有优化的反射实现，上面这个循环上的执行效率大大低于dynamic实现的效果。如果对反射实现进行优化，代码如下所示：
            DynamicSample reflectSampleBetter = new DynamicSample();
            var addMethod2 = typeof(DynamicSample).GetMethod("Add");
            var delg = (Func<DynamicSample, int, int, int>)Delegate.CreateDelegate(typeof(Func<DynamicSample, int, int, int>), addMethod2);
            Stopwatch watch3 = Stopwatch.StartNew();
            for (var i = 0; i < times; i++)
            {
                delg(reflectSampleBetter, 1, 2);
            }
            Console.WriteLine(string.Format("优化的反射耗时：{0} 毫秒", watch3.ElapsedMilliseconds));
            //可以看到，优化后的反射实现，其效率和dynamic在一个数量级上。可是它带来了效率，却牺牲了代码的整洁度，这种实现在我看来是得不偿失的。所以，现在有了dynamic类型，建议大家：
            //始终使用dynamic来简化反射实现。

            Console.ReadKey();
        }
    }

    public class DynamicSample
    {
        public string Name { get; set; }

        public int Add(int a, int b)
        {
            return a + b;
        }
    }

}
