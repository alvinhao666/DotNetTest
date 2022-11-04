using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sino.MSLS.DomainModel
{
    /// <summary>
    /// 省市区
    /// </summary>
    [Table(Name ="zones")]
    public class Zone 
    {
        public int Id { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 省市区代码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 父级代码
        /// </summary>
        public string ParentCode { get; set; }

        /// <summary>
        /// 父级名称
        /// </summary>
        public string ParentName { get; set; }

        /// <summary>
        /// 全称，详细地址
        /// </summary>
        public string FullName { get; set; }
    }
}
