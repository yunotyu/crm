using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRM.Model;
using CRM.DAL;

namespace CRM.BLL
{
    /// <summary>
    /// 数据字典业务逻辑类
    /// </summary>
   public  class bas_dictService
    {
       /// <summary>
       /// 根据类型获得字典集合
       /// </summary>
       /// <param name="p"></param>
       /// <returns></returns>
        public List<bas_dict> GetDictsByType(string p)
        {
            return new bas_dictRepository().GetDictsByType(p);
        }
       /// <summary>
       /// 根据查询对象获得数据集合
       /// </summary>
       /// <param name="searchEntity"></param>
       /// <returns></returns>
        public List<bas_dict> GetDictsBySearchEntity(bas_dict searchEntity)
        {
            return new bas_dictRepository().GetDictsBySearchEntity(searchEntity);
        }
       /// <summary>
       /// 根据编号获得数据字典对象
       /// </summary>
       /// <param name="p"></param>
       /// <returns></returns>
        public bas_dict GetDictsById(int p)
        {
            return new bas_dictRepository().GetDictsById(p);
        }

       /// <summary>
       /// 数据字典修改
       /// </summary>
       /// <param name="newObj"></param>
        public void UpdateDict(bas_dict newObj)
        {
            new bas_dictRepository().UpdateDict(newObj);
        }
       /// <summary>
       /// 根据编号删除数据字典
       /// </summary>
       /// <param name="p"></param>
        public void DeleteDictById(int p)
        {
            new bas_dictRepository().DeleteDictById(p);
        }
       /// <summary>
       /// 添加数据字典
       /// </summary>
       /// <param name="newObj"></param>
        public void AddDict(bas_dict newObj)
        {
            new bas_dictRepository().AddDict(newObj);
        }
    }
}
