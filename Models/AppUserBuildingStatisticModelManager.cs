using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BSRVemcoCS.Models
{
    public class AppUserBuildingStatisticModelManager
    {


        public string OwnerUserTokenID { get; set; } = "0";
        public string BuildingTokenID { get; set; } = "0";
        public string BuildingName { get; set; } = "0";
        public string CompanyTokenID { get; set; } = "0";
      
        public string Table1ScoreTotal { get; set; } = "0";
        public string Table2ScoreTotal { get; set; } = "0";
        public string Table3ScoreTotal { get; set; } = "0";
     
        
        public int Table1ScoreCountRow { get; set; } = 0;
        public int Table2ScoreCountRow { get; set; } = 0;
        public int Table3ScoreCountRow { get; set; } =0;
        public int Table4ScoreCountRow { get; set; } =0;
     
        public string Table4ScoreAverage { get; set; } = "0";
      
        
        public string ScoreTotalQuality  { get; set; } = "0";
        public string  ScoreRiskAverage { get; set; } = "0";
     
        public string RoleTokenID { get; set; } = "0";
        public string RoleCode { get; set; } = "0";
        public string RoleName { get; set; } = "0";





        //////[Required]
        //////[DisplayName ( "Confirm Password" )]
        //////[DataType ( DataType.Password )]
        //////[Compare ( "Password" , ErrorMessage = "Password and confirmation do not match." )]
        //////public string PasswordConfirm { get; set; }
    }
}
