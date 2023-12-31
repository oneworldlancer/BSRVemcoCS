﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BSRVemcoCS.Models
{
    public class AppUserBuildingInformationModelManager
    {


        public string AppTableTokenID { get; set; } = "0";
        public string TableTokenID { get; set; } = "0";
        public string BuildingTokenID { get; set; } = "0";
        public string APPInformationTokenID { get; set; } = "0";
        public string InformationTokenID { get; set; } = "0";
        public string InformationText { get; set; } = "0";
        public string DocumentCount { get; set; } = "0";
       public string InformationScore { get; set; } = "5";
        public string InformationScoreAdjusted { get; set; } = "5";
        public string InformationRiskControlMeasure { get; set; } = "0";
    
        public string RowBackgroundColor { get; set; } = "white";



        public bool IsAnswered { get; set; } = false;
        public bool IsViewTooltip { get; set; } = false;


        public string QuestionCode { get; set; } = "0";
        public string QuestionText { get; set; } = "0";
        public string QuestionDescription { get; set; } = "0";


        public string AnswerCode { get; set; } = "0";
        public string AnswerText { get; set; } = "0";
        public string AnswerDescription { get; set; } = "0";

   public string TimeFrame { get; set; } = "0";
   public string TimeFrameMonth { get; set; } = "0";
   public string TimeFrameYear { get; set; } = "0";
      
        public string TitleColor { get; set; } = "Black";
        public string TextColor { get; set; } = "Black";
        public string TextDescriptionColor { get; set; } = "Black";

        //public string? AnswerYESButtonCSS { get; set; } = "btn-outline-secondary";
        //public string? AnswerNOButtonCSS { get; set; } = "btn-outline-secondary";
        public string? AnswerNULLButtonCSS { get; set; } = "btn-outline-secondary";


        //public string RoleName { get; set; } = "0";





        //////[Required]
        //////[DisplayName ( "Confirm Password" )]
        //////[DataType ( DataType.Password )]
        //////[Compare ( "Password" , ErrorMessage = "Password and confirmation do not match." )]
        //////public string PasswordConfirm { get; set; }
    }
}
