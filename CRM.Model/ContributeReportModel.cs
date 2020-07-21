using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string Name { get; set; }
        /// <summary>
        /// 客户贡献总金额
        /// </summary>
        public decimal TotalMoney { get; set; }
    }
}
