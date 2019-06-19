using Dapper;
using Sino.Application.Services.Dto;
using Sino.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Sino.Hf.EtcService
{
    public class ETCInvoiceQueryInput : QueryObject<CarrierOrder>, IInputDto
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderCode { get; set; }
        /// <summary>
        /// 车牌号
        /// </summary>
        public string CarCode { get; set; }

        /// <summary>
        /// 实际发货开始时间
        /// </summary>
        public DateTime? RealDeliveryStartTime { get; set; }

        /// <summary>
        /// 实际发货结束时间
        /// </summary>
        public DateTime? RealDeliveryEndTime { get; set; }

        /// <summary>
        /// 实际到货开始时间
        /// </summary>
        public DateTime? RealArrivalStartTime { get; set; }

        /// <summary>
        /// 实际到货结束时间
        /// </summary>
        public DateTime? RealArrivalEndTime { get; set; }

        /// <summary>
        /// 订单车辆数据是否上传
        /// </summary>
        public bool? OrderCarDataIsUpload { get; set; }

        /// <summary>
        /// 订单开始数据是否上传
        /// </summary>
        public bool? OrderStartDataIsUpload { get; set; }

        /// <summary>
        /// 订单结束数据是否上传
        /// </summary>
        public bool? OrderEndDataIsUpload { get; set; }

        /// <summary>
        /// 是否开票
        /// </summary>
        public bool? IsOpenInvoice { get; set; }


        //public bool? IsUploadError { get; set; }


        public Guid? LogisticsId { get; set; }


        public override List<Expression<Func<CarrierOrder, bool>>> QueryExpression => throw new NotImplementedException();


        public override Dictionary<string, DynamicParameters> QuerySql
        {
            get
            {
                DynamicParameters param = new DynamicParameters();
                StringBuilder sql = new StringBuilder();

                sql.Append(" WHERE 1=1");
                sql.Append(" And co.IsDeleted=FALSE  And co.Status =7  ");

                if (LogisticsId.HasValue)
                {
                    sql.Append(" AND co.LogisticsId = @LogisticsId");
                    param.Add("@LogisticsId", LogisticsId);
                }


                if (!string.IsNullOrWhiteSpace(OrderCode))
                {
                    sql.Append(" AND o.OrderId like @OrderCode");
                    param.Add("@OrderCode", "%" + OrderCode + "%");
                }

                if (!string.IsNullOrWhiteSpace(CarCode))
                {
                    sql.Append(" AND co.CarCode like @CarCode");
                    param.Add("@CarCode", "%" + CarCode + "%");
                }

                if (RealDeliveryStartTime.HasValue)
                {
                    sql.Append(" AND o.RealDeliveryTime >= @RealDeliveryStartTime");
                    param.Add("@RealDeliveryStartTime", RealDeliveryStartTime);
                }
                else
                {
                    sql.Append(" And o.RealDeliveryTime >= @StarTime");
                    param.Add("@StarTime", new DateTime(2018, 1, 1, 0, 0, 0));
                }


                if (RealDeliveryEndTime.HasValue)
                {
                    sql.Append(" AND o.RealDeliveryTime <= @RealDeliveryEndTime");
                    param.Add("@RealDeliveryEndTime", RealDeliveryEndTime);
                }
                else
                {
                    sql.Append("  And o.RealDeliveryTime<@EndTime");
                    param.Add("@EndTime", new DateTime(2019, 1, 1, 0, 0, 0));
                }

                if (RealArrivalStartTime.HasValue)
                {
                    sql.Append(" AND o.RealArrivalTime >= @RealArrivalStartTime");
                    param.Add("@RealArrivalStartTime", RealArrivalStartTime);
                }
                if (RealArrivalEndTime.HasValue)
                {
                    sql.Append(" AND o.RealArrivalTime <= @RealArrivalEndTime");
                    param.Add("@RealArrivalEndTime", RealArrivalEndTime);
                }

                if (OrderCarDataIsUpload.HasValue) 
                {
                    sql.Append(" AND co.OrderCarDataIsUpload = @OrderCarDataIsUpload");
                    param.Add("@OrderCarDataIsUpload", OrderCarDataIsUpload.Value);
                }


                if (OrderStartDataIsUpload.HasValue)
                {
                    sql.Append(" AND co.OrderStartDataIsUpload = @OrderStartDataIsUpload");
                    param.Add("@OrderStartDataIsUpload", OrderStartDataIsUpload.Value);
                }


                if (OrderEndDataIsUpload.HasValue)
                {
                    sql.Append(" AND co.OrderEndDataIsUpload = @OrderEndDataIsUpload");
                    param.Add("@OrderEndDataIsUpload", OrderEndDataIsUpload.Value);
                }

                if (IsOpenInvoice.HasValue)
                {
                    sql.Append(" AND co.ETCIsInvoice = @IsOpenInvoice");
                    param.Add("@IsOpenInvoice", IsOpenInvoice.Value);
                }

                //if (IsUploadError.HasValue)
                //{
                //    sql.Append(" AND co.IsUploadError = @IsUploadError");
                //    param.Add("@IsUploadError", IsUploadError.Value);
                //}


                sql.Append(" ORDER BY  o.OrderId  DESC");
                Dictionary<string, DynamicParameters> querySql = new Dictionary<string, DynamicParameters>();
                querySql.Add(sql.ToString(), param);
                return querySql;
            }
        }
    }
}
