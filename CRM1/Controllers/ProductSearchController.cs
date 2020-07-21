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
            ViewData["pagerHelper"] = new PageHelper<product>(new productService().GetProductsBySearchEntity(searchEntity), 1, 3);
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
            int curPage = int.Parse(forms["curPage"]);
            product searchEntity = new product();
            UpdateModel<product>(searchEntity);
            ViewData["pagerHelper"] = new PageHelper<product>(new productService().GetProductsBySearchEntity(searchEntity), curPage, 3);
            return View(searchEntity);
        }

        #endregion
    }
}
