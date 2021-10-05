using CMS.Data;
using CMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Repository
{
    public class PatientRepo : IPatient
    {
        private readonly CMSContext _context;

        public PatientRepo(CMSContext Context)
        {
            _context = Context;
        }
        public Patient AddPatient(Patient p)
        {
            _context.Patient.Add(p);
            _context.SaveChanges();
            return p;
        }

        public void DeletePatient(int id)
        {
            Patient p = _context.Patient.Find(id);
            _context.Patient.Remove(p);
            _context.SaveChanges();
        }

        public List<Patient> GetPatient()
        {
            return _context.Patient.ToList();
        }

        public Patient GetPatientById(int id)
        {
            return (_context.Patient.Find(id));
        }

        public bool PatientExists(int id)
        {
            return _context.Patient.Any(e => e.PatientId == id);
        }

        public Patient UpdatePatient(int id, Patient p)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _context.Entry(p).State = EntityState.Modified;
            _context.SaveChanges();
            return p;
        }
    }
}
