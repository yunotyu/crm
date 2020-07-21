using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.Model;
using CRM.BLL;
using CRM.DAL;
using System.Linq.Expressions;
using CRM.Model.Utils;
using CRM.Model.ViewModels;

namespace CRM.Web.Controllers
{
    //[MyException]
    [LoginValidator]
    public class CustomerManagerController : Controller
    {
        #region 客户信息

        //
        // GET: /CustomerManager/
        /// <summary>
        /// 客户信息
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewData["pagerHelper"] = new PageHelper<cst_customer>(new LinqHelper().GetList<cst_customer>(), 1, 3);
            ViewData["region"] = new SelectList(new bas_dictService().GetDictsByType("地区"), "dict_value", "dict_item");
            ViewData["level"] = new SelectList(new bas_dictService().GetDictsByType("客户等级"), "dict_value", "dict_item");
            return View(new Cst_Custom_ViewModel());
        }

        /// <summary>
        /// 客户信息查询
        /// </summary>
        /// <param name="forms"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(FormCollection forms)
        {

            //拼接条件
            Expression<Func<cst_customer, bool>> expression = null;

            int curPage = int.Parse(forms["curPage"]);

            var cust_no1 = forms["cust_no"];
            var cust_name1 = forms["cust_name"];
            var cust_manager_name1 = forms["cust_manager_name"];
            var cust_level1 = forms["cust_level"];
            var cust_region1= forms["cust_region"];

            //存储搜索条件
            Cst_Custom_ViewModel searchEntity = new Cst_Custom_ViewModel
            {
                cust_no = cust_no1,
                cust_name = cust_name1,
                cust_manager_name = cust_manager_name1,
                cust_level = cust_level1,
                cust_region = cust_region1
            };

            //进行条件拼接
            //if (string.IsNullOrEmpty(cust_no1) && string.IsNullOrEmpty(cust_name1)
            //    && string.IsNullOrEmpty(cust_manager_name1) && string.IsNullOrEmpty(cust_level1))
            //{
             expression = ExpressionUtils.True<cst_customer>();

            //}

            if (!string.IsNullOrEmpty(cust_no1))
            {
                expression = ExpressionUtils.And<cst_customer>(expression, f =>f.cust_no.Contains(cust_no1));
            }

            if (!string.IsNullOrEmpty(cust_name1))
            {
                expression = ExpressionUtils.And<cst_customer>(expression,f =>f.cust_name.Contains(cust_name1));
            }

            if (!string.IsNullOrEmpty(cust_manager_name1))
            {
                expression = ExpressionUtils.And<cst_customer>(expression,f =>f.cust_manager_name.Contains(cust_manager_name1));
            }

            if (!string.IsNullOrEmpty(cust_region1))
            {
                expression = ExpressionUtils.And<cst_customer>(expression, f => f.cust_region == cust_region1);
            }

            if (!string.IsNullOrEmpty(cust_level1))
            {
                var r= int.TryParse(cust_level1, out int i) ? i : -1;
                expression = ExpressionUtils.And<cst_customer>(expression, f => f.cust_level == i);
            }

            var compileExp = expression.Compile();

            //最后使用拼接条件
            ViewData["pagerHelper"] = new PageHelper<cst_customer>(new LinqHelper().Db.cst_customer.Where(compileExp).ToList(), curPage, 3);

            ViewData["region"] = new SelectList(new bas_dictService().GetDictsByType("地区"), "dict_value", "dict_item");
            ViewData["level"] = new SelectList(new bas_dictService().GetDictsByType("客户等级"), "dict_value", "dict_item");
            return View(searchEntity);
        }

