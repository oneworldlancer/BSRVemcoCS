using Microsoft.AspNetCore.Mvc;

namespace BSRVemcoCS.Areas.iWebMember.Controllers
{


    //[Area ( "iWebMember/Contact" )]
    public class ContactController : Controller
    {
        public IActionResult Index ( )
        {
            return View ( );
        }
    }
}
