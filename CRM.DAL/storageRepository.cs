using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRM.Model;

namespace CRM.DAL
{
    /// <summary>
    /// 库存数据访问类
    /// </summary>
    public class storageRepository
    {

        /// <summary>
        /// 根据查询对象获得库存集合
        /// </summary>
        /// <param name="searchEntity"></param>
        /// <returns></returns>
        public List<storage> GetStoragesBySearchEntity(storage searchEntity)
        {
            return (from s in LinqHelper.GetDataContext().storage
                    where s.product.prod_name.Contains(searchEntity.product.prod_name == null ? "" : searchEntity.product.prod_name)
                    && s.stk_warehouse.Contains(searchEntity.stk_warehouse == null ? "" : searchEntity.stk_warehouse)
                    select s).ToList();
        }
    }
}
