using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BSRVemcoCS.Models
{
    public class AppUserBuildingInformationDocumentModelManager
    {


        public string OwnerUserTokenID { get; set; } = "0";
        public string CompanyTokenID { get; set; } = "0";
        public string BuildingTokenID { get; set; } = "0";
        public string APPInformationTokenID { get; set; } = "0";
        public string InformationTokenID { get; set; } = "0";
        public string InformationText { get; set; } = "0";
        public string DocumentTokenID { get; set; } = "0";
        public string DocumentCode { get; set; } = "0";
        public string DocumentType { get; set; } = "0";
        public string DocumentName { get; set; } = "0";
         public string DocumentDescription { get; set; } = "0";
    
        //public string RoleName { get; set; } = "0";





        //////[Required]
        //////[DisplayName ( "Confirm Password" )]
        //////[DataType ( DataType.Password )]
        //////[Compare ( "Password" , ErrorMessage = "Password and confirmation do not match." )]
        //////public string PasswordConfirm { get; set; }
    }
}
