//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace api.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class student
    {
        public int ID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string fatherName { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string passwordHash { get; set; }
        public string address { get; set; }
        public string mobileNumber { get; set; }
        public string email { get; set; }
        public System.DateTime enrollmentDate { get; set; }
    }
}
