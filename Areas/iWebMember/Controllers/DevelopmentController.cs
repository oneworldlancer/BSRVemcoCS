using BSRVemcoCS.iAppViewModel;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using BSRVemcoCS.DBModels;
using BSRVemcoCS.iAppUtility;
using System.Collections;
using BSRVemcoCS.DBContext;
using BSRVemcoCS.Models;
using BSRVemcoCS.iAppManager;
//using ChartJSCore.Helpers;
//using ChartJSCore.Models;
//using ChartJSCore.Plugins.Zoom;
using System.Diagnostics;


namespace BSRVemcoCS.Areas.iWebMember.Controllers
{








    [Area ( "iWebMember" )]
    [Authorize]
    public class DevelopmentController : Controller
    {


        private IWebHostEnvironment _iEnvironment;


        private readonly BSRDBModelContext _dbContext;




        public DevelopmentController (
                BSRDBModelContext dbContext ,
            IWebHostEnvironment iEnvironment )
        {
            _dbContext = dbContext;
            _iEnvironment = iEnvironment;

        }







        #region Page1_New


        [HttpGet]
        public IActionResult Page1_New ( )
        {
            return View ( );
        }






        [HttpPost]
        [RequestFormLimits ( MultipartBodyLengthLimit = 104857600 )]
        public async Task<IActionResult> Page1_New ( AppDevelomentNew1ViewModel iDevelomentNew1ViewModel )
        {


            if ( ModelState.IsValid )
            {

                ArrayList _arrTokenList = new ArrayList ( );
                _arrTokenList = AppUtility_ListTokenIDManager.ListTokenID_Generate_NewList ( "2" );

                //string iDay = iDevelomentNew1ViewModel.BuildingDate.Day.ToString ( );
                //string iMonth = iDevelomentNew1ViewModel.BuildingDate.Month.ToString ( );
                //string iYear = iDevelomentNew1ViewModel.BuildingDate.Year.ToString ( );
                string iYear = iDevelomentNew1ViewModel.BuildingDateYear.ToString ( );


                string wwwPath = _iEnvironment.WebRootPath;
                string contentPath = _iEnvironment.ContentRootPath;

                string path = Path.Combine ( _iEnvironment.WebRootPath , "_iUMedia/_iUBuilding" );
                if ( !Directory.Exists ( path ) )
                {
                    Directory.CreateDirectory ( path );
                }

                List<string> uploadedFiles = new List<string> ( );
                //foreach ( IFormFile postedFile in postedFiles )
                //{
                string fileName = Path.GetFileName ( iDevelomentNew1ViewModel.FUploadBuildingImage.FileName );
                string _iFileName = "img_" + _arrTokenList[ 1 ] + ".jpg";


                //   using ( FileStream stream = new FileStream ( Path.Combine ( path , fileName ) , FileMode.Create ) )


                using ( FileStream stream = new FileStream ( Path.Combine ( path , _iFileName ) , FileMode.Create ) )
                {
                    iDevelomentNew1ViewModel.FUploadBuildingImage.CopyTo ( stream );
                    uploadedFiles.Add ( fileName );
                    ViewBag.Message += string.Format ( "<b>{0}</b> uploaded.<br />" , fileName );


                }
                //}


                BsrvemcoUserBuildingList iBuildingModel = new BsrvemcoUserBuildingList ( )
                {

                    RowViewTokenId = new Guid ( ) ,


                    OwnerUserTokenId = Program.iOwnerModel.OwnerUserTokenID ,
                    CompanyTokenId = Program.iOwnerModel.CompanyTokenID ,

                    BuildingTokenId = _arrTokenList[ 0 ].ToString ( ) ,
                    BuildingName = iDevelomentNew1ViewModel.BuildingName ,
                    BuildingAddress = iDevelomentNew1ViewModel.BuildingAddress ,
                    BuildingDay = "0" ,//iDevelomentNew1ViewModel.BuildingDate.Day.ToString ( ) ,
                    BuildingMonth = "0" ,// iDevelomentNew1ViewModel.BuildingDate.Month.ToString ( ) ,
                    BuildingYear = iDevelomentNew1ViewModel.BuildingDateYear.ToString ( ) ,
                    BuildingDate = "0" ,//iDevelomentNew1ViewModel.BuildingDate.ToString ( ) ,
                    //FileTokenId = _iImageTokenID ,
                    //FileName = _iImageTokenID ,
                    //FileExtension = _iImageTokenID ,
                    ImageTokenId = _arrTokenList[ 1 ].ToString ( ) ,
                    UploadDateTimeMilliSec = AppUtility_TimeManager.Time_GetCurrentTimeInMilliSecond ( ) ,
                    IsVisible = true ,
                    IsActive = true ,

                };


                await _dbContext.BsrvemcoUserBuildingLists.AddAsync ( iBuildingModel );


                await _dbContext.SaveChangesAsync ( );

                return RedirectToAction (
                    "Page2_New" ,
                    "Development" ,
                    new { area = "iWebMember" , bldtknid = _arrTokenList[ 0 ].ToString ( ) , state = "new" } );

                //    //return RedirectToAction ( "Edit" , "Dashboard" ,
                //    //    new { id = "1101" , Area = "iWebMember" } );

                //await _dbContext.BsrvemcoUserBuildingLists.AddAsync ( iBuildingModel );



                //AppCore_IdentityUser iUser = new AppCore_IdentityUser
                //{

                //    UserName = iRegisterModel.Email ,
                //    Email = iRegisterModel.Email

                //};

                //var iResult = await iUserManager.CreateAsync ( iUser , iRegisterModel.Password );

                //if ( iResult.Succeeded )
                //{
                //    await iSignManager.SignInAsync ( iUser , true );


                //    return RedirectToAction (
                //        "Index" ,
                //        "Dashboard" ,
                //        new { area = "iWebMember" } );

                //    //return RedirectToAction ( "Edit" , "Dashboard" ,
                //    //    new { id = "1101" , Area = "iWebMember" } );
                //}

                //foreach ( var iError in iResult.Errors )
                //{

                //    ModelState.AddModelError ( "iErrorKey" , iError.Description );

                //}

            }
            else
            {

                return View ( iDevelomentNew1ViewModel );

            }


            // return View ( iDevelomentNew1ViewModel );

        }










        #endregion


        #region Page1_Edit


        [HttpGet]
        public IActionResult Page1_Edit ( )
        {

            try
            {
                //string id = HttpContext.Request.RouteValues[ "bldtknid" ].ToString ( );
                string id = Request.Query[ "bldtknid" ].ToString ( );


                string state = "edit";

                var _iUserBuildignModel = _dbContext.BsrvemcoUserBuildingLists
                        .Where ( u => u.BuildingTokenId == id )
                        //.Select (u  )
                        .FirstOrDefault ( ); // This is what actually executes the request and return a response

                AppDevelomentEdit1ViewModel _iDevelomentNew1ViewModel = new AppDevelomentEdit1ViewModel ( )
                {
                    BuildingTokenID = id ,
                    BuildingName = _iUserBuildignModel.BuildingName ,
                    BuildingAddress = _iUserBuildignModel.BuildingAddress ,
                    BuildingDateYear = _iUserBuildignModel.BuildingYear ,
                    BuildingImageTokenID = _iUserBuildignModel.ImageTokenId
                };




                return View ( _iDevelomentNew1ViewModel );

            }
            catch ( Exception )
            {

                throw;
            }










        }







