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
    public class PatientsController : ControllerBase
    {
        private readonly IPatProvider _prod;

        public PatientsController(IPatProvider Prod)
        {
            _prod = Prod;
        }

        // GET: api/Patients
        [HttpGet]
        //Get all the patients
        public ActionResult<List<Patient>> GetPatient()
        {
            return _prod.GetPatient();
        }

        // GET: api/Patients/5
        [HttpGet("{id}")]
        [ActionName("GetPatientById")]
        //Get a patient by id
        public ActionResult<Patient> GetPatient(int id)
        {
            return _prod.GetPatientById(id);
        }
        ////unit testing
        //public IActionResult GetPatientById(int id)
        //{
        //    return Ok(_prod.GetPatientById(id));
        //}



        // PUT: api/Patients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        //Edit a patient by id
        public IActionResult PutPatient(int id, Patient patient)
        {
            try
            {
                _prod.UpdatePatient(id, patient);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_prod.PatientExists(id))
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
       

        // POST: api/Patients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        //Add a patient 
        public ActionResult<Patient> PostPatient(Patient patient)
        {
            _prod.AddPatient(patient);

            return CreatedAtAction("GetPatient", new { id = patient.PatientId }, patient);
        }
       

        // DELETE: api/Patients/5
        [HttpDelete("{id}")]
        // Delete a patient by id
        public IActionResult DeletePatient(int id)
        {

            _prod.DeletePatient(id);
            return NoContent();
        }
        
    }
}
