﻿using System;

namespace 建议47_即使提供了显式释放方法也应该在终结器中提供隐式清理
{
    public class Class1
    {
//        在标准的Dispose模式中，我们注意到一个以~开头的方法，如下：
//        /// <summary>
//        /// 必须，防止程序员忘记了显式调用Dispose方法
//        /// </summary>
//        ~SampleClass()
//        {
//            //必须为false
//            Dispose(false);
//        }

//        这个方法叫做类型的终结器。提供类型终结器的意义在于，我们不能奢望类型的调用者肯定会主动调用Dispose方法，基于终结器会被垃圾回收这个特点，它被用作资源释放的补救措施。
//
//        在.NET中每次使用new操作符创建对象时，CLR都会为该对象在堆上分配内存。对于没有继承IDisposable接口的类型对象，垃圾回收器则会直接释放对象所占用的内存：而对于实现了Dispose模式的类型，每次创建对象的时候，CLR都会将该对象的一个指针放到终结列表中，垃圾回收器在回收该对象的内存前，首先将终结列表中的指针放到一个freachable队列中。同时，CLR还会分配专门的线程读取freachable队列，并调用对象的终结器，只有这个时候对象才会真正被识别为垃圾，并且在下一次进行垃圾回收时释放对象所占的内存。
//
// 
//
//        可见，实现了Dispose模式的类型对象，起码要经过两次垃圾回收才能真正地被回收掉，应为垃圾回收机制会安排CLR调用终结器。基于这个特点，如果我们的类型提供了显式释放的方法来减少一次垃圾回收，同时也可以在终结器中提供隐式清理，以避免调用者忘记调用该方法而带来的资源泄漏。
//
//        注意：有的文档中，终结器也称为析构器。析构器的叫法沿袭了C++中的称谓，因为两者形式非常接近，但两者实现机制还是不太一致，所以后来微软确定这个方法在C#中的名称为终结器。
//
// 
//        如果调用者已经调用Dispose方法进行了显式地资源释放，那么，隐式资源释放（就是终结器）就没有必要再运行了。FCL中的类型GC提供了静态方法SuppressFinalize来通知垃圾回收器这一点。
    }
}