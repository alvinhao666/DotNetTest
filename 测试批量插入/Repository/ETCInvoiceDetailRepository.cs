using Dapper;
using Sino.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sino.Hf.EtcService
{
    public class ETCInvoiceDetailRepository : TMSystemRepository<ETCInvoiceDetail, Guid>, IETCInvoiceDetailRepository
    {
        public ETCInvoiceDetailRepository(IDapperConfiguration configuration, IIdentifyProvider identifyProvider)
            : base(configuration, identifyProvider)
        { }

        /// <summary>
        /// 获取发票详情列表
        /// </summary>
        /// <param name="carrierOrderId"></param>
        /// <returns></returns>
        public async Task<List<ETCInvoiceDetail>> GetInvoiceDetailList(Guid carrierOrderId, Guid mainId)
        {
            StringBuilder sql = new StringBuilder(" Select * from etcinvoicedetails where  CarrierOrderId =@CarrierOrderId And briefid=@briefid order by ExTime desc");

            DynamicParameters param = new DynamicParameters();

            param.Add("@CarrierOrderId", carrierOrderId);
            param.Add("@briefid", mainId);
            var list = await ReadConnection.QueryAsync<ETCInvoiceDetail>(sql.ToString(), param);
            return list.ToList();
        }
        /// <summary>
        /// 添加发票详情
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public async Task<bool> InsertList(List<ETCInvoiceDetail> list)
        {
            string sql = CreateInertSql<ETCInvoiceDetail>("etcinvoicedetails");
            var paramList = new List<DynamicParameters>();
            foreach (var item in list)
            {
                DynamicParameters param = CreateParameters(item);

                paramList.Add(param);
            }

            var count = await WriteConnection.ExecuteAsync(sql, paramList);
            return count > 0;
        }
    }
}
