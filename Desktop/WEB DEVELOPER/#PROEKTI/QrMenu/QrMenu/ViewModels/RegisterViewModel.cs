using System.ComponentModel.DataAnnotations;

namespace QrMenu.ViewModels
{
    public class RegisterViewModel
    {
        //koristime data anotacii za validacija na serverska strana
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Please enter user name.")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter password.")]
        [DataType(DataType.Password)]
        //[Required(ErrorMessage = "Please enter your password.")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Please re-enter password.")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage ="Password and confirmation password do not match!")]
        public string ConfirmPassword { get; set; }
    }
}
