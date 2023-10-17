using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlogAPI.Models;
using MyBlogAPI.Repository;
using MyBlogAPI.ViewModels;
using System;
using System.Threading.Tasks;

namespace MyBlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _LoginRepository;

        public LoginController(ILoginRepository LoginRepository)
        {
            _LoginRepository = LoginRepository;
        }

        // POST: api/SignUp
        [HttpPost]
        public IActionResult Login([FromBody] LoginVM loginViewModel)
        {
            try
            {

                // Call the repository to add the user asynchronously
                _LoginRepository.AuthenticateUser(loginViewModel);
                return Ok(loginViewModel);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}