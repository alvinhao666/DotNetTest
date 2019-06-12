using Sino.Domain.Entities;
using Sino.Domain.Repositories;

namespace Sino.Hf.EtcService
{
    /// <summary>
    /// 基础仓储接口
    /// </summary>
    public interface ITMSystemRepository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {

    }
}
