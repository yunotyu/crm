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

namespace CRM.Web.Controllers
{
    //[MyException]
    [LoginValidator]
    public class CustomerServiceManagerController : Controller
    {
        #region 服务创建
        //
        // GET: /CustomerServiceManager/
        /// <summary>
        /// 服务创建
        /// </summary>
        /// <returns></returns>
        public ActionResult ServiceCreation()
        {
            //服务类型
            ViewData["serviceType"] = new SelectList(new bas_dictService().GetDictsByType("服务类型"), "dict_value", "dict_item");
            //客服经理
            ViewData["userList"] = new SelectList(new sys_userService().GetAllWaiter(), "usr_id", "usr_name");
            //满意度
            ViewData["satisfy"] = new SelectList(new bas_dictService().GetDictsByType("客户满意度"), "dict_value", "dict_item");

            var list = new LinqHelper().Db.cst_customer.Where(c => true);
            List<SelectListItem> selectLists = new List<SelectListItem>();
            foreach(var item in list)
            {
                selectLists.Add(new SelectListItem
                {
                    Text = item.cust_name,
                    Value = item.cust_name
                });
            }

            ViewData["cst_name"] = selectLists;
            return View(new cst_service());
        }

        /// <summary>
        /// 服务创建请求
        /// </summary>
        /// <param name="forms"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ServiceCreation(FormCollection forms)
        {
            cst_service newObj = new cst_service();
            UpdateModel<cst_service>(newObj);
            newObj.svr_create_date = DateTime.Now;
            newObj.svr_create_id = (Session["user"] as sys_user).usr_id;
            newObj.svr_create_by = (Session["user"] as sys_user).usr_name;
            newObj.svr_status = "新创建";
            newObj.svr_cust_no = new cst_customerService().GetCustomerByName(newObj.svr_cust_name).cust_no;
            new cst_serviceService().AddService(newObj);
            return RedirectToAction("ServiceCreation");
        }
        #endregion

        #region 服务分配
        /// <summary>
        /// 服务分配
        /// </summary>
        /// <returns></returns>
        public ActionResult ServiceAdmeasure()
        {
            cst_service searchEntity = new cst_service();
            searchEntity.svr_status = "新创建";
            ViewData["pagerHelper"] = new PageHelper<cst_service>(new LinqHelper().Db.cst_service.Where(s=>true).ToList(), 1, 3);
            //服务类型
            ViewData["serviceType"] = new SelectList(new bas_dictService().GetDictsByType("服务类型"), "dict_value", "dict_item");
            //客服经理
            ViewData["userList"] = new SelectList(new sys_userService().GetAllWaiter(), "usr_id", "usr_name");
            ViewData["date1"] = "";
            ViewData["date2"] = "";

            var list = new LinqHelper().Db.cst_customer.Where(c => true);
            List<SelectListItem> selectLists = new List<SelectListItem>();
            foreach (var item in list)
            {
                selectLists.Add(new SelectListItem
                {
                    Text = item.cust_name,
                    Value = item.cust_name
                });
            }

            ViewData["cst_name"] = selectLists;

            return View(searchEntity);
        }
        /// <summary>
        /// 服务分配分页请求
        /// </summary>
        /// <param name="forms"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ServiceAdmeasure(FormCollection forms)
        {
            Expression<Func<cst_service,bool>> exp = null;
            exp = ExpressionUtils.True<cst_service>();
            exp = Search(forms);
            var list = new LinqHelper().Db.cst_service.Where(exp.Compile()).ToList();

            int curPage = int.Parse(forms["curPage"]);
            cst_service searchEntity = new cst_service();
            searchEntity.svr_status = "新创建";
            UpdateModel<cst_service>(searchEntity);
           
            ViewData["pagerHelper"] = new PageHelper<cst_service>(list, curPage, 3);
            //服务类型
            ViewData["serviceType"] = new SelectList(new bas_dictService().GetDictsByType("服务类型"), "dict_value", "dict_item");
            //客服经理
            ViewData["userList"] = new SelectList(new sys_userService().GetAllWaiter(), "usr_id", "usr_name");
            ViewData["date1"] = forms["date1"];
            ViewData["date2"] = forms["date2"];

            var c = new LinqHelper().Db.cst_customer.Where(cs => true); 
            List<SelectListItem> selectLists = new List<SelectListItem>();
            foreach (var item in c)
            {
                selectLists.Add(new SelectListItem
                {
                    Text = item.cust_name,
                    Value = item.cust_name
                });
            }

            ViewData["cst_name"] = selectLists;
            return View(searchEntity);
        }
        /// <summary>
        /// 服务分配请求
        /// </summary>
        /// <param name="forms"></param>
        /// <returns></returns>
        public string AllotService(FormCollection forms)
        {
            if (!int.TryParse(forms["srvId"],out int srvId)|| !int.TryParse(forms["svr_due_id"], out int srvDueId))
            {
                return "no";
            }

            var db = new LinqHelper().Db;
            var s = db.cst_service.Where(ser => ser.svr_id == srvId).FirstOrDefault();
            s.svr_due_to= new sys_userService().GetUserByUserId(srvDueId).usr_name;
            s.svr_status = "已分配";
            s.svr_due_date = DateTime.Now;
            try
            {

                db.SaveChanges();
            }
            catch (Exception e)
            {

                throw;
            }
            

            //成功后返回标记
            return "ok";
        }
        /// <summary>
        /// 删除服务
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteService(int? id)
        {
            new cst_serviceService().DeleteService(id.Value);
            return RedirectToAction("ServiceAdmeasure");
        }
        #endregion

