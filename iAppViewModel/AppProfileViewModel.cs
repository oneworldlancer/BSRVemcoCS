using Microsoft.AspNetCore.Authentication;

using System.ComponentModel.DataAnnotations;

namespace BSRVemcoCS.iAppViewModel
{
    public class AppProfileViewModel
    {


        [Required]
        //[DisplayName("First Name")]
        public string FirstName { get; set; }


        [Required]
        //[DisplayName("Last Name")]
        public string LastName { get; set; }


        [Required]
        //[DisplayName("Accountable Person")]
        public string CompanyName { get; set; }


          [Required]
        //[DisplayName("Accountable Person")]
        public string MobileNumberE164 { get; set; }








        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }



        //[Required]
        //[DataType ( DataType.Password )]
        //public string Password { get; set; }



        //[Required]
        //[Display ( Name = "Remember Me" )]
        //public bool RememberMe { get; set; }



        //public string? ReturnUrl { get; set; }   =null;

        //public IList<AuthenticationScheme>? ExternalLogins { get; set; }

    }
}
