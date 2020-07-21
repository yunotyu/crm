using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRM.Model;

namespace CRM.DAL
{
    /// <summary>
    /// 客户联系人数据访问类
    /// </summary>
    public class cst_linkmanRepository
    {
        /// <summary>
        /// 添加客户公司联系人
        /// </summary>
        /// <param name="lkman"></param>
        public void AddLinkMan(cst_linkman lkman)
        {
            new LinqHelper().InsertEntity<cst_linkman>(lkman);
        }
        /// <summary>
        /// 根据公司编号获得联系人对象集合
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public List<cst_linkman> GetLinkMansByCustomerId(int p)
        {
            return LinqHelper.GetDataContext().cst_linkman.Where(l => l.cst_customer.cust_Id == p).ToList();
        }
        /// <summary>
        /// 根据联系人编号获得联系人对象
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public cst_linkman GetLinkManById(int p)
        {
            return LinqHelper.GetDataContext().cst_linkman.Where(l => l.lkm_id == p).SingleOrDefault();
        }

        /// <summary>
        /// 修改联系人
        /// </summary>
        /// <param name="newObj"></param>
        public void UpdateLinkMan(cst_linkman newObj)
        {
            new LinqHelper().UpadateEntity<cst_linkman>(newObj);
        }

        /// <summary>
        /// 根据联系人编号删除联系人
        /// </summary>
        /// <param name="p"></param>
        public void DeleteLinkManById(int p)
        {
            new LinqHelper().ExecuteCommand("DELETE FROM [cst_linkman] WHERE lkm_id=" + p);
        }
    }
}
