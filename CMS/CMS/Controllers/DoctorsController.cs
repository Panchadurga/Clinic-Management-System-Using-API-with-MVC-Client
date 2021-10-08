using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CMS.Data;
using CMS.Models;
using CMS.Provider;

namespace CMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDocProvider _prod;
        // IDocProvider _prod = new  IDocProvider();
        public DoctorsController(IDocProvider Prod)
        {
            _prod = Prod;
        }
       
        // GET: api/Doctors
        [HttpGet] 
        //Get all the details of the doctor
        public ActionResult<List<Doctor>> GetDoctor()
        {
            return _prod.GetDoctor();
        }
        // GET: api/Doctors/5
        [HttpGet("{id}")]
        [ActionName("GetDoctorById")]
        //Get the details of the doctor by id
        public ActionResult<Doctor> GetDoctor(int id)
        {
            return _prod.GetDoctorById(id);
        }
        ////unit testing
        //public IActionResult GetDoctorById(int id)
        //{
        //    return Ok(_prod.GetDoctorById(id));
        //}

        // PUT: api/Doctors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        //Update the details of the doctor by id
        public IActionResult PutDoctor(int id, Doctor doctor)
        {
            try
            {
                _prod.UpdateDoctor(id, doctor);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_prod.DoctorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Doctors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        //Insert the details of the doctor
        public ActionResult<Doctor> PostDoctor(Doctor doctor)
        {
            _prod.AddDoctor(doctor);

            return CreatedAtAction("GetDoctor", new { id = doctor.DoctorId }, doctor);
        }
        // DELETE: api/Doctors/5
        [HttpDelete("{id}")]
        //Remove the details of the doctor by id
        public IActionResult DeleteDoctor(int id)
        {

            _prod.DeleteDoctor(id);
            return NoContent();
        }
        [Route("[action]/{dname}")]
        [HttpGet]
        public int DoctorIDByDoctorName(string dname)
        {
            return _prod.DoctorIDByDoctorName(dname);
        }


        [Route("[action]/{did}")]
        [HttpGet]
        public ActionResult<List<int>> VisitinghourList(int did)
        {
            return _prod.VisitinghourList(did);

        }
        [Route("[action]/{name}/{visitdate}")]
        [HttpGet]
        public ActionResult<List<int>> BookedAppointment(string name,DateTime visitdate)
        {
            return _prod.BookedAppointment(name, visitdate);

        }
    }
}
