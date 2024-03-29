﻿using System.Numerics;

namespace MyBlogAPI.ViewModels
{
    public class SignUpVM
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string Gender { get; set; }
        public long PhoneNumber { get; set; }

        public string Password { get; set; }
        public string ConfirmPassword { get; set;}


    }
}
