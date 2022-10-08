using Hao;
using System;


namespace 有序不重复GUID
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i <= 1000; i++)
            {
                //Console.WriteLine(Util.NewMongodbId());
                Console.WriteLine(SequentialGuidHelper.Create(SequentialGuidDatabaseType.MySql));
            }

            Console.ReadKey();
        }
    }
}
