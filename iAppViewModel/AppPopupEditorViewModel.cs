using BSRVemcoCS.Models;

using Microsoft.AspNetCore.Authentication;

using System.ComponentModel.DataAnnotations;

namespace BSRVemcoCS.iAppViewModel
{
    public class AppPopupEditorViewModel
    {


               
       public string BuildingTokenID { get; set; } = "0";
       public string InformationTokenID { get; set; } = "0";
    
         public string ScoreAdjusted { get; set; } = "0";
     
        public string ScoreValueMin { get; set; } = "0";
     
        public string ScoreValueMax { get; set; } = "0";
  
        public string PageHTMLContent { get; set; } = "0";
         
   

        //  [Required]
        //[Display ( Name = "Accountable Person (AP):" )]
      //  public string PageTitle { get; set; } = "0";
    
      //  [Required]
        //[Display ( Name = "Accountable Person (AP):" )]
     
     //   public string PageCode { get; set; } =   "0";
    
     //   [Required]
      //  public string PageHTMLContent { get; set; } =   "0";





        //[Required]
        ////[Display(Name= "Building Image:" )]
        //public string BuildingImageID { get; set; }





        //[Required]
        //[Display ( Name = "Upload Document(s):" )]
        //public IFormFile FUploadInformationDocument { get; set; }


        //public IList<AppUserBuildingInformationDocumentModelManager>? BuildingInformationDocumentList { get; set; } = null;

    }
}
