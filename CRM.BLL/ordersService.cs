using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRM.Model;
using CRM.DAL;

namespace CRM.BLL
{
    /// <summary>
    /// 订单业务逻辑类
    /// </summary>
   public class ordersService
    {
       /// <summary>
       /// 根据客户编号获得订单集合
       /// </summary>
       /// <param name="p"></param>
       /// <returns></returns>
        public List<orders> GetOrdersByCustomerNo(string p)
        {
            return new ordersRepository().GetOrdersByCustomerNo(p);
        }

        /// <summary>
        /// 根据编号获得订单
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public orders GetOrderById(int p)
        {
            return new ordersRepository().GetOrderById(p);
        }
    }
}
