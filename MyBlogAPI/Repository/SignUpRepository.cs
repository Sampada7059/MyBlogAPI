using MyBlogAPI.Models;
using MyBlogAPI.ViewModels;
using System;
using System.Threading.Tasks;

namespace MyBlogAPI.Repository
{
    public class SignUpRepository : ISignUpRepository
    {
        private readonly MyBlogContext _dbContext;

        public SignUpRepository(MyBlogContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SignUp(SignUpVM signUpViewModel)
        {
            if (signUpViewModel.Password != signUpViewModel.ConfirmPassword)
            {
                
                throw new InvalidOperationException("Password and ConfirmPassword do not match");
            }

            SignUp signup = new SignUp();

            signup.Username = signUpViewModel.UserName;
            signup.FirstName = signUpViewModel.FirstName;
            signup.LastName = signUpViewModel.LastName;
            signup.Email = signUpViewModel.Email;
            signup.Gender = signUpViewModel.Gender;
            signup.PhoneNumber = signUpViewModel.PhoneNumber;
            signup.Password = signUpViewModel.Password;
            signup.ConfirmPassword = signUpViewModel.ConfirmPassword;
            signup.Date = DateTime.Now; // Assuming UTC time for registration date

            _dbContext.SignUps.Add(signup);
            _dbContext.SaveChanges();


            UserCredential user = new UserCredential();

            user.Username = signUpViewModel.UserName;
            user.Password = signUpViewModel.Password;
            user.UserType = 2;
            user.Status = true;
            user.UserId = signup.Id;




            _dbContext.UserCredentials.Add(user);
            _dbContext.SaveChanges();
        }


    }
}
