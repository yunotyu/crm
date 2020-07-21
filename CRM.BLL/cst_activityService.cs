using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRM.Model;
using CRM.DAL;

namespace CRM.BLL
{
    /// <summary>
    /// 交往记录业务逻辑类
    /// </summary>
   public class cst_activityService
    {
       /// <summary>
        /// 根据客户编号获得交往记录集合
       /// </summary>
       /// <param name="p"></param>
       /// <returns></returns>
        public List<cst_activity> GetActivityByCustomerId(string p)
        {
            return new cst_activityRepository().GetActivityByCustomerId(p);
        }

        /// <summary>
        /// 添加交往记录
        /// </summary>
        /// <param name="newObj"></param>
        public void AddContactRecord(cst_activity newObj)
        {
            new cst_activityRepository().AddContactRecord(newObj);
        }
       /// <summary>
       /// 根据记录编号获得记录对象
       /// </summary>
       /// <param name="p"></param>
       /// <returns></returns>
        public cst_activity GetActivityById(int p)
        {
            return new cst_activityRepository().GetActivityById(p);
        }

        /// <summary>
        /// 修改交往记录
        /// </summary>
        /// <param name="newObj"></param>
        public void UpdateContactRecord(cst_activity newObj)
        {
            new cst_activityRepository().UpdateContactRecord(newObj);
        }
       /// <summary>
       /// 删除交往记录
       /// </summary>
       /// <param name="p"></param>
        public void DeleteContactRecord(int p)
        {
            new cst_activityRepository().DeleteContactRecord(p);
        }
    }
}
