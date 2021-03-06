﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace UniversityPortal.Models
{
    public class Testimonial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Review")]
        public string Review { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Created Date")]
        public DateTime? CreatedDate { get; set; }

        [DisplayName("IsApproved")]
        public int IsApproved { get; set; }

        [DisplayName("Media Url")]
        public string MediaUrl { get; set; }
    }
}