        #region 服务处理
        /// <summary>
        /// 服务处理
        /// </summary>
        /// <returns></returns>
        public ActionResult ServiceDispose()
        {
            cst_service searchEntity = new cst_service();
            searchEntity.svr_status = "已分配";
            ViewData["pagerHelper"] = new PageHelper<cst_service>(new LinqHelper().Db.cst_service.Where(s=>s.svr_status=="已分配").ToList(), 1, 3);
            //服务类型
            ViewData["serviceType"] = new SelectList(new bas_dictService().GetDictsByType("服务类型"), "dict_value", "dict_item");
            //客服经理
            ViewData["userList"] = new SelectList(new sys_userService().GetAllWaiter(), "usr_id", "usr_name");
            ViewData["date1"] = "";
            ViewData["date2"] = "";

            var list = new LinqHelper().Db.cst_customer.Where(c => true);
            List<SelectListItem> selectLists = new List<SelectListItem>();
            foreach (var item in list)
            {
                selectLists.Add(new SelectListItem
                {
                    Text = item.cust_name,
                    Value = item.cust_name
                });
            }

            ViewData["cst_name"] = selectLists;

            return View(searchEntity);
        }
        /// <summary>
        /// 服务分配分页请求
        /// </summary>
        /// <param name="forms"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ServiceDispose(FormCollection forms)
        {
            Expression<Func<cst_service, bool>> exp = null;
            int curPage = int.Parse(forms["curPage"]);
            exp = Search(forms);
            exp = ExpressionUtils.And<cst_service>(exp, s => s.svr_status == "已分配");
            var list = new LinqHelper().Db.cst_service.Where(exp.Compile()).ToList();

            cst_service searchEntity = new cst_service();
            searchEntity.svr_status = "已分配";
            UpdateModel<cst_service>(searchEntity);

            ViewData["pagerHelper"] = new PageHelper<cst_service>(list, curPage, 3);
            //服务类型
            ViewData["serviceType"] = new SelectList(new bas_dictService().GetDictsByType("服务类型"), "dict_value", "dict_item");
            //客服经理
            ViewData["userList"] = new SelectList(new sys_userService().GetAllWaiter(), "usr_id", "usr_name");
            ViewData["date1"] = forms["date1"];
            ViewData["date2"] = forms["date2"];

            var l = new LinqHelper().Db.cst_customer.Where(c => true);
            List<SelectListItem> selectLists = new List<SelectListItem>();
            foreach (var item in l)
            {
                selectLists.Add(new SelectListItem
                {
                    Text = item.cust_name,
                    Value = item.cust_name
                });
            }

            ViewData["cst_name"] = selectLists;

            return View(searchEntity);
        }
        /// <summary>
        /// 处理服务
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ServiceDisposing(int? id)
        {
            return View(new cst_serviceService().GetServiceByServiceId(id.Value));
        }
        /// <summary>
        /// 处理服务
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ServiceDisposing(int? id, FormCollection forms)
        {
            var db = new LinqHelper().Db;
            //实例化新对象用于接收请求的数据
            cst_service newObj = db.cst_service.Where(s => s.svr_id == id).FirstOrDefault();
            //将页面数据添加到对象中
            newObj.svr_deal = forms["svr_deal"];
            newObj.svr_deal_date = DateTime.Now;
            newObj.svr_deal_by = (Session["user"] as sys_user).usr_name;
            newObj.svr_deal_id = (Session["user"] as sys_user).usr_id;
            newObj.svr_status = "已处理";
            db.Entry(newObj).Property("svr_deal").IsModified = true;
            db.Entry(newObj).Property("svr_deal_date").IsModified = true;
            db.Entry(newObj).Property("svr_deal_by").IsModified = true;
            db.Entry(newObj).Property("svr_deal_id").IsModified = true;
            db.Entry(newObj).Property("svr_status").IsModified = true;
            //修改
            db.SaveChanges();
            return RedirectToAction("ServiceDispose");
        }
        #endregion

