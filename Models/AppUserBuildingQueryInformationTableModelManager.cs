using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BSRVemcoCS.Models
{
    public class AppUserBuildingQueryInformationTableModelManager
    {


        public string AppQueryTableTokenID { get; set; } = "0";
        public string QueryTableTokenID { get; set; } = "0";
      
        public string QueryTableName { get; set; } = "0";
     
        
        public string BuildingTokenID { get; set; } = "0";
        //public string APPInformationTokenID { get; set; } = "0";
        //public string InformationTokenID { get; set; } = "0";
        //public string InformationText { get; set; } = "0";
        //public string DocumentCount { get; set; } = "0";
        //public string TimeFrame { get; set; } = "0";
        //public string InformationScore { get; set; } = "5";
        //public string InformationScoreAdjusted { get; set; } = "5";
        //public string InformationRiskControlMeasure { get; set; } = "0";



        public bool IsAnswered { get; set; } = false;
        public bool IsViewed { get; set; } = false;
        public bool IsPaging { get; set; } = false;


       public string ImageURL { get; set; } = "0";
       public string FontStyle { get; set; } = "0";
       public string TitleColor { get; set; } = "Black";
       public string TextColor { get; set; } = "Black";
     
        public string PageSize { get; set; } = "0";
        public string PageCount { get; set; } = "0";
        public string PageNumber { get; set; } = "0";


        //public string AnswerCode { get; set; } = "0";
        //public string AnswerText { get; set; } = "0";





        //public string RoleName { get; set; } = "0";





        //////[Required]
        //////[DisplayName ( "Confirm Password" )]
        //////[DataType ( DataType.Password )]
        //////[Compare ( "Password" , ErrorMessage = "Password and confirmation do not match." )]
        //////public string PasswordConfirm { get; set; }
    }
}
