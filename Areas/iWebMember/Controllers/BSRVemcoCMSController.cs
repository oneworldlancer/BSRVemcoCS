using BSRVemcoCS.DBContext;
using BSRVemcoCS.iAppManager;
using BSRVemcoCS.iAppUtility;
using BSRVemcoCS.iAppViewModel;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BSRVemcoCS.Areas.iWebMember.Controllers
{

    [Area ( "iWebMember" )]
    //[Authorize]
    public class BSRVemcoCMSController : Controller
    {

        private IWebHostEnvironment _iEnvironment;


        private readonly BSRDBModelContext _dbContext;



        public BSRVemcoCMSController (
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
        public IActionResult CMS_PageAbout ( )
        {
            try
            {


                var _iCMSPageModel = _dbContext.BsrvemcoAppCmsPageLists
                                    .Where ( u =>
                                    u.PageCode == "about" )
                                    //.Select (u  )
                                    .SingleOrDefault ( );


                AppCMSPageViewModel _iCMSPageViewModel = new AppCMSPageViewModel ( );

                _iCMSPageViewModel.PageCode = "about";
                _iCMSPageViewModel.PageHTMLContent = _iCMSPageModel.PageHtmlcontent;






                return View ( _iCMSPageViewModel );
            }
            catch ( Exception ex )
            {
                AppUtility_DebugManager.Debug_Get_MessageText ( ex.Message.ToString ( ) );
                return View ( );
            }
        }



        [HttpPost]
        public async Task<IActionResult> CMS_PageAbout ( AppCMSPageViewModel iCMSPageModel )
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









           
        [HttpGet]
        public IActionResult CMS_PageTerms ( )
        {
            try
            {


                var _iCMSPageModel = _dbContext.BsrvemcoAppCmsPageLists
                                    .Where ( u =>
                                    u.PageCode == "terms" )
                                    //.Select (u  )
                                    .SingleOrDefault ( );


                AppCMSPageViewModel _iCMSPageViewModel = new AppCMSPageViewModel ( );

                _iCMSPageViewModel.PageCode = "terms";
                _iCMSPageViewModel.PageHTMLContent = _iCMSPageModel.PageHtmlcontent;






                return View ( _iCMSPageViewModel );
            }
            catch ( Exception ex )
            {
                AppUtility_DebugManager.Debug_Get_MessageText ( ex.Message.ToString ( ) );
                return View ( );
            }
        }



        [HttpPost]
        public async Task<IActionResult> CMS_PageTerms ( AppCMSPageViewModel iCMSPageModel )
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


        
        [HttpGet]
        public IActionResult CMS_SaltWater( )
        {
            try
            {


                var _iCMSPageModel = _dbContext.BsrvemcoAppCmsPageLists
                                    .Where ( u =>
                                    u.PageCode == "saltwater")
                                    //.Select (u  )
                                    .SingleOrDefault ( );


                AppCMSPageViewModel _iCMSPageViewModel = new AppCMSPageViewModel ( );

                _iCMSPageViewModel.PageCode = "saltwater";
                _iCMSPageViewModel.PageHTMLContent = _iCMSPageModel.PageHtmlcontent;






                return View ( _iCMSPageViewModel );
            }
            catch ( Exception ex )
            {
                AppUtility_DebugManager.Debug_Get_MessageText ( ex.Message.ToString ( ) );
                return View ( );
            }
        }




        [HttpPost]
        public async Task<IActionResult> CMS_SaltWater( AppCMSPageViewModel iCMSPageModel )
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



        
        [HttpGet]
        public IActionResult CMS_WorkPermit( )
        {
            try
            {


                var _iCMSPageModel = _dbContext.BsrvemcoAppCmsPageLists
                                    .Where ( u =>
                                    u.PageCode == "workpermit")
                                    //.Select (u  )
                                    .SingleOrDefault ( );


                AppCMSPageViewModel _iCMSPageViewModel = new AppCMSPageViewModel ( );

                _iCMSPageViewModel.PageCode = "workpermit";
                _iCMSPageViewModel.PageHTMLContent = _iCMSPageModel.PageHtmlcontent;






                return View ( _iCMSPageViewModel );
            }
            catch ( Exception ex )
            {
                AppUtility_DebugManager.Debug_Get_MessageText ( ex.Message.ToString ( ) );
                return View ( );
            }
        }




        [HttpPost]
        public async Task<IActionResult> CMS_WorkPermit( AppCMSPageViewModel iCMSPageModel )
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
