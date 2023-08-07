using Microsoft.AspNetCore.Authentication;

using System.ComponentModel.DataAnnotations;

namespace BSRVemcoCS.iAppViewModel
{
    public class AppLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }



        [Required]
        [DataType ( DataType.Password )]
        public string Password { get; set; }



        [Required]
        [Display ( Name = "Remember Me" )]
        public bool RememberMe { get; set; }



        public string? ReturnUrl { get; set; }   =null;

        public IList<AuthenticationScheme>? ExternalLogins { get; set; }

    }
}
