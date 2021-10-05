using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CMS.Models
{
    public class Schedule
    {
        [Key]
        public int AppointmentId { get; set; }
        [Required]
        public int PatientId { get; set; }
        [Required]
        public string Specialization { get; set; }
        [Required]
        public string DoctorName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime VisitDate { get; set; }
        [Required]
        public String AppointmentTime { get; set; }
        
        




    }
}
