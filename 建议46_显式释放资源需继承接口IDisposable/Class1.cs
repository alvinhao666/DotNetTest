using System;
using System.Runtime.InteropServices;

namespace 建议46_显式释放资源需继承接口IDisposable
{
//    C#中的每一个类型都代表一种资源，资源分为两类：
//
//    托管资源：由CLR管理分配和释放的资源，即从CLR里new出来的对象。
//
//    非托管资源：不受CLR管理的对象，如Windows内核对象，或者文件、数据库连接、套接字、COOM对象等。
//    继承IDisposable接口也为实现语法糖using带来了便利。如：
//    using (SampleClass cl = new SampleClass())
//    {
//    //省略
//    }
//    等价于：
//    SampleClass cl;
//    try
//    {
//    cl == new SampleClass();
//    //省略
//    }
//    finally
//    {
//    cl.Dispose();
//    }
 public class SampleClass : IDisposable
    {
        //演示创建一个非托管资源
        private IntPtr nativeResource = Marshal.AllocHGlobal(100);
        //演示创建一个托管资源
        private AnotherResource managedResource = new AnotherResource();
        private bool disposed = false;

        /// <summary>
        /// 实现IDisposable中的Dispose方法
        /// </summary>
        public void Dispose()
        {
            //必须为true
            Dispose(true);
            //通知垃圾回收机制不再调用终结器（析构器）
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 不是必要的，提供一个Close方法仅仅是为了更符合其他语言（如
        /// C++）的规范
        /// </summary>
        public void Close()
        {
            Dispose();
        }

        /// <summary>
        /// 必须，防止程序员忘记了显式调用Dispose方法
        /// </summary>
        ~SampleClass()
        {
            //必须为false
            Dispose(false);
        }

        /// <summary>
        /// 非密封类修饰用protected virtual
        /// 密封类修饰用private
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }
            if (disposing)
            {
                // 清理托管资源
                if (managedResource != null)
                {
                    managedResource.Dispose();
                    managedResource = null;
                }
            }
            // 清理非托管资源
            if (nativeResource != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(nativeResource);
                nativeResource = IntPtr.Zero;
            }
            //让类型知道自己已经被释放
            disposed = true;
        }

        public void SamplePublicMethod()
        {
            if (disposed)
            {
                throw new ObjectDisposedException("SampleClass", "SampleClass is disposed");
            }
            //省略
        }
    }

    class AnotherResource : IDisposable
    {
        public void Dispose()
        {
        }
    }
}