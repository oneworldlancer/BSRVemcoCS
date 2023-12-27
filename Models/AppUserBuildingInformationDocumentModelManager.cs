using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BSRVemcoCS.Models
{
    public class AppUserBuildingInformationDocumentModelManager
    {


        public string OwnerUserTokenID { get; set; } = "0";
        public string CompanyTokenID { get; set; } = "0";
     
        public string AppTableTokenID { get; set; } = "0";
        public string TableTokenID { get; set; } = "0";
      
        public string BuildingTokenID { get; set; } = "0";
     
        public string APPInformationTokenID { get; set; } = "0";
        public string InformationTokenID { get; set; } = "0";
        public string InformationText { get; set; } = "0";
      
        public string DocumentTokenID { get; set; } = "0";
        public string DocumentWebURL { get; set; } = "0";
        public string DocumentCode { get; set; } = "pdf";
        public string DocumentType { get; set; } = "pdf";
        public string DocumentExtension { get; set; } = "pdf";
        public string DocumentName { get; set; } = "0";
        public string DocumentDescription { get; set; } = "0";
        public string DocumentSize { get; set; } = "0";

        //public string TimeoutYearCount { get; set; } = "0";
        public string TimeframeYear { get; set; } = "0";
        public string TimeframeMonth { get; set; } = "0";

        public string TimeoutUserUploadStartDay { get; set; } = "0";
        public string TimeoutUserUploadStartMonth { get; set; } = "0";
        public string TimeoutUserUploadStartYear { get; set; } = "0";
        public string TimeoutUserUploadStartText { get; set; } = "0";



        public string TimeoutUserUploadEndDay { get; set; } = "0";
        public string TimeoutUserUploadEndMonth { get; set; } = "0";
        public string TimeoutUserUploadEndYear { get; set; } = "0";
        public string TimeoutUserUploadEndText { get; set; } = "0";



        public DateTime TimeoutUserUploadStart { get; set; } = DateTime.Now;
        public DateTime TimeoutUserUploadEnd { get; set; } = DateTime.Now;





        //////[Required]
        //////[DisplayName ( "Confirm Password" )]
        //////[DataType ( DataType.Password )]
        //////[Compare ( "Password" , ErrorMessage = "Password and confirmation do not match." )]
        //////public string PasswordConfirm { get; set; }
    }
}
