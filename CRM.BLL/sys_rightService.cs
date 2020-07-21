using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRM.DAL;
using CRM.Model;

namespace CRM.BLL
{
    /// <summary>
    /// 权限菜单业务逻辑类
    /// </summary>
    public class sys_rightService
    {
        private sys_rightRepository rightDao = new sys_rightRepository();
        /// <summary>
        /// 获取指定角色可以操作的菜单集合
        /// </summary>
        /// <param name="roleId">角色编号</param>
        /// <returns></returns>
        public List<sys_right> GetRightsByRoleId(int roleId)
        {
            return rightDao.GetRightByRoleId(roleId);
        }
        /// <summary>
        /// 获得所有菜单集合
        /// </summary>
        /// <returns></returns>
        public List<sys_right> GetAllRights()
        {
            return rightDao.GetAllRights();
        }
        /// <summary>
        /// 更新角色权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="newList"></param>
        public void UpdateRights(int roleId, List<sys_role_right> newList)
        {
            //删除原有权限记录
            rightDao.DeleteRightsByRoleId(roleId);
            //更新新权限记录
            if (rightDao.InsertRights(newList) != newList.Count)
            {
                throw new Exception("更新权限时遇到错误，请重试!");
            }
        }
    }
}