        [HttpPost]
        [RequestFormLimits ( MultipartBodyLengthLimit = 104857600 )]
        public async Task<IActionResult> Page1_Edit ( AppDevelomentEdit1ViewModel iDevelomentEdit1ViewModel )
        {

            //   string id = HttpContext.Request.RouteValues[ "bldtknid" ].ToString ( );
            string id = Request.Query[ "bldtknid" ].ToString ( );
            string state = "edit";


            if ( ModelState.IsValid )
            {

                ArrayList _arrTokenList = new ArrayList ( );
                _arrTokenList = AppUtility_ListTokenIDManager.ListTokenID_Generate_NewList ( "1" );

                //string iDay = iDevelomentEdit1ViewModel.BuildingDate.Day.ToString ( );
                //string iMonth = iDevelomentEdit1ViewModel.BuildingDate.Month.ToString ( );
                //string iYear = iDevelomentEdit1ViewModel.BuildingDate.Year.ToString ( );
                string iYear = iDevelomentEdit1ViewModel.BuildingDateYear.ToString ( );


                //////string wwwPath = _iEnvironment.WebRootPath;
                //////string contentPath = _iEnvironment.ContentRootPath;

                //////string path = Path.Combine ( _iEnvironment.WebRootPath , "_iUMedia/_iUBuilding" );

                //////if ( !Directory.Exists ( path ) )
                //////{
                //////    Directory.CreateDirectory ( path );
                //////}

                //////List<string> uploadedFiles = new List<string> ( );

                //////string fileName = Path.GetFileName ( iDevelomentNew1ViewModel.FUploadBuildingImage.FileName );
                //////string _iFileName = "img_" + _arrTokenList[ 1 ] + ".jpg";


                //////using ( FileStream stream = new FileStream ( Path.Combine ( path , _iFileName ) , FileMode.Create ) )
                //////{
                //////    iDevelomentNew1ViewModel.FUploadBuildingImage.CopyTo ( stream );
                //////    uploadedFiles.Add ( fileName );
                //////    ViewBag.Message += string.Format ( "<b>{0}</b> uploaded.<br />" , fileName );


                //////}



                BsrvemcoUserBuildingList iBuildingModel = new BsrvemcoUserBuildingList ( )
                {

                    //   RowViewTokenId = new Guid ( ) ,


                    OwnerUserTokenId = Program.iOwnerModel.OwnerUserTokenID ,
                    CompanyTokenId = Program.iOwnerModel.CompanyTokenID ,
                    BuildingTokenId = id ,
                    BuildingName = iDevelomentEdit1ViewModel.BuildingName ,
                    BuildingAddress = iDevelomentEdit1ViewModel.BuildingAddress ,
                    BuildingDay = "0" , // iDevelomentEdit1ViewModel.BuildingDate.Day.ToString ( ) ,
                    BuildingMonth = "0" ,//  iDevelomentEdit1ViewModel.BuildingDate.Month.ToString ( ) ,
                    BuildingYear = iDevelomentEdit1ViewModel.BuildingDateYear.ToString ( ) ,
                    BuildingDate = "0" ,// iDevelomentEdit1ViewModel.BuildingDate.ToString ( ) ,
                    //FileTokenId = _iImageTokenID ,
                    //FileName = _iImageTokenID ,
                    //FileExtension = _iImageTokenID ,
                    ImageTokenId = iDevelomentEdit1ViewModel.BuildingImageTokenID.ToString ( ) ,
                    UploadDateTimeMilliSec = AppUtility_TimeManager.Time_GetCurrentTimeInMilliSecond ( ) ,
                    IsVisible = true ,
                    IsActive = true ,

                };


              _dbContext.BsrvemcoUserBuildingLists.Update ( iBuildingModel );

               await _dbContext.SaveChangesAsync ( );

                return RedirectToAction (
                    "Page2_Edit" ,
                    "Development" ,
                    new { area = "iWebMember" , bldtknid = id , state = "edit" } );

                //    //return RedirectToAction ( "Edit" , "Dashboard" ,
                //    //    new { id = "1101" , Area = "iWebMember" } );

                //await _dbContext.BsrvemcoUserBuildingLists.AddAsync ( iBuildingModel );



                //AppCore_IdentityUser iUser = new AppCore_IdentityUser
                //{

                //    UserName = iRegisterModel.Email ,
                //    Email = iRegisterModel.Email

                //};

                //var iResult = await iUserManager.CreateAsync ( iUser , iRegisterModel.Password );

                //if ( iResult.Succeeded )
                //{
                //    await iSignManager.SignInAsync ( iUser , true );


                //    return RedirectToAction (
                //        "Index" ,
                //        "Dashboard" ,
                //        new { area = "iWebMember" } );

                //    //return RedirectToAction ( "Edit" , "Dashboard" ,
                //    //    new { id = "1101" , Area = "iWebMember" } );
                //}

                //foreach ( var iError in iResult.Errors )
                //{

                //    ModelState.AddModelError ( "iErrorKey" , iError.Description );

                //}

            }
            else
            {

                return View ( iDevelomentEdit1ViewModel );

            }


            // return View ( iDevelomentNew1ViewModel );

        }







        #endregion



        #region Summary


        [HttpGet]
        public async Task<IActionResult>  Summary ()
        {
               //string bldtknid , string state 
            try
            {
                //   string id = HttpContext.Request.RouteValues[ "bldtknid" ].ToString ( );
                string id = Request.Query[ "bldtknid" ].ToString ( );
                // string state = "edit";

                var _iUserBuildignModel = _dbContext.BsrvemcoUserBuildingLists
                        .Where ( u => u.BuildingTokenId == id )
                        //.Select (u  )
                        .FirstOrDefault ( ); // This is what actually executes the request and return a response

                AppUserBuildingStatisticModelManager _iBuildingStatisticModel = new AppUserBuildingStatisticModelManager ( );
                _iBuildingStatisticModel= await AppBuildingManager.Building_Get_BuildingStatisticModel_ByBuildingTokenID (
                    _dbContext ,
                id );


                AppDevelomentSummaryViewModel _iDevelomentNew1ViewModel = new AppDevelomentSummaryViewModel ( )
                {
                    BuildingTokenID = id ,
                    BuildingName = _iUserBuildignModel.BuildingName ,
                    BuildingAddress = _iUserBuildignModel.BuildingAddress ,
                    BuildingDateYear = _iUserBuildignModel.BuildingYear ,
                    BuildingImageTokenID = _iUserBuildignModel.ImageTokenId    ,
                    iBuildingStatisticModel = _iBuildingStatisticModel
                };




                return View ( _iDevelomentNew1ViewModel );

            }
            catch ( Exception )
            {

                throw;
            }










        }


    

        [HttpGet]
        public IActionResult Summary_X1 ( string bldtknid , string state )
        {

            try
            {
                //   string id = HttpContext.Request.RouteValues[ "bldtknid" ].ToString ( );
                string id = Request.Query[ "bldtknid" ].ToString ( );
                // string state = "edit";

                var _iUserBuildignModel = _dbContext.BsrvemcoUserBuildingLists
                        .Where ( u => u.BuildingTokenId == id )
                        //.Select (u  )
                        .FirstOrDefault ( ); // This is what actually executes the request and return a response

                AppDevelomentEdit1ViewModel _iDevelomentNew1ViewModel = new AppDevelomentEdit1ViewModel ( )
                {
                    BuildingTokenID = id ,
                    BuildingName = _iUserBuildignModel.BuildingName ,
                    BuildingAddress = _iUserBuildignModel.BuildingAddress ,
                    BuildingDateYear = _iUserBuildignModel.BuildingYear ,
                    BuildingImageTokenID = _iUserBuildignModel.ImageTokenId
                };




                return View ( _iDevelomentNew1ViewModel );

            }
            catch ( Exception )
            {

                throw;
            }










        }




        #endregion







        #region Page2_New


        //[HttpGet ( "{id}" )]
        [HttpGet]
        public async Task<IActionResult> Page2_New ( )
        {
            string id = Request.Query[ "bldtknid" ].ToString ( );






            // string id = HttpContext.Request.RouteValues[ "bldtknid" ].ToString ( );


            List<BsrvemcoUserBuildingInformationList>? _arrCheckCountUserBuildingInfomationList = _dbContext.BsrvemcoUserBuildingInformationLists
            .Where ( u =>
            u.BuildingTokenId == id
            && u.ApptableTokenId == "1689022008239" )
             //.Select (u  )
             //.FirstOrDefault ( ); // This is what actually executes the request and return a response
             .ToList ( ); // This is what actually executes the request and return a response



            if ( _arrCheckCountUserBuildingInfomationList.Count == 0 )
            {

                List<BsrvemcoAppBuildingInformationList>? _arrAppDevelomentInfomationList = _dbContext.BsrvemcoAppBuildingInformationLists
                     //.Where ( u => u.BuildingTokenId == id )
                     //.Select (u  )
                     //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                     .ToList ( ); // This is what actually executes the request and return a response


                ArrayList _arrTokenList = new ArrayList ( );
                _arrTokenList = AppUtility_ListTokenIDManager.ListTokenID_Generate_NewList ( _arrAppDevelomentInfomationList.Count.ToString ( ) );



                ////////////////////////////////////////

                BsrvemcoUserBuildingInformationList iBuildingModel;

                for ( int i = 0 ; i < _arrAppDevelomentInfomationList.Count ; i++ )
                {


                    iBuildingModel = new BsrvemcoUserBuildingInformationList ( )
                    {

                        RowViewTokenId = new Guid ( ) ,



                        OwnerUserTokenId = Program.iOwnerModel.OwnerUserTokenID ,
                        CompanyTokenId = Program.iOwnerModel.CompanyTokenID ,
                        BuildingTokenId = id ,

                        ApptableTokenId = _arrAppDevelomentInfomationList[ i ].ApptableTokenId.ToString ( ) ,
                        AppinformationTokenId = _arrAppDevelomentInfomationList[ i ].AppinformationTokenId.ToString ( ) ,
                        InformationTokenId = _arrTokenList[ i ].ToString ( ) ,
                        InformationText = _arrAppDevelomentInfomationList[ i ].InformationText.ToString ( ) ,

                        InformationScore = "5" ,
                        Score = "5" ,
                        ScoreManaged = "5" ,
                        ScoreAdjusted = "5" ,
                        ScoreOriginal = "5" ,


                        UploadDateTimeMilliSec = AppUtility_TimeManager.Time_GetCurrentTimeInMilliSecond ( ) ,
                        IsVisible = true ,
                        IsActive = true ,

                    };


                    await _dbContext.BsrvemcoUserBuildingInformationLists.AddAsync ( iBuildingModel );


                    await _dbContext.SaveChangesAsync ( );


                }


            }






































            List<BsrvemcoUserBuildingInformationList>? _arrUserBuildingInfomationList = _dbContext.BsrvemcoUserBuildingInformationLists
                .Where ( u =>
                u.BuildingTokenId == id
                && u.ApptableTokenId == "1689022008239" )
                 //.Select (u  )
                 //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                 .ToList ( ); // This is what actually executes the request and return a response







            AppDevelomentNew2ViewModel iDevelomentNew2ViewModel = new AppDevelomentNew2ViewModel ( );
            List<AppUserBuildingInformationModelManager> _arrBuildingInformationModelList = new List<AppUserBuildingInformationModelManager> ( );


            AppUserBuildingInformationModelManager _iUserBuildingInformationModel;
            for ( int i = 0 ; i < _arrUserBuildingInfomationList.Count ; i++ )
            {
                _iUserBuildingInformationModel = new AppUserBuildingInformationModelManager ( )
                {
                    APPInformationTokenID = _arrUserBuildingInfomationList[ i ].AppinformationTokenId.ToString ( ) ,
                    InformationText = _arrUserBuildingInfomationList[ i ].InformationText.ToString ( ) ,
                    InformationTokenID = _arrUserBuildingInfomationList[ i ].InformationTokenId.ToString ( ) ,
                    InformationScore = "5" ,
                    InformationScoreAdjusted = "5" ,
                    DocumentCount = "0"
                };

                _arrBuildingInformationModelList.Add ( _iUserBuildingInformationModel );
            }






            iDevelomentNew2ViewModel.BuildingInformationList = _arrBuildingInformationModelList;






            //string id = "0";
            //string state = "0";




            //////var _id = id;

            //////if ( _id == null )
            //////{

            //////    return View ( );

            //////}


            return View ( iDevelomentNew2ViewModel );
        }





