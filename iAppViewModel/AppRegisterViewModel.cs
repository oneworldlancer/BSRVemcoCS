using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BSRVemcoCS.iAppViewModel
{
    public class AppRegisterViewModel
    {

        [Required]
        [DisplayName ( "First Name" )]
        public string  FirstName{ get; set; }

   
        [Required]
        [DisplayName ( "Last Name" )]
        public string LastName { get; set; }

     
        [Required]
        [DisplayName ( "Accountable Person" )]
        public string CompanyName { get; set; }


        [Required]
        [DisplayName ( "Email Address" )]
        [EmailAddress]
        //[Remote ( action: "IsEmailInUse" , controller: "Account" )]
        public string Email { get; set; }



        [Required]
        [DisplayName ( "Your Password" )]
        [DataType ( DataType.Password )]
        public string Password { get; set; }



        //////[Required]
        //////[DisplayName ( "Confirm Password" )]
        //////[DataType ( DataType.Password )]
        //////[Compare ( "Password" , ErrorMessage = "Password and confirmation do not match." )]
        //////public string PasswordConfirm { get; set; }
    }
}
