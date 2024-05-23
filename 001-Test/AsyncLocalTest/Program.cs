//AsyncLocal<string> test = new AsyncLocal<string>();

//test.Value = "111";

//await Test1();

//Console.WriteLine(test.Value);

//Test2();

//Console.WriteLine(test.Value);

//Console.ReadKey();

namespace TaskTest
{
    class Program
    {
        static AsyncLocal<string> test = new AsyncLocal<string>();

        static async Task Main(string[] args)
        {
            test.Value = "111";

            Test1();

            Console.WriteLine(test.Value);

            await Test1();

            Console.WriteLine(test.Value);

            Test2();

            Console.WriteLine(test.Value);

            Console.ReadKey();
        }


        static Task Test1()
        {
            test.Value = "222";

            return Task.CompletedTask;
        }


        static async Task Test2()
        {
            test.Value = "333";
        }

    }
}