        [HttpPost]
        public IActionResult Page2_New ( AppDevelomentNew2ViewModel iDevelomentNew2ViewModel )
        {



            try
            {
                string id = Request.Query[ "bldtknid" ].ToString ( );

                return RedirectToAction (
                    "Message" ,
                    "Development" ,
                    new { area = "iWebMember" , bldtknid = id , state = "new" } );



                //  return View ( );

            }
            catch ( Exception )
            {

                throw;
            }






        }




        #endregion


        #region Page2_Edit





        [HttpGet]
        public IActionResult Page2_Edit ( )
        {

            try
            {

                string id = Request.Query[ "bldtknid" ].ToString ( );



                List<BsrvemcoUserBuildingInformationList>? _arrUserBuildingInfomationList = _dbContext.BsrvemcoUserBuildingInformationLists
                    .Where ( u =>
                    u.BuildingTokenId == id
                    && u.ApptableTokenId == "1689022008239" )
                     //.Select (u  )
                     //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                     .ToList ( ); // This is what actually executes the request and return a response







                AppDevelomentEdit2ViewModel iDevelomenEdit2ViewModel = new AppDevelomentEdit2ViewModel ( );
                List<AppUserBuildingInformationModelManager> _arrBuildingInformationModelList = new List<AppUserBuildingInformationModelManager> ( );


                AppUserBuildingInformationModelManager _iUserBuildingInformationModel;
                for ( int i = 0 ; i < _arrUserBuildingInfomationList.Count ; i++ )
                {
                    _iUserBuildingInformationModel = new AppUserBuildingInformationModelManager ( )
                    {
                        APPInformationTokenID = _arrUserBuildingInfomationList[ i ].AppinformationTokenId.ToString ( ) ,
                        InformationText = _arrUserBuildingInfomationList[ i ].InformationText.ToString ( ) ,
                        InformationTokenID = _arrUserBuildingInfomationList[ i ].InformationTokenId.ToString ( ) ,
                        InformationScore = _arrUserBuildingInfomationList[ i ].InformationScore ,
                        InformationScoreAdjusted = _arrUserBuildingInfomationList[ i ].ScoreAdjusted ,
                        DocumentCount = _arrUserBuildingInfomationList[ i ].DocumentCount
                    };

                    _arrBuildingInformationModelList.Add ( _iUserBuildingInformationModel );
                }






                iDevelomenEdit2ViewModel.BuildingInformationList = _arrBuildingInformationModelList;






                //string id = "0";
                //string state = "0";




                //////var _id = id;

                //////if ( _id == null )
                //////{

                //////    return View ( );

                //////}


                return View ( iDevelomenEdit2ViewModel );




















                //string id = "0";
                //string state = "0";


                //var _iUserBuildignModel = _dbContext.BsrvemcoUserBuildingLists
                //     .Where ( u => u.BuildingTokenId == id )
                //     //.Select (u  )
                //     .FirstOrDefault ( ); // This is what actually executes the request and return a response

                //AppDevelomentEdit2ViewModel _iDevelomentEdit2ViewModel = new AppDevelomentEdit2ViewModel ( )
                //{
                //    //////BuildingName = _iUserBuildignModel.BuildingName ,
                //    //////BuildingAddress = _iUserBuildignModel.BuildingAddress ,
                //    //////BuildingDate = DateTime.Parse ( _iUserBuildignModel.BuildingDate ) ,
                //    //////BuildingImageTokenID = _iUserBuildignModel.ImageTokenId
                //};




                //return View ( _iDevelomentEdit2ViewModel );
            }
            catch ( Exception )
            {

                throw;
            }



            //
            //return View ( );
        }



        [HttpPost]
        public IActionResult Page2_Edit ( AppDevelomentEdit2ViewModel iDevelomentEdit2ViewModel )
        {


            string id = Request.Query[ "bldtknid" ].ToString ( );

            return RedirectToAction (
                "Message" ,
                "Development" ,
                new { area = "iWebMember" , bldtknid = id , state = "new" } );



            // return View ( );
        }




        #endregion



        #region Table1