        public ActionResult Delete(int? id)
        {
            new cst_customerService().DeleteCustomerById(id.Value);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 修改客户信息
        /// </summary>
        /// <param name="id">客户编号</param>
        /// <returns></returns>
        public ActionResult Update(int? id)
        {
            ViewData["region"] = new SelectList(new bas_dictService().GetDictsByType("地区"), "dict_value", "dict_item");
            ViewData["sys_user"] = new SelectList(new sys_userService().GetAllWaiter(), "usr_id", "usr_name");
            ViewData["level"] = new SelectList(new bas_dictService().GetDictsByType("客户等级"), "dict_value", "dict_item");
            ViewData["satisfy"] = new SelectList(new bas_dictService().GetDictsByType("客户满意度"), "dict_value", "dict_item");
            ViewData["credit"] = new SelectList(new bas_dictService().GetDictsByType("客户信用度"), "dict_value", "dict_item");
            return View(new cst_customerService().GetCustomerById(id.Value));
        }

        /// <summary>
        /// 修改客户信息请求
        /// </summary>
        /// <param name="id">客户编号</param>
        /// <param name="forms"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update(FormCollection forms)
        {
            //cst_customer c = new cst_customer();
            //c.cust_no = forms["cust_no"];
            //if (int.TryParse(forms["cust_Id"], out int id))
            //{
            //    c.cust_Id = id;
            //}
            //var linq = new LinqHelper();
            //linq.Db.Set<cst_customer>().Attach(c);

            //foreach (var p in c.GetType().GetProperties())
            //{
            //    var propName = p.Name;
            //    var proType = p.PropertyType;
            //    if (proType.Name.Contains("ICollection"))
            //    {
            //        continue;
            //    }
            //    {
            //        var o = Coommon.Cast(p.PropertyType.Name, forms[propName]);
            //        c.GetType().GetProperty(propName).SetValue(c, o);
            //    }
            //}
            //linq.Db.Entry<cst_customer>(c).State = System.Data.Entity.EntityState.Modified;
            //linq.Db.SaveChanges();

            Dictionary<string, object> dic = new Dictionary<string, object>();

            //保存客户等级管理人姓名
            cst_customer c = new cst_customer();
            if(int.TryParse(forms["cust_manager_id"],out int val))
            {
                var name = new LinqHelper().Db.sys_user.Where(u => u.usr_id == val).Select(u => u.usr_name).FirstOrDefault();
                dic.Add("cust_manager_name", name);
            }
            if (int.TryParse(forms["cust_level"], out int val1))
            {
                var level_label = Common.GetCstManaName("cust_level", val1.ToString());
                dic.Add("cust_level_label", level_label);
            }

            foreach (var key in forms.AllKeys)
            {
                dic.Add(key, forms[key]);
            }

            Common.UpdateSomeFiel<cst_customer>(c, dic, new LinqHelper().Db);
            return RedirectToAction("Index");
        }

        #endregion

        #region 联系人

        /// <summary>
        /// 联系人
        /// </summary>
        /// <param name="id">客户编号</param>
        /// <returns></returns>
        public ActionResult LinkMan(int? id)
        {
            ViewData["pagerHelper"] = new PageHelper<cst_linkman>(new cst_linkmanService().GetLinkMansByCustomerId(id.Value), 1, 3);
            return View(new cst_customerService().GetCustomerById(id.Value));
        }
        /// <summary>
        /// 联系人
        /// </summary>
        /// <param name="id">客户编号</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult LinkMan(int? id, FormCollection forms)
        {
            int curPage = int.Parse(forms["curPage"]);
            ViewData["pagerHelper"] = new PageHelper<cst_linkman>(new cst_linkmanService().GetLinkMansByCustomerId(id.Value), curPage, 3);
            return View(new cst_customerService().GetCustomerById(id.Value));
        }
        /// <summary>
        /// 修改联系人
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult UpdateLinkMan(int? id)
        {
            return View(new cst_linkmanService().GetLinkManById(id.Value));
        }
        /// <summary>
        /// 修改联系人请求
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateLinkMan(int? id, FormCollection forms)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            foreach (var key in forms.AllKeys)
            {
                dic.Add(key, forms[key]);
            }
            Common.UpdateSomeFiel<cst_linkman>(new cst_linkman(), dic, new LinqHelper().Db);
            return RedirectToAction("LinkMan", new { id = new cst_linkmanService().GetLinkManById(id.Value).cst_customer.cust_Id });
        }
        /// <summary>
        /// 删除联系人
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteLinkMan(int? id)
        {
            int cst_id = new cst_linkmanService().GetLinkManById(id.Value).cst_customer.cust_Id;
            new cst_linkmanService().DeleteLinkManById(id.Value);
            return RedirectToAction("LinkMan", new { id = cst_id });
        }

        /// <summary>
        /// 添加联系人
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult AddLinkMan(int? id)
        {
            ViewData["cst_id"] = id.Value;
            return View(new cst_linkman());
        }
        /// <summary>
        /// 添加联系人请求
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddLinkMan(int? id, FormCollection forms)
        {
            //实例化新对象用于接收请求的数据
            cst_linkman newObj = new cst_linkman();
            //将数据填充到对象中
            UpdateModel<cst_linkman>(newObj);
            cst_customer customer = new cst_customerService().GetCustomerById(id.Value);
            newObj.lkm_cust_no = customer.cust_no;
            newObj.lkm_cust_name = customer.cust_name;
            //修改
            new cst_linkmanService().AddLinkMan(newObj);
            return RedirectToAction("LinkMan", new { id = id.Value });
        }

        #endregion

        #region  交往记录
        /// <summary>
        /// 交往记录
        /// </summary>
        /// <param name="id">客户编号</param>
        /// <returns></returns>
        public ActionResult ContactRecord(string id)
        {
            ViewData["pagerHelper"] = new PageHelper<cst_activity>(new cst_activityService().GetActivityByCustomerId(id), 1, 3);
            return View(new LinqHelper().Db.cst_customer.Where(c=>c.cust_no==id).FirstOrDefault());
        }

