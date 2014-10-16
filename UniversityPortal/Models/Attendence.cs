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
    
    public partial class Attendence
    {
        [Key]
        public int id { get; set; }
        public bool forenoon { get; set; }
        public bool afternoon { get; set; }
        public string reason { get; set; }
        public Nullable<System.DateTime> month_date { get; set; }
        public int Fk_Batch_id { get; set; }
        public int Fk_Student_id { get; set; }
        public int Fk_Timetable_Entry_id { get; set; }
    
        public virtual Batch Batch { get; set; }
        public virtual Student Student { get; set; }
        public virtual TimetableEntry TimetableEntry { get; set; }
    }
}