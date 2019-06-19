using Sino.Dependency;
using Sino.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sino.Hf.EtcService
{
    public interface IETCRepository : ITMSystemRepository<CarrierOrder, Guid>, ITransientDependency
    {
        Task<List<Guid>> GetETCInvoiceList(IQueryObject<CarrierOrder> querys);



        Task<CarrierOrder> GetCarrierOrderDetail(Guid id);

        //Task<bool> UpdateIsUploadError(Guid id);
    }
}