        #region 服务反馈
        /// <summary>
        /// 服务反馈
        /// </summary>
        /// <returns></returns>
        public ActionResult ServiceFeedback()
        {
            cst_service searchEntity = new cst_service();
            searchEntity.svr_status = "已处理";
            ViewData["pagerHelper"] = new PageHelper<cst_service>(new LinqHelper().Db.cst_service.Where(s=>s.svr_status=="已处理").ToList(), 1, 3);
            //服务类型
            ViewData["serviceType"] = new SelectList(new bas_dictService().GetDictsByType("服务类型"), "dict_value", "dict_item");
            //客服经理
            ViewData["userList"] = new SelectList(new sys_userService().GetAllWaiter(), "usr_id", "usr_name");
            ViewData["date1"] = "";
            ViewData["date2"] = "";
            var list = new LinqHelper().Db.cst_customer.Where(c => true);
            List<SelectListItem> selectLists = new List<SelectListItem>();
            foreach (var item in list)
            {
                selectLists.Add(new SelectListItem
                {
                    Text = item.cust_name,
                    Value = item.cust_name
                });
            }

            ViewData["cst_name"] = selectLists;
            return View(searchEntity);
        }
        /// <summary>
        /// 服务反馈分页请求
        /// </summary>
        /// <param name="forms"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ServiceFeedback(FormCollection forms)
        {
            int curPage = int.Parse(forms["curPage"]);
            Expression<Func<cst_service, bool>> exp = null;
            exp = Search(forms);
            exp = ExpressionUtils.And<cst_service>(exp, s => s.svr_status == "已处理");
            var list = new LinqHelper().Db.cst_service.Where(exp.Compile()).ToList();

            cst_service searchEntity = new cst_service();
            searchEntity.svr_status = "已处理";
            UpdateModel<cst_service>(searchEntity);
           
            ViewData["pagerHelper"] = new PageHelper<cst_service>(list, curPage, 1);
            //服务类型
            ViewData["serviceType"] = new SelectList(new bas_dictService().GetDictsByType("服务类型"), "dict_value", "dict_item");
            //客服经理
            ViewData["userList"] = new SelectList(new sys_userService().GetAllWaiter(), "usr_id", "usr_name");
            ViewData["date1"] = forms["date1"];
            ViewData["date2"] = forms["date2"];
            var l = new LinqHelper().Db.cst_customer.Where(c => true);
            List<SelectListItem> selectLists = new List<SelectListItem>();
            foreach (var item in l)
            {
                selectLists.Add(new SelectListItem
                {
                    Text = item.cust_name,
                    Value = item.cust_name
                });
            }

            ViewData["cst_name"] = selectLists;
            return View(searchEntity);
        }
        
        /// <summary>
        /// 服务反馈处理
        /// </summary>
        /// <returns></returns>
        public ActionResult ServiceFeedbacking(int? id)
        {
            //满意度
            ViewData["satisfy"] = new SelectList(new bas_dictService().GetDictsByType("客户满意度"), "dict_value", "dict_item");
            return View(new cst_serviceService().GetServiceByServiceId(id.Value));
        }
        /// <summary>
        /// 处理反馈处理请求
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ServiceFeedbacking(int? id, FormCollection forms)
        {
            //实例化新对象用于接收请求的数据
            cst_service newObj = new RefreshMyModel().RefreshToFormCollection<cst_service>(ref forms, new cst_serviceService().GetServiceByServiceId(id.Value));
            //将页面数据添加到对象中
            UpdateModel<cst_service>(newObj);
            newObj.svr_status = "已归档";
            //修改
            new cst_serviceService().UpdateService(newObj);
            return RedirectToAction("ServiceFeedback");
        }
        #endregion

