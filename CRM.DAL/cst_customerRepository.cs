using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRM.Model;

namespace CRM.DAL
{
    /// <summary>
    /// 客户数据访问类
    /// </summary>
    public class cst_customerRepository
    {
        /// <summary>
        /// 添加客户公司
        /// </summary>
        /// <param name="cst"></param>
        public void AddCustomer(cst_customer cst)
        {
            new LinqHelper().InsertEntity<cst_customer>(cst);
        }
        /// <summary>
        /// 根据搜索条件获得客户信息集合
        /// </summary>
        /// <param name="searchEntity"></param>
        /// <returns></returns>
        public List<cst_customer> GetCustomersBySearchEntity(cst_customer searchEntity)
        {
            List<cst_customer> list= (from c in LinqHelper.GetDataContext().cst_customer
                    where c.cust_no.Contains(searchEntity.cust_no == null ? "" : searchEntity.cust_no)
                    && c.cust_name.Contains(searchEntity.cust_name == null ? "" : searchEntity.cust_name)
                    && c.cust_manager_name.Contains(searchEntity.cust_manager_name == null ? "" : searchEntity.cust_manager_name)
                    && c.cust_region.Contains(searchEntity.cust_region==null?"":searchEntity.cust_region)
                    orderby c.cust_Id descending
                    select c).ToList();
            if (searchEntity.cust_level > 0)
            {
              list=  list.Where(c => c.cust_level == searchEntity.cust_level).ToList();
            }
            return list;
        }
        /// <summary>
        /// 根据客户编号获得客户对象
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public cst_customer GetCustomerById(int p)
        {
            return new LinqHelper().GetEntity<cst_customer>(c => c.cust_Id == p);
        }
        /// <summary>
        /// 更新客户信息
        /// </summary>
        /// <param name="newObj"></param>
        public void UpdateCustomer(cst_customer newObj)
        {
            new LinqHelper().UpadateEntity<cst_customer>(newObj);
        }
        /// <summary>
        /// 根据客户编号获得客户对象
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public cst_customer GetCustomerByNo(string p)
        {
            return new LinqHelper().GetEntity<cst_customer>(c => c.cust_no == p);
        }
        /// <summary>
        /// 根据客户编号删除客户
        /// </summary>
        /// <param name="p"></param>
        public void DeleteCustomerById(int p)
        {
            new LinqHelper().DeleteEntity<cst_customer>(c => c.cust_Id == p);
        }

        /// <summary>
        /// 根据客户名称获得客户对象
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public cst_customer GetCustomerByName(string p)
        {
            return LinqHelper.GetDataContext().cst_customer.Where(c => c.cust_name == p).FirstOrDefault();
        }
    }
}
