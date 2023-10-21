using FreeSql;
using FreeSql.DataAnnotations;
using FreeSql.Internal;
using FreeSql.Internal.Model;

namespace FreeSqlMapTypeDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IFreeSql fsql = new FreeSqlBuilder()
                            .UseConnectionString(DataType.MySql, "")
                            .UseAutoSyncStructure(true)
                            .Build();

            Utils.TypeHandlers.TryAdd(typeof(Ulid), new String_UlidHandler());

            var entity = new TestM { Id = Ulid.NewUlid(), Name = "张三" + new Random().Next(1, 9999) };

            fsql.Insert(entity).ExecuteAffrows();

            var rep = new TestRepository(fsql);

            entity = new TestM { Id = Ulid.NewUlid(), Name = "张三" + new Random().Next(1, 9999) };
            rep.Insert(entity);

            //var data = fsql.Select<TestM>().ToList();

            var data = rep.Select.ToList();

            Console.WriteLine("完成");
            Console.ReadKey();
        }
    }

    class String_UlidHandler : TypeHandler<Ulid>
    {
        public override object Serialize(Ulid value)
        {
            return value.ToString();
        }

        public override Ulid Deserialize(object value)
        {
            return Ulid.Parse((string)value);
        }
    }

    public abstract class Entity<TKey>
    {
        /// <summary>
        /// 主键id
        /// </summary>
        [Column(IsPrimary = true, MapType = typeof(string), StringLength = 26)]
        public virtual TKey Id { get; set; } = default!;
    }

    public class TestM : Entity<Ulid>
    {
        public string Name { get; set; } = string.Empty;
    }


    public class TestRepository : DefaultRepository<TestM, Ulid>
    {
        public TestRepository(IFreeSql fsql) : base(fsql)
        {
        }
    }
}