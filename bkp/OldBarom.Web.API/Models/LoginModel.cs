using System.ComponentModel.DataAnnotations;

namespace OldBarom.Web.API.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Invalid email Format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
