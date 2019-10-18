using System;

namespace 位于权限
{
    class Program
    {
        static void Main(string[] args)
        {
            //定于权限 2的n次方  最多2的64次方   ulong类型  20位
            var ADD = Convert.ToUInt64(Math.Pow(2, 0)); // 增加权限
            var UPD = Convert.ToUInt64(Math.Pow(2, 1)); // 修改权限
            var SEL = Convert.ToUInt64(Math.Pow(2, 2)); // 查找权限
            var DEL = Convert.ToUInt64(Math.Pow(2, 3)); // 删除权限

            // 给予某种权限用到"位或"运算符
            var GROUP_A = ADD | UPD | SEL | DEL; // A 拥有增删改查权限
            var GROUP_B = ADD | UPD | SEL; // B 拥有增改查权限
            var GROUP_C = ADD | DEL; // C 拥有增改权限

            // 禁止某种权限用"位与"和"位非"运算符
            var GROUP_D = GROUP_A & ~UPD & ~SEL; // D 只拥有了增权限


            Console.WriteLine(0 | 1);

            Console.WriteLine(0 | 2);



            Console.WriteLine(0 | 3);
            Console.WriteLine(0 | 11);
            Console.WriteLine(0 | 100);

            //检测某个用户是否有这个权限
            Console.WriteLine("A用户组成员是否有增加权限" + ((GROUP_A & ADD) > 0));
            Console.WriteLine("A用户组成员是否有删除权限" + ((GROUP_A & DEL) > 0));

            Console.WriteLine("B用户组成员是否有增加权限" + ((GROUP_B & ADD) > 0));
            Console.WriteLine("B用户组成员是否有删除权限" + ((GROUP_B & DEL) > 0));

            Console.WriteLine("C用户组成员是否有增加权限" + ((GROUP_C & ADD) > 0));
            Console.WriteLine("C用户组成员是否有删除权限" + ((GROUP_C & DEL) > 0));

            Console.WriteLine("D用户组成员是否有增加权限" + ((GROUP_D & ADD) > 0));
            Console.WriteLine("D用户组成员是否有修改权限" + ((GROUP_D & UPD) > 0));
            Console.WriteLine("D用户组成员是否有查找权限" + ((GROUP_D & SEL) > 0));
            Console.WriteLine("D用户组成员是否有删除权限" + ((GROUP_D & DEL) > 0));




            Console.WriteLine(long.MaxValue);//9223372036854775807  19位   负号- 20位

            Console.WriteLine(ulong.MaxValue);//18446744073709551615 20位 


            //Console.WriteLine(Convert.ToInt64(Math.Pow(2, 64))); //报错

            Console.WriteLine(Convert.ToUInt64(Math.Pow(2, 63))); //9223372036854775808 19位

            //Console.WriteLine(Convert.ToUInt64(Math.Pow(2, 64))); //报错

            Console.WriteLine(Math.Pow(2, 64));//18446744073709551616 20位

            ulong sum = Convert.ToUInt64(Math.Pow(2, 0));
            for (int i = 1; i <= 63; i++)
            {
                sum = sum | Convert.ToUInt64(Math.Pow(2, i));
            }
            Console.WriteLine(sum); //18446744073709551615 一共64个
            Console.WriteLine(18446744073709551615 & 2); //18446744073709551615 一共64个


            Console.WriteLine(8804682956799 & 8796093022208);

            Console.ReadKey();
        }
    }
}
