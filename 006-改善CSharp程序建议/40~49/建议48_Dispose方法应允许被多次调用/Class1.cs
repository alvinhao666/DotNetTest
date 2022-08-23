namespace 建议48_Dispose方法应允许被多次调用
{
    public class Class1
    {
        //        一个类型的Dispose方法应该允许被多次调用而不抛出异常。鉴于此，类型内部维护了一个私有的bool变量disposed，如下：
        //
        //        private bool disposed = false;
        //        在实际清理代码的方法中，加入一下判断：
        //
        //        if(disposed)
        //        {
        //            return;       
        //        }
        ////省略清理部分的代码，并在方法最后为disposed赋值为true
        //        disposed = true;
        //        这意味着，如果类型已经被清理过，那么清理工作将不再进行。
        //
        //        对象被调用过Dispose方法，并不表示该对象被置为null，且被垃圾回收机制回收过内存，已经彻底储存在了。事实上，对象的引用可能还在。但是，对象被Dispose过，说明对象的正常状态已经不存在了，此时如果调用对象的公开的方法，应该会抛出一个ObjectDisposedException。方法SamplePublicMethod为我们演示了该方法：
        //
        //        复制代码
        //        public void SamplePublicMethod()
        //        {
        //            if (disposed)
        //            {
        //                throw new ObjectDisposedException("SampleClass", "SampleClass is disposed");
        //            }
        //            //省略
        //        }
        //        复制代码
        //            所以，在Dispose模式中，应该始终为类型创建一个变量，用来表示对象是否Dispose过。
    }
}