        /// <summary>
        /// 交往记录分页请求
        /// </summary>
        /// <param name="id">客户编号</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ContactRecord(string id, FormCollection forms)
        {
            int curPage = int.Parse(forms["curPage"]);
            ViewData["pagerHelper"] = new PageHelper<cst_activity>(new cst_activityService().GetActivityByCustomerId(id), curPage, 3);
            return View(new LinqHelper().Db.cst_customer.Where(c => c.cust_no == id).FirstOrDefault());
        }
        /// <summary>
        /// 添加交往记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult AddContactRecord(string id)
        {
            ViewData["cst_no"] = id;
            return View(new cst_activity());
        }
        /// <summary>
        /// 添加联系人请求
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddContactRecord(string id, FormCollection forms)
        {
            //实例化新对象用于接收请求的数据
            cst_activity newObj = new cst_activity();
            //将数据填充到对象中
            UpdateModel<cst_activity>(newObj);
            cst_customer customer = new LinqHelper().Db.cst_customer.Where(c => c.cust_no == id).FirstOrDefault();
            newObj.atv_cust_no = customer.cust_no;
            newObj.atv_cust_name = customer.cust_name;
            //修改
            new cst_activityService().AddContactRecord(newObj);
            return RedirectToAction("ContactRecord", new { id = id });
        }
        /// <summary>
        /// 修改交往记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult UpdateContactRecord(int? id,string no)
        {
            ViewData["no"] = no;
            return View(new cst_activityService().GetActivityById(id.Value));
        }
        /// <summary>
        /// 修改交往记录请求
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateContactRecord(int? id, FormCollection forms)
        {
            //实例化新对象用于接收请求的数据
            cst_activity newObj = new RefreshMyModel().RefreshToFormCollection<cst_activity>(ref forms, new cst_activityService().GetActivityById(id.Value));
            //将数据填充到对象中
            UpdateModel<cst_activity>(newObj);
            //修改
            new cst_activityService().UpdateContactRecord(newObj);
            return RedirectToAction("ContactRecord", new { id = new cst_activityService().GetActivityById(id.Value).cst_customer.cust_Id });
        }
        /// <summary>
        /// 删除交往记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteContactRecord(int? id)
        {
            int cst_id = new cst_activityService().GetActivityById(id.Value).cst_customer.cust_Id;
            new cst_activityService().DeleteContactRecord(id.Value);
            return RedirectToAction("ContactRecord", new { id = cst_id });
        }

        #endregion

        #region 历史订单

        /// <summary>
        /// 历史订单
        /// </summary>
        /// <param name="id">客户编号</param>
        /// <returns></returns>
        public ActionResult OrderHistory(string id)
        {
            ViewData["pagerHelper"] = new PageHelper<orders>(new ordersService().GetOrdersByCustomerNo(id), 1, 3);
            return View(new cst_customerService().GetCustomerByNo(id));
        }

        /// <summary>
        /// 历史订单分页请求
        /// </summary>
        /// <param name="id">客户编号</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult OrderHistory(string id, FormCollection forms)
        {
            int curPage = int.Parse(forms["curPage"]);
            ViewData["pagerHelper"] = new PageHelper<orders>(new ordersService().GetOrdersByCustomerNo(id), curPage, 3);
            return View(new cst_customerService().GetCustomerByNo(id));
        }

        /// <summary>
        /// 订单详细
        /// </summary>
        /// <param name="id">订单编号</param>
        /// <returns></returns>
        public ActionResult OrderHistoryInfo(int? id)
        {
            List<orders_line> list = new orders_lineService().GetOrderLinesByOrderId(id.Value);
            ViewData["pagerHelper"] = new PageHelper<orders_line>(list, 1, 1);
            ViewData["totalMoney"] = list.Sum(o => o.odd_price * o.odd_count).Value;
            return View(new ordersService().GetOrderById(id.Value));
        }

        /// <summary>
        /// 订单详细分页请求
        /// </summary>
        /// <param name="id">订单编号</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult OrderHistoryInfo(int? id, FormCollection forms)
        {
            int curPage = int.Parse(forms["curPage"]);
            List<orders_line> list = new orders_lineService().GetOrderLinesByOrderId(id.Value);
            ViewData["pagerHelper"] = new PageHelper<orders_line>(list, curPage, 3);
            ViewData["totalMoney"] = list.Sum(o => o.odd_price * o.odd_count).Value;
            return View(new ordersService().GetOrderById(id.Value));
        }
        #endregion
    }
}
