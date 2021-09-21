using Data_Access.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Access.Features.Requestes
{
    public class AddUserRequest
    {
        public string Username { get; set; }
        public UserType Type { get; set; }
        public string Creater { get; set; }
        public string Password { get; set; }
    }
}
