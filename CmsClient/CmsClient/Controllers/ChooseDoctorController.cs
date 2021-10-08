using CmsClient.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsClient.Controllers
{
    public class ChooseDoctorController : Controller
    {
       //Getting Specialization
        public IActionResult Choosedoctor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Choosedoctor(ChooseDoctors s)
        {
            return RedirectToAction("Create", "Appointment", new { d = s.SelectSpeciality });
        }
    }
}
