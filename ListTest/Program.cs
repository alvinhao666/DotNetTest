using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ListTest
{
    class Program
    {
        static void Main(string[] args)
        {
            #region List分组
            List<string> lst = new List<string>() { "1", "2", "3", "4", "5", "6" };

            List<List<string>> listGroup = new List<List<string>>();
            int j = 3;
            for (int i = 0; i < lst.Count; i += 3)
            {
                Console.WriteLine(i);
                List<string> cList = new List<string>();
                cList = lst.Take(j).Skip(i).ToList();
                j += 3;
                listGroup.Add(cList);
            }
            #endregion

            #region SortDictionary
            var dic = JsonConvert.DeserializeObject<SortedDictionary<string, object>>("{\"a\":\"1\",\"c\":\"我\"}");
            SortedDictionary<string, object> keyValues = new SortedDictionary<string, object>(dic);
            keyValues.OrderBy(m => m.Key);//按照键排序
            #endregion


            #region Select&SelectMany
            string[] text = { "Albert was here", "Burke slept late", "Connor is happy" };
            var tokens = text.Select(s => s.Split(" "));
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (string[] line in tokens)
            {
                foreach (string token in line)
                {
                    Console.WriteLine("{0}", token);
                }
            }


            string[] text2 = { "Albert was here", "Burke slept late", "Connor is happy" };
            Console.ForegroundColor = ConsoleColor.Red;
            var tokens2 = text2.SelectMany(s => s.Split(' '));
            foreach (string token in tokens2)
            {
                Console.WriteLine("{0}", token);
            }
            #endregion

            #region 去重
            var apps = new List<int>(){ 1,2,3,1,2,4,1};
            var levels = apps.Distinct().ToList();
            #endregion

            #region 序列化
            List<ulong> ls = new List<ulong>() { 1,2,3};
            string lsStr = JsonConvert.SerializeObject(ls);

            lsStr = "[]";
            ls = JsonConvert.DeserializeObject<List<ulong>>(lsStr);
            #endregion

            var levelList = new List<int> { 1,2,3,4};

            var applist = new List<App> { new App() { Level = 1, Number = 1 }, new App { Level = 2, Number = 4 }, new App { Level = 1, Number = 8 } };

            ulong[] auths = new ulong[levelList.Count];

            foreach (var item in applist)
            {
                int index = levelList.IndexOf(item.Level);
                if (index>-1)
                {
                    auths[index] = auths[index] | item.Number;
                }
            }
            
            #region Foreach
            List<Person> lstInt = new List<Person>() { new Person() { Age = 1 }, new Person() { Age = 2 } };
            lstInt.ForEach(b =>
            {
                b.Age = b.Age + 1;
            });//有变化


            foreach (var b in lstInt)
            {
                b.Age = b.Age + 1;
            }//有变化

            lstInt.ForEach(b =>
            {
                b = new Person();
            });//没变化

            var n = lstInt;


            List<int> ints = new List<int>() { 1, 2, 3 };
            ints.ForEach(x => {
                x = x + 1;
            }); //没变化

            List<String> intss = new List<String>() { "1", "1", "1" };
            intss.ForEach(x => {
                x = x + 1;
            });//没变化

            #endregion


            lst = new List<string>() { "1","23"};

            Console.WriteLine(string.Join(",", lst));
            Console.WriteLine();

            List<string> list = new List<string>();
            list=list.DefaultIfEmpty("").ToList();

            Console.WriteLine(levelList.Where(x => x == 66).Sum(x => 5));

            Console.WriteLine("xxx");
            List<Person> persons = new List<Person>();
            persons.Add(new Person { Age = 1 });
            persons.Add(new Person { Age = 2});
            persons.Add(new Person { Age = 3});
            var persons2 = persons.Where(x => x.Age != 1);
            foreach(var item in persons2)
            {
                Console.WriteLine(item.Age);
            }



            var level1s = new List<Level1> { new Level1() { Id=1,Name="1"} };
            var level2s = new List<Level2> { new Level2() { Id = 2, Name = "2",Id1=1 }, new Level2() { Id = 3, Name = "3", Id1 = 1 } };

            var level3s = new List<Level3> { new Level3() { Id = 4, Name = "5", Id2 = 2 }, new Level3() { Id = 5, Name = "5", Id2 = 3 } };

            var list12 = new List<Level2>();
            foreach (var item in level1s)
            {
                list12 = level2s.Where(a => a.Id1 == item.Id).ToList();
                item.list2 = list12;
            }
            foreach(var item in level2s)
            {
                item.list3 = level3s.Where(a => a.Id2 == item.Id).ToList();
            }

            Console.WriteLine(list12[0] == level2s[0]); // True  where之后两个集合得元素还是同一个元素
            //Console.WriteLine(list12[0] == level2s[1]); // True
            
            
            lst = new List<string>() { "1","23","4"};
            var lst1=lst;
            var lst2 = lst.FindAll(a => a == "1").ToList();

            //List<string> ssslst = null;
            //foreach(var item in ssslst) //报错
            //{
            //    Console.WriteLine("1");
            //}
            lst1[0]="666";
            Console.WriteLine(lst[0]); // 666
            Console.WriteLine(lst1[0]); // 666
            Console.WriteLine(lst2.Count);

            //去重
            var drivers = new List<Person> { new Person { Name = "张三", Age = 10 }, new Person { Name = "张三", Age = 10 } };

            var newList = drivers.Distinct(new DistinctTest<Person>()).ToList();

            Console.ReadKey();
        }
    }


    class DistinctTest<TModel> : IEqualityComparer<TModel>
    {
        public bool Equals(TModel x, TModel y)
        {
            //Test
            Person t = x as Person;
            Person tt = y as Person;
            if (t != null && tt != null) return t.Name == tt.Name;
            return false;
        }

        public int GetHashCode(TModel obj)
        {
            return obj.ToString().GetHashCode();
        }
    }


    public class App
    {
        public int Level { get; set; }

        public ulong Number { get; set; }
    }
    
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }



    public class Level1
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Level2> list2 { get; set; }
    }

    public class Level2
    {
        public int  Id { get; set; }
        public int  Id1 { get; set; }

        public string Name { get; set; }

        public List<Level3> list3 { get; set; }
    }


    public class Level3
    {
        public int Id { get; set; }

        public int Id2 { get; set; }

        public string Name { get; set; }
    }
}
