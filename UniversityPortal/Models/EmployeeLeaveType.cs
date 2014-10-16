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
    
    public partial class EmployeeLeaveType
    {
        public EmployeeLeaveType()
        {
            this.EmployeeAttendences = new HashSet<EmployeeAttendence>();
            this.EmployeeLeaves = new HashSet<EmployeeLeave>();
        }
    [Key]
        public int Employee_Leave_Type_id { get; set; }
        public string Name { get; set; }
        public string code { get; set; }
        public bool status_ { get; set; }
        public string max_leave_count { get; set; }
        public bool carry_forward { get; set; }
    
        public virtual ICollection<EmployeeAttendence> EmployeeAttendences { get; set; }
        public virtual ICollection<EmployeeLeave> EmployeeLeaves { get; set; }
    }
}
