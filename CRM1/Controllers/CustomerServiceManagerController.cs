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
            ViewData["pagerHelper"] = new PageHelper<cst_service>(new cst_serviceService().GetServicesBySearchEntity(searchEntity), 1, 3);
            //服务类型
            ViewData["serviceType"] = new SelectList(new bas_dictService().GetDictsByType("服务类型"), "dict_value", "dict_item");
            //客服经理
            ViewData["userList"] = new SelectList(new sys_userService().GetAllWaiter(), "usr_id", "usr_name");
            ViewData["date1"] = "";
            ViewData["date2"] = "";
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
            int curPage = int.Parse(forms["curPage"]);
            cst_service searchEntity = new cst_service();
            searchEntity.svr_status = "新创建";
            UpdateModel<cst_service>(searchEntity);
            List<cst_service> list = new cst_serviceService().GetServicesBySearchEntity(searchEntity);
            if (!string.IsNullOrEmpty(forms["date1"]))
            {
               list= list.Where(s => s.svr_create_date > DateTime.Parse(forms["date1"])).ToList();
            }
            if (!string.IsNullOrEmpty(forms["date2"]))
            {
                list = list.Where(s => s.svr_create_date < DateTime.Parse(forms["date2"])).ToList();
            }
            ViewData["pagerHelper"] = new PageHelper<cst_service>(list, curPage, 1);
            //服务类型
            ViewData["serviceType"] = new SelectList(new bas_dictService().GetDictsByType("服务类型"), "dict_value", "dict_item");
            //客服经理
            ViewData["userList"] = new SelectList(new sys_userService().GetAllWaiter(), "usr_id", "usr_name");
            ViewData["date1"] = forms["date1"];
            ViewData["date2"] = forms["date2"];
            return View(searchEntity);
        }
        /// <summary>
        /// 服务分配请求
        /// </summary>
        /// <param name="forms"></param>
        /// <returns></returns>
        public string AllotService(FormCollection forms)
        {
            //实例化新对象用于接收请求的数据
            cst_service newObj = new RefreshMyModel().RefreshToFormCollection<cst_service>(ref forms, new cst_serviceService().GetServiceByServiceId(int.Parse(forms["srvId"])));
            //将页面数据添加到对象中
            UpdateModel<cst_service>(newObj);
            newObj.svr_due_date = DateTime.Now;
            newObj.svr_due_to = new sys_userService().GetUserByUserId(newObj.svr_due_id.Value).usr_name;
            newObj.svr_status = "已分配";
            //修改
            new cst_serviceService().UpdateService(newObj);
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
            ViewData["pagerHelper"] = new PageHelper<cst_service>(new cst_serviceService().GetServicesBySearchEntity(searchEntity), 1, 3);
            //服务类型
            ViewData["serviceType"] = new SelectList(new bas_dictService().GetDictsByType("服务类型"), "dict_value", "dict_item");
            //客服经理
            ViewData["userList"] = new SelectList(new sys_userService().GetAllWaiter(), "usr_id", "usr_name");
            ViewData["date1"] = "";
            ViewData["date2"] = "";
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
            int curPage = int.Parse(forms["curPage"]);
            cst_service searchEntity = new cst_service();
            searchEntity.svr_status = "已分配";
            UpdateModel<cst_service>(searchEntity);
            List<cst_service> list = new cst_serviceService().GetServicesBySearchEntity(searchEntity);
            if (!string.IsNullOrEmpty(forms["date1"]))
            {
                list = list.Where(s => s.svr_create_date > DateTime.Parse(forms["date1"])).ToList();
            }
            if (!string.IsNullOrEmpty(forms["date2"]))
            {
                list = list.Where(s => s.svr_create_date < DateTime.Parse(forms["date2"])).ToList();
            }
            ViewData["pagerHelper"] = new PageHelper<cst_service>(list, curPage, 1);
            //服务类型
            ViewData["serviceType"] = new SelectList(new bas_dictService().GetDictsByType("服务类型"), "dict_value", "dict_item");
            //客服经理
            ViewData["userList"] = new SelectList(new sys_userService().GetAllWaiter(), "usr_id", "usr_name");
            ViewData["date1"] = forms["date1"];
            ViewData["date2"] = forms["date2"];
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
            //实例化新对象用于接收请求的数据
            cst_service newObj = new RefreshMyModel().RefreshToFormCollection<cst_service>(ref forms, new cst_serviceService().GetServiceByServiceId(id.Value));
            //将页面数据添加到对象中
            UpdateModel<cst_service>(newObj);
            newObj.svr_deal_date = DateTime.Now;
            newObj.svr_deal_by = (Session["user"] as sys_user).usr_name;
            newObj.svr_deal_id = (Session["user"] as sys_user).usr_id;
            newObj.svr_status = "已处理";
            //修改
            new cst_serviceService().UpdateService(newObj);
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
            ViewData["pagerHelper"] = new PageHelper<cst_service>(new cst_serviceService().GetServicesBySearchEntity(searchEntity), 1, 3);
            //服务类型
            ViewData["serviceType"] = new SelectList(new bas_dictService().GetDictsByType("服务类型"), "dict_value", "dict_item");
            //客服经理
            ViewData["userList"] = new SelectList(new sys_userService().GetAllWaiter(), "usr_id", "usr_name");
            ViewData["date1"] = "";
            ViewData["date2"] = "";
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
            cst_service searchEntity = new cst_service();
            searchEntity.svr_status = "已处理";
            UpdateModel<cst_service>(searchEntity);
            List<cst_service> list = new cst_serviceService().GetServicesBySearchEntity(searchEntity);
            if (!string.IsNullOrEmpty(forms["date1"]))
            {
                list = list.Where(s => s.svr_create_date > DateTime.Parse(forms["date1"])).ToList();
            }
            if (!string.IsNullOrEmpty(forms["date2"]))
            {
                list = list.Where(s => s.svr_create_date < DateTime.Parse(forms["date2"])).ToList();
            }
            ViewData["pagerHelper"] = new PageHelper<cst_service>(list, curPage, 1);
            //服务类型
            ViewData["serviceType"] = new SelectList(new bas_dictService().GetDictsByType("服务类型"), "dict_value", "dict_item");
            //客服经理
            ViewData["userList"] = new SelectList(new sys_userService().GetAllWaiter(), "usr_id", "usr_name");
            ViewData["date1"] = forms["date1"];
            ViewData["date2"] = forms["date2"];
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
            ViewData["pagerHelper"] = new PageHelper<cst_service>(new cst_serviceService().GetServicesBySearchEntity(searchEntity), 1, 3);
            //服务类型
            ViewData["serviceType"] = new SelectList(new bas_dictService().GetDictsByType("服务类型"), "dict_value", "dict_item");
            //客服经理
            ViewData["userList"] = new SelectList(new sys_userService().GetAllWaiter(), "usr_id", "usr_name");
            ViewData["date1"] = "";
            ViewData["date2"] = "";
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
            cst_service searchEntity = new cst_service();
            searchEntity.svr_status = "已归档";
            UpdateModel<cst_service>(searchEntity);
            List<cst_service> list = new cst_serviceService().GetServicesBySearchEntity(searchEntity);
            if (!string.IsNullOrEmpty(forms["date1"]))
            {
                list = list.Where(s => s.svr_create_date > DateTime.Parse(forms["date1"])).ToList();
            }
            if (!string.IsNullOrEmpty(forms["date2"]))
            {
                list = list.Where(s => s.svr_create_date < DateTime.Parse(forms["date2"])).ToList();
            }
            ViewData["pagerHelper"] = new PageHelper<cst_service>(list, curPage, 1);
            //服务类型
            ViewData["serviceType"] = new SelectList(new bas_dictService().GetDictsByType("服务类型"), "dict_value", "dict_item");
            //客服经理
            ViewData["userList"] = new SelectList(new sys_userService().GetAllWaiter(), "usr_id", "usr_name");
            ViewData["date1"] = forms["date1"];
            ViewData["date2"] = forms["date2"];
            return View(searchEntity);
        }
        public ActionResult CustomerServiceInfo(int? id)
        {
            //满意度
            return View(new cst_serviceService().GetServiceByServiceId(id.Value));
        }

        #endregion

    }
}
