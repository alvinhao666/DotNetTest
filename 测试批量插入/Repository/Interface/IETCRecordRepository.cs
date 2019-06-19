using Sino.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sino.Hf.EtcService
{
    public interface IETCRecordRepository : ITMSystemRepository<ETCRecord, Guid>, ITransientDependency
    {
    }
}
