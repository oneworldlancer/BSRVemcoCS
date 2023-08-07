using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BSRVemcoCS.Models
{
    public class AppUserBuildingTableCriterionModelManager
    {

       public string? CriterionToken { get; set; } = "0";
       public string? CriterionText { get; set; } = "0";
  
        //    public string? ColumnTotal { get; set; } = "0";






        //////[Required]
        //////[DisplayName ( "Confirm Password" )]
        //////[DataType ( DataType.Password )]
        //////[Compare ( "Password" , ErrorMessage = "Password and confirmation do not match." )]
        //////public string?  PasswordConfirm { get; set; }
    }
}
