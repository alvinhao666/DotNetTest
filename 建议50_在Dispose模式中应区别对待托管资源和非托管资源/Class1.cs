﻿using System;

namespace 建议50_在Dispose模式中应区别对待托管资源和非托管资源
{
    public class Class1
    {
//        真正资源释放代码的那个虚方法是带一个bool参数的，带这个参数，是因为我们在资源释放时要区别对待托管资源和非托管资源。
//
//        提供给调用者调用的显式释放资源的无参Dispose方法中，调用参数是true：
//
//        public void Dispose()
//        {
//            //必须为true
//            Dispose(true);
//            //省略其他代码
//        }
//        这表明，这时候代码要同时处理托管资源和非托管资源。
//
//        在供垃圾回收器调用的隐式清理资源的终结器中，调用的是false：
//
//        ~SampleClass()
//        {
//            //必须为false
//            Dispose(false);
//        }
//        这表明，隐式清理时，只要处理非托管资源就可以了。
//
//        为什么要区别对待托管资源和非托管资源呢？在这个问题前，我们首先要弄明白：托管资源需要手工清理吗？不妨将C#中的类型分为两类，一类继承了IDisposable接口，一类则没有继承。前者，暂时称为非普通类型，后者称为普通类型。非普通类型因为包含非托管资源，所以它需要继承IDisposable接口，但是，这里包含非托管资源的类型本身，它是一个托管资源。所以，托管资源中的普通类型不需要手动清理，而非普通类型是需要手工清理的（即调用Dispose方法）。
//
//
//            Dispose模式设计的思路是：如果调用者显式调用了Dispose方法，那么类型就应该按部就班地将自己的资源全部释放。如果调用者忘记调用Dispose方法，那么类型就假设自己的所有托管资源（哪怕是那些非普通类型）会全部都交给垃圾回收器回收，所以不进行手工清理。所以在Dispose方法中，虚方法传入参数true，在终结器中，虚方法传入参数false。
    }
}