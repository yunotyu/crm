using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRM.Model;

namespace CRM.DAL
{
    /// <summary>
    /// 流失客户数据访问类
    /// </summary>
    public class cst_lostRepository
    {
        /// <summary>
        /// 根据流失客户查询对象获得符合条件的流失客户集合
        /// </summary>
        /// <param name="searchEntity"></param>
        /// <returns></returns>
        public List<cst_lost> GetLostCustomerBySearchEntity(cst_lost searchEntity)
        {
            List<cst_lost> list = (from l in LinqHelper.GetDataContext().cst_lost
                                   where l.lst_cust_name.Contains(searchEntity.lst_cust_name == null ? "" : searchEntity.lst_cust_name)
                                   && l.lst_cust_manager_name.Contains(searchEntity.lst_cust_manager_name == null ? "" : searchEntity.lst_cust_manager_name)
                                   select l).ToList();
            if (searchEntity.lst_status > 0)
            {
                list = list.Where(l => l.lst_status == searchEntity.lst_status).ToList();
            }
            return list;
        }

        /// <summary>
        /// 暂缓流失
        /// </summary>
        /// <param name="p"></param>
        public void CustomerLosting(int p)
        {
            new LinqHelper().ExecuteCommand("UPDATE [cst_lost] SET [lst_status] = 2 WHERE lst_id=" + p);
        }
        /// <summary>
        /// 确认流失
        /// </summary>
        /// <param name="p"></param>
        public void CustomerLosted(int p)
        {
            new LinqHelper().ExecuteCommand("UPDATE [cst_lost] SET [lst_status] = 3,[lst_lost_date]=getdate() WHERE lst_id=" + p);
        }
    }
}
