//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRM.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class storage
    {
        public int stk_id { get; set; }
        public int stk_prod_id { get; set; }
        public string stk_warehouse { get; set; }
        public string stk_ware { get; set; }
        public int stk_count { get; set; }
        public string stk_memo { get; set; }
    
        public virtual product product { get; set; }
    }
}
