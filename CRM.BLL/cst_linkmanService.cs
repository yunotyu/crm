using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRM.Model;
using CRM.DAL;

namespace CRM.BLL
{
    /// <summary>
    /// 联系人业务逻辑类
    /// </summary>
   public class cst_linkmanService
   {
       /// <summary>
       /// 根据公司编号获得联系人对象集合
       /// </summary>
       /// <param name="p"></param>
       /// <returns></returns>
        public List<cst_linkman> GetLinkMansByCustomerId(int p)
        {
            return new cst_linkmanRepository().GetLinkMansByCustomerId(p);
        }

        /// <summary>
        /// 根据联系人编号获得联系人对象
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public cst_linkman GetLinkManById(int p)
        {
            return new cst_linkmanRepository().GetLinkManById(p);
        }
       /// <summary>
       /// 修改联系人
       /// </summary>
       /// <param name="newObj"></param>
        public void UpdateLinkMan(cst_linkman newObj)
        {
            new cst_linkmanRepository().UpdateLinkMan(newObj);
        }
       /// <summary>
       /// 根据联系人编号删除联系人
       /// </summary>
       /// <param name="p"></param>
        public void DeleteLinkManById(int p)
        {
            new cst_linkmanRepository().DeleteLinkManById(p);
        }
       /// <summary>
       /// 添加联系人
       /// </summary>
       /// <param name="newObj"></param>
        public void AddLinkMan(cst_linkman newObj)
        {
            new cst_linkmanRepository().AddLinkMan(newObj);
        }
   }
}
