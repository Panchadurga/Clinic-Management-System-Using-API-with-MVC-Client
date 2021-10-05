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
    }
}