using Microsoft.AspNetCore.Mvc;

namespace BSRVemcoCS.Areas.iWebMember.Controllers
{

    [Area ( "iWebMember" )]
    public class DevelopmentController : Controller
    {
        public IActionResult Index ( )
        {
            return View ( );
        } 
        
        public IActionResult New ( )
        {
            return View ( );
        }   
        
        public IActionResult Edit ( )
        {
            return View ( );
        }   
        
        //public IActionResult View ( )
        //{
        //    return View ( );
        //}
    }
}
