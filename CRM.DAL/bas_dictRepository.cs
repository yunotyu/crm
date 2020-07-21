using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRM.Model;

namespace CRM.DAL
{
    /// <summary>
    /// 数据字典数据访问类
    /// </summary>
   public class bas_dictRepository
   {
       /// <summary>
       /// 根据类型获得字典集合
       /// </summary>
       /// <param name="p"></param>
       /// <returns></returns>
        public List<bas_dict> GetDictsByType(string p)
        {
            return LinqHelper.GetDataContext().bas_dict.Where(d => d.dict_type == p).ToList();
        }

        /// <summary>
        /// 根据查询对象获得数据集合
        /// </summary>
        /// <param name="searchEntity"></param>
        /// <returns></returns>
        public List<bas_dict> GetDictsBySearchEntity(bas_dict searchEntity)
        {
            return (from d in LinqHelper.GetDataContext().bas_dict
                    where d.dict_type.Contains(searchEntity.dict_type == null ? "" : searchEntity.dict_type)
                    && d.dict_item.Contains(searchEntity.dict_item == null ? "" : searchEntity.dict_item)
                    && d.dict_value.Contains(searchEntity.dict_value == null ? "" : searchEntity.dict_value)
                    select d).ToList();
        }

        /// <summary>
        /// 根据编号获得数据字典对象
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bas_dict GetDictsById(int p)
        {
            return new LinqHelper().GetEntity<bas_dict>(d => d.dict_id == p);
        }

        /// <summary>
        /// 数据字典修改
        /// </summary>
        /// <param name="newObj"></param>
        public void UpdateDict(bas_dict newObj)
        {
            new LinqHelper().UpadateEntity<bas_dict>(newObj);
        }

        /// <summary>
        /// 根据编号删除数据字典
        /// </summary>
        /// <param name="p"></param>
        public void DeleteDictById(int p)
        {
            new LinqHelper().ExecuteCommand("delete from bas_dict where dict_id="+p,null);
        }
       /// <summary>
       /// 添加数据字典
       /// </summary>
       /// <param name="newObj"></param>
        public void AddDict(bas_dict newObj)
        {
            new LinqHelper().InsertEntity<bas_dict>(newObj);
        }
   }
}
