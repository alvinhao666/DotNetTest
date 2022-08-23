using System;
using System.Collections.Generic;

namespace 建议10_创建对象时需要考虑是否实现比较器
{

    //有对象的地方就会存在比较，在.NET的世界中也一样。举个最简单的例子，在UI中，有一个10个人的Salary列表。根据排序的需要，列表要支持针对基本工资来罗列Salary。这个时候，接口IComparable就会起作用，代码如下所示：
    class Program
    {
        static void Main(string[] args)
        {
            List<Salary> companySalary = new List<Salary>();
            companySalary.Add(new Salary() { Name = "Mike", BaseSalary = 3000 });
            companySalary.Add(new Salary() { Name = "Rose", BaseSalary = 2000 });
            companySalary.Add(new Salary() { Name = "Jeffry", BaseSalary = 1000 });
            companySalary.Add(new Salary() { Name = "Steve", BaseSalary = 4000 });
            companySalary.Sort();
            foreach (Salary item in companySalary)
            {
                Console.WriteLine(item.Name + "\t BaseSalary: " + item.BaseSalary.ToString());
            }

            List<Salary> companySalary2 = new List<Salary>();
            companySalary2.Add(new Salary() { Name = "Mike", BaseSalary = 3000, Bonus = 1000 });
            companySalary2.Add(new Salary() { Name = "Rose", BaseSalary = 2000, Bonus = 4000 });
            companySalary2.Add(new Salary() { Name = "Jeffry", BaseSalary = 1000, Bonus = 6000 });
            companySalary2.Add(new Salary() { Name = "Steve", BaseSalary = 4000, Bonus = 3000 });
            companySalary2.Sort(new BonusComparer());    //提供一个非默认的比较器  
            foreach (Salary item in companySalary2)
            {
                Console.WriteLine(string.Format("Name:{0} \tBaseSalary:{1} \tBonus:{2}",
                    item.Name, item.BaseSalary, item.Bonus));
            }

            Console.ReadKey();
        }
    }

    class Salary : IComparable
    {
        public string Name { get; set; }
        /// <summary>
        /// 基本工资
        /// </summary>
        public int BaseSalary { get; set; }
        /// <summary>
        /// 奖金
        /// </summary>
        public int Bonus { get; set; }

        #region IComparable 成员  

        public int CompareTo(object obj)
        {
            Salary staff = obj as Salary;
            if (BaseSalary > staff.BaseSalary)
            {
                return 1;
            }
            else if (BaseSalary == staff.BaseSalary)
            {
                return 0;
            }
            else
            {
                return -1;
            }
            //return BaseSalary.CompareTo(staff.BaseSalary);   上面代码中CompareTo方法有一条注释的代码，其实本方法完全可以使用该注释代码代替，因为利用了整型的默认比较方法。此处未使用本注释代码，是为了更好地说明比较器的工作原理。
        }

        #endregion
    }

    //现在，问题来了：如果不想以基本工资BaseSalary进行排序，而是以奖金Bonus进行排序，该如何处理呢？这个时候，接口IComparer的作用就体现出来了，可以使用IComparer来实现一个自定义的比较器。如下所示：
    class BonusComparer : IComparer<Salary>
    {
        #region IComparer 成员  

        public int Compare(Salary x, Salary y)
        {

            return x.Bonus.CompareTo(y.Bonus);
        }

        #endregion
    }
}
