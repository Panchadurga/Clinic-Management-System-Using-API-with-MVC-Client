using CmsClient.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CMS.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CmsClient.Controllers
{
    public class AppointmentController : Controller
    {
        string Baseurl = "https://localhost:44305/";
        //Get all the Appointments
        public async Task<IActionResult> ViewAppointments()
        {
            List<Schedule> ScheduleInfo = new List<Schedule>();

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Schedules");

                if (Res.IsSuccessStatusCode)
                {
                    var ScheduleResponse = Res.Content.ReadAsStringAsync().Result;
                    ScheduleInfo = JsonConvert.DeserializeObject<List<Schedule>>(ScheduleResponse);

                }
                return View(ScheduleInfo);
            }

        }
        //Booking an Appointment
        [HttpGet]
        public async Task<IActionResult> Create(string d)
        {
            List<Doctor> DoctorsList = new List<Doctor>();

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Doctors");

                if (Res.IsSuccessStatusCode)
                {
                    var DoctorResponse = Res.Content.ReadAsStringAsync().Result;
                    DoctorsList = JsonConvert.DeserializeObject<List<Doctor>>(DoctorResponse);

                }
            }
            List<Patient> Patientslist = new List<Patient>();

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Patients");

                if (Res.IsSuccessStatusCode)
                {
                    var PatientResponse = Res.Content.ReadAsStringAsync().Result;
                    Patientslist = JsonConvert.DeserializeObject<List<Patient>>(PatientResponse);

                }
            }
            //Getting a patientID from the database
            var patientid = (from p in Patientslist
                             select p.PatientId).ToList();
            ViewBag.pid = new SelectList(patientid);

            //Storing the specialization in a ViewBag
            ViewBag.specialization = d;

            //Populating doctor Names using specialization from the database
            var doctorsobj = (from k in DoctorsList
                              where k.Specialization == d
                              select  k.Firstname).ToList();
            ViewBag.doctor = new SelectList(doctorsobj);

            //Storing the available list of doctor details
            var availablelist = (from a in DoctorsList
                                 where a.Specialization == d
                                 select a);
            ViewBag.availablelist = availablelist;
            
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Create(Schedule s)
        {
            Schedule sobj = new Schedule();
           
            //  HttpClient obj = new HttpClient();
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(Baseurl);
                StringContent content = new StringContent(JsonConvert.SerializeObject(s), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("api/Schedules", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    sobj = JsonConvert.DeserializeObject<Schedule>(apiResponse);
                }
            }
            

            return RedirectToAction("ViewAppointments");
        }
        
        //Edit an Appointment
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Schedule s = new Schedule();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44305/api/Schedules/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    s = JsonConvert.DeserializeObject<Schedule>(apiResponse);
                }
            }
            return View(s);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(Schedule s)
        {
            Schedule s1 = new Schedule();
            using (var httpClient = new HttpClient())
            {
                int id = s.AppointmentId;
                StringContent content1 = new StringContent(JsonConvert.SerializeObject(s), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("https://localhost:44305/api/Schedules/" + id, content1))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    s1 = JsonConvert.DeserializeObject<Schedule>(apiResponse);
                }
            }
            return RedirectToAction("ViewAppointments");
        }

        //Delete an Appointment
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            TempData["AppointmentId"] = id;
            Schedule s = new Schedule();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44305/api/Schedules/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    s = JsonConvert.DeserializeObject<Schedule>(apiResponse);
                }
            }
            return View(s);

        }

        [HttpPost]
        public async Task<ActionResult> Delete(Schedule s)
        {
            int appid = Convert.ToInt32(TempData["AppointmentId"]);
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44305/api/Schedules/" + appid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("ViewAppointments");
        }
    }
}
