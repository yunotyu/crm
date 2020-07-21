using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRM.Model;
using CRM.DAL;

namespace CRM.BLL
{
    /// <summary>
    /// 库存业务逻辑类
    /// </summary>
    public class storageService
    {
        /// <summary>
        /// 根据查询对象获得库存集合
        /// </summary>
        /// <param name="searchEntity"></param>
        /// <returns></returns>
        public List<storage> GetStoragesBySearchEntity(storage searchEntity)
        {
            return new storageRepository().GetStoragesBySearchEntity(searchEntity);
        }
    }
}
