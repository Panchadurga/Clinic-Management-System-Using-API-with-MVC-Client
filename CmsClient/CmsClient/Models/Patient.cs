using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsClient.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "No Special Characters")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "No Special Characters")]
        public string Lastname { get; set; }
        
        public string Sex { get; set; }

        [Required]
        [DataType(DataType.Date)]
        //[Display(Name ="Date of Birth")]
        public DateTime DOB { get; set; }

        [Required]
        [Range(1, 120, ErrorMessage = "Age must be between 1 - 120 years")]
        public int Age { get; set; }

    }
}
