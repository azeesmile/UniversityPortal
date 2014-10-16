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
    
    public partial class SubjectLeave
    {
        [Key]
        public int Subject_Leave_id { get; set; }
        public Nullable<System.DateTime> month_date { get; set; }
        public string reason { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public int Fk_Batch_id { get; set; }
        public int Fk_Student_id { get; set; }
        public int Fk_Subject_id { get; set; }
        public int Fk_Employee_id { get; set; }
        public int Fk_Class_Timing_id { get; set; }
    
        public virtual Batch Batch { get; set; }
        public virtual ClassTiming ClassTiming { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}