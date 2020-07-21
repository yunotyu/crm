using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRM.Model;
using CRM.DAL;

namespace CRM.BLL
{
    /// <summary>
    /// 订单详细业务逻辑类
    /// </summary>
   public class orders_lineService
    {
       /// <summary>
       /// 根据订单编号获得订单详细记录
       /// </summary>
       /// <param name="p"></param>
       /// <returns></returns>
        public List<orders_line> GetOrderLinesByOrderId(int p)
        {
            return new orders_lineRepository().GetOrderLinesByOrderId(p);
        }
    }
}
