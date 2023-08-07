using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BSRVemcoCS.Models
{
    public class AppPointModelManager
    {


        public string PointX { get; set; } = "0";
        public string PointY { get; set; } = "0";
     
      
     
        public string PointXSpan { get; set; } = "0";
        public string PointYSpan { get; set; } = "0";
      
        public string PointXValue { get; set; } = "0";
        public string PointYValue { get; set; } = "0";


         public string PointXText { get; set; } = "0";
        public string PointYText { get; set; } = "0";







        //////[Required]
        //////[DisplayName ( "Confirm Password" )]
        //////[DataType ( DataType.Password )]
        //////[Compare ( "Password" , ErrorMessage = "Password and confirmation do not match." )]
        //////public string PasswordConfirm { get; set; }
    }
}
