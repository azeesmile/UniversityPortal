//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace UniversityPortal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class EmployeeCours
    {
        [Key]
        public int Course_Id { get; set; }
        public string Courses { get; set; }
        public int Fk_Employee_Id { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}