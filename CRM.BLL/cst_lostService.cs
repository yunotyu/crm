using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRM.Model;
using CRM.DAL;

namespace CRM.BLL
{
    /// <summary>
    /// 流失客户业务逻辑类
    /// </summary>
   public class cst_lostService
   {
       /// <summary>
       /// 根据流失客户查询对象获得符合条件的流失客户集合
       /// </summary>
       /// <param name="searchEntity"></param>
       /// <returns></returns>
        public List<cst_lost> GetLostCustomerBySearchEntity(cst_lost searchEntity)
        {
            return new cst_lostRepository().GetLostCustomerBySearchEntity(searchEntity);
        }
       /// <summary>
       /// 暂缓流失
       /// </summary>
       /// <param name="p"></param>
        public void CustomerLosting(int p)
        {
            new cst_lostRepository().CustomerLosting(p);
        }
        /// <summary>
        /// 确认流失
        /// </summary>
        /// <param name="p"></param>
        public void CustomerLosted(int p)
        {
            new cst_lostRepository().CustomerLosted(p);
        }
   }
}
