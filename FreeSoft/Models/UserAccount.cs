using System.ComponentModel.DataAnnotations;
using System.Web.ModelBinding;

namespace FreeSoft.Models
{
    public class UserAccount
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "FirstName name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email name is required.")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3]\.)|(([\w-]+\.)+))([a-zA-Z{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter valid email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Username name is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password name is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Please confirm your password.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}