        [HttpGet]
        public async Task<IActionResult> Table1_Edit ( )
        {

            try
            {
                string id = Request.Query[ "bldtknid" ].ToString ( );

                string state = "0";


                //////var _iUserBuildignModel = _dbContext.BsrvemcoUserBuildingLists
                //////     .Where ( u => u.BuildingTokenId == id )
                //////     //.Select (u  )
                //////     .FirstOrDefault ( ); // This is what actually executes the request and return a response
                ///



                //  List<AppUserBuildingTable1ModelManager> _iRowContentList;



                List<BsrvemcoUserBuildingInformationList>? _arrUserBuildingInfomationList = _dbContext.BsrvemcoUserBuildingInformationLists
                     .Where ( u =>
                     u.ApptableTokenId == "1689022008239" &&
                     u.BuildingTokenId == id )
                     //.Select (u  )
                     //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                     .ToList ( ); // This is what actually executes the request and return a response



                //////List<BsrvemcoAppBuildingInformationList>? _arrBuildingInfomationList = _dbContext.BsrvemcoAppBuildingInformationLists
                //////     .Where ( u => u.ApptableTokenId == "1689022008239" )
                //////     //.Select (u  )
                //////     //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                //////     .ToList ( ); // This is what actually executes the request and return a response





                List<AppUserBuildingTableRowModelManager> _iRowContentList = new List<AppUserBuildingTableRowModelManager> ( );

                for ( int i = 0 ; i < _arrUserBuildingInfomationList.Count ; i++ )
                {
                    _iRowContentList
                  .Add ( new AppUserBuildingTableRowModelManager ( )
                  {
                      _id = i ,

                      AppTableTokenID = _arrUserBuildingInfomationList[ i ].ApptableTokenId ,
                      TableTokenID = _arrUserBuildingInfomationList[ i ].ApptableTokenId ,

                      AppInformationTokenID = _arrUserBuildingInfomationList[ i ].AppinformationTokenId ,
                      InformationTokenID = _arrUserBuildingInfomationList[ i ].InformationTokenId ,

                      CompanyTokenID = Program.iOwnerModel.CompanyTokenID ,
                      BuildingTokenID = id ,

                      ColumnDescription = _arrUserBuildingInfomationList[ i ].InformationText , //"Fire Strategy" ,
                      ColumnCommentary = _arrUserBuildingInfomationList[ i ].Commentary ,
                      ColumnCriterion = "0" ,


                      ColumnScore = _arrUserBuildingInfomationList[ i ].Score ,
                      ColumnScoreOriginal = _arrUserBuildingInfomationList[ i ].ScoreOriginal ,
                      ColumnScoreManaged = _arrUserBuildingInfomationList[ i ].ScoreManaged ,
                      ColumnScoreAdjused = _arrUserBuildingInfomationList[ i ].ScoreAdjusted ,
                      ColumnRiskControlMeasure = _arrUserBuildingInfomationList[ i ].RiskControlMeasure ,
                      ColumnTotal = "0" ,






                      //ColumnScore = "5" ,
                      //ColumnScoreOriginal = "5" ,
                      //ColumnScoreManaged = "5" ,
                      //ColumnScoreAdjused = "5" ,
                      //ColumnRiskControlMeasure = "" ,
                      //ColumnTotal = "5" ,

                      ColumnCriterionList = await AppBuildingInformationCriterionManager.getCriterionList ( _dbContext , _arrUserBuildingInfomationList[ i ].AppinformationTokenId! )

                  } );
                }




                //////_iRowContentList
                //////    .Add ( new AppUserBuildingTable1RowModelManager ( )
                //////    {
                //////        AppTableTokenID = "X1AppTableTokenID" ,
                //////        TableTokenID = "X1TableTokenID" ,

                //////        AppInformationTokenID = "X1AppInformationTokenID" ,
                //////        InformationTokenID = "X1InformationTokenID" ,

                //////        CompanyTokenID = "X1CompanyTokenID" ,
                //////        BuildingTokenID = "X1BuildingTokenID" ,

                //////        ColumnDescription = "Fire Strategy" ,
                //////        ColumnCommentary = "X1ColumnCommentary" ,
                //////        ColumnCriterion = "X1ColumnCriterion" ,

                //////        ColumnScore = "5" ,
                //////        ColumnScoreOriginal = "5" ,
                //////        ColumnScoreManaged = "5" ,
                //////        ColumnScoreAdjused = "5" ,
                //////        ColumnRiskControlMeasure = "X1ColumnRiskControlMeasure" ,
                //////        ColumnTotal = "5" ,

                //////        ColumnCriterionList = getCriterionList ( )

                //////    } );


                //////_iRowContentList
                //////    .Add ( new AppUserBuildingTable1RowModelManager ( )
                //////    {
                //////        AppTableTokenID = "X2AppTableTokenID" ,
                //////        TableTokenID = "X2TableTokenID" ,

                //////        AppInformationTokenID = "X2AppInformationTokenID" ,
                //////        InformationTokenID = "X2InformationTokenID" ,

                //////        CompanyTokenID = "X2CompanyTokenID" ,
                //////        BuildingTokenID = "X2BuildingTokenID" ,

                //////        ColumnDescription = "Up-to-date Fire risk Assessment (FRA)" ,
                //////        ColumnCommentary = "X2ColumnCommentary" ,
                //////        ColumnCriterion = "X2ColumnCriterion" ,

                //////        ColumnScore = "3" ,
                //////        ColumnScoreOriginal = "3" ,
                //////        ColumnScoreManaged = "3" ,
                //////        ColumnScoreAdjused = "3" ,
                //////        ColumnRiskControlMeasure = "X2ColumnRiskControlMeasure" ,
                //////        ColumnTotal = "3" ,

                //////        ColumnCriterionList = getCriterionList2 ( )

                //////    } );









                AppDevelomentTable1EditViewModel _iDevelomentTable1EditModel = new AppDevelomentTable1EditViewModel ( )
                {
                    TableTitle = "TableTitle" ,
                    TableDescription = "TableDescription" ,

                    ColumnDescription = "Description" ,
                    ColumnCommentary = "Commentary" ,
                    ColumnCriterion = "Criterion" ,
                    ColumnScore = "Score" ,
                    ColumnScoreOriginal = "ScoreOriginal" ,
                    ColumnScoreManaged = "Score" ,
                    ColumnScoreAdjused = "Adjusted Score" ,
                    //ColumnRiskControlMeasure = "Risk Control Measure Risk Control Measure" ,
                    ColumnRiskControlMeasure = "Risk Control Measure" ,
                    //ColumnScoreTotal = "333" ,
                    ColumnScoreTotal = _dbContext.BsrvemcoUserBuildingInformationLists
                    .Where (
                        c =>
                        c.ApptableTokenId == "1689022008239" &&
                        c.BuildingTokenId == id )
                    .Sum ( clmn => Convert.ToDecimal ( clmn.ScoreAdjusted! ) ).ToString ( "0.0" ) ,

                    RowContentList = _iRowContentList ,
                };





                //////BuildingName = _iUserBuildignModel.BuildingName ,
                //////BuildingAddress = _iUserBuildignModel.BuildingAddress ,
                //////BuildingDate = DateTime.Parse ( _iUserBuildignModel.BuildingDate ) ,
                //////BuildingImageTokenID = _iUserBuildignModel.ImageTokenId




                return View ( _iDevelomentTable1EditModel );
            }
            catch ( Exception ex)
            {

                iAppUtility.AppUtility_DebugManager.Debug_Get_MessageText ( ex.Message );

                return View();
                //    throw;
            }



            //
            //return View ( );
        }



        [HttpPost]
        public IActionResult Table1_Edit ( AppDevelomentEdit2ViewModel iDevelomentEdit2ViewModel , string id , string state )
        {
            return View ( );
        }







        #endregion




        #region Table2




        [HttpGet]
        public async Task<IActionResult> Table2_Edit ( )
        {

            try
            {

                string id = Request.Query[ "bldtknid" ].ToString ( );

                string state = "0";


                //////var _iUserBuildignModel = _dbContext.BsrvemcoUserBuildingLists
                //////     .Where ( u => u.BuildingTokenId == id )
                //////     //.Select (u  )
                //////     .FirstOrDefault ( ); // This is what actually executes the request and return a response
                ///



                //  List<AppUserBuildingTable1ModelManager> _iRowContentList;



                List<BsrvemcoUserBuildingInformationList>? _arrUserBuildingInfomationList = _dbContext.BsrvemcoUserBuildingInformationLists
                     .Where ( u =>
                     u.ApptableTokenId == "1689162197100" &&
                     u.BuildingTokenId == id )
                     //.Select (u  )
                     //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                     .ToList ( ); // This is what actually executes the request and return a response


                //////List<BsrvemcoAppBuildingInformationList>? _arrBuildingInfomationList = _dbContext.BsrvemcoAppBuildingInformationLists
                //////     .Where ( u => u.ApptableTokenId == "1689162197100" )
                //////     //.Select (u  )
                //////     //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                //////     .ToList ( ); // This is what actually executes the request and return a response





                List<AppUserBuildingTableRowModelManager> _iRowContentList = new List<AppUserBuildingTableRowModelManager> ( );

                for ( int i = 0 ; i < _arrUserBuildingInfomationList.Count ; i++ )
                {
                    _iRowContentList
                  .Add ( new AppUserBuildingTableRowModelManager ( )
                  {

                      _id = i ,

                      AppTableTokenID = _arrUserBuildingInfomationList[ i ].ApptableTokenId ,
                      TableTokenID = _arrUserBuildingInfomationList[ i ].ApptableTokenId ,

                      AppInformationTokenID = _arrUserBuildingInfomationList[ i ].AppinformationTokenId ,
                      InformationTokenID = _arrUserBuildingInfomationList[ i ].InformationTokenId ,

                      CompanyTokenID = Program.iOwnerModel.CompanyTokenID ,
                      BuildingTokenID = id ,

                      ColumnDescription = _arrUserBuildingInfomationList[ i ].InformationText , //"Fire Strategy" ,
                      ColumnCommentary = _arrUserBuildingInfomationList[ i ].Commentary ,
                      ColumnCriterion = "0" ,






















                      //AppTableTokenID = "X1AppTableTokenID" ,
                      //TableTokenID = "X1TableTokenID" ,

                      //AppInformationTokenID = "X1AppInformationTokenID" ,
                      //InformationTokenID = "X1InformationTokenID" ,

                      //CompanyTokenID = "X1CompanyTokenID" ,
                      //BuildingTokenID = "X1BuildingTokenID" ,

                      //ColumnDescription = _arrBuildingInfomationList[ i ].InformationText , //"Fire Strategy" ,
                      //ColumnCommentary = _arrBuildingInfomationList[ i ].Commentary ,
                      //ColumnCriterion = "0" ,





                      ColumnScore = _arrUserBuildingInfomationList[ i ].Score ,
                      ColumnScoreOriginal = _arrUserBuildingInfomationList[ i ].ScoreOriginal ,
                      ColumnScoreManaged = _arrUserBuildingInfomationList[ i ].ScoreManaged ,
                      ColumnScoreAdjused = _arrUserBuildingInfomationList[ i ].ScoreAdjusted ,
                      ColumnRiskControlMeasure = _arrUserBuildingInfomationList[ i ].RiskControlMeasure ,
                      ColumnTotal = "0" ,






                      //ColumnScore = "5" ,
                      //ColumnScoreOriginal = "5" ,
                      //ColumnScoreManaged = "5" ,
                      //ColumnScoreAdjused = "5" ,
                      //ColumnRiskControlMeasure = "" ,
                      //ColumnTotal = "5" ,

                      ColumnCriterionList = await AppBuildingInformationCriterionManager.getCriterionList ( _dbContext , _arrUserBuildingInfomationList[ i ].AppinformationTokenId! )

                  } );
                }




                //////_iRowContentList
                //////    .Add ( new AppUserBuildingTable1RowModelManager ( )
                //////    {
                //////        AppTableTokenID = "X1AppTableTokenID" ,
                //////        TableTokenID = "X1TableTokenID" ,

                //////        AppInformationTokenID = "X1AppInformationTokenID" ,
                //////        InformationTokenID = "X1InformationTokenID" ,

                //////        CompanyTokenID = "X1CompanyTokenID" ,
                //////        BuildingTokenID = "X1BuildingTokenID" ,

                //////        ColumnDescription = "Fire Strategy" ,
                //////        ColumnCommentary = "X1ColumnCommentary" ,
                //////        ColumnCriterion = "X1ColumnCriterion" ,

                //////        ColumnScore = "5" ,
                //////        ColumnScoreOriginal = "5" ,
                //////        ColumnScoreManaged = "5" ,
                //////        ColumnScoreAdjused = "5" ,
                //////        ColumnRiskControlMeasure = "X1ColumnRiskControlMeasure" ,
                //////        ColumnTotal = "5" ,

                //////        ColumnCriterionList = getCriterionList ( )

                //////    } );


                //////_iRowContentList
                //////    .Add ( new AppUserBuildingTable1RowModelManager ( )
                //////    {
                //////        AppTableTokenID = "X2AppTableTokenID" ,
                //////        TableTokenID = "X2TableTokenID" ,

                //////        AppInformationTokenID = "X2AppInformationTokenID" ,
                //////        InformationTokenID = "X2InformationTokenID" ,

                //////        CompanyTokenID = "X2CompanyTokenID" ,
                //////        BuildingTokenID = "X2BuildingTokenID" ,

                //////        ColumnDescription = "Up-to-date Fire risk Assessment (FRA)" ,
                //////        ColumnCommentary = "X2ColumnCommentary" ,
                //////        ColumnCriterion = "X2ColumnCriterion" ,

                //////        ColumnScore = "3" ,
                //////        ColumnScoreOriginal = "3" ,
                //////        ColumnScoreManaged = "3" ,
                //////        ColumnScoreAdjused = "3" ,
                //////        ColumnRiskControlMeasure = "X2ColumnRiskControlMeasure" ,
                //////        ColumnTotal = "3" ,

                //////        ColumnCriterionList = getCriterionList2 ( )

                //////    } );









                AppDevelomentTable1EditViewModel _iDevelomentTable1EditModel = new AppDevelomentTable1EditViewModel ( )
                {
                    TableTitle = "TableTitle" ,
                    TableDescription = "TableDescription" ,

                    ColumnDescription = "Description" ,
                    ColumnCommentary = "Commentary" ,
                    ColumnCriterion = "Criterion" ,
                    ColumnScore = "Score" ,
                    ColumnScoreOriginal = "ScoreOriginal" ,
                    ColumnScoreManaged = "Score" ,
                    ColumnScoreAdjused = "Adjusted Score" ,
                    //ColumnRiskControlMeasure = "Risk Control Measure Risk Control Measure" ,
                    ColumnRiskControlMeasure = "Risk Control Measure" ,

                    //ColumnScoreTotal = "333" ,
                    ColumnScoreTotal = _dbContext.BsrvemcoUserBuildingInformationLists
                    .Where (
                        c =>
                        c.ApptableTokenId == "1689162197100" &&
                        c.BuildingTokenId == id )
                    .Sum ( clmn => Convert.ToDecimal ( clmn.ScoreAdjusted! ) ).ToString ( "0.0" ) ,



                    RowContentList = _iRowContentList ,
                };





                //////BuildingName = _iUserBuildignModel.BuildingName ,
                //////BuildingAddress = _iUserBuildignModel.BuildingAddress ,
                //////BuildingDate = DateTime.Parse ( _iUserBuildignModel.BuildingDate ) ,
                //////BuildingImageTokenID = _iUserBuildignModel.ImageTokenId




                return View ( _iDevelomentTable1EditModel );
            }
            catch ( Exception )
            {

                throw;
            }



            //
            //return View ( );
        }



