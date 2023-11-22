using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BSRVemcoCS.Models
{
    public class AppUserOwnerModelManager
    {

           public string OwnerUserTokenID { get; set; } = "0";
           public string OwnerMobileNumberTokenID { get; set; } = "0";
      
     
        public string CompanyName { get; set; } = "0";
        public string CompanyTokenID { get; set; } = "0";
      public string UserName { get; set; } = "0";
        public string EmailAddress { get; set; } = "0";
        public string FirstName { get; set; } = "0";
        public string LastName { get; set; } = "0";
        public string FullName { get; set; } = "0";
        //public string EmailAddress { get; set; } = "0";
        public string RoleTokenID { get; set; } = "0";
        public string RoleCode { get; set; } = "0";
        public string RoleName { get; set; } = "0";
        public string MobileNumberE164 { get; set; } = "0";





        //////[Required]
        //////[DisplayName ( "Confirm Password" )]
        //////[DataType ( DataType.Password )]
        //////[Compare ( "Password" , ErrorMessage = "Password and confirmation do not match." )]
        //////public string PasswordConfirm { get; set; }
    }
}
