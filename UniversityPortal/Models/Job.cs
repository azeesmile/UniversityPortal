//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace UniversityPortal.Models
{
    using System;
    using System.Collections.Generic;

    [Bind(Exclude = "Id,CreatedAt")]
    public partial class Job
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [DisplayName("Title")]
        public string Title { get; set; }
        
        [DisplayName("Description")]
        public string Description { get; set; }
        
        [DisplayName("Job Reference")]
        public string JobReference { get; set; }
        
        [DisplayName("Department")]
        public string Department { get; set; }
        
        [DisplayName("Location")]
        public string Location { get; set; }
        
        [DisplayName("Minimum Salary")]
        public int MinimumSalary { get; set; }
        
        [DisplayName("Maximum Salary")]
        public int MaximumSalary { get; set; }

        [DisplayName("Job Type")]
        public int hours { get; set; }

        [DisplayName("CreatedAt")]
        public Nullable<System.DateTime> CreatedAt { get; set; }
        
        [DisplayName("Application Form")]
        public string ApplicationForm { get; set; }
        
        [DisplayName("Email To Apply")]
        public string EmailToApply { get; set; }
    }
}
