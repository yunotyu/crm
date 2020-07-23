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
    public class StorageSearchController : Controller
    {
        #region 产品信息
        //
        // GET: /ProductSearch/
        /// <summary>
        /// 库存信息查询
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            storage searchEntity = new storage();
            searchEntity.product = new product();
            ViewData["pagerHelper"] = new PageHelper<storage>(new LinqHelper().Db.storage.Where(s=>true).ToList(), 1, 3);
            return View(searchEntity);
        }
        /// <summary>
        /// 库存信息查询分页请求
        /// </summary>
        /// <param name="forms"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(FormCollection forms)
        {
            Expression<Func<storage, bool>> exp = ExpressionUtils.True<storage>();
            if (!string.IsNullOrEmpty(forms["prod_name"]))
            {
                var name = forms["prod_name"];
                var prod_id = new LinqHelper().Db.product.Where(pro => pro.prod_name == name).Select(pp=>pp.prod_id).FirstOrDefault();
                exp = ExpressionUtils.And<storage>(exp, d => d.stk_prod_id == prod_id);

            }
            if (!string.IsNullOrEmpty(forms["stk_warehouse"]))
            {
                exp = ExpressionUtils.And<storage>(exp, d => d.stk_warehouse.Contains(forms["stk_warehouse"]));
            }
           
           
            int curPage = int.Parse(forms["curPage"]);
            storage searchEntity = new storage();
            product empProduct = new product();
            UpdateModel<product>(empProduct);
            UpdateModel<storage>(searchEntity);
            searchEntity.product = empProduct;
            ViewData["pagerHelper"] = new PageHelper<storage>(new LinqHelper().Db.storage.Where(exp.Compile()).ToList(), curPage, 3);
            return View(searchEntity);
        }

        #endregion
    }
}
