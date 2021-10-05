using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CMS.Models;
using CMS.Provider;

namespace CMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private readonly ISchProvider _prod;

        public SchedulesController(ISchProvider prod)
        {
            _prod = prod;
        }
        // GET: api/Schedules
        [HttpGet]
        //Get a list of scheduled appointments
        public ActionResult<List<Schedule>> GetSchedule()
        {
            return _prod.GetAppointment();
        }
        // GET: api/Schedules/5
        [HttpGet("{id}")]
        [ActionName("GetAppointmentById")]
        //Get a scheduled appointments by id
        public ActionResult<Schedule> GetSchedule(int id)
        {
            return _prod.GetAppointmentById(id);
        }
        ////unit testing
        //public IActionResult GetAppointmentById(int id)
        //{
        //    return Ok(_prod.GetAppointmentById(id));
        //}

        // PUT: api/Schedules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        //Edit an appointment
        public IActionResult PutSchedule(int id, Schedule s)
        {
            try
            {
                _prod.UpdateAppointment(id, s);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_prod.AppointmentExists(id))
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

        // POST: api/Schedules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        //Add an appointment
        public ActionResult<Schedule> PostSchedule(Schedule s)
        {
            _prod.AddAppointment(s);

            return CreatedAtAction("GetSchedule", new { id = s.AppointmentId }, s);
        }
        // DELETE: api/Schedules/5
        [HttpDelete("{id}")]
        //Delete an appointment
        public IActionResult DeleteSchedule(int id)
        {

            _prod.DeleteAppointment(id);
            return NoContent();
        }
    }

}