        [HttpPost]
        public IActionResult Table2_Edit ( AppDevelomentEdit2ViewModel iDevelomentEdit2ViewModel , string id , string state )
        {
            return View ( );
        }







        #endregion




        #region Table3




        [HttpGet]
        public async Task<IActionResult> Table3_Edit ( )
        {

            try
            {

                string id = Request.Query[ "bldtknid" ].ToString ( );

                string state = "0";


                //////var _iUserBuildignModel = _dbContext.BsrvemcoUserBuildingLists
                //////     .Where ( u => u.BuildingTokenId == id )
                //////     //.Select (u  )
                //////     .FirstOrDefault ( ); // This is what actually executes the request and return a response
                ///



                //  List<AppUserBuildingTable1ModelManager> _iRowContentList;



                List<BsrvemcoUserBuildingInformationList>? _arrUserBuildingInfomationList = _dbContext.BsrvemcoUserBuildingInformationLists
                     .Where ( u =>
                     u.ApptableTokenId == "1689162201957" &&
                     u.BuildingTokenId == id )
                     //.Select (u  )
                     //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                     .ToList ( ); // This is what actually executes the request and return a response


                //////List<BsrvemcoAppBuildingInformationList>? _arrBuildingInfomationList = _dbContext.BsrvemcoAppBuildingInformationLists
                //////     .Where ( u => u.ApptableTokenId == "1689162201957" )
                //////     //.Select (u  )
                //////     //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                //////     .ToList ( ); // This is what actually executes the request and return a response





                List<AppUserBuildingTableRowModelManager> _iRowContentList = new List<AppUserBuildingTableRowModelManager> ( );

                for ( int i = 0 ; i < _arrUserBuildingInfomationList.Count ; i++ )
                {
                    _iRowContentList
                  .Add ( new AppUserBuildingTableRowModelManager ( )
                  {

                      _id = i ,

                      AppTableTokenID = _arrUserBuildingInfomationList[ i ].ApptableTokenId ,
                      TableTokenID = _arrUserBuildingInfomationList[ i ].ApptableTokenId ,

                      AppInformationTokenID = _arrUserBuildingInfomationList[ i ].AppinformationTokenId ,
                      InformationTokenID = _arrUserBuildingInfomationList[ i ].InformationTokenId ,

                      CompanyTokenID = Program.iOwnerModel.CompanyTokenID ,
                      BuildingTokenID = id ,

                      ColumnDescription = _arrUserBuildingInfomationList[ i ].InformationText , //"Fire Strategy" ,
                      ColumnCommentary = _arrUserBuildingInfomationList[ i ].Commentary ,
                      ColumnCriterion = "0" ,
















                      //AppTableTokenID = "X1AppTableTokenID" ,
                      //TableTokenID = "X1TableTokenID" ,

                      //AppInformationTokenID = "X1AppInformationTokenID" ,
                      //InformationTokenID = "X1InformationTokenID" ,

                      //CompanyTokenID = "X1CompanyTokenID" ,
                      //BuildingTokenID = "X1BuildingTokenID" ,

                      //ColumnDescription = _arrBuildingInfomationList[ i ].InformationText , //"Fire Strategy" ,
                      //ColumnCommentary = _arrBuildingInfomationList[ i ].Commentary ,
                      //ColumnCriterion = "0" ,

                      ColumnScore = _arrUserBuildingInfomationList[ i ].Score ,
                      ColumnScoreOriginal = _arrUserBuildingInfomationList[ i ].ScoreOriginal ,
                      ColumnScoreManaged = _arrUserBuildingInfomationList[ i ].ScoreManaged ,
                      ColumnScoreAdjused = _arrUserBuildingInfomationList[ i ].ScoreAdjusted ,
                      ColumnRiskControlMeasure = _arrUserBuildingInfomationList[ i ].RiskControlMeasure ,
                      ColumnTotal = "0" ,




                      //ColumnScore = "5" ,
                      //ColumnScoreOriginal = "5" ,
                      //ColumnScoreManaged = "5" ,
                      //ColumnScoreAdjused = "5" ,
                      //ColumnRiskControlMeasure = "" ,
                      //ColumnTotal = "5" ,

                      ColumnCriterionList = await AppBuildingInformationCriterionManager.getCriterionList ( _dbContext , _arrUserBuildingInfomationList[ i ].AppinformationTokenId! )

                  } );
                }




                //////_iRowContentList
                //////    .Add ( new AppUserBuildingTable1RowModelManager ( )
                //////    {
                //////        AppTableTokenID = "X1AppTableTokenID" ,
                //////        TableTokenID = "X1TableTokenID" ,

                //////        AppInformationTokenID = "X1AppInformationTokenID" ,
                //////        InformationTokenID = "X1InformationTokenID" ,

                //////        CompanyTokenID = "X1CompanyTokenID" ,
                //////        BuildingTokenID = "X1BuildingTokenID" ,

                //////        ColumnDescription = "Fire Strategy" ,
                //////        ColumnCommentary = "X1ColumnCommentary" ,
                //////        ColumnCriterion = "X1ColumnCriterion" ,

                //////        ColumnScore = "5" ,
                //////        ColumnScoreOriginal = "5" ,
                //////        ColumnScoreManaged = "5" ,
                //////        ColumnScoreAdjused = "5" ,
                //////        ColumnRiskControlMeasure = "X1ColumnRiskControlMeasure" ,
                //////        ColumnTotal = "5" ,

                //////        ColumnCriterionList = getCriterionList ( )

                //////    } );


                //////_iRowContentList
                //////    .Add ( new AppUserBuildingTable1RowModelManager ( )
                //////    {
                //////        AppTableTokenID = "X2AppTableTokenID" ,
                //////        TableTokenID = "X2TableTokenID" ,

                //////        AppInformationTokenID = "X2AppInformationTokenID" ,
                //////        InformationTokenID = "X2InformationTokenID" ,

                //////        CompanyTokenID = "X2CompanyTokenID" ,
                //////        BuildingTokenID = "X2BuildingTokenID" ,

                //////        ColumnDescription = "Up-to-date Fire risk Assessment (FRA)" ,
                //////        ColumnCommentary = "X2ColumnCommentary" ,
                //////        ColumnCriterion = "X2ColumnCriterion" ,

                //////        ColumnScore = "3" ,
                //////        ColumnScoreOriginal = "3" ,
                //////        ColumnScoreManaged = "3" ,
                //////        ColumnScoreAdjused = "3" ,
                //////        ColumnRiskControlMeasure = "X2ColumnRiskControlMeasure" ,
                //////        ColumnTotal = "3" ,

                //////        ColumnCriterionList = getCriterionList2 ( )

                //////    } );









                AppDevelomentTable1EditViewModel _iDevelomentTable1EditModel = new AppDevelomentTable1EditViewModel ( )
                {
                    TableTitle = "TableTitle" ,
                    TableDescription = "TableDescription" ,

                    ColumnDescription = "Description" ,
                    ColumnCommentary = "Commentary" ,
                    ColumnCriterion = "Criterion" ,
                    ColumnScore = "Score" ,
                    ColumnScoreOriginal = "ScoreOriginal" ,
                    ColumnScoreManaged = "Score" ,
                    ColumnScoreAdjused = "Adjusted Score" ,
                    //ColumnRiskControlMeasure = "Risk Control Measure Risk Control Measure" ,
                    ColumnRiskControlMeasure = "Risk Control Measure" ,

                    //ColumnScoreTotal = "333" ,
                    ColumnScoreTotal = _dbContext.BsrvemcoUserBuildingInformationLists
                    .Where (
                        c =>
                        c.ApptableTokenId == "1689162201957" &&
                        c.BuildingTokenId == id )
                    .Sum ( clmn => Convert.ToDecimal ( clmn.ScoreAdjusted! ) ).ToString ( "0.0" ) ,


                    RowContentList = _iRowContentList ,
                };





                //////BuildingName = _iUserBuildignModel.BuildingName ,
                //////BuildingAddress = _iUserBuildignModel.BuildingAddress ,
                //////BuildingDate = DateTime.Parse ( _iUserBuildignModel.BuildingDate ) ,
                //////BuildingImageTokenID = _iUserBuildignModel.ImageTokenId




                return View ( _iDevelomentTable1EditModel );
            }
            catch ( Exception )
            {

                throw;
            }



            //
            //return View ( );
        }



