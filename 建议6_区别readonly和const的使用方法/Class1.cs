using System;

namespace 建议6_区别readonly和const的使用方法
{

    //很多初学者分不清readonly和const的使用场合。在我看来，要使用const的理由只有一个，那就是效率。但是，在大部分应用情况下， “效率”并没有那么高的地位，所以我更愿意采用readonly，因为readonly赋予代码更多的灵活性。const和readonly的本质区别如 下：

    //const是一个编译期常量，readonly是一个运行时常量。

    //const只能修饰基元类型、枚举类型或字符串类型，readonly没有限制。

    //关于第一个区别，因为const是编译期常量，所以它天然就是static的，不能手动再为const增加一个static修饰符，

    //而之所以说const变量的效率高，是因为经过编译器编译后，我们在代码中引用const变量的地方会用const变量所对应的实际值来代替，如：

    //Console.WriteLine(ConstValue); 

    //和下面的代码生成的IL代码是一致的：

    //Console.WriteLine(100); 


    //readonly变量是运行时变量，其赋值行为发生在运行时。readonly的全部意义在于，它在运行时第一次被赋值后将不可以改变。当然，“不可以改变”分为两层意思：

    //1）对于值类型变量，值本身不可改变（readonly，只读）。

    //2）对于引用类型变量，引用本身（相当于指针）不可改变。
    public class Class1
    {
    }
}
