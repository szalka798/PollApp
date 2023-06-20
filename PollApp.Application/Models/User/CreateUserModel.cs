using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollApp.Application.Models.User
{
    public class CreateUserModel
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
    public class CreateUserResponseModel
    {

    }
}
