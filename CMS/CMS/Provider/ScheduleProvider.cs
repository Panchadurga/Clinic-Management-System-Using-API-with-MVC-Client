using CMS.Models;
using CMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Provider
{
    public class ScheduleProvider:ISchProvider
    {
        private readonly ISchedule _repo;

        public ScheduleProvider(ISchedule repo)
        {
            _repo = repo;
        }

        public Schedule AddAppointment(Schedule s)
        {
            
              _repo.AddAppointment(s);
              return s;
        }

        public bool AppointmentExists(int id)
        {
            return _repo.AppointmentExists(id);
        }

        public void DeleteAppointment(int id)
        {
            _repo.DeleteAppointment(id);
        }

        public List<Schedule> GetAppointment()
        {
            return _repo.GetAppointment();
        }

        public Schedule GetAppointmentById(int id)
        {
            return _repo.GetAppointmentById(id);
        }

        public Schedule UpdateAppointment(int id, Schedule s)
        {
            _repo.UpdateAppointment(id, s);
            return s;
        }
    }
}
