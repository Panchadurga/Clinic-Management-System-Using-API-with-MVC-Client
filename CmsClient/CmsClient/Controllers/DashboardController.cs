using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsClient.Controllers
{
    public class DashboardController : Controller
    {

       
        public IActionResult Index()
        {
            ViewBag.msg = HttpContext.Session.GetString("username");
            if(ViewBag.msg != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login","Login");
            }

        }
       


        public IActionResult AddDoctor()
        {
           
            return RedirectToAction("GetAllDoctors", "Doctor");

        }
        public IActionResult AddPatient()
        {
           
            return RedirectToAction("GetAllPatients", "Patient");

        }
        public IActionResult Schedule()
        {
            
            return RedirectToAction("ViewAppointments", "Appointment");

        }

        //public IActionResult Cancel()
        //{

        //    return RedirectToAction("Delete", "Appointment");

        //}
        public IActionResult Logout()
        {

            HttpContext.Session.Clear();

            return RedirectToAction("Login", "Login");

        }
            
    }
}
