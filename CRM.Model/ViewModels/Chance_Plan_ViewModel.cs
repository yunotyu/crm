using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Model.ViewModels
{
    /// <summary>
    /// 返回页面时，仍保留上次的搜索条件
    /// </summary>
    public class Chance_Plan_ViewModel
    {
        public string Chc_Cust_Name { get; set; }       
        public string Chc_Title { get; set; }
        public string Chc_Linkman { get; set; }
        public string Start_Pla_Date { get; set; }
        public string End_Pla_Date { get; set; }
    }
}
