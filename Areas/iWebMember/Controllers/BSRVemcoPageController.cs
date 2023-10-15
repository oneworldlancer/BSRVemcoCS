using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BSRVemcoCS.Areas.iWebMember.Controllers
{

    [Area ( "iWebMember" )]
    //[Authorize]
    public class BSRVemcoPageController : Controller
    {
        public IActionResult Index ( )
        {
            return View ( );
        }

        public IActionResult About ( )
        {
            return View ( );
        }

        public IActionResult Subscription ( )
        {
            return View ( );
        }

        public IActionResult Terms ( )
        {
            return View ( );
        }

     
        public IActionResult FAQ ( )
        {
            return View ( );
        }


        public IActionResult ContactUs ( )
        {
            return View ( );
        }
        
        public IActionResult SaltWater ( )
        {
            return View ( );
        }



    }
}
