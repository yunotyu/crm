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
    public class ProductSearchController : Controller
    {
        #region 产品信息
        //
        // GET: /ProductSearch/
        /// <summary>
        /// 产品信息查询
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            product searchEntity = new product();
            ViewData["pagerHelper"] = new PageHelper<product>(new LinqHelper().Db.product.Where(p=>true).ToList(), 1, 3);
            return View(searchEntity);
        }
        /// <summary>
        /// 产品信息查询分页请求
        /// </summary>
        /// <param name="forms"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(FormCollection forms)
        {
            Expression<Func<product, bool>> exp = ExpressionUtils.True<product>();
            if (!string.IsNullOrEmpty(forms["prod_name"]))
            {
                exp = ExpressionUtils.And<product>(exp, d => d.prod_name.Contains(forms["prod_name"]));
            }
            if (!string.IsNullOrEmpty(forms["prod_type"]))
            {
                exp = ExpressionUtils.And<product>(exp, d => d.prod_type.Contains(forms["prod_type"]));
            }
            if (!string.IsNullOrEmpty(forms["prod_batch"]))
            {
                exp = ExpressionUtils.And<product>(exp, d => d.prod_batch.Contains(forms["prod_batch"]));
            }
            int curPage = int.Parse(forms["curPage"]);
            product searchEntity = new product();
            UpdateModel<product>(searchEntity);
            ViewData["pagerHelper"] = new PageHelper<product>(new LinqHelper().Db.product.Where(exp.Compile()).ToList(), curPage, 3);
            return View(searchEntity);
        }

        #endregion
    }
}
