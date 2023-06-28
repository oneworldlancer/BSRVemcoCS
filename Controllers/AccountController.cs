using Microsoft.AspNetCore.Mvc;

namespace BSRVemcoCS.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index ( )
        {
            return View ( );
        }
    }
}
