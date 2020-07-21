using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRM.Model;

namespace CRM.DAL
{
    /// <summary>
    /// 系统用户数据访问类
    /// </summary>
    public class sys_userRepository
    {
        private LinqHelper helper = new LinqHelper();

        /// <summary>
        /// 根据用户名查找指定用户对象
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public sys_user GetUserByName(string name)
        {
            return helper.GetEntity<sys_user>(u => u.usr_name == name);
        }

        /// <summary>
        /// 获得所有用户信息（包含其角色等附加信息）
        /// </summary>
        /// <returns></returns>
        public List<sys_user> GetAllUsers()
        {
            return (from u in LinqHelper.GetDataContext().sys_user
                    select u).ToList();
        }
        /// <summary>
        /// 根据用户编号查找指定用户对象
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public sys_user GetUserByUserId(int userId)
        {
            return (from u in LinqHelper.GetDataContext().sys_user
                    where u.usr_id == userId
                    select u).SingleOrDefault();
        }
        /// <summary>
        /// 根据角色编号获得用户列表
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<sys_user> GetUserByRoleId(int roleId)
        {
            return (from u in LinqHelper.GetDataContext().sys_user
                    where u.usr_role_id == roleId
                    select u).ToList();
        }
    }
}
