using CMS.Data;
using CMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Repository
{
    public class ScheduleRepo : ISchedule
    {
        private readonly CMSContext _context;

        public ScheduleRepo(CMSContext Context)
        {
            _context = Context;
        }
        public Schedule AddAppointment(Schedule s)
        {
            _context.Schedule.Add(s);
            _context.SaveChanges();
            return s;
        }

        public bool AppointmentExists(int id)
        {
            return _context.Schedule.Any(e => e.AppointmentId == id);
        }

        public void DeleteAppointment(int id)
        {
            Schedule s = _context.Schedule.Find(id);
            _context.Schedule.Remove(s);
            _context.SaveChanges();
        }

        public List<Schedule> GetAppointment()
        {
            return _context.Schedule.ToList();
        }

        public Schedule GetAppointmentById(int id)
        {
            return (_context.Schedule.Find(id));
        }

        public Schedule UpdateAppointment(int id, Schedule s)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _context.Entry(s).State = EntityState.Modified;
            _context.SaveChanges();
            return s;
        }
    }
}
