using eSaleSolution.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace eSaleSolution.ViewModels.Common
{
    public class LoginApiResult: LoginRequest
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public string Token { get; set; }

    }
}