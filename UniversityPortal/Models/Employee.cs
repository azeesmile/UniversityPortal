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

    public partial class Employee
    {
        public Employee()
        {
            this.Batches = new HashSet<Batch>();
            this.EmployeeAdditionalDetails = new HashSet<EmployeeAdditionalDetail>();
            this.EmployeeAttendences = new HashSet<EmployeeAttendence>();
            this.EmployeeCourses = new HashSet<EmployeeCours>();
            this.EmployeeLeaves = new HashSet<EmployeeLeave>();
            this.EmployeeResearches = new HashSet<EmployeeResearch>();
            this.EmployeesSubjects = new HashSet<EmployeesSubject>();
            this.SubjectLeaves = new HashSet<SubjectLeave>();
            this.TimetableEntries = new HashSet<TimetableEntry>();
        }

        [Key]
        public string Fk_User_Id { get; set; }
        public int Employee_id { get; set; }
        public string employee_number { get; set; }
        public Nullable<System.DateTime> joining_date { get; set; }
        public string gender_ { get; set; }
        public string job_title { get; set; }
        public string qualification { get; set; }
        public string experience_detail { get; set; }
        public int experience_year { get; set; }
        public int experience_month { get; set; }
        public bool status_ { get; set; }
        public string status_description { get; set; }
        public string marital_status { get; set; }
        public int children_count { get; set; }
        public string father_name { get; set; }
        public string mother_name { get; set; }
        public string husband_name { get; set; }
        public string blood_group { get; set; }
        public string nationality { get; set; }
        public string home_address_line1 { get; set; }
        public string home_address_line2 { get; set; }
        public string home_city { get; set; }
        public string home_state { get; set; }
        public string home_pin_code { get; set; }
        public string office_address_line1 { get; set; }
        public string office_address_line2 { get; set; }
        public string office_city { get; set; }
        public string office_state { get; set; }
        public string office_pin_code { get; set; }
        public string office_phone1 { get; set; }
        public string office_phone2 { get; set; }
        public string mobile_phone { get; set; }
        public string home_phone { get; set; }
        public string email_id { get; set; }
        public string fax { get; set; }
        public string photo_filename { get; set; }
        public string photo_content_type { get; set; }
        public byte[] photo_data { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public int photo_file_size { get; set; }
        public int Fk_Employee_Category_id { get; set; }
        public int Fk_Employee_Position_id { get; set; }
        public int Fk_Employee_Department_id { get; set; }
        public int Fk_Reporting_Manager_id { get; set; }
        public int Fk_Employee_Grade_id { get; set; }
        public int Fk_Home_Country_id { get; set; }
        public int Fk_Office_Country_id { get; set; }
        public int designation { get; set; }
    
        public virtual ICollection<Batch> Batches { get; set; }
        public virtual EmployeeCategory EmployeeCategory { get; set; }
        public virtual EmployeeDepartment EmployeeDepartment { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<EmployeeAdditionalDetail> EmployeeAdditionalDetails { get; set; }
        public virtual ICollection<EmployeeAttendence> EmployeeAttendences { get; set; }
        public virtual ICollection<EmployeeCours> EmployeeCourses { get; set; }
        public virtual ICollection<EmployeeLeave> EmployeeLeaves { get; set; }
        public virtual ICollection<EmployeeResearch> EmployeeResearches { get; set; }
        public virtual ICollection<EmployeesSubject> EmployeesSubjects { get; set; }
        public virtual ICollection<SubjectLeave> SubjectLeaves { get; set; }
        public virtual ICollection<TimetableEntry> TimetableEntries { get; set; }
    }
}
