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
    
    public partial class StudentPreviousSubjectMark
    {
        [Key]
        public int Previous_Subject_Mark_id { get; set; }
        public string subject { get; set; }
        public string mark { get; set; }
        public int Fk_Student_id { get; set; }
    
        public virtual Student Student { get; set; }
    }
}