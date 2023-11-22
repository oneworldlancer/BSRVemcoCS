using BSRVemcoCS.Models;

using Microsoft.AspNetCore.Authentication;

using System.ComponentModel.DataAnnotations;

namespace BSRVemcoCS.iAppViewModel
{
    public class AppPagePathNameViewModel
    {


               
       public string ParentPageName { get; set; } = "0";
       public string ChildPageName { get; set; } = "0";
       public string ParentPageNameColorCSS { get; set; } = "#9999cc";
       public string ChildPageNameColorCSS { get; set; } = "#0a75bb";
       public string ChildPageNameCSS { get; set; } = "none";
  
   
        //  public string PageTokenID { get; set; } = "0";
         
   

      //  //  [Required]
      //  //[Display ( Name = "Accountable Person (AP):" )]
      //  public string PageTitle { get; set; } = "0";
    
      ////  [Required]
      //  //[Display ( Name = "Accountable Person (AP):" )]
     
      //  public string PageCode { get; set; } =   "0";
    
      //  [Required]
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
