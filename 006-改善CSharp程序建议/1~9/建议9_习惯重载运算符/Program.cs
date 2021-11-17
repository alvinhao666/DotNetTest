using System;

namespace 建议9_习惯重载运算符
{
    class Program
    {
        static void Main(string[] args)
        {
            Salary mikeIncome = new Salary() { RMB = 22 };
            Salary roseIncome = new Salary() { RMB = 33 };
            //Salary familyIncome = Salary.Add(mikeIncome, roseIncome);

            Salary familyIncome = mikeIncome + roseIncome;
        }
    }

    class Salary
    {
        public int RMB { get; set; }

        public static Salary operator +(Salary s1, Salary s2)
        {
            s2.RMB += s1.RMB;
            return s2;
        }
    }

}
