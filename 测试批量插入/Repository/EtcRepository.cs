using Dapper;
using Sino.Dapper;
using Sino.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sino.Hf.EtcService
{
    public class ETCRepository : TMSystemRepository<CarrierOrder, Guid>, IETCRepository
    {
        public ETCRepository(IDapperConfiguration configuration, IIdentifyProvider identifyProvider)
            : base(configuration, identifyProvider)
        { }

        /// <summary>
        /// 获取ETC开票管理
        /// </summary>
        /// <param name="querys"></param>
        /// <returns></returns>
        public async Task<List<Guid>> GetETCInvoiceList(IQueryObject<CarrierOrder> querys)
        {
            StringBuilder sql = new StringBuilder(" SELECT  distinct(co.Id) from carrierorders co INNER JOIN orders o on co.Id=o.CarrierOrderId ");

            //查询条件+排序的sql
            var query = querys.QuerySql.FirstOrDefault();
            if (querys.QuerySql.Count > 0)
            {
                sql.Append(query.Key);
            }

            //分页
            if (querys.Count <= 0)
            {
                querys.Count = int.MaxValue;
            }

            sql.Append(" LIMIT " + querys.Skip + "," + querys.Count);

            var idResult = await ReadConnection.QueryAsync<Guid>(sql.ToString(), query.Value);
            var idList = idResult.ToList();
            //if (idList.Count == 0)
            //{
            //    return new List<ETCInvoice>();
            //}
            //sql.Clear();
            //sql.Append(" SELECT co.Id,co.CarCode,co.OrderCarDataIsUpload,co.OrderStartDataIsUpload,co.OrderEndDataIsUpload,co.ETCUpdateTime,co.ETCIsInvoice,o.OrderId as OrderCode,o.RealDeliveryTime,o.RealArrivalTIme from carrierorders co INNER JOIN orders o on co.Id=o.CarrierOrderId ");
            //sql.Append(" Where co.Id in @Ids");
            //sql.Append(" Order by o.OrderId desc");
            //var result = await ReadConnection.QueryAsync<ETCInvoice>(sql.ToString(), new { Ids = idList });

            return idList;
        }

        /// <summary>
        /// 获取总数
        /// </summary>
        /// <param name="querys"></param>
        /// <returns></returns>
        public async Task<int> GetTotalCount(IQueryObject<CarrierOrder> querys)
        {
            StringBuilder sql = new StringBuilder(" SELECT  count(distinct(co.Id)) from carrierorders co INNER JOIN orders o on co.Id=o.CarrierOrderId ");

            //查询条件+排序的sql
            var query = querys.QuerySql.FirstOrDefault();
            if (querys.QuerySql.Count > 0)
            {
                sql.Append(query.Key);
            }
            var uList = await ReadConnection.QueryAsync<int>(sql.ToString(), query.Value);
            return uList.FirstOrDefault();
        }

        /// <summary>
        /// 获取上传成功的数量
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public async Task<int> GetUploadSuccessCount(List<Guid> ids)
        {
            StringBuilder sql = new StringBuilder(" SELECT  count(*) from carrierorders Where Id in @IdList ");

            sql.Append(" And OrderCarDataIsUpload=True And OrderStartDataIsUpload=True And OrderEndDataIsUpload=True");
            var uList = await ReadConnection.QueryAsync<int>(sql.ToString(), new { IdList = ids });
            return uList.FirstOrDefault();
        }

        /// <summary>
        /// 更新订单车辆数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> UpdateOrderCarData(Guid id)
        {
            StringBuilder sb = new StringBuilder(" Update carrierorders Set OrderCarDataIsUpload=True WHERE Id=@Id ");
            DynamicParameters param = new DynamicParameters();

            param.Add("@Id", id);

            var result = await WriteConnection.ExecuteAsync(sb.ToString(), param);
            return result > 0;
        }

        /// <summary>
        /// 更新订单开始数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> UpdateOrderStartData(Guid id)
        {
            StringBuilder sb = new StringBuilder(" Update carrierorders Set OrderStartDataIsUpload=True WHERE Id=@Id ");
            DynamicParameters param = new DynamicParameters();

            param.Add("@Id", id);

            var result = await WriteConnection.ExecuteAsync(sb.ToString(), param);
            return result > 0;
        }

        /// <summary>
        /// 更新订单结束数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> UpdateOrderEndDataAndTime(Guid id, DateTime receiveTime)
        {
            StringBuilder sb = new StringBuilder(" Update carrierorders Set OrderEndDataIsUpload=True,EtcUpdateTime=@EtcUpdateTime WHERE Id=@Id ");
            DynamicParameters param = new DynamicParameters();

            param.Add("@Id", id);

            param.Add("@EtcUpdateTime", receiveTime);

            var result = await WriteConnection.ExecuteAsync(sb.ToString(), param);
            return result > 0;
        }

        /// <summary>
        /// 更新Etc是否开票
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> UpdateETCIsInvoice(Guid id)
        {
            StringBuilder sb = new StringBuilder(" Update carrierorders Set EtcIsInvoice=True WHERE Id=@Id ");
            DynamicParameters param = new DynamicParameters();

            param.Add("@Id", id);

            var result = await WriteConnection.ExecuteAsync(sb.ToString(), param);
            return result > 0;
        }

        //public async Task<bool> UpdateIsUploadError(Guid id)
        //{
        //    StringBuilder sb = new StringBuilder(" Update carrierorders Set IsUploadError=True WHERE Id=@Id ");
        //    DynamicParameters param = new DynamicParameters();

        //    param.Add("@Id", id);

        //    var result = await WriteConnection.ExecuteAsync(sb.ToString(), param);
        //    return result > 0;
        //}


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


    }
}
