using CMS.Models;
using CMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Provider
{
    public class DocProvider :IDocProvider
    {
        private readonly IDoctor _repo;

        public DocProvider(IDoctor repo)
        {
            _repo = repo;
        }
        //public DoctorRepo _repo = new DoctorRepo();
        //public DocProviderr()
        //{

        //}
        public Doctor AddDoctor(Doctor d)
        {
            _repo.AddDoctor(d);
            return d;
        }
        public void DeleteDoctor(int id)
        {
            _repo.DeleteDoctor(id);
        }
        public Doctor GetDoctorById(int id)
        {
            return _repo.GetDoctorById(id);
        }
        public List<Doctor> GetDoctor()
        {
            return _repo.GetDoctor();
        }
        public Doctor UpdateDoctor(int id, Doctor d)
        {
            _repo.UpdateDoctor(id, d);
            return d;
        }

        public bool DoctorExists(int id)
        {
            return _repo.DoctorExists(id);

        }
    }
}
