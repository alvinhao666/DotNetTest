using System;

namespace 位于权限
{
    class Program
    {
        static void Main(string[] args)
        {
            //定于权限 2的n次方
            var ADD = 1; // 增加权限
            var UPD = 2; // 修改权限
            var SEL = 4; // 查找权限
            var DEL = 8; // 删除权限

            // 给予某种权限用到"位或"运算符
            var GROUP_A = ADD | UPD | SEL | DEL; // A 拥有增删改查权限
            var GROUP_B = ADD | UPD | SEL; // B 拥有增改查权限
            var GROUP_C = ADD | UPD; // C 拥有增改权限

            // 禁止某种权限用"位与"和"位非"运算符
            var GROUP_D = GROUP_A & ~UPD & ~SEL; // D 只拥有了增权限


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

            Console.ReadKey();
        }
    }
}
