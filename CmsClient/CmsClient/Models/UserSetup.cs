using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsClient.Models
{
    public class UserSetup
    {
        [Key]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "No Special Characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        public string Lastname { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
