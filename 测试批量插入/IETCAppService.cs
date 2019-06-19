using Sino.Application.Services;
using Sino.Dependency;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sino.TMSystem.AppService.Order
{
    public interface IETCAppService: ITransientDependency
    {


        ///// <summary>
        ///// 上传订单
        ///// </summary>
        ///// <param name="query"></param>
        ///// <returns></returns>
        //Task UploadOrder(List<Guid> ids, long userId);

        ///// <summary>
        ///// 上传订单全选
        ///// </summary>
        ///// <param name="query"></param>
        ///// <returns></returns>
        //Task UploadOrderAll(ETCInvoiceQueryInput query, long userId);

        ///// <summary>
        ///// 查询发票
        ///// </summary>
        ///// <param name="query"></param>
        ///// <returns></returns>
        //Task SearchInvoice(List<Guid> ids,long userId);

        ///// <summary>
        ///// 查询发票全选
        ///// </summary>
        ///// <param name="query"></param>
        ///// <returns></returns>
        //Task SearchInvoiceAll(ETCInvoiceQueryInput query, long userId);


        /// <summary>
        /// 查看详情
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<GetETCInvoiceDetailListOutput> ViewDetail(Guid id);


    }
}
