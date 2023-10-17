using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlogAPI.Models;
using MyBlogAPI.Repository;
using MyBlogAPI.ViewModels;
using System;
using System.Threading.Tasks;

namespace MyBlogAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly ISignUpRepository _signUpRepository;

        public SignUpController(ISignUpRepository signUpRepository)
        {
            _signUpRepository = signUpRepository;
        }

        // POST: api/SignUp
        [HttpPost]
        public IActionResult SignUp([FromBody] SignUpVM signUpViewModel)
        {
            try
            {

                // Call the repository to add the user asynchronously
                _signUpRepository.SignUp(signUpViewModel);
                return Ok(signUpViewModel);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}