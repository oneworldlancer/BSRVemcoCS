using BSRVemcoCS.Models;

using Microsoft.AspNetCore.Authentication;

using System.ComponentModel.DataAnnotations;

namespace BSRVemcoCS.iAppViewModel
{
    public class AppDevelomentQueryDocumentListViewModel
    {




        //[Required]
        ////[Display ( Name = "Accountable Person (AP):" )]
        public string BuildingTokenID { get; set; } = "0";
        public string AppQueryTableTokenID { get; set; } = "0";
        public string AppQueryInformationTokenID { get; set; } = "0";
        public string QueryInformationTokenID { get; set; } = "0";



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


        public List<AppUserBuildingQueryDocumentModelManager>? BuildingQueryDocumentList { get; set; } = null;

    }
}
