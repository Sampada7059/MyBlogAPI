using MyBlogAPI.Models;
using MyBlogAPI.ViewModels;

namespace MyBlogAPI.Repository
{
        public interface ISignUpRepository
        {
            void SignUp(SignUpVM signUpViewModel);

        }
}
