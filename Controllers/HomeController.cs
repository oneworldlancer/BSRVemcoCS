using BSRVemcoCS.DBContext;
using BSRVemcoCS.iApp_Identity;
using BSRVemcoCS.iAppUtility;
using BSRVemcoCS.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace BSRVemcoCS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        private readonly BSRDBModelContext _dbContext;


        private readonly UserManager<AppCore_IdentityUser> iUserManager;
        private readonly SignInManager<AppCore_IdentityUser> iSignManager;


        //public HomeController ( ILogger<HomeController> logger )
        //{
        //    _logger = logger;
        //}
              public HomeController ( BSRDBModelContext dbContext ,
            UserManager<AppCore_IdentityUser> iUserManager ,
                        SignInManager<AppCore_IdentityUser> iSignManager )
        {
            // _logger = logger;

            _dbContext = dbContext;
            this.iUserManager = iUserManager;
            this.iSignManager = iSignManager;

        }

        public async Task<IActionResult>  Index ( )
        {
                        try
            {

                await iSignManager.SignOutAsync ( );

                return View ( );
       
            }
            catch ( Exception ex)
            {
                AppUtility_DebugManager.Debug_Get_MessageText (ex.Message.ToString() );
                return View ( );
            }
         
        }
           
        public IActionResult Home ( )
        {
            return View ( );
        }

        public IActionResult Privacy ( )
        {
            return View ( );
        }

        [ResponseCache ( Duration = 0 , Location = ResponseCacheLocation.None , NoStore = true )]
        public IActionResult Error ( )
        {
            return View ( new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier } );
        }
    }
}