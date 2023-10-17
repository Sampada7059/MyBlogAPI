using MyBlogAPI.ViewModels;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


// MyBlogMVC\Controllers\AccountController.cs
namespace MyBlogMVC.Controllers
{
    public class SignUpMVCController : Controller 
    {
        [HttpGet]
        public ActionResult SignUp()
        {
            // Display the signup form
            return View();
        }
        Uri baseAddress = new Uri(ConfigurationManager.AppSettings["ApiLink"]);
        private readonly HttpClient _client;
        public SignUpMVCController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpPost]
        public ActionResult SignUp(SignUpVM signUpViewModel)
        {
            if (ModelState.IsValid)
            {
                string data = JsonConvert.SerializeObject(signUpViewModel);//Serialization is the process of converting . NET objects, such as strings, into a JSON format
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/SignUp/SignUp", content).Result;//PostAsync-> sends Post request along with Api-link and content and returns StatusCode
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Login", "LoginMVC");

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
