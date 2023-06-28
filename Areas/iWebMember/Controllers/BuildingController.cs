using Microsoft.AspNetCore.Mvc;

namespace BSRVemcoCS.Areas.iWebMember.Controllers
{

    //[Area ( "iWebMember/Building" )]
    public class BuildingController : Controller
    {
        public IActionResult Index ( )
        {
            return View ( );
        }
    }
}
