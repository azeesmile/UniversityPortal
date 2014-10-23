using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityPortal.Models
{
    [Bind(Exclude = "Id, CreatedDate, UserName, Name, Department")]
    public class Testimonial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public string UserName { get; set; }

        public string Review { get; set; }

        [ScaffoldColumn(false)]
        public string Name { get; set; }

        [ScaffoldColumn(false)]
        public string Department { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? CreatedDate { get; set; }

        [ScaffoldColumn(false)]
        public int IsApproved { get; set; }
    }
}