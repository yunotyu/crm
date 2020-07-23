using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Model
{
    /// <summary>
    /// 客户构成报表对象
    /// </summary>
    public class ComposingReportModel
    {
        /// <summary>
        /// 客户类型名称
        /// </summary>
        [DisplayName("客户类型名称")]
        public string TypeName { get; set; }
        /// <summary>
        /// 客户数量
        /// </summary>
        [DisplayName("客户数量")]
        public int CustomerCount { get; set; }
    }
}
