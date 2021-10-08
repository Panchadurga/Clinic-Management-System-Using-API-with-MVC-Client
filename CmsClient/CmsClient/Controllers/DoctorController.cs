using AspNetCoreHero.ToastNotification.Abstractions;
using CmsClient.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CmsClient.Controllers
{
    public class DoctorController : Controller
    {
        private readonly INotyfService _notyf;
        public DoctorController(INotyfService notyf)
        {
            _notyf = notyf;
        }
        string Baseurl = "https://localhost:44305/";

        //Get all the List of doctors
        public async Task<IActionResult> GetAllDoctors()
        {
            List<Doctor> DoctorInfo = new List<Doctor>();

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Doctors");

                if (Res.IsSuccessStatusCode)
                {
                    var DoctorResponse = Res.Content.ReadAsStringAsync().Result;
                    DoctorInfo = JsonConvert.DeserializeObject<List<Doctor>>(DoctorResponse);

                }

                return View(DoctorInfo);
            }
        }
        //Adding a doctor 
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Doctor d)
        {
            Doctor Dobj = new Doctor();
            //  HttpClient obj = new HttpClient();
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(Baseurl);
                StringContent content = new StringContent(JsonConvert.SerializeObject(d), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("api/Doctors", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Dobj = JsonConvert.DeserializeObject<Doctor>(apiResponse);
                }
            }
            _notyf.Success("Successfully Added.", 3);
            return RedirectToAction("GetAllDoctors");
        }
        //Edit the details of the doctor
        public async Task<IActionResult> Edit(int id)
        {
            Doctor d = new Doctor();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44305/api/Doctors/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    d = JsonConvert.DeserializeObject<Doctor>(apiResponse);
                }
            }
            return View(d);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(Doctor d)
        {
            Doctor d1 = new Doctor();
            using (var httpClient = new HttpClient())
            {
                int id = d.DoctorId;
                StringContent content1 = new StringContent(JsonConvert.SerializeObject(d), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("https://localhost:44305/api/Doctors/" + id, content1))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    d1 = JsonConvert.DeserializeObject<Doctor>(apiResponse);
                }
            }
            _notyf.Success("Successfully Updated.", 3);
            return RedirectToAction("GetAllDoctors");
        }

        //Delete a doctor
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            TempData["DoctorId"] = id;
            Doctor d = new Doctor();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44305/api/Doctors/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    d = JsonConvert.DeserializeObject<Doctor>(apiResponse);
                }
            }
            return View(d);

        }

        [HttpPost]
        public async Task<ActionResult> Delete(Doctor d)
        {
            int doctorid = Convert.ToInt32(TempData["DoctorId"]);
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44305/api/Doctors/" + doctorid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            _notyf.Success("Successfully Deleted.", 3);
            return RedirectToAction("GetAllDoctors");
        }
    }
}
