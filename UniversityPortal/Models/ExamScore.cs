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
    
    public partial class ExamScore
    {
        [Key]
        public int Exam_Score_id { get; set; }
        public int marks { get; set; }
        public string remarks { get; set; }
        public bool is_failed { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public int Fk_Student_id { get; set; }
        public int Fk_Exam_id { get; set; }
        public int Fk_Grading_Level_id { get; set; }
    
        public virtual Exam Exam { get; set; }
        public virtual GradingLevel GradingLevel { get; set; }
        public virtual Student Student { get; set; }
    }
}