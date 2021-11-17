using SevenTiny.Bantina.Aop;
using System;
using System.Collections.Generic;
using Test.SevenTiny.Bantina.Aop;

namespace EmitAOP
{
    class Program
    {
        static void Main(string[] args)
        {
            FaultTolerantOfRealize();
            Console.ReadKey();
        }


        // 实现方式动态代理
        public static void FaultTolerantOfRealize()
        {
            IBusinessClass Instance = DynamicProxy.CreateProxyOfRealize<IBusinessClass, BusinessClass>();
            //IBusinessClass Instance = new BusinessClassProxy();

            Instance.Test();
            //Instance.GetInt(123);
            //Instance.NoArgument();
            //Instance.ThrowException();
            //Instance.ArgumentVoid(123, "123");
            //Instance.GetBool(false);
            //Instance.GetString("123");
            //Instance.GetFloat(123f);
            //Instance.GetDouble(123.123);
            //Instance.GetObject(null);
            //Instance.GetOperateResult(123, "123");
            //Instance.GetOperateResults(new List<OperateResult>());
            //Instance.GetDecimal(123.123m);
            //Instance.GetDateTime(DateTime.Now);

        }
    }
}
