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
            ViewData["pagerHelper"] = new PageHelper<storage>(new storageService().GetStoragesBySearchEntity(searchEntity), 1, 3);
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
            int curPage = int.Parse(forms["curPage"]);
            storage searchEntity = new storage();
            product empProduct = new product();
            UpdateModel<product>(empProduct);
            UpdateModel<storage>(searchEntity);
            searchEntity.product = empProduct;
            ViewData["pagerHelper"] = new PageHelper<storage>(new storageService().GetStoragesBySearchEntity(searchEntity), curPage, 3);
            return View(searchEntity);
        }

        #endregion
    }
}
