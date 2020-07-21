using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRM.Model;
using CRM.DAL;

namespace CRM.BLL
{
    /// <summary>
    /// 登录业务逻辑类
    /// </summary>
    public class LoginService
    {
        private sys_userRepository userDao = new sys_userRepository();
        /// <summary>
        /// 用户登录
        /// 如果账号不存在，则会抛异常：用户不存在或账号错
        /// 如果密码错，则会抛异常：登录失败！请检查密码是否正确或者账号已禁用
        /// 如果用户被禁用或其他未知错误，则会抛异常：登录失败！请检查密码是否正确或者账号已禁用
        /// </summary>
        /// <param name="user">需要登录的用户对象</param>
        /// <returns></returns>
        public bool Login(ref sys_user user)
        {
            bool flag = false;
            sys_user empUser = userDao.GetUserByName(user.usr_name);

            if (empUser == null)
            {
                throw new Exception("用户不存在或账号错");
            }
            else if (empUser.usr_pwd.Equals(user.usr_pwd) && empUser.usr_state == 0)
            {
                user = empUser;
                flag = true;
            }
            else
            {
                throw new Exception("登录失败！请检查密码是否正确或者账号已禁用");
            }
            return flag;
        }
    }
}
