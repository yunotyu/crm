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
    
    public partial class orders
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public orders()
        {
            this.orders_line = new HashSet<orders_line>();
        }
    
        public int odr_id { get; set; }
        public string odr_cust_no { get; set; }
        public string odr_cust_name { get; set; }
        public System.DateTime odr_date { get; set; }
        public string odr_addr { get; set; }
        public int odr_status { get; set; }
    
        public virtual cst_customer cst_customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orders_line> orders_line { get; set; }
    }
}
