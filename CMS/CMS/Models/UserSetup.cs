using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models
{
    public class UserSetup
    { 
        //Data validation
        [Key]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$",ErrorMessage ="Special Characters not allowed")]
        public string Username { get; set; }

        [Required(ErrorMessage ="FirstName is Required")]
        public string Firstname { get; set; }
        [Required(ErrorMessage ="LastName is Required")]
        public string Lastname { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
