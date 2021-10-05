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
    
    public class UserController : Controller
    {
        private readonly INotyfService _notyf;
        public UserController(INotyfService notyf)
        {
            _notyf = notyf;
        }
        // Accessing the data from API using this base Url
        string Baseurl = "https://localhost:44305/";

        //Get the List of users
        public async Task<IActionResult> GetAllUsers()
        {
            List<UserSetup> UserSetupInfo = new List<UserSetup>();

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/UserSetups");

                if (Res.IsSuccessStatusCode)
                {
                    var UserSetupResponse = Res.Content.ReadAsStringAsync().Result;
                    UserSetupInfo = JsonConvert.DeserializeObject<List<UserSetup>>(UserSetupResponse);

                }
                return View(UserSetupInfo);
            }
        }

        //Creating  a new user;
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserSetup u)
        {
                UserSetup Uobj = new UserSetup();
            
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(Baseurl);
                    StringContent content = new StringContent(JsonConvert.SerializeObject(u), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync("api/UserSetups", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        Uobj = JsonConvert.DeserializeObject<UserSetup>(apiResponse);
                    }
                }   
                _notyf.Success("Successfully Registered!", 3);
                return RedirectToAction("Login", "Login");

        }

        //Edit the user details;
        [HttpGet]
        public async Task<IActionResult> Edit(string username)
        {
            UserSetup u = new UserSetup();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44305/api/UserSetups/" + username))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    u = JsonConvert.DeserializeObject<UserSetup>(apiResponse);
                }
            }
            return View(u);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserSetup u)
        {
            UserSetup u1 = new UserSetup();
            using (var httpClient = new HttpClient())
            {
                string username = u.Username;
                StringContent content1 = new StringContent(JsonConvert.SerializeObject(u), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("https://localhost:44305/api/UserSetups/" + username, content1))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    u1 = JsonConvert.DeserializeObject<UserSetup>(apiResponse);
                }
            }
            _notyf.Success("Successfully Updated!", 3);
            return RedirectToAction("GetAllUsers");
        }

        //Delete a user
        [HttpGet]
        public async Task<ActionResult> Delete(string username)
        {
            TempData["Username"] = username;
            UserSetup e = new UserSetup();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44305/api/UserSetups/" + username))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    e = JsonConvert.DeserializeObject<UserSetup>(apiResponse);
                }
            }
            return View(e);

        }

        [HttpPost]
        public async Task<ActionResult> Delete(UserSetup u)
        {
            string username = (string)TempData["Username"];
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44305/api/UserSetups/" + username))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            _notyf.Success("Successfully Deleted!", 3);
            return RedirectToAction("GetAllUsers");
        }
    }
}
