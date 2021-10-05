using CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Repository
{
    public interface ISchedule
    {
        public List<Schedule> GetAppointment();
        public Schedule GetAppointmentById(int id);
        public Schedule AddAppointment(Schedule s);
        public Schedule UpdateAppointment(int id, Schedule s);
        public void DeleteAppointment(int id);

        public bool AppointmentExists(int id);
    }
}
