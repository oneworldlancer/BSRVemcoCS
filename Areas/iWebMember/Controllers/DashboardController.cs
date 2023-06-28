using Microsoft.AspNetCore.Mvc;

namespace BSRVemcoCS.Areas.iWebMember.Controllers
{

    [Area ( "iWebMember" )]
    public class DashboardController : Controller
    {
        public IActionResult Index ( )
        {
            return View ( );
        }


          public IActionResult Dashboard ( )
        {
            return View ( );
        }

    }
}
