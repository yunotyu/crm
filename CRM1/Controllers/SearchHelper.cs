using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.Web.Controllers
{
    public class SearchHelper<T> where T : class
    {
        private T searchEntity { get; set; }

    }
}