using CMS.Data;
using CMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Repository
{
    public class DoctorRepo: IDoctor
    {
        //public CMSContext _context = new CMSContext();
        //public DoctorRepo()
        //{

        //}
        private readonly CMSContext _context;

        public DoctorRepo(CMSContext Context)
        {
            _context = Context;
        }
        public Doctor AddDoctor(Doctor d)
        {
            _context.Doctor.Add(d);
            _context.SaveChanges();
            return d;
        }
        public void DeleteDoctor(int id)
        {
            Doctor d = _context.Doctor.Find(id);
            _context.Doctor.Remove(d);
            _context.SaveChanges();
        }
        public Doctor GetDoctorById(int id)
        {
            return (_context.Doctor.Find(id));
        }

        public List<Doctor> GetDoctor()
        {
            return _context.Doctor.ToList();
            //return _context.Doctor.AsNoTracking().ToList();
        }

       
        public Doctor UpdateDoctor(int id, Doctor d)
        {
            //Doctor d1 = _context.Doctor.Find(id);
            // _context.Update(d);
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _context.Entry(d).State = EntityState.Modified;
            _context.SaveChanges();
            return d;
        }
        public bool DoctorExists(int id)
        {
            return _context.Doctor.Any(e => e.DoctorId == id);
        }
        // Getting DoctorId by using Doctor Name from the database
        public int DoctorIDByDoctorName(string name)
        {
            List<Doctor> doc = _context.Doctor.ToList();
            int id = 0;//initalizing id 
            foreach(Doctor d in doc)
            {
                if(d.Firstname == name)
                {
                    id = d.DoctorId;
                    break;
                }
                
            }
            return id;
        }
        //Getting a list of Visiting hour[Start/End Time] by DoctorId from the database   
        public List<int> VisitinghourList(int id)
        {
            Doctor d= (_context.Doctor.Find(id));
            //Visiting hour = 11:00 - 17:00
            String[] From = d.StartTime.Split(':'); //11:00
            String[] To = d.EndTime.Split(':'); //17:00
            List<int> Visithrs = new List<int>();//[11, 17]
            Visithrs.Add(Int32.Parse(From[0]));
            Visithrs.Add(Int32.Parse(To[0]));
            return Visithrs;
        }
        
        //passing doctor name and visitdate 
        //[11,12,13,14,15,16,17]
        //[12,15] - BookedAppointment
        public List<int> BookedAppointment(string name,DateTime visitdate )
        {
            //Check given doctorname/visitdate with already scheduled Appointment
            List<Schedule> app = _context.Schedule.Where(e => e.DoctorName == name && e.VisitDate == visitdate).ToList();
            List<int> BookedSlot = new List<int>();//[12,15]
            foreach(var i in app)
            {
                String[] appointmentTime = i.AppointmentTime.Split(':');
                BookedSlot.Add(Int32.Parse(appointmentTime[0]));
                       
            }
           
            return BookedSlot;
        }
    }
}