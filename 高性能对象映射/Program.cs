using System;
using System.Linq.Expressions;

namespace 高性能对象映射
{

    // https://www.cnblogs.com/castyuan/p/9324088.html
    class Program
    {
        //private static const string ss = "123"; //错误 Const是静态常量，所以它本身就是Static的，因此不能手动再为Const增加一个Static修饰符
        private const string ss = "123";
        static void Main(string[] args)
        {

            var a = new A
            {
                Id = 1,
                Name = "张三",
                User = new C
                {
                    Id = 1,
                    Name = "李四"
                }
            };
            B b = Mapper<A, B>.Map(a);//得到转换结果

            //Expression<Func<A, B>> ss = (x) => new B { Id = x.Id, Name = x.Name };
            //var f = ss.Compile();
            //B studentSecond = f(a);
            Console.ReadKey();
        }
    }



    public class A
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public C User { get; set; }

        /// <summary>
        /// 标注为notmapped特性时，不转换赋值
        /// </summary>
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public D UserA { get; set; }

    }

    public class B
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public D User { get; set; }
        public D UserA { get; set; }
    }

    public class C
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class D
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
