using System;
using System.Collections.Generic;

namespace MyBlogAPI.Models
{
    public partial class UserCredential
    {
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int UserType { get; set; }
        public bool Status { get; set; }

        public virtual SignUp User { get; set; } = null!;
    }
}
