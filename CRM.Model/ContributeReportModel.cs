using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using CRM.Model.Attribute;

namespace CRM.Model
{
    /// <summary>
    /// 客户贡献报表对象
    /// </summary>
    public class ContributeReportModel
    {
        /// <summary>
        /// 客户名称
        /// </summary>
        [DisplayName("客户名称")]
        public string Name { get; set; }
        /// <summary>
        /// 客户贡献总金额
        /// </summary>
        [DisplayName("总金额")]
        public decimal? TotalMoney { get; set; }

        [Ignore]
        public DateTime Year { get; set; }
    }   
}
