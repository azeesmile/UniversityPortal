using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using UniversityPortal.Common;

namespace UniversityPortal.Models
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "RoleName")]
        public string Name { get; set; }
    }

    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Reg Number")]
        [RegularExpression(Constants.RegNumberPattern, ErrorMessage = "Registration Number is required and must be properly formatted.")]
        public string UserName { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public System.DateTime? DateOfBirth { get; set; }

        [Required]
        public System.DateTime CreatedAt { get; set; }
        public IEnumerable<SelectListItem> RolesList { get; set; }
    }
}