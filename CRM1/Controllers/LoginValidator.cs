using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;//引入MVC命名空间

namespace CRM.Web.Controllers
{
    /// <summary>
    /// 登录超时验证类（Action过滤器实现）
    /// 原理：在每一个Action执行之前(OnActionExecuting)去判断Session是否还存在
    /// 如果不存在，则给出提示
    /// 否则不进行任何操作
    /// </summary>
    public class LoginValidator : FilterAttribute, IActionFilter
    {
        #region IActionFilter 成员
        /// <summary>
        /// Action执行之后
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }
        /// <summary>
        /// Action执行之前
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["user"] == null)
            {
                filterContext.HttpContext.Response.Write("<script type='text/javascript'>if(confirm('安全提示:\\n由于您长时间未操作，为确保安全，系统已经自动帮您下线。\\n如果需要继续操作，请重新登陆！')){window.parent.parent.parent.parent.parent.location.href='"+new UrlHelper(filterContext.RequestContext).Action("Login","Shared")+"';}</script>");
            }
        }

        #endregion
    }
}