using System;

namespace 建议49_在Dispose模式中应提取一个受保护的虚方法
{
    public class Class1
    {
//        在标准的Dispose模式中，真正的IDisposable接口的Dispose方法并没有做实际的清理工作，它其实是调用了下面的这个带bool参数且受保护的的虚方法
//        /// <summary>
//        /// 非密封类修饰用protected virtual
//        /// 密封类修饰用private
//        /// </summary>
//        /// <param name="disposing"></param>
//        protected virtual void Dispose(bool disposing)
//        {
//            //省略代码
//        }        
//            
//            之所以提供这样一个受保护的虚方法，是因为考虑了这个类型会被其他类型继承的情况。如果类型存在一个子类，子类也许会实现自己的Dispose模式。受保护的虚方法用来提醒子类：必须在自己的清理方法时注意到父类的清理工作，即子类需要在自己的释放方法中调用base.Dispose方法。
    }
}