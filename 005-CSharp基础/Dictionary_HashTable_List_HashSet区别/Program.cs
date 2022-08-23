using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Dictionary_HashTable_List_HashSet区别
{
    class Program
    {
        #region
        //同样是集合，为什么性能会有这样的差距。我们要从存储结构和操作系统的原理谈起。
        //首先我们清楚List<T> 是对数组做了一层包装，我们在数据结构上称之为线性表，而线性表的概念是，在内存中的连续区域，除了首节点和尾节点外，每个节点都有着其唯一的前驱结点和后续节点。我们在这里关注的是连续这个概念。
        //而HashTable或者Dictionary，他是根据Key而根据Hash算法分析产生的内存地址，因此在宏观上是不连续的，虽然微软对其算法也进行了很大的优化。
        //由于这样的不连续，在遍历时，Dictionary必然会产生大量的内存换页操作，而List只需要进行最少的内存换页即可，这就是List和Dictionary在遍历时效率差异的根本原因。
        //Dictionary的存储空间问题，在Dictionary中，除了要存储我们实际需要的Value外，还需要一个辅助变量Key，这就造成了内存空间的双重浪费。
        //而且在尾部插入时，List只需要在其原有的地址基础上向后延续存储即可，而Dictionary却需要经过复杂的Hash计算，这也是性能损耗的地方。
        #endregion
        static void Main(string[] args)
        {

            #region Hashtable 哈希表（散列表）
            //1.HashTable不支持泛型
            //2.HashTable中key-value键值对均为object类型,所以在存储或检索值类型时通常发生装箱和拆箱的操作，所以你可能需要进行一些类型转换的操作，而且对于int,float这些值类型还需要进行装箱等操作，非常耗时。
            //3.Hashtable是线程安全的，而Dictionary明显不具备如此特性。
            //4.Hashtable在查找数据时用处很大，因为速度很快，但用牺牲内存消耗作代价。QQ在查找在线用户的时候就适当的用了Hashtable。大家可以根据场合适当使用。
            Hashtable ht = new Hashtable();
            ht.Add("北京", "帝都"); //添加keyvalue键值对
            ht.Add("上海", "魔都");
            ht.Add("广州", "省会");
            ht.Add("深圳", "特区");
            ht.Add("名字", "小丽");
            ht.Add("年龄", 22);
            string capital = (string)ht["北京"];
            int age = (int)ht["年龄"];
            Console.WriteLine(ht.Contains("上海")); //判断哈希表是否包含特定键,其返回值为true或false
            ht.Remove("深圳"); //移除一个keyvalue键值对
            ht.Clear(); //移除所有元素

            foreach (DictionaryEntry de in ht) //ht为一个Hashtable实例
            {
                Console.WriteLine(de.Key);  //de.Key对应于keyvalue键值对key
                Console.WriteLine(de.Value);  //de.Key对应于keyvalue键值对value
            }
            #endregion


            #region Dictionary 字典
            //1.泛型版本的哈希表Dictionary<object,object>,Dictionary和Hashtable之间并非只是简单的泛型和非泛型的区别，两者使用了完全不同的哈希冲突解决办法
            //2.线程不安全

            #endregion

            #region ConcurrentDictionary
            //1.ConcurrentDictionary<TKey, TValue> framework4出现的，可由多个线程同时访问，且线程安全。
            #endregion


            #region HashSet<T>

            //.NET 3.5在System.Collections.Generic命名空间中包含一个新的集合类：HashSet<T>
            //HashSet<T>类主要是设计用来做高性能集运算的，例如对两个集合求交集、并集、差集等。
            //集合中包含一组不重复出现且无特性顺序的元素，HashSet拒绝接受重复的对象
            // HashSet<T> 的一些特性如下:

            //a.HashSet<T> 中的值不能重复且没有顺序。

            // b.HashSet<T> 的容量会按需自动添加。
            HashSet<Student> hashSet = new HashSet<Student>();

            var s1 = new Student { Name = "张三", Age = 20 };

            hashSet.Add(s1);
            hashSet.Add(s1);

            var s2 = new Student { Name = "张三", Age = 20 };
            hashSet.Add(s2);

            Console.WriteLine(JsonConvert.SerializeObject(hashSet)); //输出两个张三

            #endregion



            Console.ReadKey();
        }
    }


    public class Student
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
}
