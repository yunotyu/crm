using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRM.Model;
using CRM.DAL;

namespace CRM.BLL
{
    /// <summary>
    /// 客户信息业务逻辑类
    /// </summary>
    public class cst_customerService
    {
        /// <summary>
        /// 根据搜索条件获得客户信息集合
        /// </summary>
        /// <param name="searchEntity"></param>
        /// <returns></returns>
        public List<cst_customer> GetCustomersBySearchEntity(cst_customer searchEntity)
        {
            return new cst_customerRepository().GetCustomersBySearchEntity(searchEntity);
        }



        /// <summary>
        /// 根据客户编号获得客户对象
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public cst_customer GetCustomerById(int p)
        {
            return new cst_customerRepository().GetCustomerById(p);
        }
        /// <summary>
        /// 更新客户信息
        /// </summary>
        /// <param name="newObj"></param>
        public void UpdateCustomer(cst_customer newObj)
        {
            if (newObj.cust_manager_id > 0)
            {
                newObj.cust_manager_name = new sys_userRepository().GetUserByUserId(newObj.cust_manager_id.Value).usr_name;
            }
            new cst_customerRepository().UpdateCustomer(newObj);
        }
        /// <summary>
        /// 根据客户帐号获得客户对象
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public cst_customer GetCustomerByNo(string p)
        {
            return new cst_customerRepository().GetCustomerByNo(p);
        }
        /// <summary>
        /// 根据客户编号删除客户
        /// </summary>
        /// <param name="p"></param>
        public void DeleteCustomerById(int p)
        {
            new cst_customerRepository().DeleteCustomerById(p);
        }
        /// <summary>
        /// 根据客户名称获得客户对象
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public cst_customer GetCustomerByName(string p)
        {
            cst_customer customer= new cst_customerRepository().GetCustomerByName(p);
            if(customer==null)
            {
                throw new Exception("客户不存在");
            }
            else
            {
                return customer;
            }
        }
    }
}
