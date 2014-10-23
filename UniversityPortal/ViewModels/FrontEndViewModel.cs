using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace UniversityPortal.Models
{
    public class TestinomialFrontEndViewModel
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public string Review { get; set; }
    }

    public class JobFrontEndViewModel
    {
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public string JobReference { get; set; }
        
        public string Department { get; set; }
        
        public string Location { get; set; }
        
        public int MinSalary { get; set; }
        
        public int MaxSalary { get; set; }

        public int Hours { get; set; }
    }

    public class EventFrontEndViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int Duration { get; set; }

        public string Location { get; set; }

        public DateTime? StartDate { get; set; }


    }

    public class NewsFrontEndViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string MediaUrl { get; set; }
    }

    public class CourseFrontEndViewModel
    {
    }

}