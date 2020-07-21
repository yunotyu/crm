using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.Model;
using CRM.BLL;

namespace CRM.Web.Controllers
{
    //[MyException]
    public class SharedController : Controller
    {
        private LoginService loginSer = new LoginService();
        //
        // GET: /Shared/

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection forms)
        {
            sys_user user = new sys_user();
            //user.usr_name = "admin";
            //user.usr_pwd = "123456";
            if (string.IsNullOrEmpty(forms["valicode"]))
            {
                throw new Exception("验证码不能为空");
            }
            else if (Session["ValidateCode"].Equals(forms["valicode"].Trim()))
            {
                UpdateModel<sys_user>(user);
            //登录
            if (loginSer.Login(ref user))
            {
                //保存当前登录用户到Session中
                Session["user"] = user;
                //登录成功
                return RedirectToAction("Index", "Default");
            }
            }
            else
            {
                throw new Exception("验证码错误");
            }
            return View();
            
        }

        #region 验证码
        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <returns></returns>
        public FileContentResult GetValicodeImage()
        {
            ValidateCode vCode = new ValidateCode();
            string code = vCode.CreateValidateCode(5);
            Session["ValidateCode"] = code;
            byte[] bytes = vCode.CreateValidateGraphic(code);
            return File(bytes, @"image/jpeg");
        }
        #endregion
        /// <summary>
        /// 中间错误页
        /// </summary>
        /// <returns></returns>
        public ActionResult Error()
        {
            ViewData["backUrl"] = Session["backUrl"] == null ? Url.Action("Index", "Shared") : Session["backUrl"].ToString();
            ViewData["msg"] = Session["msg"] == null ? "未知错误" : Session["msg"].ToString();
            return View();
        }
        /// <summary>
        /// 中间成功页
        /// </summary>
        /// <returns></returns>
        public ActionResult Success()
        {
            return View();
        }
    }
}
