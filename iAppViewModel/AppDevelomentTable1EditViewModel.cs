﻿using BSRVemcoCS.Models;

using Microsoft.AspNetCore.Authentication;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BSRVemcoCS.iAppViewModel
{
    public class AppDevelomentTable1EditViewModel
    {
        //[Required]
        //[Display(Name= "Accountable Person (AP):" )]
        //public string AccountablePerson { get; set; }

        //[Required]
        //[Display(Name= "Accountable Person (AP):" )]
        //public string CompanyTokenID { get; set; }

        //[Required]
        //[Display(Name= "Accountable Person (AP):" )]
        public string? BuildingTokenID { get; set; } = "0";
         public string? TableTitle { get; set; } = "0";
        public string? TableDescription { get; set; } = "0";

        public string? ColumnDescription { get; set; } = "0";
        public string? ColumnCommentary { get; set; } = "0";
        public string? ColumnCriterion { get; set; } = "0";
        public string? ColumnVePlus { get; set; } = "0";
        public string? ColumnVeMinus { get; set; } = "0";
        public string? ColumnNeutral { get; set; } = "0";
        public string? ColumnScore { get; set; } = "0";
        public string? ColumnScoreOriginal { get; set; } = "0";
        public string? ColumnScoreManaged { get; set; } = "0";
        public string? ColumnScoreAdjused { get; set; } = "0";
        public string? ColumnRiskControlMeasure { get; set; } = "0";
        public string? ColumnScoreTotal { get; set; } = "0";
        public string? ColumnScoreAverage { get; set; } = "0";
        public string? ColumnScoreQualityTotal { get; set; } = "0";
        public string? ColumnScoreRiskTotal { get; set; } = "0";
       

        public List<AppUserBuildingTableRowModelManager>? RowContentList { get; set; } = new List<AppUserBuildingTableRowModelManager> ( );





        //////[Required]
        //////  [Display(Name= "Development name:" )]
        //////  public string BuildingName { get; set; }



        //////    [Required]
        //////  [Display(Name= "Development address:" )]
        //////  public string BuildingAddress { get; set; }



        //////    [Required]
        //////  [Display(Name= "Build date:" )]
        //////  public DateTime BuildingDate { get; set; }

        //////  public string? BuildingImageTokenID { get; set; } = "0";


        //[Required]
        ////[Display(Name= "Building Image:" )]
        //public string BuildingImageID { get; set; }





        ////////[Required]
        //////[Display(Name= "Building Image:" )]
        //////public IFormFile? FUploadBuildingImage{ get; set; }



        //[Required]
        //[DataType ( DataType.Password )]
        //public string Password { get; set; }



        //[Required]
        //[Display ( Name = "Remember Me" )]
        //public bool RememberMe { get; set; }



        //public string? ReturnUrl { get; set; }   =null;

        //public IList<AuthenticationScheme>? ExternalLogins { get; set; }

    }
}
