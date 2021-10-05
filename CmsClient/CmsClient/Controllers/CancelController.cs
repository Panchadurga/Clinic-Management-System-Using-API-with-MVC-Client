using CMS.Data;
using CMS.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsClient.Controllers
{
    public class CancelController : Controller
    {
        private readonly CMSContext _db;
        public CancelController(CMSContext db)
        {
            _db = db;
        }
       
        public IActionResult ViewAppointment()
        {
            var db1 = _db.Schedule;
            var schedule = _db.Schedule.ToList();
            return View(db1.ToList());
        }
        [HttpGet]
        public IActionResult Cancel(int id)
        {
            var c = _db.Schedule.Find(id);
            _db.Schedule.Remove(c);
            _db.SaveChanges();
            return RedirectToAction("ViewAppointment");
        }
        //[HttpGet]
        //public ActionResult Cancel()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Cancel(int PatientId)
        //{
        //    Schedule obj = _db.Schedule.Find(PatientId);
        //    _db.Schedule.Remove(obj);
        //    _db.SaveChanges();
        //    return RedirectToAction("Cancel");
        //}
    }
}
