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

        public async Task<CarrierOrder> GetCarrierOrderDetail(Guid id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT co.*,c.*");
            sb.Append(" FROM carrierorders co");
            sb.Append(" LEFT JOIN contracts c");
            sb.Append(" ON co.ContractId=c.Id");
            sb.Append(" WHERE co.Id=@Id  And co.IsDeleted=false");
            var CarrierOrder = ReadConnection.Query<CarrierOrder, Contract, CarrierOrder>(sb.ToString(),
            (carrierorder, contract) =>
            {
                if (contract != null)
                {
                    carrierorder.Contract = contract;
                }
                return carrierorder;
            }, new { Id = id }).ToList().FirstOrDefault();
            if (CarrierOrder != null)
            {
                sb.Clear();
                sb.Append(" SELECT * from Orders where CarrierOrderId=@Id AND IsDeleted=false;");
                var query = ReadConnection.QueryMultiple(sb.ToString(), new { Id = id });
                var orderList = query.Read<Order>().ToList();
                if (orderList?.Count > 0)
                {
                    //List<Guid> Ids = orderList.Select(x => x.Id).ToList();
                    //var orderChildList = ReadConnection.Query<OrderChild>("SELECT * FROM orderchilds WHERE OrderId IN @Ids", new { Ids = Ids.ToArray() });
                    //foreach (var order in orderList)
                    //{
                    //    order.ChildList = orderChildList.Where(x => x.OrderId == order.Id).ToList();
                    //}
                    CarrierOrder.OrderList = orderList.Where(x => x.CarrierOrderId == id).ToList();
                }
                else
                {
                    CarrierOrder.OrderList = new List<Order>();
                }

            }
            return CarrierOrder;
        }

        /// <summary>
        /// 获取发票详情列表
        /// </summary>
        /// <param name="carrierOrderId"></param>
        /// <returns></returns>
        public async Task<List<ETCInvoiceDetail>> GetInvoiceDetailList(Guid carrierOrderId)
        {
            StringBuilder sql = new StringBuilder(" Select * from etcinvoicedetails where  CarrierOrderId =@CarrierOrderId order by ExTime desc");

            DynamicParameters param = new DynamicParameters();

            param.Add("@CarrierOrderId", carrierOrderId);
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
