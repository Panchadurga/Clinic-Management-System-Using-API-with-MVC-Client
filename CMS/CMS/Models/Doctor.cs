using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CMS.Models
{
    public class Doctor
    {

        [Key]
        public int DoctorId { get; set; }
        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "No Special Characters")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "No Special Characters")]
        public string Lastname { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        public string Specialization { get; set; }

        [DisplayFormat(DataFormatString = "{HH:MM}")]
        [DataType(DataType.Time)]
        [Display(Name="From")]
        
        [Required]
        public String StartTime { get; set; }
        [DisplayFormat(DataFormatString = "{HH:MM}")]
        [DataType(DataType.Time)]
        [Display(Name="To")]
        [Required]
        
        public string EndTime { get; set; }



    }
}
