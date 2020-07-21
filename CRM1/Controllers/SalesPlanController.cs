using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.Model;
using CRM.BLL;
using CRM.DAL;
using System.Linq.Expressions;
using System.Data.Entity;
using CRM.Model.ViewModels;

namespace CRM.Web.Controllers
{
    [MyException]
    [LoginValidator]
    public class SalesPlanController : Controller
    {
        //
        // GET: /SalesPlan/
        /// <summary>
        /// 销售机会计划
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Index()
        {
            Chance_Plan_ViewModel search = new Chance_Plan_ViewModel();
            ViewData["pagerHelper"] = new PageHelper<sal_plan>(new LinqHelper().GetList<sal_plan>(), 1, 3);
            return View(search);
        }
        /// <summary>
        /// 销售计划查询分页
        /// </summary>
        /// <param name="forms"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(FormCollection forms)
        {
            int curPage = int.Parse(forms["curPage"]);
            Dictionary<string, object> dic = new Dictionary<string, object>();

            //存储搜索条件，每次返回页面不会使条件消失
            Chance_Plan_ViewModel search = new Chance_Plan_ViewModel
            {
                Chc_Cust_Name=forms["chc_cust_name"],
                Chc_Linkman=forms["chc_linkman"],
                Chc_Title=forms["chc_title"],
                Start_Pla_Date=forms["start_pla_date"],
                End_Pla_Date=forms["end_pla_date"],
            };

            //如果没有输入条件，直接返回全部的客户计划
            if (string.IsNullOrEmpty(forms["chc_cust_name"])&& string.IsNullOrEmpty(forms["chc_title"]) && string.IsNullOrEmpty(forms["chc_linkman"])
                 &&( string.IsNullOrEmpty(forms["start_pla_date"]) || string.IsNullOrEmpty(forms["end_pla_date"])))
            {
                var express = LinqHelper.GetExpress<sal_plan>(dic);
                var li = new LinqHelper().Db.sal_plan.Where(express).ToList();
                ViewData["pagerHelper"] = new PageHelper<sal_plan>(li, curPage, 3);
                return View(search);
            }

            //只查询日期
            if (!string.IsNullOrEmpty(forms["start_pla_date"]) && !string.IsNullOrEmpty(forms["end_pla_date"])
                && string.IsNullOrEmpty(forms["chc_cust_name"]) && string.IsNullOrEmpty(forms["chc_title"]) && string.IsNullOrEmpty(forms["chc_linkman"]))
            {
                DateTime start_pla_date = Convert.ToDateTime(forms["start_pla_date"]);
                DateTime end_pla_date = Convert.ToDateTime(forms["end_pla_date"]);
                var li = new LinqHelper().Db.sal_plan.Where(p => p.pla_date >= start_pla_date && p.pla_date <= end_pla_date).ToList();
                ViewData["pagerHelper"] = new PageHelper<sal_plan>(li, curPage, 3);
                return View(search);
            }

            //日期为空时
            List<sal_plan> plans = new List<sal_plan>();
            foreach (var key in forms.AllKeys)
            {
                dic.Add(key, forms[key]);
            }
            var expression = LinqHelper.GetExpress<sal_chance>(dic);
            plans = new LinqHelper().Db.sal_chance.Include(p => p.sal_plan).Where(expression).SelectMany(c => c.sal_plan).ToList();

            if (string.IsNullOrEmpty(forms["start_pla_date"]) || string.IsNullOrEmpty(forms["end_pla_date"]))
            {
                ViewData["pagerHelper"] = new PageHelper<sal_plan>(plans, curPage, 3);
            }
            //查询日期和其他条件的情况
            else
            {
                DateTime start_pla_date = Convert.ToDateTime(forms["start_pla_date"]);
                DateTime end_pla_date = Convert.ToDateTime(forms["end_pla_date"]);
                var li= plans.Where(p => p.pla_date >= start_pla_date && p.pla_date <= end_pla_date).ToList();
                ViewData["pagerHelper"] = new PageHelper<sal_plan>(li, curPage, 3);
            }
            
            return View(search);
        }

        #region 制定计划
        /// <summary>
        /// 制定计划
        /// </summary>
        /// <param name="id">客户编号</param>
        /// <returns></returns>
        public ActionResult AddPlan(int? id)
        {
            ViewData["curSal"] = new sal_chanceService().GetSalById(id.Value);
            ViewData["pagerHelper"] = new PageHelper<sal_plan>(new sal_planService().GetPlanBySalId(id.Value), 0, 3);
            return View();
        }

        /// <summary>
        /// 制定计划（添加计划项）请求页
        /// </summary>
        /// <param name="id">客户编号</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddPlan(int? id, FormCollection forms)
        {
            sal_plan sal = new sal_plan();
            UpdateModel<sal_plan>(sal);
            sal.pla_chc_id = id.Value;
            new sal_planService().AddPlan(sal);
            return RedirectToAction("AddPlan");
        }
        /// <summary>
        /// 修改计划项
        /// </summary>
        /// <param name="forms"></param>
        /// <returns></returns>
        [HttpPost]
        public string UpdateTodoPlan(FormCollection forms)
        {
            sal_plan sal = new sal_plan();
            UpdateModel<sal_plan>(sal);
            new sal_planService().UpdateTodoPlan(sal);
            return "ok";
        }
        /// <summary>
        /// 删除计划项
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DeletePlan(int? id)
        {
            new sal_planService().DeletePlanByPlanId(id.Value);
            return "ok";
        }
        #endregion

        #region 执行计划
        /// <summary>
        /// 执行计划
        /// </summary>
        /// <param name="id">客户编号</param>
        /// <returns></returns>
        public ActionResult ExcutePlan(int? id)
        {
            ViewData["curSal"] = new sal_chanceService().GetSalById(id.Value);
            ViewData["pagerHelper"] = new PageHelper<sal_plan>(new sal_planService().GetPlanBySalId(id.Value), 0, 3);
            return View();
        }
        /// <summary>
        /// 执行计划
        /// </summary>
        /// <param name="forms"></param>
        /// <returns></returns>
        [HttpPost]
        public string UpdateTodoPlanResult(FormCollection forms)
        {
            sal_plan sal = new sal_plan();
            UpdateModel<sal_plan>(sal);
            new sal_planService().UpdateTodoPlanResult(sal);
            return "ok";
        }
        /// <summary>
        /// 开发失败（终止开发）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult PlanError(int? id)
        {
            new sal_planService().PlanError(id.Value);
            return RedirectToAction("Index");
        }
        /// <summary>
        /// 开发成功
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult PlanOk(int? id)
        {
            new sal_planService().PlanOk(id.Value, (Session["user"] as sys_user).usr_id, (Session["user"] as sys_user).usr_name);
            return RedirectToAction("Index");
        }

        #endregion

        #region 计划详细
        /// <summary>
        /// 计划详细（归档）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult PlanInfo(int? id)
        {
            ViewData["curSal"] = new sal_chanceService().GetSalById(id.Value);
            ViewData["pagerHelper"] = new PageHelper<sal_plan>(new sal_planService().GetPlanBySalId(id.Value),0, 3);
            return View();
        }
        #endregion
    }
}