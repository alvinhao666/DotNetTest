using Dapper;
using Sino.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sino.Hf.EtcService
{
    public class ETCInvoiceBriefRepository : TMSystemRepository<ETCInvoiceBrief, Guid>, IETCInvoiceBriefRepository
    {
        public ETCInvoiceBriefRepository(IDapperConfiguration configuration, IIdentifyProvider identifyProvider)
            : base(configuration, identifyProvider)
        { }

        /// <summary>
        /// 获取发票详情列表
        /// </summary>
        /// <param name="carrierOrderId"></param>
        /// <returns></returns>
        public async Task<ETCInvoiceBrief> GetInvoiceBrief(Guid carrierOrderId)
        {
            StringBuilder sql = new StringBuilder(" Select * from etcinvoicebriefs where  CarrierOrderId =@CarrierOrderId order by CreationTime desc limit  1 ");

            DynamicParameters param = new DynamicParameters();

            param.Add("@CarrierOrderId", carrierOrderId);
            var list = await ReadConnection.QueryAsync<ETCInvoiceBrief>(sql.ToString(), param);
            return list.FirstOrDefault();
        }
    }
}
