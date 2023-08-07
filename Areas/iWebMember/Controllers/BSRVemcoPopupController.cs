using BSRVemcoCS.DBContext;
using BSRVemcoCS.iAppManager;
using BSRVemcoCS.iAppUtility;
using BSRVemcoCS.iAppViewModel;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BSRVemcoCS.Areas.iWebMember.Controllers
{

    [Area ( "iWebMember" )]
    [Authorize]
    public class BSRVemcoPopupController : Controller
    {

        private IWebHostEnvironment _iEnvironment;


        private readonly BSRDBModelContext _dbContext;



        public BSRVemcoPopupController (
                BSRDBModelContext dbContext ,
            IWebHostEnvironment iEnvironment )
        {
            _dbContext = dbContext;
            _iEnvironment = iEnvironment;

        }







        public IActionResult Index ( )
        {
            return View ( );
        }



        [HttpGet]
        public IActionResult Popup_GetEditor (string bldtknid, string inftknid )
        {
            try
            {
              
                //var _iCMSPageModel = _dbContext.BsrvemcoAppCmsPageLists
                //                    .Where ( u =>
                //                    u.PageCode == "about" )
                //                    //.Select (u  )
                //                    .SingleOrDefault ( );


                //AppCMSPageViewModel _iCMSPageViewModel = new AppCMSPageViewModel ( );

                //_iCMSPageViewModel.PageCode = "about";
                //_iCMSPageViewModel.PageHTMLContent = _iCMSPageModel.PageHtmlcontent;






                return ViewComponent ( "Editor",new { bldtknid=bldtknid, inftknid=inftknid } );
            }
            catch ( Exception ex )
            {
                AppUtility_DebugManager.Debug_Get_MessageText ( ex.Message.ToString ( ) );
                return View ( );
            }
        }



        [HttpPost]
        public async Task<IActionResult> CMS_PageEdit ( AppCMSPageViewModel iCMSPageModel )
        {
            try
            {

                var x = false;

                x = await AppCMSPageManager.CMSPage_Update_HTMLContent_ByPageTokenID (
                              _dbContext ,
               iCMSPageModel.PageTokenID ,
              iCMSPageModel.PageCode ,
               iCMSPageModel.PageHTMLContent );





                return View ( );
            }
            catch ( Exception ex )
            {
                AppUtility_DebugManager.Debug_Get_MessageText ( ex.Message.ToString ( ) );
                return View ( );
            }
        }

    }
}