        [HttpPost]
        public IActionResult Table3_Edit ( AppDevelomentEdit2ViewModel iDevelomentEdit2ViewModel , string id , string state )
        {
            return View ( );
        }







        #endregion




        #region Table4




        [HttpGet]
        public async Task<IActionResult> Table4_Edit ( )
        {

            try
            {
                string id = Request.Query[ "bldtknid" ].ToString ( );

                string state = "0";


                //////var _iUserBuildignModel = _dbContext.BsrvemcoUserBuildingLists
                //////     .Where ( u => u.BuildingTokenId == id )
                //////     //.Select (u  )
                //////     .FirstOrDefault ( ); // This is what actually executes the request and return a response
                ///



                //  List<AppUserBuildingTable1ModelManager> _iRowContentList;



                List<BsrvemcoUserBuildingInformationList>? _arrUserBuildingInfomationList = _dbContext.BsrvemcoUserBuildingInformationLists
                     .Where ( u =>
                     u.ApptableTokenId == "1689162207917" &&
                     u.BuildingTokenId == id )
                     //.Select (u  )
                     //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                     .ToList ( ); // This is what actually executes the request and return a response

                //////List<BsrvemcoAppBuildingInformationList>? _arrBuildingInfomationList = _dbContext.BsrvemcoAppBuildingInformationLists
                //////    .Where ( u => u.ApptableTokenId == "1689162207917" )
                //////    //.Select (u  )
                //////    //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                //////    .ToList ( ); // This is what actually executes the request and return a response





                List<AppUserBuildingTableRowModelManager> _iRowContentList = new List<AppUserBuildingTableRowModelManager> ( );

                for ( int i = 0 ; i < _arrUserBuildingInfomationList.Count ; i++ )
                {
                    _iRowContentList
                  .Add ( new AppUserBuildingTableRowModelManager ( )
                  {

                      _id = i ,

                      AppTableTokenID = _arrUserBuildingInfomationList[ i ].ApptableTokenId ,
                      TableTokenID = _arrUserBuildingInfomationList[ i ].ApptableTokenId ,

                      AppInformationTokenID = _arrUserBuildingInfomationList[ i ].AppinformationTokenId ,
                      InformationTokenID = _arrUserBuildingInfomationList[ i ].InformationTokenId ,

                      CompanyTokenID = Program.iOwnerModel.CompanyTokenID ,
                      BuildingTokenID = id ,

                      ColumnDescription = _arrUserBuildingInfomationList[ i ].InformationText , //"Fire Strategy" ,
                      ColumnCommentary = _arrUserBuildingInfomationList[ i ].Commentary ,
                      ColumnCriterion = "0" ,









                      //AppTableTokenID = "X1AppTableTokenID" ,
                      //TableTokenID = "X1TableTokenID" ,

                      //AppInformationTokenID = "X1AppInformationTokenID" ,
                      //InformationTokenID = "X1InformationTokenID" ,

                      //CompanyTokenID = "X1CompanyTokenID" ,
                      //BuildingTokenID = "X1BuildingTokenID" ,

                      //ColumnDescription = _arrBuildingInfomationList[ i ].InformationText , //"Fire Strategy" ,
                      //ColumnCommentary = _arrBuildingInfomationList[ i ].Commentary ,
                      //ColumnCriterion = "0" ,

                      ColumnScore = _arrUserBuildingInfomationList[ i ].Score ,
                      ColumnScoreOriginal = _arrUserBuildingInfomationList[ i ].ScoreOriginal ,
                      ColumnScoreManaged = _arrUserBuildingInfomationList[ i ].ScoreManaged ,
                      ColumnScoreAdjused = _arrUserBuildingInfomationList[ i ].ScoreAdjusted ,
                      ColumnRiskControlMeasure = _arrUserBuildingInfomationList[ i ].RiskControlMeasure ,
                      ColumnTotal = "0" ,


                      //ColumnScore = "5" ,
                      //ColumnScoreOriginal = "5" ,
                      //ColumnScoreManaged = "5" ,
                      //ColumnScoreAdjused = "5" ,
                      //ColumnRiskControlMeasure = "" ,
                      //ColumnTotal = "5" ,



                      ColumnCriterionList = await AppBuildingInformationCriterionManager.getCriterionList ( _dbContext , _arrUserBuildingInfomationList[ i ].AppinformationTokenId! )

                  } );
                }




                //////_iRowContentList
                //////    .Add ( new AppUserBuildingTable1RowModelManager ( )
                //////    {
                //////        AppTableTokenID = "X1AppTableTokenID" ,
                //////        TableTokenID = "X1TableTokenID" ,

                //////        AppInformationTokenID = "X1AppInformationTokenID" ,
                //////        InformationTokenID = "X1InformationTokenID" ,

                //////        CompanyTokenID = "X1CompanyTokenID" ,
                //////        BuildingTokenID = "X1BuildingTokenID" ,

                //////        ColumnDescription = "Fire Strategy" ,
                //////        ColumnCommentary = "X1ColumnCommentary" ,
                //////        ColumnCriterion = "X1ColumnCriterion" ,

                //////        ColumnScore = "5" ,
                //////        ColumnScoreOriginal = "5" ,
                //////        ColumnScoreManaged = "5" ,
                //////        ColumnScoreAdjused = "5" ,
                //////        ColumnRiskControlMeasure = "X1ColumnRiskControlMeasure" ,
                //////        ColumnTotal = "5" ,

                //////        ColumnCriterionList = getCriterionList ( )

                //////    } );


                //////_iRowContentList
                //////    .Add ( new AppUserBuildingTable1RowModelManager ( )
                //////    {
                //////        AppTableTokenID = "X2AppTableTokenID" ,
                //////        TableTokenID = "X2TableTokenID" ,

                //////        AppInformationTokenID = "X2AppInformationTokenID" ,
                //////        InformationTokenID = "X2InformationTokenID" ,

                //////        CompanyTokenID = "X2CompanyTokenID" ,
                //////        BuildingTokenID = "X2BuildingTokenID" ,

                //////        ColumnDescription = "Up-to-date Fire risk Assessment (FRA)" ,
                //////        ColumnCommentary = "X2ColumnCommentary" ,
                //////        ColumnCriterion = "X2ColumnCriterion" ,

                //////        ColumnScore = "3" ,
                //////        ColumnScoreOriginal = "3" ,
                //////        ColumnScoreManaged = "3" ,
                //////        ColumnScoreAdjused = "3" ,
                //////        ColumnRiskControlMeasure = "X2ColumnRiskControlMeasure" ,
                //////        ColumnTotal = "3" ,

                //////        ColumnCriterionList = getCriterionList2 ( )

                //////    } );









                AppDevelomentTable1EditViewModel _iDevelomentTable1EditModel = new AppDevelomentTable1EditViewModel ( )
                {
                    TableTitle = "TableTitle" ,
                    TableDescription = "TableDescription" ,

                    ColumnDescription = "Description" ,
                    ColumnCommentary = "Commentary" ,
                    ColumnCriterion = "Criterion" ,
                    ColumnScore = "Score" ,
                    ColumnScoreOriginal = "ScoreOriginal" ,
                    ColumnScoreManaged = "Score" ,
                    ColumnScoreAdjused = "Adjusted Score" ,
                    //ColumnRiskControlMeasure = "Risk Control Measure Risk Control Measure" ,
                    ColumnRiskControlMeasure = "Risk Control Measure" ,
                    //ColumnScoreAverage = "2.5" ,
                    ColumnScoreTotal = "0" ,



                    ColumnScoreAverage = _dbContext.BsrvemcoUserBuildingInformationLists
                    .Where (
                        c =>
                        c.ApptableTokenId == "1689162207917" &&
                        c.BuildingTokenId == id )
                    .Average ( clmn => Convert.ToDouble ( clmn.ScoreAdjusted! ) ).ToString ( "0.0" ) ,



                    RowContentList = _iRowContentList ,
                };





                //////BuildingName = _iUserBuildignModel.BuildingName ,
                //////BuildingAddress = _iUserBuildignModel.BuildingAddress ,
                //////BuildingDate = DateTime.Parse ( _iUserBuildignModel.BuildingDate ) ,
                //////BuildingImageTokenID = _iUserBuildignModel.ImageTokenId




                return View ( _iDevelomentTable1EditModel );
            }
            catch ( Exception )
            {

                throw;
            }



            //
            //return View ( );
        }



