using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.Model;
using CRM.BLL;
using CRM.DAL;

namespace CRM.Web.Controllers
{
    /// <summary>
    /// 各类报表控制器
    /// </summary>
    [LoginValidator]
    [MyException]
    public class TheReportsController : Controller
    {
        #region 客户贡献报表分析
        /// <summary>
        /// 贡献报表分析
        /// </summary>
        /// <returns></returns>
        public ActionResult Contribute()
        {
            orders searchEntity = new orders();
            var db = new LinqHelper().Db;
            var sql = from line in db.orders_line
                      join order in db.orders
                      on line.odd_order_id equals order.odr_id
                      select new { line.odd_price, line.odd_count, order.odr_cust_name } into tab
                      group tab by tab.odr_cust_name into newGroup
                      select new ContributeReportModel { Name = newGroup.Key, TotalMoney = newGroup.Sum(n => n.odd_count * n.odd_price) };

            ViewData["pagerHelper"] = new PageHelper<ContributeReportModel>(sql.ToList(), 1, 10);
            ViewData["reportData"] = new JavaScriptSerializer().Serialize(ViewData["pagerHelper"] as PageHelper<ContributeReportModel>);
            SetYeasList();
            return View(searchEntity);
        }
        /// <summary>
        /// 贡献报表分析分页请求
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Contribute(FormCollection forms)
        {
            int curPage = int.Parse(forms["curPage"]);
            orders searchEntity = new orders();
            SetYeasList();
            UpdateModel<orders>(searchEntity);
            ViewData["pagerHelper"] = new PageHelper<ContributeReportModel>(new TheReportsService().GetContributesBySearchEntity(searchEntity), curPage, 10);
            ViewData["reportData"] = new JavaScriptSerializer().Serialize(ViewData["pagerHelper"] as PageHelper<ContributeReportModel>);
            return View(searchEntity);
        }
        /// <summary>
        /// 生成最近五年的选择项列表集合，并存放于ViewData["years"]中
        /// </summary>
        private void SetYeasList()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            SelectListItem item = new SelectListItem();
            item.Text = "--请选择--";
            item.Value = "0";
            list.Add(item);
            for (int i = 0; i < 5; i++)
            {
                item = new SelectListItem();
                item.Text = (DateTime.Now.Year - i) + "年";
                item.Value = (DateTime.Now.Year - i).ToString();
                list.Add(item);
            }
            ViewData["years"] = new SelectList(list, "Value", "Text");
        }
        #endregion

        #region 客户构成报表分析
        //
        // GET: /TheReports/
        /// <summary>
        /// 客户构成报表分析
        /// </summary>
        /// <returns></returns>
        public ActionResult Composing()
        {
            ComposingReportModel searchEntity = new ComposingReportModel();
            searchEntity.TypeName = "按等级";
            ViewData["pagerHelper"] = new PageHelper<ComposingReportModel>(new TheReportsService().GetComposingReportBySearchEntity(searchEntity), 1, 10);
            ViewData["reportData"] = new JavaScriptSerializer().Serialize(ViewData["pagerHelper"] as PageHelper<ComposingReportModel>);
            SetReportTypeList();
            return View(searchEntity);
        }
        /// <summary>
        /// 客户构成报表分析分页请求
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Composing(FormCollection forms)
        {
            int curPage = int.Parse(forms["curPage"]);
            ComposingReportModel searchEntity = new ComposingReportModel();
            UpdateModel<ComposingReportModel>(searchEntity);
            ViewData["pagerHelper"] = new PageHelper<ComposingReportModel>(new TheReportsService().GetComposingReportBySearchEntity(searchEntity), curPage, 10);
            ViewData["reportData"] = new JavaScriptSerializer().Serialize(ViewData["pagerHelper"] as PageHelper<ComposingReportModel>);
            SetReportTypeList();
            return View(searchEntity);
        }
        /// <summary>
        /// 生成客户构成报表方式的选择项列表集合，并存放于ViewData["reportType"]中
        /// </summary>
        private void SetReportTypeList()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            SelectListItem item = new SelectListItem();
            item.Text = "按等级";
            item.Value = "按等级";
            list.Add(item);
            item = new SelectListItem();
            item.Text = "按信用度";
            item.Value = "按信用度";
            list.Add(item);
            item = new SelectListItem();
            item.Text = "按满意度";
            item.Value = "按满意度";
            list.Add(item);
            ViewData["reportType"] = new SelectList(list, "Value", "Text");
        }
        #endregion

        #region 客户服务报表分析
        //
        // GET: /TheReports/
        /// <summary>
        /// 贡献报表分析
        /// </summary>
        /// <returns></returns>
        public ActionResult Service()
        {
            return View();
        }
        #endregion

        #region 客户流失报表分析
        //
        // GET: /TheReports/
        /// <summary>
        /// 贡献报表分析
        /// </summary>
        /// <returns></returns>
        public ActionResult Lost()
        {
            return View();
        }
        #endregion

    }
}