        #region 服务归档
        /// <summary>
        /// 服务归档
        /// </summary>
        /// <returns></returns>
        public ActionResult ServicePigeonhole()
        {
            cst_service searchEntity = new cst_service();
            searchEntity.svr_status = "已归档";
            ViewData["pagerHelper"] = new PageHelper<cst_service>(new LinqHelper().Db.cst_service.Where(s=>s.svr_status=="已归档").ToList(), 1, 3);
            //服务类型
            ViewData["serviceType"] = new SelectList(new bas_dictService().GetDictsByType("服务类型"), "dict_value", "dict_item");
            //客服经理
            ViewData["userList"] = new SelectList(new sys_userService().GetAllWaiter(), "usr_id", "usr_name");
            ViewData["date1"] = "";
            ViewData["date2"] = "";
            var list = new LinqHelper().Db.cst_customer.Where(c => true);
            List<SelectListItem> selectLists = new List<SelectListItem>();
            foreach (var item in list)
            {
                selectLists.Add(new SelectListItem
                {
                    Text = item.cust_name,
                    Value = item.cust_name
                });
            }

            ViewData["cst_name"] = selectLists;
            return View(searchEntity);
        }
        /// <summary>
        /// 服务归档分页请求
        /// </summary>
        /// <param name="forms"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ServicePigeonhole(FormCollection forms)
        {
            int curPage = int.Parse(forms["curPage"]);

            Expression<Func<cst_service, bool>> exp = null;
            exp = Search(forms);
            exp = ExpressionUtils.And<cst_service>(exp, s => s.svr_status == "已归档");
            var list = new LinqHelper().Db.cst_service.Where(exp.Compile()).ToList();

            cst_service searchEntity = new cst_service();
            searchEntity.svr_status = "已归档";
            UpdateModel<cst_service>(searchEntity);
          
            ViewData["pagerHelper"] = new PageHelper<cst_service>(list, curPage, 1);
            //服务类型
            ViewData["serviceType"] = new SelectList(new bas_dictService().GetDictsByType("服务类型"), "dict_value", "dict_item");
            //客服经理
            ViewData["userList"] = new SelectList(new sys_userService().GetAllWaiter(), "usr_id", "usr_name");
            ViewData["date1"] = forms["date1"];
            ViewData["date2"] = forms["date2"];
            var l = new LinqHelper().Db.cst_customer.Where(c => true);
            List<SelectListItem> selectLists = new List<SelectListItem>();
            foreach (var item in l)
            {
                selectLists.Add(new SelectListItem
                {
                    Text = item.cust_name,
                    Value = item.cust_name
                });
            }

            ViewData["cst_name"] = selectLists;
            return View(searchEntity);
        }
        public ActionResult CustomerServiceInfo(int? id)
        {
            //满意度
            return View(new cst_serviceService().GetServiceByServiceId(id.Value));
        }

        #endregion


        /// <summary>
        /// 搜索条件拼接
        /// </summary>
        /// <param name="forms"></param>
        /// <returns></returns>
        Expression<Func<cst_service, bool>> Search(FormCollection forms)
        {
            Expression<Func<cst_service, bool>> exp = null;
            exp = ExpressionUtils.True<cst_service>();
            if (!string.IsNullOrEmpty(forms["svr_cust_name"]))
            {
                exp = ExpressionUtils.And<cst_service>(exp, s => s.svr_cust_name.Contains(forms["svr_cust_name"]));
            }
            if (!string.IsNullOrEmpty(forms["svr_type"]))
            {
                exp = ExpressionUtils.And<cst_service>(exp, s => s.svr_type==(forms["svr_type"]));
            }
            if (!string.IsNullOrEmpty(forms["svr_title"]))
            {
                exp = ExpressionUtils.And<cst_service>(exp, s => s.svr_title.Contains(forms["svr_title"]));
            }
            if (DateTime.TryParse(forms["date1"], out DateTime date1) && DateTime.TryParse(forms["date2"], out DateTime date2))
            {

                exp = ExpressionUtils.And<cst_service>(exp, s => s.svr_create_date >= date1 && s.svr_create_date <= date2);
            }
            return exp;
        }
    }
}
