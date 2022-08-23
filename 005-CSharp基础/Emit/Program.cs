using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Emit
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic obj = CreateAssembly();
            //LoadAssembly();

            obj.MyMethod();

            Console.ReadKey();
        }

        //.NetCore 平台已经不支持直接输出到目录，仅仅可以在内存中Run

        //public static void LoadAssembly()
        //{
        //    var ass = AppDomain.CurrentDomain.Load("MyAssembly");
        //    var m = ass.GetModule("MyModule");
        //    var ts = m.GetTypes();
        //    var t = ts.FirstOrDefault();
        //    if (t != null)
        //    {
        //        object obj = Activator.CreateInstance(t);
        //        var me = t.GetMethod("MyMethod");
        //        me.Invoke(obj, null);
        //    }
        //}

        public static object CreateAssembly()
        {

            //定义一个程序集的名称
            var asmName = new AssemblyName("MyAssembly");

            //首先就需要定义一个程序集
            var defAssembly = AssemblyBuilder.DefineDynamicAssembly(asmName, AssemblyBuilderAccess.Run);

            //定义一个构建类
            var defModuleBuilder = defAssembly.DefineDynamicModule("MyModule");


            //定义一个类
            var defClassBuilder = defModuleBuilder.DefineType("MyClass", TypeAttributes.Public);

            //定义一个方法
            var defMethodBuilder = defClassBuilder.DefineMethod("MyMethod",
                MethodAttributes.Public,
                null,//返回类型
                null//参数类型
                );

            //获取IL生成器
            var il = defMethodBuilder.GetILGenerator();
            //定义一个字符串
            il.Emit(OpCodes.Ldstr, "生成的第一个程序");
            //调用一个函数
            il.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }));
            //返回到方法开始（返回）
            il.Emit(OpCodes.Ret);

            ////创建类型
            //defClassBuilder.CreateType();

            var typeInfo = defClassBuilder.CreateTypeInfo();
            ////保存程序集
            //defAssembly.("MyAssembly.dll");

            return Activator.CreateInstance(typeInfo);
        }

    }
}
