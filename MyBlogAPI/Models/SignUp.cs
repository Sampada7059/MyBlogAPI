using System;
using System.Collections.Generic;

namespace MyBlogAPI.Models
{
    public partial class SignUp
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string Email { get; set; } = null!;
        public long PhoneNumber { get; set; }
        public DateTime Date { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;

        public virtual UserCredential UserCredential { get; set; } = null!;
    }
}
