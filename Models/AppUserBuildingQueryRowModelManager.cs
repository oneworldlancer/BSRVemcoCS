using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BSRVemcoCS.Models
{
    public class AppUserBuildingQueryRowModelManager
    {


        public int? _id { get; set; } = -1;
      
        public string? AppQueryTableTokenID { get; set; } = "0";
        public string? QueryTableTokenID { get; set; } = "0";
      
        public string? AppQueryInformationTokenID { get; set; } = "0";
        public string? QueryInformationTokenID { get; set; } = "0";
        public string? InformationText { get; set; } = "0";
        public string? InformationTitle { get; set; } = "0";
        public string? InformationDescription { get; set; } = "0";
         public string? InformationTitleSystem { get; set; } = "0";
        public string? InformationDescriptionSystem { get; set; } = "0";
         public string? InformationTitleUser { get; set; } = "0";
        public string? InformationDescriptionUser { get; set; } = "0";
        public string? CompanyTokenID { get; set; } = "0";
        public string? BuildingTokenID { get; set; } = "0";
   


        public string? ColumnActivity { get; set; } = "0";
        public string? ColumnDescription { get; set; } = "0";
        public string? ColumnCommentary { get; set; } = "0";
        public string? ColumnEvidenceText { get; set; } = "0";
        public string? ColumnEvidenceDescription { get; set; } = "0";
        public string? ColumnEvideceLink { get; set; } = "0";

        public string? DocumentCount { get; set; } = "0";
        public string? AnswerCode { get; set; } = "0";
        public string? AnswerYESButtonCSS { get; set; } = "btn-outline-secondary";
        public string? AnswerNOButtonCSS { get; set; } = "btn-outline-secondary";
        public string? AnswerNULLButtonCSS { get; set; } = "btn-outline-secondary";
        //public string? ColumnScoreOriginal { get; set; } = "0";
        //public string? ColumnScoreManaged { get; set; } = "0";
        //public string? ColumnScoreAdjused { get; set; } = "0";
        //public string? ColumnRiskControlMeasure { get; set; } = "0";
        //public string? ColumnTotal { get; set; } = "0";



        public List<AppUserBuildingQueryEvidenceModelManager>? ColumnEvidenceList { get; set; } = new List<AppUserBuildingQueryEvidenceModelManager> ( );
        public List<AppUserBuildingQueryDocumentModelManager>? ColumnQueryDocumentList { get; set; } = new List<AppUserBuildingQueryDocumentModelManager> ( );






        //////[Required]
        //////[DisplayName ( "Confirm Password" )]
        //////[DataType ( DataType.Password )]
        //////[Compare ( "Password" , ErrorMessage = "Password and confirmation do not match." )]
        //////public string?  PasswordConfirm { get; set; }
    }
}
