using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsClient.Models
{
    public class Cancel
    {
        
        public int PatientId { get; set; }
        public DateTime VisitDate { get; set;}
        [Required]
        [DataType(DataType.Time)]
        public String StartTime { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public String EndTime { get; set; }
    }
}
