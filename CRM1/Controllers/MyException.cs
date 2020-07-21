using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;//引入MVC命名空间

namespace CRM.Web.Controllers
{
    /// <summary>
    /// 异常处理类，用于处理发生异常的Action，当发生异常后，统一跳到中间页，并显示相应提示信息
    /// </summary>
    public class MyException : FilterAttribute, IExceptionFilter
    {
        #region IExceptionFilter 成员

        /// <summary>
        /// 异常处理方法，当“监视”的Action发生异常后会由本方法截取并处理
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnException(ExceptionContext filterContext)
        {
            Exception ex = filterContext.Exception;
            //取出出错的页面地址
            filterContext.Controller.ViewData.Add(new KeyValuePair<string, object>("backUrl", filterContext.HttpContext.Request.Url));
            ////判断是否为服务器验证异常
            if (ex.GetType().Name == "InvalidOperationException")
            {
                filterContext.Controller.ViewData.Add(new KeyValuePair<string, object>("msg", "您输入的数据有误，请核对"));
            }
            else if (ex.GetType().Name == "NullReferenceException")
            {
                filterContext.Controller.ViewData.Add(new KeyValuePair<string, object>("msg", "获取数据失败!请重试!"));
            }
            else if (ex.GetType().Name == "SqlException")
            {
                //判断是否数据库服务器异常
                filterContext.Controller.ViewData.Add(new KeyValuePair<string, object>("msg", "与数据库服务器连接失败，可能服务器正在维护，请联系管理员!"));
            }
            else
            {
                filterContext.Controller.ViewData.Add(new KeyValuePair<string, object>("msg", string.IsNullOrEmpty(ex.Message) ? "系统未知错误" : ex.Message));
            }
            //改变要显示的视图
            filterContext.Result = new ViewResult()
             {
                 ViewName = "Error",
                 ViewData = filterContext.Controller.ViewData
             };
            //标记异常已经被处理
            filterContext.ExceptionHandled = true;
        }

        #endregion
    }
}

