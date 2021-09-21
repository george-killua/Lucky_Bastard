
using System.ComponentModel.DataAnnotations;

namespace Data_Access.Features.Requestes
{
    public class AuthenticateRequest
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
