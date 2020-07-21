using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRM.Model;
using CRM.DAL;

namespace CRM.BLL
{
    /// <summary>
    /// 产品业务逻辑类
    /// </summary>
    public class productService
    {
        /// <summary>
        /// 根据查询对象获得商品集合
        /// </summary>
        /// <param name="searchEntity"></param>
        /// <returns></returns>
        public List<product> GetProductsBySearchEntity(product searchEntity)
        {
            return new productRepository().GetProductsBySearchEntity(searchEntity);
        }
    }
}
