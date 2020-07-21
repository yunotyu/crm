using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM.DAL
{
    /// <summary>
    /// 延迟加载标记类
    /// </summary>
   public static class IsAtOnceLoad
    {
        public static bool IsLazyLoad { get; set; }
    }
}
