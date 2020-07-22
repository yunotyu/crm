﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.Model;
using CRM.BLL;
using CRM.DAL;
using System.Linq.Expressions;
using CRM.Model.Utils;

namespace CRM.Web.Controllers
{
    /// <summary>
    /// 流失客户管理控制器
    /// </summary>
    [MyException]
    [LoginValidator]
    public class CustomerLostController : Controller
    {
        #region 流失客户
        //
        // GET: /CustomerLost/
        /// <summary>
        /// 流失客户信息
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //实例化查询对象
            cst_lost searchEntity = new cst_lost();
            //获得分页数据
            ViewData["pagerHelper"] = new PageHelper<cst_lost>(new LinqHelper().Db.cst_lost.Where(l=>true).ToList(), 1, 3);
            ViewData["cstStatus"] = new SelectList(new bas_dictService().GetDictsByType("客户流失状态"), "dict_value", "dict_item");
            return View(searchEntity);
        }
        /// <summary>
        /// 流失客户信息分页请求
        /// </summary>
        /// <param name="forms"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(FormCollection forms)
        {
            
            int curPage = int.Parse(forms["curPage"]);
            Expression<Func<cst_lost, bool>> expression = null;
            expression = ExpressionUtils.True<cst_lost>();
            if (!string.IsNullOrEmpty(forms["lst_cust_name"]))
            {
                expression = ExpressionUtils.And<cst_lost>(expression, l => l.lst_cust_name.Contains(forms["lst_cust_name"]));
            }
            if (!string.IsNullOrEmpty(forms["lst_cust_manager_name"]))
            {
                expression = ExpressionUtils.And<cst_lost>(expression, l => l.lst_cust_manager_name.Contains(forms["lst_cust_manager_name"]));
            }
            if (int.TryParse(forms["lst_status"],out int status))
            {
                expression = ExpressionUtils.And<cst_lost>(expression, l => l.lst_status== status);
            }
            var list = new LinqHelper().Db.cst_lost.Where(expression.Compile()).ToList();

            cst_lost searchEntity = new cst_lost();
            UpdateModel<cst_lost>(searchEntity);
            ViewData["pagerHelper"] = new PageHelper<cst_lost>(list, curPage, 3);
            ViewData["cstStatus"] = new SelectList(new bas_dictService().GetDictsByType("客户流失状态"), "dict_value", "dict_item");
            return View(searchEntity);
        }
        /// <summary>
        /// 暂缓流失
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult CustomerLosting(int? id)
        {
            new cst_lostService().CustomerLosting(id.Value);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 确认流失
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult CustomerLosted(int? id)
        {
            new cst_lostService().CustomerLosted(id.Value);
            return RedirectToAction("Index");
        }



        #endregion
    }
}
