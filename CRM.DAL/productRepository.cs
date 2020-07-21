using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRM.Model;

namespace CRM.DAL
{
    /// <summary>
    /// 产品数据访问类
    /// </summary>
   public class productRepository
    {

        /// <summary>
        /// 根据查询对象获得商品集合
        /// </summary>
        /// <param name="searchEntity"></param>
        /// <returns></returns>
        public List<product> GetProductsBySearchEntity(product searchEntity)
        {
            return (from p in LinqHelper.GetDataContext().product
                    where p.prod_name.Contains(searchEntity.prod_name == null ? "" : searchEntity.prod_name)
                    && p.prod_type.Contains(searchEntity.prod_type == null ? "" : searchEntity.prod_type)
                    && p.prod_batch.Contains(searchEntity.prod_batch == null ? "" : searchEntity.prod_batch)
                    select p).ToList();
        }
    }
}
