using BSRVemcoCS.Models;

using Microsoft.AspNetCore.Authentication;

using System.ComponentModel.DataAnnotations;

namespace BSRVemcoCS.iAppViewModel
{
    public class AppDevelomentInformationReportViewModel
    {




        ////////[Required]
        //////////[Display ( Name = "Accountable Person (AP):" )]
        ////////public string APPInformationTokenID { get; set; }
         
    
        ////////[Required]
        //////////[Display ( Name = "Accountable Person (AP):" )]
        ////////public string InformationTokenID { get; set; }





        //////////[Required]
        ////////////[Display(Name= "Building Image:" )]
        //////////public string BuildingImageID { get; set; }





        ////////[Required]
        ////////[Display ( Name = "Upload Document(s):" )]
        ////////public IFormFile FUploadInformationDocument { get; set; }


        ////////public IList<AppUserBuildingInformationDocumentModelManager>? BuildingInformationDocumentList { get; set; } = null;




        public List<AppUserBuildingInformationModelManager>? BuildingInformationList { get; set; } = null;
        public List<AppUserBuildingInformationModelManager>? BuildingInformationList1 { get; set; } = null;
        public List<AppUserBuildingInformationModelManager>? BuildingInformationList2 { get; set; } = null;




    }
}
