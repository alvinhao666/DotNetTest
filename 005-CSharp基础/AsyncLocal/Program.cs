using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncLocal
{
    class Program
    {
        public static AsyncLocal<int> v = new AsyncLocal<int>();
 
        static async Task Main(string[] args)
        {
            Console.WriteLine(Thread.CurrentThread.ExecutionContext.GetHashCode());

            v.Value = 123;
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

            Console.WriteLine(Thread.CurrentThread.ExecutionContext.GetHashCode()); //AsyncLocal每设置一次值就会创建一个新的ExecutionContext并覆盖到Thread.CurrentThread.ExecutionContext
            var intercept = new Intercept();
            await Intercept.Invoke1(); //异步执行
            Console.WriteLine(Program.v.Value); //123
            await Intercept.Invoke2(); //没有异步执行
            Console.WriteLine(Program.v.Value); //888  

            Console.ReadKey();
        }
    }

    public class Intercept
    {
        public static async Task Invoke1()
        {
            Console.WriteLine();

            Console.WriteLine("Invoke1线程：" + Thread.CurrentThread.ManagedThreadId);  //异步操作会不会创建线程 ？  有可能会也有可能不会
            Console.WriteLine(Thread.CurrentThread.ExecutionContext.GetHashCode());

            Program.v.Value = 888;
            Console.WriteLine(Thread.CurrentThread.ExecutionContext.GetHashCode());
            await Task.CompletedTask;
        }

        public static Task Invoke2()
        {
            Console.WriteLine();

            Console.WriteLine("Invoke2线程：" + Thread.CurrentThread.ManagedThreadId);

            Console.WriteLine(Thread.CurrentThread.ExecutionContext.GetHashCode());

            Program.v.Value = 888;


            Console.WriteLine(Thread.CurrentThread.ExecutionContext.GetHashCode());
            return Task.CompletedTask;
        }
    }


    //class Program
    //{
    //    // 线程共享变量
    //    static ThreadLocal<int> local = new ThreadLocal<int>();

    //    // 线程共享变量
    //    static AsyncLocal<int> local2 = new AsyncLocal<int>();
    //    static async Task Main(string[] args)
    //    {
    //        //我这里是先声明一个Action委托实例，并通过Lambda表达式调用异步方法，并且异步等待其完成。
    //        //因为使用了await关键字的方法上必须标注async修饰符，以说明该方法中出现异步等待代码，但是，Main入口方法上是不允许添加async修饰符的，所以，我就用一个委托来调用。
    //        //// 声明一个委托实例
    //        //Action act = async () =>
    //        //{
    //        //    await RunAsync();
    //        //};

    //        //// 执行委托
    //        //act();

    //        await RunAsync();

    //        Console.Read();
    //    }


    //    static async Task RunAsync()
    //    {
    //        //// 输出当前线程的ID
    //        //Console.WriteLine($"异步等待前，当前线程ID：{Thread.CurrentThread.ManagedThreadId}");
    //        //// 开始执行异步方法，并等待完成
    //        //await Task.Delay(50);
    //        //// 异步等待完成后，再次输出当前线程的ID
    //        //Console.WriteLine($"异步等待后，当前线程ID：{Thread.CurrentThread.ManagedThreadId}");

    //        // 给共享变量赋值
    //        local.Value = 53000; //假设，设置local值为53000是在线程A上执行的，那么，local变量为线程A保留了值53000；当代码执行到await关键字一行后，开始异步等待，而等待返回后，当前代码可能被调度到线程B上了。而53000是为线程A所存储的值，对于线程B，未赋值，所以就得到默认的值0。

    //        // 输出变量的值
    //        Console.WriteLine($"异步等待前：{nameof(local)} = {local.Value}");
    //        await Task.Delay(50); //异步等待
    //        // 异步等待回来，再次输出变量的值
    //        Console.WriteLine($"异步等待后：{nameof(local)} = {local.Value}");

    //        // 给共享变量赋值
    //        local2.Value = 53000;

    //        // 输出变量的值
    //        Console.WriteLine($"异步等待前：{nameof(local2)} = {local2.Value}");
    //        await Task.Delay(50); //异步等待
    //        // 异步等待回来，再次输出变量的值
    //        Console.WriteLine($"异步等待后：{nameof(local2)} = {local2.Value}");  //53000在异步上下文中被保留了。
    //    }

    //}
}
