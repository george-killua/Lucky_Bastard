using Data_Access.Enum;
using Data_Access.Models;

namespace Data_Access.Features.Response
{
    public class AuthenticateResponse
    {
        public string Username { get; set; }

        public UserType Type { get; set; }

        public string Token { get; set; }


        public AuthenticateResponse(User user, UserType type, string token)
        {
            Username = user.Username;

            Type = type;

            Token = token;

        }
    }
}
