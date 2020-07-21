using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRM.Model;

namespace CRM.DAL
{
    /// <summary>
    /// 交往记录数据访问类
    /// </summary>
    public class cst_activityRepository
    {
        /// <summary>
        /// 根据客户编号获得交往记录集合
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public List<Model.cst_activity> GetActivityByCustomerId(string p)
        {
            return LinqHelper.GetDataContext().cst_activity.Where(a => a.atv_cust_no == p).ToList();
        }
        /// <summary>
        /// 添加交往记录
        /// </summary>
        /// <param name="newObj"></param>
        public void AddContactRecord(cst_activity newObj)
        {
            new LinqHelper().InsertEntity<cst_activity>(newObj);
        }

        /// <summary>
        /// 根据记录编号获得记录对象
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public cst_activity GetActivityById(int p)
        {
            return LinqHelper.GetDataContext().cst_activity.Where(a => a.atv_id == p).SingleOrDefault();
        }
        /// <summary>
        /// 修改交往记录
        /// </summary>
        /// <param name="newObj"></param>
        public void UpdateContactRecord(cst_activity newObj)
        {
            new LinqHelper().UpadateEntity<cst_activity>(newObj);
        }

        /// <summary>
        /// 删除交往记录
        /// </summary>
        /// <param name="p"></param>
        public void DeleteContactRecord(int p)
        {
           new LinqHelper().ExecuteCommand("DELETE FROM [cst_activity] WHERE atv_id=" + p);
        }
    }
}
