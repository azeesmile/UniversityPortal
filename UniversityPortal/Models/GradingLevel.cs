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
    
    public partial class GradingLevel
    {
        public GradingLevel()
        {
            this.Exams = new HashSet<Exam>();
            this.ExamScores = new HashSet<ExamScore>();
        }
        [Key]
        public int Grading_Level_id { get; set; }
        public string Name { get; set; }
        public int min_score { get; set; }
        public int order_ { get; set; }
        public bool is_deleted { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public decimal credited_points { get; set; }
        public string description_ { get; set; }
        public int Fk_Batch_id { get; set; }
    
        public virtual Batch Batch { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
        public virtual ICollection<ExamScore> ExamScores { get; set; }
    }
}
