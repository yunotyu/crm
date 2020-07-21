using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRM.Model;
using CRM.DAL;

namespace CRM.BLL
{
    /// <summary>
    /// 系统用户业务逻辑类
    /// </summary>
    public class sys_userService
    {
        private sys_userRepository userDao = new sys_userRepository();
        /// <summary>
        /// 获得所有用户信息（包含角色等附加信息）
        /// </summary>
        /// <returns></returns>
        public List<sys_user> GetAllUsers()
        {
            return userDao.GetAllUsers();
        }
        /// <summary>
        /// 根据用户编号获得指定用户对象
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public sys_user GetUserByUserId(int userId)
        {
            return userDao.GetUserByUserId(userId);
        }
        /// <summary>
        /// 获得所有客服经理
        /// </summary>
        /// <returns></returns>
        public List<sys_user> GetAllWaiter()
        {
            return userDao.GetUserByRoleId(3);
        }
    }
}
