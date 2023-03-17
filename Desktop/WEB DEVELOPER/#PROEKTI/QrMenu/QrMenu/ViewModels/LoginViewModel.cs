using System.ComponentModel.DataAnnotations;

namespace QrMenu.ViewModels
{
    public class LoginViewModel
    {
        //koristime data anotacii za validacija na serverska strana
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Please enter your user name.")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter your password.")]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
