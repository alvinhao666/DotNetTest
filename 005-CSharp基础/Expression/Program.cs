using System;
using System.Linq.Expressions;

namespace Test
{
    //https://www.cnblogs.com/Ninputer/archive/2009/08/28/expression_tree1.html
    class Program
    {
        static void Main(string[] args)
        {
            //ConstantExpression _constExp = Expression.Constant("aaa", typeof(string));//一个常量
            //                                                                          //Console.Writeline("aaa");
            //MethodCallExpression _methodCallexp = Expression.Call(typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }), _constExp);
            //Expression<Action> consoleLambdaExp = Expression.Lambda<Action>(_methodCallexp);
            //consoleLambdaExp.Compile()();


            ParameterExpression _parameExp = Expression.Parameter(typeof(string), "MyParameter");

            MethodCallExpression _methodCallexpP = Expression.Call(typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }), _parameExp);
            Expression<Action<string>> _consStringExp = Expression.Lambda<Action<string>>(_methodCallexpP, _parameExp);
            _consStringExp.Compile()("Hello!!");

            User user = new User { Name = "123" };

            UpdateAsync<User>(user => new { });

            Console.ReadLine();
        }


        static void UpdateAsync<T>(Expression<Func<T, object>> columns)
        {

            var properties = columns.Body.Type.GetProperties();
            Console.WriteLine(properties.Length);
        }
    }


    public class User
    {
        public string Name { get; set; }
    }
}
