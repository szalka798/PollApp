using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollApp.Application.Models.User
{
    public class LoginUserModel
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
    public class LoginResponseModel
    {
        public string Token { get; set; }
    }
}
