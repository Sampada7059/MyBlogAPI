using MyBlogAPI.Models;
using MyBlogAPI.Repository;
using MyBlogAPI.ViewModels;

namespace MyBlogAPI.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly MyBlogContext _dbContext;

        public LoginRepository(MyBlogContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AuthenticateUser(LoginVM loginViewModel)
        {
            

            UserCredential user = new UserCredential();

            var result = _dbContext.UserCredentials
            .SingleOrDefault(u => u.Username == loginViewModel.UserName);

            // If the user is not found, or the password doesn't match, authentication fails
            if (user == null || user.Password != loginViewModel.Password)
            {
                return false;
            }

            // Additional checks, if needed (e.g., check user status or type)

            // Authentication successful
            return true;

        }
    }
}


