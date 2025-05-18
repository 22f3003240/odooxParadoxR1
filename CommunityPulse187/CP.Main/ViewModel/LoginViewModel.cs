using System.ComponentModel.DataAnnotations;

namespace CP.Main.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }

}
