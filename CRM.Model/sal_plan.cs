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
    
    public partial class sal_plan
    {
        public int pla_id { get; set; }
        public int pla_chc_id { get; set; }
        public System.DateTime pla_date { get; set; }
        public string pla_todo { get; set; }
        public string pla_result { get; set; }
    
        public virtual sal_chance sal_chance { get; set; }
    }
}
