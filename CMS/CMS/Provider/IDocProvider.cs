using CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Provider
{
    public interface IDocProvider
    {
        public List<Doctor> GetDoctor();
        public Doctor GetDoctorById(int id);
        public Doctor AddDoctor(Doctor d);
        public Doctor UpdateDoctor(int id, Doctor d);
        public void DeleteDoctor(int id);
        public int DoctorIDByDoctorName(string name);
        public List<Int32> VisitinghourList(int id);
        public List<Int32> BookedAppointment(String name, DateTime visitdate);
        public bool DoctorExists(int id);
    }
}