        [HttpPost]
        public IActionResult Table4_Edit ( AppDevelomentEdit2ViewModel iDevelomentEdit2ViewModel , string id , string state )
        {
            return View ( );
        }







        #endregion



        #region Diagram





        [HttpGet]
        public async Task<IActionResult> Diagram ( )
        {

            try
            {
                string id = Request.Query[ "bldtknid" ].ToString ( );
             
                string PointXText = Request.Query[ "px" ].ToString ( );
               
                string PointYText = Request.Query[ "py" ].ToString ( );

                AppPointModelManager _iPointModel = new AppPointModelManager ( );

                //AppUserBuildingStatisticModelManager _iUserBuildingStatisticModel = new AppUserBuildingStatisticModelManager ( );


                //_iUserBuildingStatisticModel = await AppBuildingManager.Building_Get_BuildingStatisticModel_ByBuildingTokenID (
                //    _dbContext ,
                //id );

                // ( Value * 60 ) + 2
                _iPointModel.PointX = ( ( Double.Parse ( PointXText ) * 60 ) + 0 ).ToString ( ); //"152.0";
                _iPointModel.PointY = ( ( Double.Parse ( PointYText ) * 60 ) + 0 ).ToString ( ); ;

                //////_iPointModel.PointX ="3.0";
                //////_iPointModel.PointY = "3.0";


                // ( Value * 50 )    >>> 46.6 unit
                _iPointModel.PointXSpan = ( ( Double.Parse ( PointXText ) * 50 ) ).ToString ( );

                // ( Value * 45 )   >>>  53.3  unit
                _iPointModel.PointYSpan = ( ( Double.Parse ( PointYText ) * 45 ) ).ToString ( );

                ///////////////////////////////////////////////////////////////////



                ////////////// ( Value * 60 ) + 2
                ////////////_iPointModel.PointX = "122.0";
                ////////////_iPointModel.PointY = "122.0";

                //////////////////_iPointModel.PointX ="3.0";
                //////////////////_iPointModel.PointY = "3.0";


                ////////////// ( Value * 50 )    >>> 46.6 unit
                ////////////_iPointModel.PointXSpan = "100";

                ////////////// ( Value * 45 )   >>>  53.3  unit
                ////////////_iPointModel.PointYSpan = "90";







                ///////////////////////////////////////////////////////////////////





                ////////_iPointModel.PointX = "182.0";
                //////// _iPointModel.PointY = "182.0";

                //////// //////_iPointModel.PointX ="3.0";
                //////// //////_iPointModel.PointY = "3.0";



                //////// _iPointModel.PointXSpan = "140.0";
                //////// _iPointModel.PointYSpan = "160.0";



                _iPointModel.PointXText = PointXText;
                _iPointModel.PointYText = PointYText;


                return View ( _iPointModel );
            }
            catch ( Exception )
            {

                throw;
            }



            //
            //return View ( );
        }

      
        
      

