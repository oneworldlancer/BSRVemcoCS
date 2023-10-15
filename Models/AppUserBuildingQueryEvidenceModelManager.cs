using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BSRVemcoCS.Models
{
    public class AppUserBuildingQueryEvidenceModelManager
    {

       public string? EvidenceToken { get; set; } = "0";
       public string? EvidenceText { get; set; } = "0";
  
        //    public string? ColumnTotal { get; set; } = "0";






        //////[Required]
        //////[DisplayName ( "Confirm Password" )]
        //////[DataType ( DataType.Password )]
        //////[Compare ( "Password" , ErrorMessage = "Password and confirmation do not match." )]
        //////public string?  PasswordConfirm { get; set; }
    }
}
