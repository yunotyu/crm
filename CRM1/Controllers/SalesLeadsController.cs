using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.Model;
using CRM.BLL;
using CRM.DAL;

namespace CRM.Web.Controllers
{
    /// <summary>
    /// 销售机会管理
    /// </summary>
    //[MyException]
    [LoginValidator]
    public class SalesLeadsController : Controller
    {

        //
        // GET: /SalesLeads/
        /// <summary>
        /// 销售机会管理
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            sal_chance searchEntity = new sal_chance();
            searchEntity.chc_status = 0;
            ViewData["pagerHelper"] = new PageHelper<sal_chance>(new sal_chanceService().GetAllSal(),1, 3);
            return View(new sal_chance());
        }

        /// <summary>
        /// 销售机会分页和查询
        /// </summary>
        /// <param name="forms"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(FormCollection forms)
        {
            int curPage = int.Parse(forms["curPage"]);
            sal_chance searchEntity = new sal_chance();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            foreach (var key in forms.AllKeys)
            {
                dic.Add(key, forms[key]);
            }
            var expression = LinqHelper.GetExpress<sal_chance>(dic);

            var li= new LinqHelper().Db.sal_chance.Where(expression).ToList();

            ViewData["pagerHelper"] = new PageHelper<sal_chance>(li, curPage, 3);
            return View(searchEntity);
        }

        public ActionResult Find(FormCollection forms)
        {
           

            //if (string.IsNullOrEmpty(forms["chc_cust_name"]))
            //{
            //    chc_cust_name = forms["chc_cust_name"];
            //}
            //if (string.IsNullOrEmpty(forms["chc_title"]))
            //{
            //    chc_title = forms["chc_title"];
            //}
            //if (string.IsNullOrEmpty(forms["chc_linkman"]))
            //{
            //    chc_linkman = forms["chc_linkman"];
            //}
            return Content("");
        }

        /// <summary>
        /// 新增机会
        /// </summary>
        /// <returns></returns>
        public ActionResult AddSal()
        {
            ViewData["userList"] = new SelectList(new sys_userService().GetAllWaiter(), "usr_id", "usr_name");
            return View(new sal_chance());
        }

        /// <summary>
        /// 新增机会
        /// </summary>
        /// <param name="id"></param>
        /// <param name="forms"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddSal(FormCollection forms)
        {
            sal_chance sal = new sal_chance();
            ////如果是修改，则补全原有数据
            UpdateModel<sal_chance>(sal);
            if (!(sal.chc_id > 0))
            {
                sal.chc_create_by = (Session["user"] as sys_user).usr_name;
                sal.chc_create_id = (Session["user"] as sys_user).usr_id;
            }
            new sal_chanceService().AddOrUpdateSal(sal);
            return RedirectToAction("Index");
        }
        /// <summary>
        /// 指派
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult AllotSal(int? id)
        {
            ViewData["userList"] = new SelectList(new sys_userService().GetAllWaiter(), "usr_id", "usr_name");
            return View(new sal_chanceService().GetSalById(id.Value));
        }
        /// <summary>
        /// 指派请求
        /// </summary>
        /// <param name="id"></param>
        /// <param name="forms"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AllotSal(int? id, FormCollection forms)
        {
            //实例化新对象用于接收请求的数据
            sal_chance sal = new RefreshMyModel().RefreshToFormCollection<sal_chance>(ref forms, new sal_chanceService().GetSalById(id.Value));
            //将数据填充到对象中
            UpdateModel<sal_chance>(sal);
            //修改
            new sal_chanceService().AddOrUpdateSal(sal);
            return RedirectToAction("Index");
        }
        /// <summary>
        /// 修改机会
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Update(int? id)
        {
            ViewData["userList"] = new SelectList(new sys_userService().GetAllWaiter(), "usr_id", "usr_name");
            return View(new sal_chanceService().GetSalById(id.Value));
        }
        /// <summary>
        /// 修改机会请求
        /// </summary>
        /// <param name="id"></param>
        /// <param name="forms"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update(int? id, FormCollection forms)
        {
            //实例化新对象用于接收请求的数据
            sal_chance sal = new RefreshMyModel().RefreshToFormCollection<sal_chance>(ref forms, new sal_chanceService().GetSalById(id.Value));
            //将页面数据添加到对象中
            UpdateModel<sal_chance>(sal);
            //修改
            new sal_chanceService().AddOrUpdateSal(sal);
            //成功后返回列表页
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            //删除销售机会
            new sal_chanceService().Delete(id.Value);
            //成功后返回列表页
            return RedirectToAction("Index");
        }
    }

}

