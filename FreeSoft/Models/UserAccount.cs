using System.ComponentModel.DataAnnotations;
using System.Web.ModelBinding;

namespace FreeSoft.Models
{
    public class UserAccount
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "FirstName name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email name is required.")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "Please enter correct email address")]
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