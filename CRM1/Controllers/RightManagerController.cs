using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.Model;
using CRM.BLL;

namespace CRM.Web.Controllers
{
    [MyException]
    [LoginValidator]
    public class RightManagerController : Controller
    {
        //
        // GET: /RightManager/

        /// <summary>
        /// 权限
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewData["pagerHelper"] = new PageHelper<sys_user>(new sys_userService().GetAllUsers(), 1, 3);
            return View();
        }

        /// <summary>
        /// 权限分页查询
        /// </summary>
        /// <param name="forms"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(FormCollection forms)
        {
            int curPage = int.Parse(forms["curPage"]);
            ViewData["pagerHelper"] = new PageHelper<sys_user>(new sys_userService().GetAllUsers(), curPage, 3);
            return View();
        }
        /// <summary>
        /// 修改权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Update(int id)
        {
            sys_user controlUser = new sys_userService().GetUserByUserId(id);
            //所有菜单集合
            ViewData["allList"] = new sys_rightService().GetAllRights();
            ViewData["curList"] = new sys_rightService().GetRightsByRoleId(controlUser.usr_role_id);
            return View(controlUser);
        }
        /// <summary>
        /// 修改权限请求
        /// </summary>
        /// <param name="id"></param>
        /// <param name="forms"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update(int id, FormCollection forms)
        {
            List<sys_role_right> newList = new List<sys_role_right>();
            foreach (var item in forms.AllKeys)
            {
                sys_role_right newRight = new sys_role_right();
                newRight.rf_right_code = forms[item];
                newRight.rf_role_id = id;
                newList.Add(newRight);
            }
            new sys_rightService().UpdateRights(id, newList);
            //修改成功
            return RedirectToAction("Index");
        }
    }
}
