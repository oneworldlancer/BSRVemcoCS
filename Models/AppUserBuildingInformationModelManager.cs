using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BSRVemcoCS.Models
{
    public class AppUserBuildingInformationModelManager
    {


        public string BuildingTokenID { get; set; } = "0";
        public string APPInformationTokenID { get; set; } = "0";
        public string InformationTokenID { get; set; } = "0";
        public string InformationText { get; set; } = "0";
        public string DocumentCount { get; set; } = "0";
        public string InformationScore { get; set; } = "5";
        public string InformationScoreAdjusted { get; set; } = "5";
        public string InformationRiskControlMeasure { get; set; } = "0";
        //public string RoleName { get; set; } = "0";





        //////[Required]
        //////[DisplayName ( "Confirm Password" )]
        //////[DataType ( DataType.Password )]
        //////[Compare ( "Password" , ErrorMessage = "Password and confirmation do not match." )]
        //////public string PasswordConfirm { get; set; }
    }
}
