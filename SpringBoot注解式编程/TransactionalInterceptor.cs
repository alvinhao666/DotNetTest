using System;
using System.Reflection;
using Castle.DynamicProxy;

namespace SpringBoot注解式编程
{
    /// <summary>
    /// 事务拦截器
    /// </summary>
    public class TransactionalInterceptor:StandardInterceptor
    {
        private IUnitOfWork _unitOfWork;

        public TransactionalInterceptor(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected override void PreProceed(IInvocation invocation)
        {
            Console.WriteLine($"{invocation.Method.Name}拦截前");

            var method = invocation.TargetType.GetMethod(invocation.Method.Name);
            if (method != null && method.GetCustomAttribute<TransactionalAttribute>() != null)
            {
                _unitOfWork.BeginTransaction();
            }
        }
        
        protected override void PerformProceed(IInvocation invocation)
        {
            invocation.Proceed();
        }
        
        protected override void PostProceed(IInvocation invocation)
        {
            Console.WriteLine("{0}拦截后， 返回值是{1}", invocation.Method.Name, invocation.ReturnValue);

            var method = invocation.TargetType.GetMethod(invocation.Method.Name);
            if (method != null && method.GetCustomAttribute<TransactionalAttribute>() != null)
            {
                _unitOfWork.Commit();
            }
        }
    }
}