namespace 建议90_不要为抽象类提供公开的构造方法
{
    public class Class1
    {
        //        首先，抽象类可以有构造方法。即使没有为抽象类指定构造方法，编译器也会为我们生成一个默认的protected的构造方法。下面是一个标准的最简单的抽象类：
        //
        //        abstract class MyAbstractClass
        //        {
        //            protected MyAbstractClass(){}
        //        }
        //        其次，抽象类的方法不应该是public或internal的。抽象类设计的本意是让子类继承，而不是用于生成实例对象的。如果抽象类是public或internal的，它对于其它类型来说就是可见的，而这时不必要的，也是多余的。换句话来说，抽象类只需要对子类可见就行了。
    }
}