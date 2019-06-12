using Sino.Dependency;
using System;
using System.Threading.Tasks;

namespace Sino.Hf.EtcService
{
    /// <summary>
    /// 用于创建ID
    /// </summary>
    public interface IIdentifyProvider : ISingletonDependency
    {
        /// <summary>
        /// 创建标识符（可异步）
        /// </summary>
        Task<string> CreateIdAsync(Type type);

        /// <summary>
        /// 创建标识符
        /// </summary>
        string CreateId(Type type);

        string CreateId<T>();
    }
}
