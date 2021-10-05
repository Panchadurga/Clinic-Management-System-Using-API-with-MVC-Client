using CMS.Models;
using CMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Provider
{
    public class PatientProvider : IPatProvider
    {
        private readonly IPatient _repo;

        public PatientProvider(IPatient repo)
        {
            _repo = repo;
        }
        public Patient AddPatient(Patient p)
        {
            _repo.AddPatient(p);
            return p;
        }

        public void DeletePatient(int id)
        {
            _repo.DeletePatient(id);
        }

        public List<Patient> GetPatient()
        {
            return _repo.GetPatient();
        }

        public Patient GetPatientById(int id)
        {
            return _repo.GetPatientById(id);
        }

        public bool PatientExists(int id)
        {
            return _repo.PatientExists(id);
        }

        public Patient UpdatePatient(int id, Patient p)
        {
            _repo.UpdatePatient(id, p);
            return p;
        }
    }
}
