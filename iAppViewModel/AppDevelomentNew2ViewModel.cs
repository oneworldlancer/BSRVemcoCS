using BSRVemcoCS.Models;

using Microsoft.AspNetCore.Authentication;

using System.ComponentModel.DataAnnotations;

namespace BSRVemcoCS.iAppViewModel
{
    public class AppDevelomentNew2ViewModel
    {




        //[Required]
        ////[Display ( Name = "Accountable Person (AP):" )]
        //public string BuildingTokenID { get; set; }



        //[Required]
        //[Display ( Name = "Accountable Person (AP):" )]
        //public string BuildingAddress { get; set; }



        //[Required]
        //[Display ( Name = "Accountable Person (AP):" )]
        //public DateTime BuildingDate { get; set; }




        ////[Required]
        //////[Display(Name= "Building Image:" )]
        ////public string BuildingImageID { get; set; }





        //[Required]
        //[Display ( Name = "Building Image:" )]
        //public IFormFile FUploadBuildingImage { get; set; }


        public List<AppUserBuildingInformationModelManager>? BuildingInformationList { get; set; } = null;

    }
}
