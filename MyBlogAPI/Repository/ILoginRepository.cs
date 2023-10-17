using MyBlogAPI.Models;
using MyBlogAPI.ViewModels;

namespace MyBlogAPI.Repository
{
    public interface ILoginRepository
    {
        bool AuthenticateUser(LoginVM loginViewModel);


    }
}
