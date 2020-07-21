using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.BLL;
using CRM.Model;

namespace CRM.Web.Controllers
{
    [MyException]
    [LoginValidator]
    public class DefaultController : Controller
    {
        private sys_rightService rightSer = new sys_rightService();
        //
        // GET: /Default/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Middle()
        {
            return View();
        }

        public ActionResult Top()
        {
            return View((Session["user"] as sys_user));
        }

        public ActionResult Buttom()
        {
            return View();
        }

        public ActionResult Menu()
        {
            return View();
        }

        [HttpPost]
        public string Menu(FormCollection forms)
        {
            int roleId = ((sys_user)Session["user"]).usr_role_id;
            #region 递归
            //List<sys_right> rightList = rightSer.GetRightsByRoleId(roleId);
            //string strMenu = string.Empty;
            //foreach (var item in rightList)
            //{
            //    if (item.right_parent_code.Equals("000"))
            //    {
            //        GetChildMenu(ref strMenu, item, rightList);
            //    }
            //}
            //if (string.IsNullOrEmpty(strMenu))
            //{
            //    throw new Exception("对不起！你的账号存在异常无法正常使用，请联系客服");
            //}
            //return strMenu;
            #endregion

            //根据角色编号查询这个角色所拥有的权限节点
            List<sys_right> list = rightSer.GetRightsByRoleId(roleId);

            string html = string.Empty;
            foreach (var rightItem in list.Where(r => r.right_parent_code == "001").ToList())
            {
                //子节点
                string childHtml = "";
                foreach (var childItem in list.Where(r => r.right_parent_code == rightItem.right_code).ToList())
                {
                    //Target属性
                    childHtml += "<a href=\"" + childItem.right_url + "\" Target=\"main\">" + childItem.right_text + "</a>";
                }
                //添加根节点标记 
                html += "<div><span>" + rightItem.right_text + "</span>" + childHtml + "</div>";
            }
            return html;

        }
        ///// <summary>
        ///// 通过递归方式获得子菜单
        ///// </summary>
        ///// <param name="strMenu"></param>
        ///// <param name="parentRight"></param>
        ///// <param name="allRights"></param>
        //private void GetChildMenu(ref string strMenu, sys_right parentRight, List<sys_right> allRights)
        //{
        //    //默认没有子节点
        //    bool flag = false;
        //    strMenu+="<ul>";
        //    foreach (var item in allRights)
        //    {
        //        if (item.right_parent_code.Equals(parentRight.right_code))
        //        {
        //            //标记有子节点
        //            flag = true;
        //            strMenu += "<li><a href='" + item.right_url + "'>" + item.right_text + "</a>";
        //            GetChildMenu(ref strMenu, item, allRights);
        //            strMenu += "</li>";
        //        }
        //    }
        //    //如果存在子节点，则添加ul结束标签；否则删除ul开始标签
        //    if (flag)
        //    {
        //        strMenu += "</ul>";
        //    }
        //    else
        //    {
        //        strMenu = strMenu.Substring(0, strMenu.Length - 4);
        //    }
        //}

        public ActionResult Main()
        {
            return View();
        }

        public string LogOut()
        {
            Session.Clear();
            return "ok";
        }
    }
}
