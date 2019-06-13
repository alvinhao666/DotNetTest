using System;
using System.Linq.Expressions;

namespace LambdaAndExpression
{
    /// <summary>
    /// 创建一个委托
    /// </summary>
    /// <param name="x"></param>
    public delegate void Del(int x);
    class Program
    {
        static void Main(string[] args)
        {
            Del d = delegate (int x) { Console.WriteLine(x); };

            ////Lambda 表达式是一种可用于创建委托或表达式目录树类型的匿名函数。
            //若要创建 Lambda 表达式，需要在 Lambda 运算符 => 左侧指定输入参数（如果有），然后在另一侧输入表达式或语句块。
            //仅当 lambda 只有一个输入参数时，括号才是可选的；否则括号是必需的。 括号内的两个或更多输入参数使用逗号加以分隔：
            Del del = x => Console.WriteLine(x);


            del(2);//4
            //若要创建表达式目录树，可以这样：

            Expression<Del> expression = x => Console.WriteLine(x);

            var compiledLambda = expression.Compile();
            //var result = compiledLambda.DynamicInvoke(5);
            compiledLambda(5);


            Expression<Func<int, bool>> expression2 = num => num >= 5;
            var a = expression2.Compile();
            var flag = a(3);

            //在表达式树中使用ParameterExpression或者ParameterExpression表达式表示变量类型，下面看一个例子，我们定义一个int类型的变量i：
            // ParameterExpression表示命名的参数表达式。
            ParameterExpression i = Expression.Parameter(typeof(int), "i");

            ParameterExpression j = Expression.Variable(typeof(int), "j");
            //发现这两个方法的注释几乎是一样的。静态方法Parameter第一个参数：定义的参数类型，第二个参数：为参数名称。
            Console.ReadKey();
        }


        static void Test()
        {
            //创建lambda表达式 num=>num>=5
            //第一步创建输入参数,参数名为num，类型为int类型
            ParameterExpression numParameter = Expression.Parameter(typeof(int), "num");
            //第二步创建常量表达式5，类型int
            ConstantExpression constant = Expression.Constant(5, typeof(int));
            //第三步创建比较运算符>=,大于等于,并将输入参数表达式和常量表达式输入
            //表示包含二元运算符的表达式。BinaryExpression继承自Expression
            BinaryExpression greaterThanOrEqual = Expression.GreaterThanOrEqual(numParameter, constant);
            //第四步构建lambda表达式树
            //Expression.Lambda<Func<int, bool>>:通过先构造一个委托类型来创建一个 LambdaExpression
            Expression<Func<int, bool>> lambda = Expression.Lambda<Func<int, bool>>(greaterThanOrEqual, numParameter);
        }

    }
}
