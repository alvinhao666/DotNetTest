namespace 闭包
{
    // delegate 被编译器 编译成一个class, 所以才能传来传去(具体参考 《CLR via C#》第四版), 所以 Action、Func也是如此

    //闭包是指有权访问另一个函数作用域中的变量的函数。 https://www.cnblogs.com/blurhkh/p/9535289.html   https://www.cnblogs.com/jujusharp/archive/2011/08/04/2127999.html

    //第一次执行委托internalAdd 10 + 10 输出20

    //接着改变了被internalAdd引用的局部变量值val，再次以相同的参数执行委托，输出40。显然局部变量的改变影响到了委托的执行结果。

    //GetClosureFunction将internalAdd返回至外部，以30作为参数，去执行得到的结果是60，和val局部变量最后的值30是一致的。

    //val 作为一个局部变量。它的生命周期本应该在GetClosureFunction执行完毕后就结束了。为什么还会对之后的结果产生影响呢?

    class Program
    {
        //static void Main(string[] args)
        //{

        //    Console.WriteLine(GetClosureFunction()(30)); //30+ 30 60
        //}

        //static Func<int, int> GetClosureFunction()
        //{
        //    int val = 10;
        //    Func<int, int> internalAdd = x => x + val;

        //    Console.WriteLine(internalAdd(10)); // 10 +10 20

        //    val = 30;
        //    Console.WriteLine(internalAdd(10)); //10 +30  40

        //    return internalAdd;
        //}
    }

    //上述代码的执行流程是Main函数调用GetClosureFunction函数，GetClosureFunction返回了委托internalAdd并被立即执行了。

    //输出结果依次为20、40、60

    //对应到一开始提出的闭包的概念。这个委托internalAdd就是一个闭包，引用了外部函数GetClosureFunction作用域中的变量val。

    //注意：internalAdd有没有被当做返回值和闭包的定义无关。就算它没有被返回到外部，它依旧是个闭包。


    //编译器创建了一个匿名类（如果不需要创建闭包，匿名函数只会是与GetClosureFunction生存在同一个类中，并且委托实例会被缓存，参见clr via C# 第四版362页），
    //并在GetClosureFunction中创建了它实例。局部变量实际上是作为匿名类中的字段存在的。

    //class Program
    //{
    //    sealed class DisplayClass
    //    {
    //        public int val;

    //        public int AnonymousFunction(int x)
    //        {
    //            return x + this.val;
    //        }
    //    }

    //    static void Main(string[] args)
    //    {
    //        Console.WriteLine(GetClosureFunction()(30));
    //    }

    //    static Func<int, int> GetClosureFunction()
    //    {
    //        DisplayClass displayClass = new DisplayClass();
    //        displayClass.val = 10;
    //        Func<int, int> internalAdd = displayClass.AnonymousFunction;

    //        Console.WriteLine(internalAdd(10));

    //        displayClass.val = 30;
    //        Console.WriteLine(internalAdd(10));

    //        return internalAdd;
    //    }
    //}
}
