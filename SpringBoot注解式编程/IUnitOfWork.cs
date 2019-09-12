using System;

namespace SpringBoot注解式编程
{
    public interface IUnitOfWork:IDisposable
    {
        /// <summary>
        /// 开启事务
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// 提交
        /// </summary>
        void Commit();

        /// <summary>
        /// 回滚
        /// </summary>
        void RollBack();
    }


    public class UnitOfWork : IUnitOfWork
    {
        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public void BeginTransaction()
        {
            Console.WriteLine("开启事务");
        }

        public void Commit()
        {
            Console.WriteLine("提交事务");
        }

        public void RollBack()
        {
            Console.WriteLine("回滚事务");
        }
    }
}