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
    
    public partial class News
    {
        public News()
        {
            this.NewsComments = new HashSet<NewsComment>();
        }
    [Key]
        public int News_id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string mediaurl { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public Nullable<int> FK_updated_Author_id { get; set; }
        public int Fk_Author_id { get; set; }
    
        public virtual ICollection<NewsComment> NewsComments { get; set; }
    }
}
