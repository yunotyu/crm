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
    [MyException]
    [LoginValidator]
    public class DataDictManagerController : Controller
    {
        #region 数据字典

        //
        // GET: /DataDictManager/
        /// <summary>
        /// 数据字典
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            bas_dict searchEntity = new bas_dict();
            ViewData["pagerHelper"] = new PageHelper<bas_dict>(new LinqHelper().Db.bas_dict.Where(d=>true).ToList(), 1, 3);
            return View(searchEntity);
        }
        /// <summary>
        /// 数据字典分页请求
        /// </summary>
        /// <param name="forms"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(FormCollection forms)
        {
            Expression<Func<bas_dict,bool> > exp = ExpressionUtils.True<bas_dict>();
            if (!string.IsNullOrEmpty(forms["dict_type"])){
                exp = ExpressionUtils.And<bas_dict>(exp, d => d.dict_type==(forms["dict_type"]));
            }
            if (!string.IsNullOrEmpty(forms["dict_item"]))
            {
                exp = ExpressionUtils.And<bas_dict>(exp, d => d.dict_item==(forms["dict_item"]));
            }
            if (!string.IsNullOrEmpty(forms["dict_value"]))
            {
                exp = ExpressionUtils.And<bas_dict>(exp, d => d.dict_value==(forms["dict_value"]));
            }

            int curPage = int.Parse(forms["curPage"]);
            bas_dict searchEntity = new bas_dict();
            UpdateModel<bas_dict>(searchEntity);
            ViewData["pagerHelper"] = new PageHelper<bas_dict>(new LinqHelper().Db.bas_dict.Where(exp.Compile()).ToList(), curPage, 3);
            return View(searchEntity);
        }
        /// <summary>
        /// 数据字典修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Update(int? id)
        {
            return View(new bas_dictService().GetDictsById(id.Value));
        }
        /// <summary>
        /// 数据字典修改请求
        /// </summary>
        /// <param name="id"></param>
        /// <param name="forms"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update(int? id, FormCollection forms)
        {
            var db = new LinqHelper().Db;
            bas_dict newObj = new bas_dict();
            if(int.TryParse(id.ToString(),out int i))
            {
                newObj = db.bas_dict.Where(b => b.dict_id == id).FirstOrDefault();
            }
            UpdateModel<bas_dict>(newObj);
            db.Entry(newObj).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /// <summary>
        /// 删除数据字典
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int? id)
        {
            new bas_dictService().DeleteDictById(id.Value);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 添加数据字典
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            return View(new bas_dict());
        }

        /// <summary>
        /// 添加数据字典请求
        /// </summary>
        /// <param name="forms"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add(FormCollection forms)
        {
            bas_dict newObj = new bas_dict();
            UpdateModel<bas_dict>(newObj);
            new bas_dictService().AddDict(newObj);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
