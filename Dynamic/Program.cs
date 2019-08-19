using System;

namespace Dynamic
{
    //dynamic被编译后，实际是一个object类型，只不过编译器会对dynamic类型进行特殊处理
    //让它在编译期间不进行任何的类型检查，而是将类型检查放到了运行期
    class Program
    {
        static void Main(string[] args)
        {
            string strA = "Test";//显示类型声明
            var strB = "Test";//隐式类型声明
            
            //动态类型语言是指在运行时执行类型检查的语言。如果您不知道您将获得或需要分配的值的类型，则在此情况下，类型是在运行时定义的

            dynamic strC = "Test";
            strC++; //不会给出错误提示信息，生成应用程序，也不会有错误产生，应用程序也会成功生成，但是，如果你运行这个应用程序，对不起，会给你如下所示的运行时错误
            
            //var和dynamic关键字之间的主要区别在于绑定时间不一样：var是早期绑定，dynamic绑定则会在运行时进行
            //var实际上是编译器抛给我们的语法糖，一旦被编译，编译器就会自动匹配var变量的实际类型
            //dynamic被编译后是一个Object类型，编译器编译时不会对dynamic进行类型检查,没有IntelliSense智能感知提示
            
            
            
            //合理的运用dynamic可以让你的代码更加的简洁，而且比直接使用反射性能更好（反射没有优化处理的前提），
            //因为dynamic是基于DLR，第一次运行后会缓存起来。其实有心的同学会发现.net的类库里面很多地方都用了dynamic这个东西，
            //例如：mvc中的ViewBag就是一个很好的例子。一般情况下，如果开发者不知道方法和方法的返回类型是否公开，请使用dynamic关键字。
            
            #region 简化反射

            Sample sample=new Sample();
            var addMethod = typeof(Sample).GetMethod("Add");
            int re = (int) addMethod.Invoke(sample, new object[] {1, 2});

            dynamic sample2 = new Sample();
            int re2 = sample2.Add(1, 2);
            
            Sample sample3 = new Sample();
            int re3 = sample3.Add(1, 2);

            #endregion


            Console.ReadKey();
        }
    }
    

    public class Sample
    {
        public string Name { get; set; }

        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}