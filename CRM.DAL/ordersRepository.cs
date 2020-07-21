using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRM.Model;

namespace CRM.DAL
{
    /// <summary>
    /// 订单数据访问类
    /// </summary>
    public class ordersRepository
    {
        /// <summary>
        /// 根据客户编号获得订单集合
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public List<orders> GetOrdersByCustomerNo(string p)
        {
            return LinqHelper.GetDataContext().orders.Where(o => o.odr_cust_no == p).OrderBy(o => o.odr_date).ToList();
        }
        /// <summary>
        /// 根据编号获得订单
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public orders GetOrderById(int p)
        {
            return new LinqHelper().GetEntity<orders>(o => o.odr_id == p);
        }
    }
}
