using BSRVemcoCS.Models;

using Microsoft.AspNetCore.Authentication;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BSRVemcoCS.iAppViewModel
{
    public class AppDevelomentSummaryViewModel
    {
        //[Required]
        //[Display(Name= "Accountable Person (AP):" )]
        //public string AccountablePerson { get; set; }

        //[Required]
        //[Display(Name= "Accountable Person (AP):" )]
        //public string CompanyTokenID { get; set; }

        //[Required]
        //[Display(Name= "Accountable Person (AP):" )]
        public string? BuildingTokenID { get; set; } = "0";





        [Required]
        [Display ( Name = "Building name:" )]
        public string BuildingName { get; set; } = "0";



        [Required]
        [Display ( Name = "Building address:" )]
        public string BuildingAddress { get; set; } = "0";




        //[Required]
        //[Display ( Name = "Build date:" )]
        //public DateTime? BuildingDate { get; set; } = DateTime.Now;

        public string BuildingDateDay { get; set; } = "0";
        public string BuildingDateMonth { get; set; } = "0";

        [Required]
        [Display ( Name = "Building date:" )]
        public string BuildingDateYear { get; set; } = "0";


        public string? BuildingImageTokenID { get; set; } = "0";



        public AppUserBuildingStatisticModelManager? iBuildingStatisticModel { get; set; } = null;


        //[Required]
        ////[Display(Name= "Building Image:" )]
        //public string BuildingImageID { get; set; }





        //[Required]
        [Display ( Name = "Building Image:" )]
        public IFormFile? FUploadBuildingImage { get; set; }



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
