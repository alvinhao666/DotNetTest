using Autofac.Extras.DynamicProxy;

namespace AopDemo2
{
    public interface IBaseTestService
    {
        string GetString();
    }

    public interface ITestService1 : IBaseTestService { }
    public interface ITestService2 : IBaseTestService { }
    public interface ITestService3 : IBaseTestService { }

    [Intercept(typeof(AOPTest))]
    public class TestService1 : ITestService1
    {
        private string str { get; set; }
        public TestService1()
        {
            str = "方法1";
        }
        public string GetString()
        {
            return str;
        }
    }

    public class TestService2 : ITestService2
    {
        private string str { get; set; }
        public TestService2()
        {
            str = "方法2";
        }
        public string GetString()
        {
            return str;
        }
    }

    public class TestService3 : ITestService3
    {
        private string str { get; set; }
        public TestService3()
        {
            str = "方法3";
        }
        public string GetString()
        {
            return str;
        }
    }
}
