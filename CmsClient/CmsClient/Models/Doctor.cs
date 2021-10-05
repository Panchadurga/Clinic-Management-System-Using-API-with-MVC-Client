using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsClient.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "No Special Characters")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "No Special Characters")]
        public string Lastname { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        public string Specialization { get; set; }

        [Required]
        public string VisitingHour { get; set; }


    }
}