        [HttpGet]
        public async Task<IActionResult> Diagram_X1 ( )
        {

            try
            {
                string id = Request.Query[ "bldtknid" ].ToString ( );

                AppPointModelManager _iPointModel = new AppPointModelManager ( );

                AppUserBuildingStatisticModelManager _iUserBuildingStatisticModel = new AppUserBuildingStatisticModelManager ( );


                _iUserBuildingStatisticModel = await AppBuildingManager.Building_Get_BuildingStatisticModel_ByBuildingTokenID (
                    _dbContext ,
                id );

                // ( Value * 60 ) + 2
                _iPointModel.PointX = ( ( Double.Parse ( _iUserBuildingStatisticModel.ScoreRiskAverage ) * 60 ) + 0 ).ToString ( ); //"152.0";
                _iPointModel.PointY = ( ( Double.Parse ( _iUserBuildingStatisticModel.Table4ScoreAverage ) * 60 ) + 0 ).ToString ( ); ;

                //////_iPointModel.PointX ="3.0";
                //////_iPointModel.PointY = "3.0";


                // ( Value * 50 )    >>> 46.6 unit
                _iPointModel.PointXSpan = ( ( Double.Parse ( _iUserBuildingStatisticModel.ScoreRiskAverage ) * 50 ) ).ToString ( );

                // ( Value * 45 )   >>>  53.3  unit
                _iPointModel.PointYSpan = ( ( Double.Parse ( _iUserBuildingStatisticModel.Table4ScoreAverage ) * 45 ) ).ToString ( );

                ///////////////////////////////////////////////////////////////////



                ////////////// ( Value * 60 ) + 2
                ////////////_iPointModel.PointX = "122.0";
                ////////////_iPointModel.PointY = "122.0";

                //////////////////_iPointModel.PointX ="3.0";
                //////////////////_iPointModel.PointY = "3.0";


                ////////////// ( Value * 50 )    >>> 46.6 unit
                ////////////_iPointModel.PointXSpan = "100";

                ////////////// ( Value * 45 )   >>>  53.3  unit
                ////////////_iPointModel.PointYSpan = "90";







                ///////////////////////////////////////////////////////////////////





                ////////_iPointModel.PointX = "182.0";
                //////// _iPointModel.PointY = "182.0";

                //////// //////_iPointModel.PointX ="3.0";
                //////// //////_iPointModel.PointY = "3.0";



                //////// _iPointModel.PointXSpan = "140.0";
                //////// _iPointModel.PointYSpan = "160.0";



                _iPointModel.PointXText = _iUserBuildingStatisticModel.ScoreRiskAverage;
                _iPointModel.PointYText = _iUserBuildingStatisticModel.Table4ScoreAverage;




                //string id = "0";
                //string state = "0";


                //////var _iUserBuildignModel = _dbContext.BsrvemcoUserBuildingLists
                //////     .Where ( u => u.BuildingTokenId == id )
                //////     //.Select (u  )
                //////     .FirstOrDefault ( ); // This is what actually executes the request and return a response
                ///



                //  List<AppUserBuildingTable1ModelManager> _iRowContentList;



                //List<BsrvemcoAppBuildingInformationList>? _arrBuildingInfomationList = _dbContext.BsrvemcoAppBuildingInformationLists
                //     .Where ( u => u.ApptableTokenId == "1689162207917" )
                //     //.Select (u  )
                //     //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                //     .ToList ( ); // This is what actually executes the request and return a response





                //List<AppUserBuildingTable1RowModelManager> _iRowContentList = new List<AppUserBuildingTable1RowModelManager> ( );

                //for ( int i = 0 ; i < _arrBuildingInfomationList.Count ; i++ )
                //{
                //    _iRowContentList
                //  .Add ( new AppUserBuildingTable1RowModelManager ( )
                //  {
                //      AppTableTokenID = "X1AppTableTokenID" ,
                //      TableTokenID = "X1TableTokenID" ,

                //      AppInformationTokenID = "X1AppInformationTokenID" ,
                //      InformationTokenID = "X1InformationTokenID" ,

                //      CompanyTokenID = "X1CompanyTokenID" ,
                //      BuildingTokenID = "X1BuildingTokenID" ,

                //      ColumnDescription = _arrBuildingInfomationList[ i ].InformationText , //"Fire Strategy" ,
                //      ColumnCommentary = _arrBuildingInfomationList[ i ].Commentary ,
                //      ColumnCriterion = "0" ,

                //      ColumnScore = "5" ,
                //      ColumnScoreOriginal = "5" ,
                //      ColumnScoreManaged = "5" ,
                //      ColumnScoreAdjused = "5" ,
                //      ColumnRiskControlMeasure = "" ,
                //      ColumnTotal = "5" ,

                //      ColumnCriterionList = await AppBuildingInformationCriterionManager.getCriterionList ( _dbContext , _arrBuildingInfomationList[ i ].AppinformationTokenId! )

                //  } );
                //}




                //////_iRowContentList
                //////    .Add ( new AppUserBuildingTable1RowModelManager ( )
                //////    {
                //////        AppTableTokenID = "X1AppTableTokenID" ,
                //////        TableTokenID = "X1TableTokenID" ,

                //////        AppInformationTokenID = "X1AppInformationTokenID" ,
                //////        InformationTokenID = "X1InformationTokenID" ,

                //////        CompanyTokenID = "X1CompanyTokenID" ,
                //////        BuildingTokenID = "X1BuildingTokenID" ,

                //////        ColumnDescription = "Fire Strategy" ,
                //////        ColumnCommentary = "X1ColumnCommentary" ,
                //////        ColumnCriterion = "X1ColumnCriterion" ,

                //////        ColumnScore = "5" ,
                //////        ColumnScoreOriginal = "5" ,
                //////        ColumnScoreManaged = "5" ,
                //////        ColumnScoreAdjused = "5" ,
                //////        ColumnRiskControlMeasure = "X1ColumnRiskControlMeasure" ,
                //////        ColumnTotal = "5" ,

                //////        ColumnCriterionList = getCriterionList ( )

                //////    } );


                //////_iRowContentList
                //////    .Add ( new AppUserBuildingTable1RowModelManager ( )
                //////    {
                //////        AppTableTokenID = "X2AppTableTokenID" ,
                //////        TableTokenID = "X2TableTokenID" ,

                //////        AppInformationTokenID = "X2AppInformationTokenID" ,
                //////        InformationTokenID = "X2InformationTokenID" ,

                //////        CompanyTokenID = "X2CompanyTokenID" ,
                //////        BuildingTokenID = "X2BuildingTokenID" ,

                //////        ColumnDescription = "Up-to-date Fire risk Assessment (FRA)" ,
                //////        ColumnCommentary = "X2ColumnCommentary" ,
                //////        ColumnCriterion = "X2ColumnCriterion" ,

                //////        ColumnScore = "3" ,
                //////        ColumnScoreOriginal = "3" ,
                //////        ColumnScoreManaged = "3" ,
                //////        ColumnScoreAdjused = "3" ,
                //////        ColumnRiskControlMeasure = "X2ColumnRiskControlMeasure" ,
                //////        ColumnTotal = "3" ,

                //////        ColumnCriterionList = getCriterionList2 ( )

                //////    } );









                //AppDevelomentTable1EditViewModel _iDevelomentTable1EditModel = new AppDevelomentTable1EditViewModel ( )
                //{
                //    TableTitle = "TableTitle" ,
                //    TableDescription = "TableDescription" ,

                //    ColumnDescription = "Description" ,
                //    ColumnCommentary = "Commentary" ,
                //    ColumnCriterion = "Criterion" ,
                //    ColumnScore = "Score" ,
                //    ColumnScoreOriginal = "ScoreOriginal" ,
                //    ColumnScoreManaged = "Score" ,
                //    ColumnScoreAdjused = "Adjusted Score" ,
                //    //ColumnRiskControlMeasure = "Risk Control Measure Risk Control Measure" ,
                //    ColumnRiskControlMeasure = "Risk Control Measure" ,
                //    ColumnScoreAverage = "2.5" ,

                //    RowContentList = _iRowContentList ,
                //};





                //////BuildingName = _iUserBuildignModel.BuildingName ,
                //////BuildingAddress = _iUserBuildignModel.BuildingAddress ,
                //////BuildingDate = DateTime.Parse ( _iUserBuildignModel.BuildingDate ) ,
                //////BuildingImageTokenID = _iUserBuildignModel.ImageTokenId




                return View ( _iPointModel );
            }
            catch ( Exception )
            {

                throw;
            }



            //
            //return View ( );
        }

      
        
        
        
        
        
        
        
        
        
        
        
        [HttpPost]
        // [Microsoft.AspNetCore.Mvc.va.ValidateInput ( false )]
        public IActionResult GetImage ( string divhtml )
        {

            try
            {
                var x = "123";
                var y = "456";

            }
            catch ( Exception )
            {

                throw;
            }

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


        #endregion



        #region List


        //[HttpGet ( "{id}" )]
        [HttpGet]
        public IActionResult List ( )
        {

            //AppDevelomentInfomationViewModel


            List<BsrvemcoUserBuildingList>? _arrDevelomentList = _dbContext.BsrvemcoUserBuildingLists
                 .Where ( u => u.CompanyTokenId == Program.iOwnerModel.CompanyTokenID )
                 //.Select (u  )
                 //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                 .ToList ( ); // This is what actually executes the request and return a response




            //  AppUserBuildingModelManager iDevelomentNew2ViewModel = new AppUserBuildingModelManager ( );
            List<AppUserBuildingModelManager> _arrBuildingList = new List<AppUserBuildingModelManager> ( );


            AppUserBuildingModelManager _iUserBuildingModel;
            for ( int i = 0 ; i < _arrDevelomentList.Count ; i++ )
            {
                _iUserBuildingModel = new AppUserBuildingModelManager ( )
                {
                    BuildingName = _arrDevelomentList[ i ].BuildingName.ToString ( )! ,
                    BuildingTokenID = _arrDevelomentList[ i ].BuildingTokenId.ToString ( )! ,
                    //InformationText = _arrDevelomentInfomationList[ i ].InformationText.ToString ( ) ,

                };

                _arrBuildingList.Add ( _iUserBuildingModel );
            }


            //  iDevelomentNew2ViewModel.BuildingInformationList = _arrBuildingInformationList;






            //string id = "0";
            //string state = "0";




            //////var _id = id;

            //////if ( _id == null )
            //////{

            //////    return View ( );

            //////}


            return View ( _arrBuildingList );
        }




        #endregion







        #region CriterionList


        List<AppUserBuildingTableCriterionModelManager> getCriterionList ( )
        {


            try
            {
                List<AppUserBuildingTableCriterionModelManager> _arrColumnCriterionList = new List<AppUserBuildingTableCriterionModelManager> ( );

                ////// ColumnCriterionList = new List<AppUserBuildingTableCriterionModelManager> ( ) 
                _arrColumnCriterionList.Add ( new AppUserBuildingTableCriterionModelManager ( )
                {
                    CriterionToken = "0" ,
                    CriterionText = "Good quality"
                } );

                _arrColumnCriterionList.Add ( new AppUserBuildingTableCriterionModelManager ( )
                {
                    CriterionToken = "0" ,
                    CriterionText = "Needs updating"
                } );

                _arrColumnCriterionList.Add ( new AppUserBuildingTableCriterionModelManager ( )
                {
                    CriterionToken = "0" ,
                    CriterionText = "No/unknown"
                } );

                return _arrColumnCriterionList;
            }
            catch ( Exception )
            {

                throw;
            }


        }




        List<AppUserBuildingTableCriterionModelManager> getCriterionList2 ( )
        {


            try
            {
                List<AppUserBuildingTableCriterionModelManager> _arrColumnCriterionList = new List<AppUserBuildingTableCriterionModelManager> ( );

                ////// ColumnCriterionList = new List<AppUserBuildingTableCriterionModelManager> ( ) 
                _arrColumnCriterionList.Add ( new AppUserBuildingTableCriterionModelManager ( )
                {
                    CriterionToken = "0" ,
                    CriterionText = "<4 years > 3 years"
                } );

                _arrColumnCriterionList.Add ( new AppUserBuildingTableCriterionModelManager ( )
                {
                    CriterionToken = "0" ,
                    CriterionText = "more than 4 years/unknown"
                } );

                //_arrColumnCriterionList.Add ( new AppUserBuildingTableCriterionModelManager ( )
                //{
                //    CriterionToken = "0" ,
                //    CriterionText = "No/unknown"
                //} );

                return _arrColumnCriterionList;
            }
            catch ( Exception )
            {

                throw;
            }


        }




        #endregion



        #region Message


        [HttpGet]
        public IActionResult Message ( )
        {
            return View ( );
        }





        #endregion



        //public IActionResult View ( )
        //{
        //    return View ( );
        //}
    }


}
