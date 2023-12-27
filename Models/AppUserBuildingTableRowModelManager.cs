using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BSRVemcoCS.Models
{
    public class AppUserBuildingTableRowModelManager
    {


        public int? _id { get; set; } = -1;
      
        public string? AppTableTokenID { get; set; } = "0";
        public string? TableTokenID { get; set; } = "0";
      
        public string? AppInformationTokenID { get; set; } = "0";
        public string? InformationTokenID { get; set; } = "0";
        public string? InformationText { get; set; } = "0";
        public string? CompanyTokenID { get; set; } = "0";
        public string? BuildingTokenID { get; set; } = "0";
   


        public string? ColumnDescription { get; set; } = "0";
        public string? ColumnCommentary { get; set; } = "0";
        public string? ColumnCriterion { get; set; } = "0";

        public string? ColumnRiskCode { get; set; } = "0";
        public string? ColumnRiskOption { get; set; } = "0";
        public string? ColumnRiskText { get; set; } = "0";
        public string? ColumnRiskDescription { get; set; } = "0";



        //public string? ColumnVePlusText { get; set; } = "0";
        //public string? ColumnVeMinusText { get; set; } = "0";
        //public string? ColumnNeutralText{ get; set; } = "0";




        public string? ColumnScore { get; set; } = "0";
        public string? ColumnScoreOriginal { get; set; } = "0";
        public string? ColumnScoreManaged { get; set; } = "0";
        public string? ColumnScoreAdjused { get; set; } = "0";
        public string? ColumnRiskControlMeasure { get; set; } = "0";
        public string? ColumnTotal { get; set; } = "0";
     
        
        public string? InformationButtonText { get; set; } = "0";
        public string? InformationButtonStyleCSS { get; set; } = "0";



        public List<AppUserBuildingTableCriterionModelManager>? ColumnCriterionList { get; set; } = new List<AppUserBuildingTableCriterionModelManager> ( );






        //////[Required]
        //////[DisplayName ( "Confirm Password" )]
        //////[DataType ( DataType.Password )]
        //////[Compare ( "Password" , ErrorMessage = "Password and confirmation do not match." )]
        //////public string?  PasswordConfirm { get; set; }
    }
}
