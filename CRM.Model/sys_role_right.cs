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
    
    public partial class sys_role_right
    {
        public int rf_id { get; set; }
        public int rf_role_id { get; set; }
        public string rf_right_code { get; set; }
    
        public virtual sys_right sys_right { get; set; }
        public virtual sys_role sys_role { get; set; }
    }
}
