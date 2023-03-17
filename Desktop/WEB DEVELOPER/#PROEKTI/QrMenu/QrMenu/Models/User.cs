using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace QrMenu.Models
{
    //IdentityUser e gotova klasa od Identity, po default ima username i pass
    //dodavame nova klasa koja nasleduva od IdentityUser za ako ni treba da definirame dopolnitelni parametri
    public class User : IdentityUser
    {   
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Please enter your user name.")]
        public string Name { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter your password.")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}

