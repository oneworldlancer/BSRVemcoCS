using Microsoft.AspNetCore.Mvc;

namespace BSRVemcoCS.Controllers
{
    public class DebugController : Controller
    {
        public IActionResult Index ( )
        {
            return View ( );
        }    
        
        
        public IActionResult Editor ( )
        {
            return View ( );
        }
    }
}
