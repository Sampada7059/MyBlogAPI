using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MyBlogAPI.ViewModels;
using System.Configuration;

namespace MyBlogMVC.Controllers
{
    public class LoginMVCController : Controller
    {
        Uri baseAddress = new Uri(ConfigurationManager.AppSettings["ApiLink"]);
        private readonly HttpClient _client;
        public LoginMVCController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        [HttpGet]

        public ActionResult Login()
        {
            return View();
        }
        // GET: LoginMVC
        [HttpPost]
        public ActionResult Login(LoginVM loginViewModel)
        {
            if (ModelState.IsValid)
            {
                string data = JsonConvert.SerializeObject(loginViewModel);//Serialization is the process of converting . NET objects, such as strings, into a JSON format
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/Login", content).Result;//PostAsync-> sends Post request along with Api-link and content and returns StatusCode
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    return View();
                }
                //TempData["SuccessMessage"] = "Student registered successfully."; //for SweetAlert Message
            }
            return View();
        }
    }
}