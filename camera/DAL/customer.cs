//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace camera.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class customer
    {
        public customer()
        {
            this.customeracounts = new HashSet<customeracount>();
        }
    
        public int CustomerID { get; set; }
        public string username { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string password_temp { get; set; }
        public string code { get; set; }
        public int active { get; set; }
        public System.DateTime created_at { get; set; }
        public System.DateTime updated_at { get; set; }
        public int remember_token { get; set; }
    
        public virtual ICollection<customeracount> customeracounts { get; set; }
        public virtual vehicle vehicle { get; set; }
    }
}
