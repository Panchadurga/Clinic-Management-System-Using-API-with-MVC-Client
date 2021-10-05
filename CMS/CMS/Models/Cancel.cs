using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CMS.Models
{
    public class Cancel
    {
        [Key]
        public int PatientId { get; set; }
        [Required]
        public DateTime VisitDate { get; set; }
        [Required]
        public String StartTime { get; set; }
        [Required]
        public String EndTime { get; set; }

    }
}
