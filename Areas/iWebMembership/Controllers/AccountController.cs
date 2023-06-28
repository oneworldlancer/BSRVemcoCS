using Microsoft.AspNetCore.Mvc;

namespace BSRVemcoCS.Areas.iWebMembership.Controllers
{

    [Area ( "iWebMembership" )]
    public class AccountController : Controller
    {
        public IActionResult Index ( )
        {
            return View ( );
        }  
        
        
        public IActionResult Login ( )
        {
            return View ( );
        }  
        
        
        public IActionResult Register ( )
        {
            return View ( );
        }
    }
}
