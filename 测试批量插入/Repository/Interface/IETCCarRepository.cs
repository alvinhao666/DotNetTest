using Sino.Dependency;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sino.Hf.EtcService
{
    public interface IETCCarRepository : ITMSystemRepository<ETCCar, Guid>, ITransientDependency
    {
        Task<ETCCar> GetCar(string carCode);
    }
}
