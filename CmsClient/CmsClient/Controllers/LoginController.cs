using CmsClient.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Data;
using CMS.Models;

namespace CmsClient.Controllers
{
    //for login
    public class LoginController : Controller
    {
        //To access the user's data from sql database with the help of context class
        private readonly CMSContext _db;
        public LoginController(CMSContext db)
        {
            _db = db;
        }

        //Get - login form
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        
        // Post(Hits the login button)
        [HttpPost]
        public IActionResult Login(CMS.Models.Login l)
        {
            CMS.Models.UserSetup obj = (from i in _db.UserSetup
                                        where i.Username == l.Username && i.Password == l.Password
                                        select i).FirstOrDefault();
            
         
            if (obj != null)
            {
                    string username = obj.Username;
                    HttpContext.Session.SetString("username", username);
                    return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                ViewBag.errormsg = "Incorrect Username or Password";
                return View();

            }
        }
    }
}