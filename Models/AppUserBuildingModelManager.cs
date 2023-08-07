using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BSRVemcoCS.Models
{
    public class AppUserBuildingModelManager
    {


        public string OwnerUserTokenID { get; set; } = "0";
        public string BuildingTokenID { get; set; } = "0";
        public string BuildingName { get; set; } = "0";
        public string CompanyTokenID { get; set; } = "0";
      
        public string OwnerRoleTokenID { get; set; } = "0";
        public string OwnerRoleCode { get; set; } = "0";
        public string OwnerRoleName { get; set; } = "0";
     
        public string OwnerBuildingRoleTokenID { get; set; } = "0";
        public string OwnerBuildingRoleCode { get; set; } = "0";
        public string OwnerBuildingRoleName { get; set; } = "0";
     
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
