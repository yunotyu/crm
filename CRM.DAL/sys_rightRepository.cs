using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRM.Model;

namespace CRM.DAL
{
    /// <summary>
    /// 菜单数据访问类
    /// </summary>
    public class sys_rightRepository
    {
        private LinqHelper helper = new LinqHelper();
        /// <summary>
        /// 根据角色编号查询该角色所拥有的权限菜单
        /// </summary>
        /// <param name="roleId">角色编号</param>
        /// <returns></returns>
        public List<sys_right> GetRightByRoleId(int roleId)
        {
            //所有菜单集合
            List<sys_right> rightList = new List<sys_right>();
            rightList = helper.GetList<sys_right>();
            //当前角色所拥有的权限的集合
            List<sys_role_right> rrList = new List<sys_role_right>();
            rrList = helper.GetList<sys_role_right>().Where(r => r.rf_role_id == roleId).ToList();
            //当前角色所拥有的菜单的集合
            List<sys_right> myRightList = new List<sys_right>();
            //嵌套循环判断当前角色所拥有的菜单，并存放到MyRightList集合中
            foreach (var rightItem in rightList)//10个菜单A\B\C....
            {
                foreach (var rrItem in rrList)//5条权限记录1\2\3\4....
                {
                    if (rightItem.right_code.Equals(rrItem.rf_right_code))
                    {
                        myRightList.Add(rightItem);
                        break;
                    }
                }
            }
            //返回当前角色所能操作的菜单集合
            return myRightList;
        }
        /// <summary>
        /// 获得所有菜单
        /// </summary>
        /// <returns></returns>
        public List<sys_right> GetAllRights()
        {
            return helper.GetList<sys_right>();
        }
        /// <summary>
        /// 根据角色编号查找其权限记录
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<sys_role_right> GetRoleRightByRoleId(int roleId)
        {
            return helper.GetList<sys_role_right>().Where(r => r.rf_role_id == roleId).ToList();
        }
        /// <summary>
        /// 批量插入权限集合
        /// </summary>
        /// <param name="newList"></param>
        /// <returns></returns>
        public int InsertRights(List<sys_role_right> newList)
        {
            int rowCount = 0;
            foreach (var item in newList)
            {
                helper.InsertEntity<sys_role_right>(item);
                rowCount++;
            }
            return rowCount;
        }
        /// <summary>
        /// 根据角色编号删除权限记录
        /// </summary>
        /// <param name="roleId"></param>
        public void DeleteRightsByRoleId(int roleId)
        {
            new LinqHelper().ExecuteCommand("delete sys_role_right where rf_role_id=" + roleId);
        }
    }
}
