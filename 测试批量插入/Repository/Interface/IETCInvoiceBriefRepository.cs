using Sino.Dependency;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sino.Hf.EtcService
{
    public interface IETCInvoiceBriefRepository : ITMSystemRepository<ETCInvoiceBrief, Guid>, ITransientDependency
    {
        Task<ETCInvoiceBrief> GetInvoiceBrief(Guid carrierOrderId);
    }
}
