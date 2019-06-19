using Sino.Dependency;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sino.Hf.EtcService
{
    public interface IETCInvoiceDetailRepository : ITMSystemRepository<ETCInvoiceDetail, Guid>, ITransientDependency
    {
        Task<List<ETCInvoiceDetail>> GetInvoiceDetailList(Guid carrierOrderId, Guid mainId);

        Task<bool> InsertList(List<ETCInvoiceDetail> list);
    }
}
