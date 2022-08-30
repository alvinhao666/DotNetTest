using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.Core.Logging;
using Castle.DynamicProxy;
using System;
using System.IO;
using System.Linq;

namespace AutofacTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<First>()
                   .EnableClassInterceptors();

            builder.RegisterType<First2>()
                    .EnableClassInterceptors();

            builder.Register(c => new CallLogger());

            var container = builder.Build();

            var first = container.Resolve<First>();

            first.GetValue();

            var first2 = container.Resolve<First2>();

            first2.GetValue();

            // Using the NAMED attribute:
            var builder2 = new ContainerBuilder();
            builder2.RegisterType<Second>()
                   .EnableClassInterceptors();
            builder2.Register(c => new CallLogger())
                   .Named<IInterceptor>("log-calls");

       
            Console.ReadLine();
        }
    }


    // This attribute will look for a TYPED
    // interceptor registration:
    [Intercept(typeof(CallLogger))]
    public class First
    {
        public virtual void GetValue()
        {
            // Do some calculation and return a value

            Console.WriteLine("FirstGetValue");
        }
    }

    [Intercept(typeof(CallLogger))]
    public class First2: BaseFirst
    {
        public override void GetValue()
        {
            // Do some calculation and return a value

            Console.WriteLine("First2222GetValue");
        }
    }

    public abstract class BaseFirst
    {
        public abstract void GetValue();
    }

    // This attribute will look for a NAMED
    // interceptor registration:
    [Intercept("log-calls")]
    public class Second
    {
        public virtual void GetValue()
        {
            // Do some calculation and return a value
            Console.WriteLine("SecondValue");
        }
    }

    public class CallLogger : IInterceptor
    {
        public CallLogger()
        {
        }

        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("Calling method {0} with parameters {1}... ",
              invocation.Method.Name,
              string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()).ToArray()));

            invocation.Proceed();

            Console.WriteLine("Done: result was {0}.", invocation.ReturnValue);
            Console.WriteLine();
        }
    }
}
