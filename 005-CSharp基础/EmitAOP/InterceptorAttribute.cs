using SevenTiny.Bantina.Aop;
using System;

namespace Test.SevenTiny.Bantina.Aop
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class InterceptorAttribute : InterceptorBaseAttribute
    {
        public override object Invoke(object @object, string method, object[] parameters)
        {
            Console.WriteLine(string.Format("interceptor does something before invoke [{0}]...", @method));

            object obj = null;

            try
            {
                obj = base.Invoke(@object, method, parameters);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine(string.Format("interceptor does something after invoke [{0}]...", @method));

            return obj;
        }
    }
}
