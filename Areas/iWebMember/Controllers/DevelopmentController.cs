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
using Microsoft.Extensions.FileProviders;
using Microsoft.CodeAnalysis.Operations;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace BSRVemcoCS.Areas.iWebMember.Controllers
{








    [Area("iWebMember")]
    [Authorize]
    public class DevelopmentController : Controller
    {


        private IWebHostEnvironment _iEnvironment;


        private readonly BSRDBModelContext _dbContext;




        public DevelopmentController(
                BSRDBModelContext dbContext,
            IWebHostEnvironment iEnvironment)
        {
            _dbContext = dbContext;
            _iEnvironment = iEnvironment;

        }







        #region Page1_New


        [HttpGet]
        public IActionResult Page1_New()
        {
            return View();
        }






        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 104857600)]
        public async Task<IActionResult> Page1_New(AppDevelomentNew1ViewModel iDevelomentNew1ViewModel)
        {


            if (ModelState.IsValid)
            {

                ArrayList _arrTokenList = new ArrayList();
                _arrTokenList = AppUtility_ListTokenIDManager.ListTokenID_Generate_NewList("2");

                //string iDay = iDevelomentNew1ViewModel.BuildingDate.Day.ToString ( );
                //string iMonth = iDevelomentNew1ViewModel.BuildingDate.Month.ToString ( );
                //string iYear = iDevelomentNew1ViewModel.BuildingDate.Year.ToString ( );
                string iYear = iDevelomentNew1ViewModel.BuildingDateYear.ToString();


                string wwwPath = _iEnvironment.WebRootPath;
                string contentPath = _iEnvironment.ContentRootPath;

                string path = Path.Combine(_iEnvironment.WebRootPath, "_iUMedia/_iUBuilding");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                List<string> uploadedFiles = new List<string>();
                //foreach ( IFormFile postedFile in postedFiles )
                //{
                //string fileName = Path.GetFileName(iDevelomentNew1ViewModel.FUploadBuildingImage.FileName);
                string _iFileName = "img_" + _arrTokenList[1] + ".jpg";

                //////////////////////////////////////////


                var files = HttpContext.Request.Form.Files;

                // if ( iDevelomentEdit1ViewModel.FUploadBuildingImage != null )
                foreach (var file in files)
                {

                    using (FileStream stream = new FileStream(Path.Combine(path, _iFileName), FileMode.Create))
                    {
                        files[0].CopyTo(stream);
                        uploadedFiles.Add(files[0].FileName);

                        //ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", files[0].FileName);


                    }

                }















                //   using ( FileStream stream = new FileStream ( Path.Combine ( path , fileName ) , FileMode.Create ) )



                //}


                BsrvemcoUserBuildingList iBuildingModel = new BsrvemcoUserBuildingList()
                {

                    RowViewTokenId = new Guid(),


                    OwnerUserTokenId = Program.iOwnerModel.OwnerUserTokenID,
                    CompanyTokenId = Program.iOwnerModel.CompanyTokenID,

                    BuildingTokenId = _arrTokenList[0].ToString(),
                    BuildingName = iDevelomentNew1ViewModel.BuildingName,
                    BuildingAddress = iDevelomentNew1ViewModel.BuildingAddress,
                    BuildingDay = "0",//iDevelomentNew1ViewModel.BuildingDate.Day.ToString ( ) ,
                    BuildingMonth = "0",// iDevelomentNew1ViewModel.BuildingDate.Month.ToString ( ) ,
                    BuildingYear = iDevelomentNew1ViewModel.BuildingDateYear.ToString(),
                    BuildingDate = "0",//iDevelomentNew1ViewModel.BuildingDate.ToString ( ) ,
                    //FileTokenId = _iImageTokenID ,
                    //FileName = _iImageTokenID ,
                    //FileExtension = _iImageTokenID ,
                    ImageTokenId = _arrTokenList[1].ToString(),
                    UploadDateTimeMilliSec = AppUtility_TimeManager.Time_GetCurrentTimeInMilliSecond(),
                    IsVisible = true,
                    IsActive = true,

                };


                await _dbContext.BsrvemcoUserBuildingLists.AddAsync(iBuildingModel);


                await _dbContext.SaveChangesAsync();

                return RedirectToAction(
                    "Page2_New",
                    "Development",
                    new { area = "iWebMember", bldtknid = _arrTokenList[0].ToString(), state = "new" });

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

                return View(iDevelomentNew1ViewModel);

            }


            // return View ( iDevelomentNew1ViewModel );

        }










        #endregion


        #region Page1_Edit


        [HttpGet]
        public IActionResult Page1_Edit()
        {

            try
            {
                //string id = HttpContext.Request.RouteValues[ "bldtknid" ].ToString ( );
                string id = Request.Query["bldtknid"].ToString();


                string state = "edit";

                var _iUserBuildignModel = _dbContext.BsrvemcoUserBuildingLists
                        .Where(u => u.BuildingTokenId == id)
                        //.Select (u  )
                        .FirstOrDefault(); // This is what actually executes the request and return a response

                AppDevelomentEdit1ViewModel _iDevelomentNew1ViewModel = new AppDevelomentEdit1ViewModel()
                {
                    BuildingTokenID = id,
                    BuildingName = _iUserBuildignModel.BuildingName,
                    BuildingAddress = _iUserBuildignModel.BuildingAddress,
                    BuildingDateYear = _iUserBuildignModel.BuildingYear,
                    BuildingImageTokenID = _iUserBuildignModel.ImageTokenId
                };




                return View(_iDevelomentNew1ViewModel);

            }
            catch (Exception)
            {

                throw;
            }










        }







        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 104857600)]
        public async Task<IActionResult> Page1_Edit(AppDevelomentEdit1ViewModel iDevelomentEdit1ViewModel)
        {

            //   string id = HttpContext.Request.RouteValues[ "bldtknid" ].ToString ( );
            string id = Request.Query["bldtknid"].ToString();
            string state = "edit";


            if (ModelState.IsValid)
            {

                ArrayList _arrTokenList = new ArrayList();
                _arrTokenList = AppUtility_ListTokenIDManager.ListTokenID_Generate_NewList("1");

                //string iDay = iDevelomentEdit1ViewModel.BuildingDate.Day.ToString ( );
                //string iMonth = iDevelomentEdit1ViewModel.BuildingDate.Month.ToString ( );
                //string iYear = iDevelomentEdit1ViewModel.BuildingDate.Year.ToString ( );
                string iYear = iDevelomentEdit1ViewModel.BuildingDateYear.ToString();


                //////////////////////////////////////////////////

                bool bln_IsImageTokenID = false;

                var files = HttpContext.Request.Form.Files;

                // if ( iDevelomentEdit1ViewModel.FUploadBuildingImage != null )
                foreach (var file in files)
                {

                    string wwwPath = _iEnvironment.WebRootPath;
                    string contentPath = _iEnvironment.ContentRootPath;

                    string path = Path.Combine(_iEnvironment.WebRootPath, "_iUMedia/_iUBuilding");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    List<string> uploadedFiles = new List<string>();
                    //foreach ( IFormFile postedFile in postedFiles )
                    //{
                    string fileName = file.FileName; //Path.GetFileName ( iDevelomentEdit1ViewModel.FUploadBuildingImage.FileName );
                    string _iFileName = "img_" + _arrTokenList[0] + ".jpg";


                    using (FileStream stream = new FileStream(Path.Combine(path, _iFileName), FileMode.Create))
                    {
                        // iDevelomentEdit1ViewModel.FUploadBuildingImage.CopyTo ( stream );
                        file.CopyTo(stream);
                        uploadedFiles.Add(fileName);
                        bln_IsImageTokenID = true;

                        //ViewBag.Message += string.Format ( "<b>{0}</b> uploaded.<br />" , fileName );


                    }


                }






                var _iUserBuildignModel = _dbContext.BsrvemcoUserBuildingLists
                   .Where(u => u.BuildingTokenId == id)
                   //.Select (u  )
                   .FirstOrDefault(); // This is what actually executes the request and return a response





                _iUserBuildignModel.BuildingName = iDevelomentEdit1ViewModel.BuildingName;
                _iUserBuildignModel.BuildingAddress = iDevelomentEdit1ViewModel.BuildingAddress;
                _iUserBuildignModel.BuildingYear = iDevelomentEdit1ViewModel.BuildingDateYear;

                if (bln_IsImageTokenID)
                {
                    _iUserBuildignModel.ImageTokenId = _arrTokenList[0].ToString();

                }


                _dbContext.BsrvemcoUserBuildingLists.Update(_iUserBuildignModel);

                await _dbContext.SaveChangesAsync();

                return RedirectToAction(
                    "Page2_New",
                    "Development",
                    new { area = "iWebMember", bldtknid = id, state = "new" });

                ////////return RedirectToAction (
                ////////     "Page2_Edit" ,
                ////////     "Development" ,
                ////////     new { area = "iWebMember" , bldtknid = id , state = "new" } );

                //////// //    //return RedirectToAction ( "Edit" , "Dashboard" ,
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

                return View(iDevelomentEdit1ViewModel);

            }


            // return View ( iDevelomentNew1ViewModel );

        }







        #endregion



        #region Summary


        [HttpGet]
        public async Task<IActionResult> Summary()
        {
            //string bldtknid , string state 
            try
            {
                //   string id = HttpContext.Request.RouteValues[ "bldtknid" ].ToString ( );
                string id = Request.Query["bldtknid"].ToString();
                // string state = "edit";

                var _iUserBuildignModel = _dbContext.BsrvemcoUserBuildingLists
                        .Where(u => u.BuildingTokenId == id)
                        //.Select (u  )
                        .FirstOrDefault(); // This is what actually executes the request and return a response

                AppUserBuildingStatisticModelManager _iBuildingStatisticModel = new AppUserBuildingStatisticModelManager();
                _iBuildingStatisticModel = await AppBuildingManager.Building_Get_BuildingStatisticModel_ByBuildingTokenID(
                    _dbContext,
                id);


                AppDevelomentSummaryViewModel _iDevelomentNew1ViewModel = new AppDevelomentSummaryViewModel()
                {
                    BuildingTokenID = id,
                    BuildingName = _iUserBuildignModel.BuildingName,
                    BuildingAddress = _iUserBuildignModel.BuildingAddress,
                    BuildingDateYear = _iUserBuildignModel.BuildingYear,
                    BuildingImageTokenID = _iUserBuildignModel.ImageTokenId,
                    iBuildingStatisticModel = _iBuildingStatisticModel
                };




                return View(_iDevelomentNew1ViewModel);

            }
            catch (Exception)
            {

                throw;
            }










        }




        [HttpGet]
        public IActionResult Summary_X1(string bldtknid, string state)
        {

            try
            {
                //   string id = HttpContext.Request.RouteValues[ "bldtknid" ].ToString ( );
                string id = Request.Query["bldtknid"].ToString();
                // string state = "edit";

                var _iUserBuildignModel = _dbContext.BsrvemcoUserBuildingLists
                        .Where(u => u.BuildingTokenId == id)
                        //.Select (u  )
                        .FirstOrDefault(); // This is what actually executes the request and return a response

                AppDevelomentEdit1ViewModel _iDevelomentNew1ViewModel = new AppDevelomentEdit1ViewModel()
                {
                    BuildingTokenID = id,
                    BuildingName = _iUserBuildignModel.BuildingName,
                    BuildingAddress = _iUserBuildignModel.BuildingAddress,
                    BuildingDateYear = _iUserBuildignModel.BuildingYear,
                    BuildingImageTokenID = _iUserBuildignModel.ImageTokenId
                };




                return View(_iDevelomentNew1ViewModel);

            }
            catch (Exception)
            {

                throw;
            }










        }




        #endregion







        #region Page2_New


        //[HttpGet ( "{id}" )]
        [HttpGet]
        public async Task<IActionResult> Page2_New()
        {

            try
            {


                string id = Request.Query["bldtknid"].ToString();



                // string id = HttpContext.Request.RouteValues[ "bldtknid" ].ToString ( );


                List<BsrvemcoUserBuildingInformationList>? _arrCheckCountUserBuildingInfomationList = _dbContext.BsrvemcoUserBuildingInformationLists
                .Where(u =>
                u.BuildingTokenId == id &&
                u.ApptableTokenId == "1689022008239" &&
                u.IsVisible == true)
                 //.Select (u  )
                 //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                 .ToList(); // This is what actually executes the request and return a response



                if (_arrCheckCountUserBuildingInfomationList.Count == 0)
                {

                    List<BsrvemcoAppBuildingInformationList>? _arrAppDevelomentInfomationList = _dbContext.BsrvemcoAppBuildingInformationLists
                         //.Where ( u => u.BuildingTokenId == id )
                         //.Select (u  )
                         //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                         .ToList(); // This is what actually executes the request and return a response


                    ArrayList _arrTokenList = new ArrayList();
                    _arrTokenList = AppUtility_ListTokenIDManager.ListTokenID_Generate_NewList(_arrAppDevelomentInfomationList.Count.ToString());



                    ////////////////////////////////////////

                    BsrvemcoUserBuildingInformationList iBuildingModel;

                    for (int i = 0; i < _arrAppDevelomentInfomationList.Count; i++)
                    {


                        iBuildingModel = new BsrvemcoUserBuildingInformationList()
                        {

                            RowViewTokenId = new Guid(),



                            OwnerUserTokenId = Program.iOwnerModel.OwnerUserTokenID,
                            CompanyTokenId = Program.iOwnerModel.CompanyTokenID,
                            BuildingTokenId = id,

                            ApptableTokenId = _arrAppDevelomentInfomationList[i].ApptableTokenId.ToString(),
                            AppinformationTokenId = _arrAppDevelomentInfomationList[i].AppinformationTokenId.ToString(),
                            InformationTokenId = _arrTokenList[i].ToString(),
                            InformationText = _arrAppDevelomentInfomationList[i].InformationText.ToString(),

                            Commentary = _arrAppDevelomentInfomationList[i].Commentary.ToString(),


                            TimeoutYearCount=  _arrAppDevelomentInfomationList[i].TimeoutYearCount.ToString(),

                            InformationScore = "5",
                            Score = "5",
                            ScoreManaged = "5",
                            ScoreAdjusted = "5",
                            ScoreOriginal = "5",


                            IsAnswered = false,
                            AnswerCode="evidence_default",
                            AnswerText="Awaiting Evidence",
                            AnswerDescription="You will NOT able to generate a \"Gap Analysis Report\" untill you have responded.",

                            UploadDateTimeMilliSec = AppUtility_TimeManager.Time_GetCurrentTimeInMilliSecond(),
                            IsVisible = true,
                            IsActive = true,

                        };


                        await _dbContext.BsrvemcoUserBuildingInformationLists.AddAsync(iBuildingModel);


                        await _dbContext.SaveChangesAsync();


                    }


                }





































                // Golden-Thread-Documents
                List<BsrvemcoUserBuildingInformationList>? _arrUserBuildingInfomationList = _dbContext.BsrvemcoUserBuildingInformationLists
                    .Where(u =>
                    u.BuildingTokenId == id
                    && u.ApptableTokenId == "1689022008239" &&
                    u.IsVisible== true)
                     //.Select (u  )
                     //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                     .ToList(); // This is what actually executes the request and return a response







                AppDevelomentNew2ViewModel iDevelomentNew2ViewModel = new AppDevelomentNew2ViewModel();
                List<AppUserBuildingInformationModelManager> _arrBuildingInformationModelList = new List<AppUserBuildingInformationModelManager>();


                AppUserBuildingInformationModelManager _iUserBuildingInformationModel;
                for (int i = 0; i < _arrUserBuildingInfomationList.Count; i++)
                {
                    _iUserBuildingInformationModel = new AppUserBuildingInformationModelManager()
                    {
                        AppTableTokenID = _arrUserBuildingInfomationList[i].ApptableTokenId.ToString(),
                        TableTokenID = _arrUserBuildingInfomationList[i].ApptableTokenId.ToString(),
                        APPInformationTokenID = _arrUserBuildingInfomationList[i].AppinformationTokenId.ToString(),
                        BuildingTokenID = id.ToString(),
                        InformationText = _arrUserBuildingInfomationList[i].InformationText.ToString(),
                        InformationTokenID = _arrUserBuildingInfomationList[i].InformationTokenId.ToString(),
                        InformationScore = _arrUserBuildingInfomationList[i].Score,
                        InformationScoreAdjusted = _arrUserBuildingInfomationList[i].ScoreAdjusted,
                        DocumentCount = _arrUserBuildingInfomationList[i].DocumentCount,
                        TimeFrame = _arrUserBuildingInfomationList[i].TimeoutYearCount
                    };



                    if (_arrUserBuildingInfomationList[i].AnswerCode == "evidence_null")
                    {
                        _iUserBuildingInformationModel.AnswerNULLButtonCSS="btn-secondary";
                    }
                    else
                    {
                        _iUserBuildingInformationModel.AnswerNULLButtonCSS="btn-outline-secondary";
                    }


                    _arrBuildingInformationModelList.Add(_iUserBuildingInformationModel);
                }








                /////////////////////////////////////////
                // Table-2

                List<BsrvemcoUserBuildingInformationList>? _arrUserBuildingTable2_InfomationList = _dbContext.BsrvemcoUserBuildingInformationLists
                     .Where(u =>
                     u.ApptableTokenId == "1689162197100" &&
                     u.BuildingTokenId == id &&
                     u.IsVisible == true)
                     //.Select (u  )
                     //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                     .ToList(); // This is what actually executes the request and return a response




                for (int i = 0; i < _arrUserBuildingTable2_InfomationList.Count; i++)
                {
                    _iUserBuildingInformationModel = new AppUserBuildingInformationModelManager()
                    {
                        AppTableTokenID = _arrUserBuildingTable2_InfomationList[i].ApptableTokenId.ToString(),
                        TableTokenID = _arrUserBuildingTable2_InfomationList[i].ApptableTokenId.ToString(),
                        APPInformationTokenID = _arrUserBuildingTable2_InfomationList[i].AppinformationTokenId.ToString(),
                        BuildingTokenID = id.ToString(),
                        InformationText = _arrUserBuildingTable2_InfomationList[i].InformationText.ToString(),
                        InformationTokenID = _arrUserBuildingTable2_InfomationList[i].InformationTokenId.ToString(),
                        InformationScore = _arrUserBuildingTable2_InfomationList[i].Score,
                        InformationScoreAdjusted = _arrUserBuildingTable2_InfomationList[i].ScoreAdjusted,
                        DocumentCount = _arrUserBuildingTable2_InfomationList[i].DocumentCount,
                        TimeFrame = _arrUserBuildingTable2_InfomationList[i].TimeoutYearCount
                    };


                    if (_arrUserBuildingTable2_InfomationList[i].AnswerCode == "evidence_null")
                    {
                        _iUserBuildingInformationModel.AnswerNULLButtonCSS="btn-secondary";
                    }
                    else
                    {
                        _iUserBuildingInformationModel.AnswerNULLButtonCSS="btn-outline-secondary";
                    }

                    _arrBuildingInformationModelList.Add(_iUserBuildingInformationModel);
                }






                iDevelomentNew2ViewModel.BuildingInformationList = _arrBuildingInformationModelList;



                return View(iDevelomentNew2ViewModel);

            }
            catch (Exception ex)
            {
                AppUtility_DebugManager.Debug_Get_MessageText(ex.Message.ToString());
                return null;
            }

        }





        [HttpPost]
        public IActionResult Page2_New(AppDevelomentNew2ViewModel iDevelomentNew2ViewModel)
        {



            try
            {
                string id = Request.Query["bldtknid"].ToString();

                return RedirectToAction(
                    "Message",
                    "Development",
                    new { area = "iWebMember", bldtknid = id, state = "new" });



                //  return View ( );

            }
            catch (Exception)
            {

                throw;
            }






        }




        #endregion


        #region Page2_Edit





        [HttpGet]
        public IActionResult Page2_Edit()
        {

            try
            {

                string id = Request.Query["bldtknid"].ToString();



                List<BsrvemcoUserBuildingInformationList>? _arrUserBuildingInfomationList = _dbContext.BsrvemcoUserBuildingInformationLists
                    .Where(u =>
                    u.BuildingTokenId == id
                    && u.ApptableTokenId == "1689022008239")
                     //.Select (u  )
                     //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                     .ToList(); // This is what actually executes the request and return a response







                AppDevelomentEdit2ViewModel iDevelomenEdit2ViewModel = new AppDevelomentEdit2ViewModel();
                List<AppUserBuildingInformationModelManager> _arrBuildingInformationModelList = new List<AppUserBuildingInformationModelManager>();


                AppUserBuildingInformationModelManager _iUserBuildingInformationModel;
                for (int i = 0; i < _arrUserBuildingInfomationList.Count; i++)
                {
                    _iUserBuildingInformationModel = new AppUserBuildingInformationModelManager()
                    {
                        APPInformationTokenID = _arrUserBuildingInfomationList[i].AppinformationTokenId.ToString(),
                        InformationText = _arrUserBuildingInfomationList[i].InformationText.ToString(),
                        InformationTokenID = _arrUserBuildingInfomationList[i].InformationTokenId.ToString(),
                        InformationScore = _arrUserBuildingInfomationList[i].InformationScore,
                        InformationScoreAdjusted = _arrUserBuildingInfomationList[i].ScoreAdjusted,
                        DocumentCount = _arrUserBuildingInfomationList[i].DocumentCount
                    };

                    _arrBuildingInformationModelList.Add(_iUserBuildingInformationModel);
                }






                iDevelomenEdit2ViewModel.BuildingInformationList = _arrBuildingInformationModelList;






                //string id = "0";
                //string state = "0";




                //////var _id = id;

                //////if ( _id == null )
                //////{

                //////    return View ( );

                //////}


                return View(iDevelomenEdit2ViewModel);




















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
            catch (Exception)
            {

                throw;
            }



            //
            //return View ( );
        }



        [HttpPost]
        public IActionResult Page2_Edit(AppDevelomentEdit2ViewModel iDevelomentEdit2ViewModel)
        {


            string id = Request.Query["bldtknid"].ToString();

            return RedirectToAction(
                "Message",
                "Development",
                new { area = "iWebMember", bldtknid = id, state = "new" });



            // return View ( );
        }




        #endregion



        #region Table1




        [HttpGet]
        public async Task<IActionResult> Table1_Edit()
        {

            try
            {
                string id = Request.Query["bldtknid"].ToString();

                string state = "0";


                //////var _iUserBuildignModel = _dbContext.BsrvemcoUserBuildingLists
                //////     .Where ( u => u.BuildingTokenId == id )
                //////     //.Select (u  )
                //////     .FirstOrDefault ( ); // This is what actually executes the request and return a response
                ///



                //  List<AppUserBuildingTable1ModelManager> _iRowContentList;



                List<BsrvemcoUserBuildingInformationList>? _arrUserBuildingInfomationList = _dbContext.BsrvemcoUserBuildingInformationLists
                     .Where(u =>
                     u.ApptableTokenId == "1689022008239" &&
                     u.BuildingTokenId == id &&
                     u.IsVisible == true)
                     //.Select (u  )
                     //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                     .ToList(); // This is what actually executes the request and return a response



                //////List<BsrvemcoAppBuildingInformationList>? _arrBuildingInfomationList = _dbContext.BsrvemcoAppBuildingInformationLists
                //////     .Where ( u => u.ApptableTokenId == "1689022008239" )
                //////     //.Select (u  )
                //////     //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                //////     .ToList ( ); // This is what actually executes the request and return a response





                List<AppUserBuildingTableRowModelManager> _iRowContentList = new List<AppUserBuildingTableRowModelManager>();

                for (int i = 0; i < _arrUserBuildingInfomationList.Count; i++)
                {
                    _iRowContentList
                  .Add(new AppUserBuildingTableRowModelManager()
                  {
                      _id = i,

                      AppTableTokenID = _arrUserBuildingInfomationList[i].ApptableTokenId,
                      TableTokenID = _arrUserBuildingInfomationList[i].ApptableTokenId,

                      AppInformationTokenID = _arrUserBuildingInfomationList[i].AppinformationTokenId,
                      InformationTokenID = _arrUserBuildingInfomationList[i].InformationTokenId,

                      CompanyTokenID = Program.iOwnerModel.CompanyTokenID,
                      BuildingTokenID = id,

                      ColumnDescription = _arrUserBuildingInfomationList[i].InformationText, //"Fire Strategy" ,
                      ColumnCommentary = _arrUserBuildingInfomationList[i].Commentary,
                      ColumnCriterion = "0",


                      ColumnScore = _arrUserBuildingInfomationList[i].Score,
                      ColumnScoreOriginal = _arrUserBuildingInfomationList[i].ScoreOriginal,
                      ColumnScoreManaged = _arrUserBuildingInfomationList[i].ScoreManaged,
                      ColumnScoreAdjused = _arrUserBuildingInfomationList[i].ScoreAdjusted,
                      ColumnRiskControlMeasure = _arrUserBuildingInfomationList[i].RiskControlMeasure,
                      ColumnTotal = "0",






                      //ColumnScore = "5" ,
                      //ColumnScoreOriginal = "5" ,
                      //ColumnScoreManaged = "5" ,
                      //ColumnScoreAdjused = "5" ,
                      //ColumnRiskControlMeasure = "" ,
                      //ColumnTotal = "5" ,

                      ColumnCriterionList = await AppBuildingInformationCriterionManager.getCriterionList(_dbContext, _arrUserBuildingInfomationList[i].AppinformationTokenId!)

                  });
                }







                AppDevelomentTable1EditViewModel _iDevelomentTable1EditModel = new AppDevelomentTable1EditViewModel()
                {
                    TableTitle = "TableTitle",
                    TableDescription = "TableDescription",

                    ColumnDescription = "Description",
                    ColumnCommentary = "Commentary",
                    ColumnCriterion = "Criterion",
                    ColumnScore = "Score",
                    ColumnScoreOriginal = "ScoreOriginal",
                    ColumnScoreManaged = "Score",
                    ColumnScoreAdjused = "Adjusted Score",
                    //ColumnRiskControlMeasure = "Risk Control Measure Risk Control Measure" ,
                    ColumnRiskControlMeasure = "Risk Control Measure",
                    //ColumnScoreTotal = "333" ,
                    ColumnScoreTotal = _dbContext.BsrvemcoUserBuildingInformationLists
                    .Where(
                        c =>
                        c.ApptableTokenId == "1689022008239" &&
                        c.BuildingTokenId == id)
                    .Sum(clmn => Convert.ToDecimal(clmn.ScoreAdjusted!)).ToString("0.0"),

                    RowContentList = _iRowContentList,
                };


                return View(_iDevelomentTable1EditModel);


            }
            catch (Exception ex)
            {

                iAppUtility.AppUtility_DebugManager.Debug_Get_MessageText(ex.Message);

                return View();
                //    throw;
            }



            //
            //return View ( );
        }



        [HttpPost]
        public IActionResult Table1_Edit(AppDevelomentEdit2ViewModel iDevelomentEdit2ViewModel, string id, string state)
        {
            return View();
        }







        #endregion




        #region Table2




        [HttpGet]
        public async Task<IActionResult> Table2_Edit()
        {

            try
            {

                string id = Request.Query["bldtknid"].ToString();

                string state = "0";


                //////var _iUserBuildignModel = _dbContext.BsrvemcoUserBuildingLists
                //////     .Where ( u => u.BuildingTokenId == id )
                //////     //.Select (u  )
                //////     .FirstOrDefault ( ); // This is what actually executes the request and return a response
                ///



                //  List<AppUserBuildingTable1ModelManager> _iRowContentList;



                List<BsrvemcoUserBuildingInformationList>? _arrUserBuildingInfomationList = _dbContext.BsrvemcoUserBuildingInformationLists
                     .Where(u =>
                     u.ApptableTokenId == "1689162197100" &&
                     u.BuildingTokenId == id &&
                     u.IsVisible == true)
                     //.Select (u  )
                     //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                     .ToList(); // This is what actually executes the request and return a response



                List<AppUserBuildingTableRowModelManager> _iRowContentList = new List<AppUserBuildingTableRowModelManager>();

                for (int i = 0; i < _arrUserBuildingInfomationList.Count; i++)
                {
                    _iRowContentList
                  .Add(new AppUserBuildingTableRowModelManager()
                  {

                      _id = i,

                      AppTableTokenID = _arrUserBuildingInfomationList[i].ApptableTokenId,
                      TableTokenID = _arrUserBuildingInfomationList[i].ApptableTokenId,

                      AppInformationTokenID = _arrUserBuildingInfomationList[i].AppinformationTokenId,
                      InformationTokenID = _arrUserBuildingInfomationList[i].InformationTokenId,

                      CompanyTokenID = Program.iOwnerModel.CompanyTokenID,
                      BuildingTokenID = id,

                      ColumnDescription = _arrUserBuildingInfomationList[i].InformationText, //"Fire Strategy" ,
                      ColumnCommentary = _arrUserBuildingInfomationList[i].Commentary,
                      ColumnCriterion = "0",






















                      //AppTableTokenID = "X1AppTableTokenID" ,
                      //TableTokenID = "X1TableTokenID" ,

                      //AppInformationTokenID = "X1AppInformationTokenID" ,
                      //InformationTokenID = "X1InformationTokenID" ,

                      //CompanyTokenID = "X1CompanyTokenID" ,
                      //BuildingTokenID = "X1BuildingTokenID" ,

                      //ColumnDescription = _arrBuildingInfomationList[ i ].InformationText , //"Fire Strategy" ,
                      //ColumnCommentary = _arrBuildingInfomationList[ i ].Commentary ,
                      //ColumnCriterion = "0" ,





                      ColumnScore = _arrUserBuildingInfomationList[i].Score,
                      ColumnScoreOriginal = _arrUserBuildingInfomationList[i].ScoreOriginal,
                      ColumnScoreManaged = _arrUserBuildingInfomationList[i].ScoreManaged,
                      ColumnScoreAdjused = _arrUserBuildingInfomationList[i].ScoreAdjusted,
                      ColumnRiskControlMeasure = _arrUserBuildingInfomationList[i].RiskControlMeasure,
                      ColumnTotal = "0",






                      //ColumnScore = "5" ,
                      //ColumnScoreOriginal = "5" ,
                      //ColumnScoreManaged = "5" ,
                      //ColumnScoreAdjused = "5" ,
                      //ColumnRiskControlMeasure = "" ,
                      //ColumnTotal = "5" ,

                      ColumnCriterionList = await AppBuildingInformationCriterionManager.getCriterionList(_dbContext, _arrUserBuildingInfomationList[i].AppinformationTokenId!)

                  });
                }




                AppDevelomentTable1EditViewModel _iDevelomentTable1EditModel = new AppDevelomentTable1EditViewModel()
                {
                    TableTitle = "TableTitle",
                    TableDescription = "TableDescription",

                    ColumnDescription = "Description",
                    ColumnCommentary = "Commentary",
                    ColumnCriterion = "Criterion",
                    ColumnScore = "Score",
                    ColumnScoreOriginal = "ScoreOriginal",
                    ColumnScoreManaged = "Score",
                    ColumnScoreAdjused = "Adjusted Score",
                    //ColumnRiskControlMeasure = "Risk Control Measure Risk Control Measure" ,
                    ColumnRiskControlMeasure = "Risk Control Measure",

                    //ColumnScoreTotal = "333" ,
                    ColumnScoreTotal = _dbContext.BsrvemcoUserBuildingInformationLists
                    .Where(
                        c =>
                        c.ApptableTokenId == "1689162197100" &&
                        c.BuildingTokenId == id)
                    .Sum(clmn => Convert.ToDecimal(clmn.ScoreAdjusted!)).ToString("0.0"),



                    RowContentList = _iRowContentList,
                };





                //////BuildingName = _iUserBuildignModel.BuildingName ,
                //////BuildingAddress = _iUserBuildignModel.BuildingAddress ,
                //////BuildingDate = DateTime.Parse ( _iUserBuildignModel.BuildingDate ) ,
                //////BuildingImageTokenID = _iUserBuildignModel.ImageTokenId




                return View(_iDevelomentTable1EditModel);
            }
            catch (Exception)
            {

                throw;
            }



            //
            //return View ( );
        }



        [HttpPost]
        public IActionResult Table2_Edit(AppDevelomentEdit2ViewModel iDevelomentEdit2ViewModel, string id, string state)
        {
            return View();
        }







        #endregion




        #region Table3




        [HttpGet]
        public async Task<IActionResult> Table3_Edit()
        {

            try
            {

                string id = Request.Query["bldtknid"].ToString();

                string state = "0";


                //////var _iUserBuildignModel = _dbContext.BsrvemcoUserBuildingLists
                //////     .Where ( u => u.BuildingTokenId == id )
                //////     //.Select (u  )
                //////     .FirstOrDefault ( ); // This is what actually executes the request and return a response
                ///



                //  List<AppUserBuildingTable1ModelManager> _iRowContentList;



                List<BsrvemcoUserBuildingInformationList>? _arrUserBuildingInfomationList = _dbContext.BsrvemcoUserBuildingInformationLists
                     .Where(u =>
                     u.ApptableTokenId == "1689162201957" &&
                     u.BuildingTokenId == id &&
                     u.IsVisible == true)
                     //.Select (u  )
                     //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                     .ToList(); // This is what actually executes the request and return a response


                //////List<BsrvemcoAppBuildingInformationList>? _arrBuildingInfomationList = _dbContext.BsrvemcoAppBuildingInformationLists
                //////     .Where ( u => u.ApptableTokenId == "1689162201957" )
                //////     //.Select (u  )
                //////     //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                //////     .ToList ( ); // This is what actually executes the request and return a response





                List<AppUserBuildingTableRowModelManager> _iRowContentList = new List<AppUserBuildingTableRowModelManager>();

                for (int i = 0; i < _arrUserBuildingInfomationList.Count; i++)
                {
                    _iRowContentList
                  .Add(new AppUserBuildingTableRowModelManager()
                  {

                      _id = i,

                      AppTableTokenID = _arrUserBuildingInfomationList[i].ApptableTokenId,
                      TableTokenID = _arrUserBuildingInfomationList[i].ApptableTokenId,

                      AppInformationTokenID = _arrUserBuildingInfomationList[i].AppinformationTokenId,
                      InformationTokenID = _arrUserBuildingInfomationList[i].InformationTokenId,

                      CompanyTokenID = Program.iOwnerModel.CompanyTokenID,
                      BuildingTokenID = id,

                      ColumnDescription = _arrUserBuildingInfomationList[i].InformationText, //"Fire Strategy" ,
                      ColumnCommentary = _arrUserBuildingInfomationList[i].Commentary,
                      ColumnCriterion = "0",
















                      //AppTableTokenID = "X1AppTableTokenID" ,
                      //TableTokenID = "X1TableTokenID" ,

                      //AppInformationTokenID = "X1AppInformationTokenID" ,
                      //InformationTokenID = "X1InformationTokenID" ,

                      //CompanyTokenID = "X1CompanyTokenID" ,
                      //BuildingTokenID = "X1BuildingTokenID" ,

                      //ColumnDescription = _arrBuildingInfomationList[ i ].InformationText , //"Fire Strategy" ,
                      //ColumnCommentary = _arrBuildingInfomationList[ i ].Commentary ,
                      //ColumnCriterion = "0" ,

                      ColumnScore = _arrUserBuildingInfomationList[i].Score,
                      ColumnScoreOriginal = _arrUserBuildingInfomationList[i].ScoreOriginal,
                      ColumnScoreManaged = _arrUserBuildingInfomationList[i].ScoreManaged,
                      ColumnScoreAdjused = _arrUserBuildingInfomationList[i].ScoreAdjusted,
                      ColumnRiskControlMeasure = _arrUserBuildingInfomationList[i].RiskControlMeasure,
                      ColumnTotal = "0",




                      //ColumnScore = "5" ,
                      //ColumnScoreOriginal = "5" ,
                      //ColumnScoreManaged = "5" ,
                      //ColumnScoreAdjused = "5" ,
                      //ColumnRiskControlMeasure = "" ,
                      //ColumnTotal = "5" ,

                      ColumnCriterionList = await AppBuildingInformationCriterionManager.getCriterionList(_dbContext, _arrUserBuildingInfomationList[i].AppinformationTokenId!)

                  });
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









                AppDevelomentTable1EditViewModel _iDevelomentTable1EditModel = new AppDevelomentTable1EditViewModel()
                {
                    TableTitle = "TableTitle",
                    TableDescription = "TableDescription",

                    ColumnDescription = "Description",
                    ColumnCommentary = "Commentary",
                    ColumnCriterion = "Criterion",
                    ColumnScore = "Score",
                    ColumnScoreOriginal = "ScoreOriginal",
                    ColumnScoreManaged = "Score",
                    ColumnScoreAdjused = "Adjusted Score",
                    //ColumnRiskControlMeasure = "Risk Control Measure Risk Control Measure" ,
                    ColumnRiskControlMeasure = "Risk Control Measure",

                    //ColumnScoreTotal = "333" ,
                    ColumnScoreTotal = _dbContext.BsrvemcoUserBuildingInformationLists
                    .Where(
                        c =>
                        c.ApptableTokenId == "1689162201957" &&
                        c.BuildingTokenId == id)
                    .Sum(clmn => Convert.ToDecimal(clmn.ScoreAdjusted!)).ToString("0.0"),


                    RowContentList = _iRowContentList,
                };





                //////BuildingName = _iUserBuildignModel.BuildingName ,
                //////BuildingAddress = _iUserBuildignModel.BuildingAddress ,
                //////BuildingDate = DateTime.Parse ( _iUserBuildignModel.BuildingDate ) ,
                //////BuildingImageTokenID = _iUserBuildignModel.ImageTokenId




                return View(_iDevelomentTable1EditModel);
            }
            catch (Exception)
            {

                throw;
            }



            //
            //return View ( );
        }



        [HttpPost]
        public IActionResult Table3_Edit(AppDevelomentEdit2ViewModel iDevelomentEdit2ViewModel, string id, string state)
        {
            return View();
        }







        #endregion




        #region Table4




        [HttpGet]
        public async Task<IActionResult> Table4_Edit()
        {

            try
            {
                string id = Request.Query["bldtknid"].ToString();

                string state = "0";


                //////var _iUserBuildignModel = _dbContext.BsrvemcoUserBuildingLists
                //////     .Where ( u => u.BuildingTokenId == id )
                //////     //.Select (u  )
                //////     .FirstOrDefault ( ); // This is what actually executes the request and return a response
                ///



                //  List<AppUserBuildingTable1ModelManager> _iRowContentList;



                List<BsrvemcoUserBuildingInformationList>? _arrUserBuildingInfomationList = _dbContext.BsrvemcoUserBuildingInformationLists
                     .Where(u =>
                     u.ApptableTokenId == "1689162207917" &&
                     u.BuildingTokenId == id &&
                     u.IsVisible == true)
                     //.Select (u  )
                     //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                     .ToList(); // This is what actually executes the request and return a response

                //////List<BsrvemcoAppBuildingInformationList>? _arrBuildingInfomationList = _dbContext.BsrvemcoAppBuildingInformationLists
                //////    .Where ( u => u.ApptableTokenId == "1689162207917" )
                //////    //.Select (u  )
                //////    //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                //////    .ToList ( ); // This is what actually executes the request and return a response





                List<AppUserBuildingTableRowModelManager> _iRowContentList = new List<AppUserBuildingTableRowModelManager>();

                for (int i = 0; i < _arrUserBuildingInfomationList.Count; i++)
                {
                    _iRowContentList
                  .Add(new AppUserBuildingTableRowModelManager()
                  {

                      _id = i,

                      AppTableTokenID = _arrUserBuildingInfomationList[i].ApptableTokenId,
                      TableTokenID = _arrUserBuildingInfomationList[i].ApptableTokenId,

                      AppInformationTokenID = _arrUserBuildingInfomationList[i].AppinformationTokenId,
                      InformationTokenID = _arrUserBuildingInfomationList[i].InformationTokenId,

                      CompanyTokenID = Program.iOwnerModel.CompanyTokenID,
                      BuildingTokenID = id,

                      ColumnDescription = _arrUserBuildingInfomationList[i].InformationText, //"Fire Strategy" ,
                      ColumnCommentary = _arrUserBuildingInfomationList[i].Commentary,
                      ColumnCriterion = "0",









                      //AppTableTokenID = "X1AppTableTokenID" ,
                      //TableTokenID = "X1TableTokenID" ,

                      //AppInformationTokenID = "X1AppInformationTokenID" ,
                      //InformationTokenID = "X1InformationTokenID" ,

                      //CompanyTokenID = "X1CompanyTokenID" ,
                      //BuildingTokenID = "X1BuildingTokenID" ,

                      //ColumnDescription = _arrBuildingInfomationList[ i ].InformationText , //"Fire Strategy" ,
                      //ColumnCommentary = _arrBuildingInfomationList[ i ].Commentary ,
                      //ColumnCriterion = "0" ,

                      ColumnScore = _arrUserBuildingInfomationList[i].Score,
                      ColumnScoreOriginal = _arrUserBuildingInfomationList[i].ScoreOriginal,
                      ColumnScoreManaged = _arrUserBuildingInfomationList[i].ScoreManaged,
                      ColumnScoreAdjused = _arrUserBuildingInfomationList[i].ScoreAdjusted,
                      ColumnRiskControlMeasure = _arrUserBuildingInfomationList[i].RiskControlMeasure,
                      ColumnTotal = "0",


                      //ColumnScore = "5" ,
                      //ColumnScoreOriginal = "5" ,
                      //ColumnScoreManaged = "5" ,
                      //ColumnScoreAdjused = "5" ,
                      //ColumnRiskControlMeasure = "" ,
                      //ColumnTotal = "5" ,



                      ColumnCriterionList = await AppBuildingInformationCriterionManager.getCriterionList(_dbContext, _arrUserBuildingInfomationList[i].AppinformationTokenId!)

                  });
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









                AppDevelomentTable1EditViewModel _iDevelomentTable1EditModel = new AppDevelomentTable1EditViewModel()
                {
                    TableTitle = "TableTitle",
                    TableDescription = "TableDescription",

                    ColumnDescription = "Description",
                    ColumnCommentary = "Commentary",
                    ColumnCriterion = "Criterion",
                    ColumnScore = "Score",
                    ColumnScoreOriginal = "ScoreOriginal",
                    ColumnScoreManaged = "Score",
                    ColumnScoreAdjused = "Adjusted Score",
                    //ColumnRiskControlMeasure = "Risk Control Measure Risk Control Measure" ,
                    ColumnRiskControlMeasure = "Risk Control Measure",
                    //ColumnScoreAverage = "2.5" ,
                    ColumnScoreTotal = "0",



                    ColumnScoreAverage = _dbContext.BsrvemcoUserBuildingInformationLists
                    .Where(
                        c =>
                        c.ApptableTokenId == "1689162207917" &&
                        c.BuildingTokenId == id)
                    .Average(clmn => Convert.ToDouble(clmn.ScoreAdjusted!)).ToString("0.0"),



                    RowContentList = _iRowContentList,
                };





                //////BuildingName = _iUserBuildignModel.BuildingName ,
                //////BuildingAddress = _iUserBuildignModel.BuildingAddress ,
                //////BuildingDate = DateTime.Parse ( _iUserBuildignModel.BuildingDate ) ,
                //////BuildingImageTokenID = _iUserBuildignModel.ImageTokenId




                return View(_iDevelomentTable1EditModel);
            }
            catch (Exception)
            {

                throw;
            }



            //
            //return View ( );
        }



        [HttpPost]
        public IActionResult Table4_Edit(AppDevelomentEdit2ViewModel iDevelomentEdit2ViewModel, string id, string state)
        {
            return View();
        }







        #endregion



        #region Diagram





        [HttpGet]
        public async Task<IActionResult> Diagram()
        {

            try
            {
                string id = Request.Query["bldtknid"].ToString();

                string PointXText = Request.Query["px"].ToString();

                string PointYText = Request.Query["py"].ToString();

                AppPointModelManager _iPointModel = new AppPointModelManager();

                //AppUserBuildingStatisticModelManager _iUserBuildingStatisticModel = new AppUserBuildingStatisticModelManager ( );


                //_iUserBuildingStatisticModel = await AppBuildingManager.Building_Get_BuildingStatisticModel_ByBuildingTokenID (
                //    _dbContext ,
                //id );

                // ( Value * 60 ) + 2
                _iPointModel.PointX = ((Double.Parse(PointXText) * 60) + 0).ToString(); //"152.0";
                _iPointModel.PointY = ((Double.Parse(PointYText) * 60) + 0).ToString(); ;

                //////_iPointModel.PointX ="3.0";
                //////_iPointModel.PointY = "3.0";


                // ( Value * 50 )    >>> 46.6 unit
                _iPointModel.PointXSpan = ((Double.Parse(PointXText) * 50)).ToString();

                // ( Value * 45 )   >>>  53.3  unit
                _iPointModel.PointYSpan = ((Double.Parse(PointYText) * 45)).ToString();

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


                return View(_iPointModel);
            }
            catch (Exception)
            {

                throw;
            }



            //
            //return View ( );
        }





        [HttpGet]
        public async Task<IActionResult> Diagram_X1()
        {

            try
            {
                string id = Request.Query["bldtknid"].ToString();

                AppPointModelManager _iPointModel = new AppPointModelManager();

                AppUserBuildingStatisticModelManager _iUserBuildingStatisticModel = new AppUserBuildingStatisticModelManager();


                _iUserBuildingStatisticModel = await AppBuildingManager.Building_Get_BuildingStatisticModel_ByBuildingTokenID(
                    _dbContext,
                id);

                // ( Value * 60 ) + 2
                _iPointModel.PointX = ((Double.Parse(_iUserBuildingStatisticModel.ScoreRiskAverage) * 60) + 0).ToString(); //"152.0";
                _iPointModel.PointY = ((Double.Parse(_iUserBuildingStatisticModel.Table4ScoreAverage) * 60) + 0).ToString(); ;

                //////_iPointModel.PointX ="3.0";
                //////_iPointModel.PointY = "3.0";


                // ( Value * 50 )    >>> 46.6 unit
                _iPointModel.PointXSpan = ((Double.Parse(_iUserBuildingStatisticModel.ScoreRiskAverage) * 50)).ToString();

                // ( Value * 45 )   >>>  53.3  unit
                _iPointModel.PointYSpan = ((Double.Parse(_iUserBuildingStatisticModel.Table4ScoreAverage) * 45)).ToString();

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




                return View(_iPointModel);
            }
            catch (Exception)
            {

                throw;
            }



            //
            //return View ( );
        }













        [HttpPost]
        // [Microsoft.AspNetCore.Mvc.va.ValidateInput ( false )]
        public IActionResult GetImage(string divhtml)
        {

            try
            {
                var x = "123";
                var y = "456";

            }
            catch (Exception)
            {

                throw;
            }

            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        #endregion



        #region List


        //[HttpGet ( "{id}" )]
        [HttpGet]
        public IActionResult List()
        {

            //AppDevelomentInfomationViewModel


            List<BsrvemcoUserBuildingList>? _arrDevelomentList = _dbContext.BsrvemcoUserBuildingLists
                 .Where(u =>
                 u.CompanyTokenId == Program.iOwnerModel.CompanyTokenID &&
                 u.IsVisible ==true)
                 //.Select (u  )
                 //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                 .ToList(); // This is what actually executes the request and return a response




            //  AppUserBuildingModelManager iDevelomentNew2ViewModel = new AppUserBuildingModelManager ( );
            List<AppUserBuildingModelManager> _arrBuildingList = new List<AppUserBuildingModelManager>();


            AppUserBuildingModelManager _iUserBuildingModel;
            for (int i = 0; i < _arrDevelomentList.Count; i++)
            {
                _iUserBuildingModel = new AppUserBuildingModelManager()
                {
                    BuildingName = _arrDevelomentList[i].BuildingName.ToString()!,
                    BuildingTokenID = _arrDevelomentList[i].BuildingTokenId.ToString()!,
                    //InformationText = _arrDevelomentInfomationList[ i ].InformationText.ToString ( ) ,

                };

                _arrBuildingList.Add(_iUserBuildingModel);
            }


            //  iDevelomentNew2ViewModel.BuildingInformationList = _arrBuildingInformationList;






            //string id = "0";
            //string state = "0";




            //////var _id = id;

            //////if ( _id == null )
            //////{

            //////    return View ( );

            //////}


            return View(_arrBuildingList);
        }




        #endregion






        #region Update-Score


        //[HttpGet ( "{id}" )]
        [HttpPost]
        public async Task<JsonResult> Update_Score_ByInformationTokenID(
            string iAppTableTokenID,
            string iTableTokenID,
             string iBuildingTokenID,
            string iInformationTokenID,
            string iScoreAdjusted = "0",
            string iRiskControlMeasure = "0")
        {

            string _strResult = "0";

            _ = await AppBuildingManager.Building_Update_BuildingInformationScore_ByInformationTokenID(
                           _dbContext,
                             iBuildingTokenID,
                  iInformationTokenID,
                  iScoreAdjusted,
                  iRiskControlMeasure);


            //Table1ScoreTotal
            if (iAppTableTokenID == "1689022008239")
            {

                var Table1ScoreTotal = _dbContext.BsrvemcoUserBuildingInformationLists
                              .Where(
                                  c =>
                                  c.ApptableTokenId == "1689022008239" &&
                                  c.BuildingTokenId == iBuildingTokenID)
                              .Sum(clmn => Convert.ToDecimal(clmn.ScoreAdjusted!)).ToString("0.0");//"60"; //3 * 20 ;

                _strResult = Table1ScoreTotal;

            }

            //Table2ScoreTotal
            else if (iAppTableTokenID == "1689162197100")
            {

                var Table2ScoreTotal = _dbContext.BsrvemcoUserBuildingInformationLists
                          .Where(
                              c =>
                              c.ApptableTokenId == "1689162197100" &&
                              c.BuildingTokenId == iBuildingTokenID)
                          .Sum(clmn => Convert.ToDecimal(clmn.ScoreAdjusted!)).ToString("0.0");//"27"; // 3 * 9 ;


                _strResult = Table2ScoreTotal;



            }

            //Table3ScoreTotal
            else if (iAppTableTokenID == "1689162201957")
            {

                var Table3ScoreTotal = _dbContext.BsrvemcoUserBuildingInformationLists
                               .Where(
                                   c =>
                                   c.ApptableTokenId == "1689162201957" &&
                                   c.BuildingTokenId == iBuildingTokenID)
                               .Sum(clmn => Convert.ToDecimal(clmn.ScoreAdjusted!)).ToString("0.0");// "12"; //  4 * 3 ;


                _strResult = Table3ScoreTotal;


            }

            //Table4ScoreAverage
            else if (iAppTableTokenID == "1689162207917")
            {


                var Table4ScoreAverage = _dbContext.BsrvemcoUserBuildingInformationLists
                        .Where(
                            c =>
                            c.ApptableTokenId == "1689162207917" &&
                            c.BuildingTokenId == iBuildingTokenID)
                        .Average(clmn => Convert.ToDouble(clmn.ScoreAdjusted!)).ToString("0.0");// "3.5"; // (3 * 11) / 11  iBuildingTokenID;


                _strResult = Table4ScoreAverage;


            }






















            //  return Json ( new { result = true }, JsonRequestBehavior.AllowGet );
            // return Json ( new { total = _strResult } , new Newtonsoft.Json.JsonSerializerSettings ( ) );
            return Json(new { total = _strResult });
        }




        #endregion




        #region CriterionList


        List<AppUserBuildingTableCriterionModelManager> getCriterionList()
        {


            try
            {
                List<AppUserBuildingTableCriterionModelManager> _arrColumnCriterionList = new List<AppUserBuildingTableCriterionModelManager>();

                ////// ColumnCriterionList = new List<AppUserBuildingTableCriterionModelManager> ( ) 
                _arrColumnCriterionList.Add(new AppUserBuildingTableCriterionModelManager()
                {
                    CriterionToken = "0",
                    CriterionText = "Good quality"
                });

                _arrColumnCriterionList.Add(new AppUserBuildingTableCriterionModelManager()
                {
                    CriterionToken = "0",
                    CriterionText = "Needs updating"
                });

                _arrColumnCriterionList.Add(new AppUserBuildingTableCriterionModelManager()
                {
                    CriterionToken = "0",
                    CriterionText = "No/unknown"
                });

                return _arrColumnCriterionList;
            }
            catch (Exception)
            {

                throw;
            }


        }




        List<AppUserBuildingTableCriterionModelManager> getCriterionList2()
        {


            try
            {
                List<AppUserBuildingTableCriterionModelManager> _arrColumnCriterionList = new List<AppUserBuildingTableCriterionModelManager>();

                ////// ColumnCriterionList = new List<AppUserBuildingTableCriterionModelManager> ( ) 
                _arrColumnCriterionList.Add(new AppUserBuildingTableCriterionModelManager()
                {
                    CriterionToken = "0",
                    CriterionText = "<4 years > 3 years"
                });

                _arrColumnCriterionList.Add(new AppUserBuildingTableCriterionModelManager()
                {
                    CriterionToken = "0",
                    CriterionText = "more than 4 years/unknown"
                });

                //_arrColumnCriterionList.Add ( new AppUserBuildingTableCriterionModelManager ( )
                //{
                //    CriterionToken = "0" ,
                //    CriterionText = "No/unknown"
                //} );

                return _arrColumnCriterionList;
            }
            catch (Exception)
            {

                throw;
            }


        }




        #endregion



        #region Message


        [HttpGet]
        public IActionResult Message()
        {
            return View();
        }





        #endregion


        #region Documents




        [HttpPost]
        public async Task<IActionResult> UploadFiles_X11()
        {
            var files = HttpContext.Request.Form.Files;

            if (files.Any())
            {
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        //Getting FileName
                        var fileName = Path.GetFileName(file.FileName);
                        //Assigning Unique Filename (Guid)
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid().ToString("N"));
                        //Getting file Extension
                        var fileExtension = Path.GetExtension(fileName);
                        // concatenating  FileName + FileExtension
                        var newFileName = String.Concat(myUniqueFileName, fileExtension);
                        await using var target = new MemoryStream();
                        await file.CopyToAsync(target);
                        var physicalPath = $"{new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadedFiles")).Root}{$@"{fileName}"}";
                        string filePath = $"/UploadedFiles/{fileName}";
                        await using FileStream fs = System.IO.File.Create(physicalPath);
                        await file.CopyToAsync(fs);
                        fs.Flush();
                    }
                }

                return Json(new { status = true, Message = "Files Uploaded Successfully!" });
            }

            return View();
        }



        //[HttpPost]
        //[RequestFormLimits(MultipartBodyLengthLimit = 104857600)]
        public async Task<IActionResult> QueryForm_Upload_FileLinks(
            string iAppQueryTableTokenID,
            string iAppQueryInformationTokenID,
            string iQueryTableTokenID,
            string iQueryInformationTokenID,
            string iBuildingTokenID,
            string iFileLinkList,
            string iAnswerCode)
        {

            /* , IFormFile filedata*/


            try
            {

                //string phrase = "The quick brown fox jumps over the lazy dog.";
                //string[ ] words = phrase.Split(' ');

                //string phrase = "The quick brown fox jumps over the lazy dog.";
                string[ ] words = iFileLinkList.Split(',');

                List<string> uploadedFilesName = new List<string>();
                //List<string> uploadedFilesTokenID = new List<string> ( );
                //List<string> uploadedFileExtension = new List<string>();
                //List<string> uploadedFileSize = new List<string>();
                ArrayList _arrTokenList = new ArrayList();

                _arrTokenList = AppUtility_ListTokenIDManager.ListTokenID_Generate_NewList(words.Length.ToString());



                foreach (var word in words)
                {

                    uploadedFilesName.Add(word);
                    //uploadedFilesTokenID.Add ( _xFileName );
                    //uploadedFileExtension.Add(_iFileExtension);
                    //uploadedFileSize.Add(_iFileSize);

                    //System.Console.WriteLine($"<{word}>");
                }

                // Save-Database

                try
                {


                    BsrvemcoUserBuildingQueryDocumentList iQueryDocumentModel;
                    for (int i = 0; i < uploadedFilesName.Count; i++)
                    {
                        iQueryDocumentModel = new BsrvemcoUserBuildingQueryDocumentList()
                        {

                            RowViewTokenId = new Guid(),


                            OwnerUserTokenId = Program.iOwnerModel.OwnerUserTokenID,
                            CompanyTokenId = Program.iOwnerModel.CompanyTokenID,

                            AppqueryTableTokenId = iAppQueryTableTokenID,
                            QueryTableTokenId = iQueryTableTokenID,
                            BuildingTokenId = iBuildingTokenID,
                            AppqueryInformationTokenId = iAppQueryInformationTokenID,
                            QueryInformationTokenId = iQueryInformationTokenID,
                            DocumentTokenId = _arrTokenList[i].ToString(),
                            DocumentWebUrl = uploadedFilesName[i].ToString(),

                            //iDevelomentNew1ViewModel.BuildingDate.Day.ToString ( ) ,
                            //DocumentTitle = uploadedFilesName[i].ToString(),// iDevelomentNew1ViewModel.BuildingDate.Month.ToString ( ) ,
                            //DocumentExtension = uploadedFileExtension[i].ToString(),
                            //DocumentCode = uploadedFileExtension[i].ToString(),
                            //DocumentType = uploadedFileExtension[i].ToString(),
                            //DocumentSize = uploadedFileSize[i].ToString(),//iDevelomentNew1ViewModel.BuildingDate.ToString ( ) ,



                            TimeoutUserUploadStartDay =DateTime.Now.Day.ToString(),
                            TimeoutUserUploadStartMonth =DateTime.Now.Month.ToString(),
                            TimeoutUserUploadStartYear =DateTime.Now.Year.ToString(),
                            TimeoutUserUploadStartText = "0",





                            //TimeoutYearCount = iTimeFrame,
                            UploadDateTimeMilliSec = AppUtility_TimeManager.Time_GetCurrentTimeInMilliSecond(),
                            IsVisible = true,
                            IsActive = true,

                        };


                        await _dbContext.BsrvemcoUserBuildingQueryDocumentLists.AddAsync(iQueryDocumentModel);

                        await _dbContext.SaveChangesAsync();


                    }



                    // Update-Scores


                    if (iAnswerCode== "yes")
                    {

                        await QueryForm_Answer_YES_NO(
            iAppQueryTableTokenID,
            iAppQueryInformationTokenID,
            iQueryTableTokenID,
           iQueryInformationTokenID,
            iBuildingTokenID,
            iAnswerCode,
         "0");
                    }

                    //         string _iDocumentCount = _dbContext.BsrvemcoUserBuildingDocumentLists
                    //.Where(
                    //    c =>
                    //    c.BuildingTokenId == iBuildingTokenID &&
                    //    c.InformationTokenId == iInformationTokenID &&
                    //    c.IsVisible == true)
                    //.Count().ToString();


                    //         var _iUserBuildignInfoModel = _dbContext.BsrvemcoUserBuildingInformationLists
                    //                 .Where(u =>
                    //                 u.BuildingTokenId == iBuildingTokenID &&
                    //                 u.InformationTokenId == iInformationTokenID)
                    //                 //.Select (u  )
                    //                 .FirstOrDefault(); // This is what actually executes the request and return a response

                    //         _iUserBuildignInfoModel.Score = "3";
                    //         _iUserBuildignInfoModel.ScoreOriginal = "3";
                    //         _iUserBuildignInfoModel.ScoreAdjusted = "3";
                    //         _iUserBuildignInfoModel.ScoreManaged = "3";
                    //         _iUserBuildignInfoModel.DocumentCount = _iDocumentCount;



                    //         _iUserBuildignInfoModel.IsAnswered = true;
                    //         _iUserBuildignInfoModel.AnswerCode="evidence_upload";
                    //         _iUserBuildignInfoModel.AnswerText="Evidence has been uploaded and is awaiting verification";
                    //         _iUserBuildignInfoModel.AnswerDescription="0";


                    //         _dbContext.BsrvemcoUserBuildingInformationLists.Update(_iUserBuildignInfoModel);

                    //         await _dbContext.SaveChangesAsync();



                }
                catch (Exception ex)
                {
                    AppUtility_DebugManager.Debug_Get_MessageText(ex.Message.ToString());

                }





                return Json(new { status = true, Message = "Files Uploaded Successfully!" });


                //return View();



            }
            catch (Exception ex)
            {
                AppUtility_DebugManager.Debug_Get_MessageText(ex.Message.ToString());
                return View();
            }

        }






        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 104857600)]
        public async Task<IActionResult> UploadFiles(
            string iAppinformationTokenID, string iInformationTokenID, string iBuildingTokenID, string iTimeFrame, List<IFormFile> filedata)
        {

            /* , IFormFile filedata*/


            try
            {


                //var files = HttpContext.Request.Form.Files;

                if (filedata.Count > 0)
                {
                    string wwwPath = _iEnvironment.WebRootPath;
                    string contentPath = _iEnvironment.ContentRootPath;

                    string path = Path.Combine(_iEnvironment.WebRootPath, "_iUMedia/_iUDocument");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }


                    List<string> uploadedFilesName = new List<string>();
                    //List<string> uploadedFilesTokenID = new List<string> ( );
                    List<string> uploadedFileExtension = new List<string>();
                    List<string> uploadedFileSize = new List<string>();
                    ArrayList _arrTokenList = new ArrayList();

                    _arrTokenList = AppUtility_ListTokenIDManager.ListTokenID_Generate_NewList(filedata.Count.ToString());



                    foreach (var formFile in filedata)
                    {
                        if (formFile.Length > 0)
                        {
                            //////using (var stream = new FileStream(filePath, FileMode.Create))
                            //////{
                            //////    await formFile.CopyToAsync(stream);
                            //////}
                            ///

                            //Getting FileName
                            var _xFileName = Path.GetFileName(formFile.FileName);

                            //Getting file Extension
                            var _iFileExtension = (Path.GetExtension(_xFileName).ToLower().ToString()).Remove(0, 1); ;
                            var _iFileSize = BytesToString(formFile.Length).ToString();

                            //string fileName = Path.GetFileName ( iDevelomentNew1ViewModel.FUploadBuildingImage.FileName );
                            string _iFileName = "doc_" + _arrTokenList[0] + "." + _iFileExtension;

                            //await using var target = new MemoryStream ( );
                            //await file.CopyToAsync ( target );
                            //var physicalPath = $"{new PhysicalFileProvider ( Path.Combine ( Directory.GetCurrentDirectory ( ) , "wwwroot" , "UploadedFiles" ) ).Root}{$@"{fileName}"}";
                            ////string filePath = $"/UploadedFiles/{fileName}";
                            //await using FileStream fs = System.IO.File.Create ( path );
                            //await file.CopyToAsync ( fs );
                            //fs.Flush ( );

                            using (FileStream stream = new FileStream(Path.Combine(path, _iFileName), FileMode.Create))
                            {
                                formFile.CopyTo(stream);

                                uploadedFilesName.Add(_xFileName);
                                //uploadedFilesTokenID.Add ( _xFileName );
                                uploadedFileExtension.Add(_iFileExtension);
                                uploadedFileSize.Add(_iFileSize);

                            }


                        }
                    }






                    // Save-Database

                    try
                    {

                        //await Task.Delay(10000);




                        BsrvemcoUserBuildingDocumentList iInformationDocumentModel;
                        for (int i = 0; i < uploadedFilesName.Count; i++)
                        {
                            iInformationDocumentModel = new BsrvemcoUserBuildingDocumentList()
                            {

                                RowViewTokenId = new Guid(),


                                OwnerUserTokenId = Program.iOwnerModel.OwnerUserTokenID,
                                CompanyTokenId = Program.iOwnerModel.CompanyTokenID,

                                ApptableTokenId = "1689022008239",
                                BuildingTokenId = iBuildingTokenID,
                                AppinformationTokenId = iAppinformationTokenID,
                                InformationTokenId = iInformationTokenID,
                                DocumentTokenId = _arrTokenList[i].ToString(),
                                DocumentName = uploadedFilesName[i].ToString(),//iDevelomentNew1ViewModel.BuildingDate.Day.ToString ( ) ,
                                DocumentTitle = uploadedFilesName[i].ToString(),// iDevelomentNew1ViewModel.BuildingDate.Month.ToString ( ) ,
                                DocumentExtension = uploadedFileExtension[i].ToString(),
                                DocumentCode = uploadedFileExtension[i].ToString(),
                                DocumentType = uploadedFileExtension[i].ToString(),
                                DocumentSize = uploadedFileSize[i].ToString(),//iDevelomentNew1ViewModel.BuildingDate.ToString ( ) ,



                                TimeoutUserUploadStartDay =DateTime.Now.Day.ToString(),
                                TimeoutUserUploadStartMonth =DateTime.Now.Month.ToString(),
                                TimeoutUserUploadStartYear =DateTime.Now.Year.ToString(),
                                TimeoutUserUploadStartText = "0",





                                TimeoutYearCount = iTimeFrame,
                                UploadDateTimeMilliSec = AppUtility_TimeManager.Time_GetCurrentTimeInMilliSecond(),
                                IsVisible = true,
                                IsActive = true,

                            };


                            await _dbContext.BsrvemcoUserBuildingDocumentLists.AddAsync(iInformationDocumentModel);

                            await _dbContext.SaveChangesAsync();


                        }



                        // Update-Scores

                        string _iDocumentCount = _dbContext.BsrvemcoUserBuildingDocumentLists
               .Where(
                   c =>
                   c.BuildingTokenId == iBuildingTokenID &&
                   c.InformationTokenId == iInformationTokenID &&
                   c.IsVisible == true)
               .Count().ToString();


                        var _iUserBuildignInfoModel = _dbContext.BsrvemcoUserBuildingInformationLists
                                .Where(u =>
                                u.BuildingTokenId == iBuildingTokenID &&
                                u.InformationTokenId == iInformationTokenID)
                                //.Select (u  )
                                .FirstOrDefault(); // This is what actually executes the request and return a response

                        _iUserBuildignInfoModel.Score = "3";
                        _iUserBuildignInfoModel.ScoreOriginal = "3";
                        _iUserBuildignInfoModel.ScoreAdjusted = "3";
                        _iUserBuildignInfoModel.ScoreManaged = "3";
                        _iUserBuildignInfoModel.DocumentCount = _iDocumentCount;



                        _iUserBuildignInfoModel.IsAnswered = true;
                        _iUserBuildignInfoModel.AnswerCode="evidence_upload";
                        _iUserBuildignInfoModel.AnswerText="Evidence has been uploaded and is awaiting verification";
                        _iUserBuildignInfoModel.AnswerDescription="0";


                        _dbContext.BsrvemcoUserBuildingInformationLists.Update(_iUserBuildignInfoModel);

                        await _dbContext.SaveChangesAsync();


                    }
                    catch (Exception ex)
                    {
                        AppUtility_DebugManager.Debug_Get_MessageText(ex.Message.ToString());

                    }



                    //           Task.Run(async () =>
                    //       {
                    //           await saveDatabase(iAppinformationTokenID,
                    //               iInformationTokenID,
                    //               iBuildingTokenID,
                    //               iTimeFrame,
                    //        uploadedFilesName,
                    // uploadedFileExtension,
                    // uploadedFileSize,
                    //_arrTokenList);
                    //       }).ConfigureAwait(false);




                    ////////////////////         BsrvemcoUserBuildingDocumentList iInformationDocumentModel;
                    ////////////////////         for (int i = 0; i < uploadedFilesName.Count; i++)
                    ////////////////////         {
                    ////////////////////             iInformationDocumentModel = new BsrvemcoUserBuildingDocumentList()
                    ////////////////////             {

                    ////////////////////                 RowViewTokenId = new Guid(),


                    ////////////////////                 OwnerUserTokenId = Program.iOwnerModel.OwnerUserTokenID,
                    ////////////////////                 CompanyTokenId = Program.iOwnerModel.CompanyTokenID,

                    ////////////////////                 ApptableTokenId = "1689022008239",
                    ////////////////////                 BuildingTokenId = iBuildingTokenID,
                    ////////////////////                 AppinformationTokenId = iAppinformationTokenID,
                    ////////////////////                 InformationTokenId = iInformationTokenID,
                    ////////////////////                 DocumentTokenId = _arrTokenList[i].ToString(),
                    ////////////////////                 DocumentName = uploadedFilesName[i].ToString(),//iDevelomentNew1ViewModel.BuildingDate.Day.ToString ( ) ,
                    ////////////////////                 DocumentTitle = uploadedFilesName[i].ToString(),// iDevelomentNew1ViewModel.BuildingDate.Month.ToString ( ) ,
                    ////////////////////                 DocumentExtension = uploadedFileExtension[i].ToString(),
                    ////////////////////                 DocumentCode = uploadedFileExtension[i].ToString(),
                    ////////////////////                 DocumentType = uploadedFileExtension[i].ToString(),
                    ////////////////////                 DocumentSize = uploadedFileSize[i].ToString(),//iDevelomentNew1ViewModel.BuildingDate.ToString ( ) ,

                    ////////////////////                 TimeoutYearCount = iTimeFrame,
                    ////////////////////                 UploadDateTimeMilliSec = AppUtility_TimeManager.Time_GetCurrentTimeInMilliSecond(),
                    ////////////////////                 IsVisible = true,
                    ////////////////////                 IsActive = true,

                    ////////////////////             };


                    ////////////////////             _dbContext.BsrvemcoUserBuildingDocumentLists.AddAsync(iInformationDocumentModel);

                    ////////////////////             _dbContext.SaveChangesAsync();


                    ////////////////////         }



                    ////////////////////         // Update-Scores

                    ////////////////////         string _iDocumentCount = _dbContext.BsrvemcoUserBuildingDocumentLists
                    ////////////////////.Where(
                    ////////////////////    c =>
                    ////////////////////    c.BuildingTokenId == iBuildingTokenID &&
                    ////////////////////    c.InformationTokenId == iInformationTokenID &&
                    ////////////////////    c.IsVisible == true)
                    ////////////////////.Count().ToString();


                    ////////////////////         var _iUserBuildignInfoModel = _dbContext.BsrvemcoUserBuildingInformationLists
                    ////////////////////                 .Where(u =>
                    ////////////////////                 u.BuildingTokenId == iBuildingTokenID &&
                    ////////////////////                 u.InformationTokenId == iInformationTokenID)
                    ////////////////////                 //.Select (u  )
                    ////////////////////                 .FirstOrDefault(); // This is what actually executes the request and return a response

                    ////////////////////         _iUserBuildignInfoModel.Score = "3";
                    ////////////////////         _iUserBuildignInfoModel.ScoreOriginal = "3";
                    ////////////////////         _iUserBuildignInfoModel.DocumentCount = _iDocumentCount;


                    ////////////////////         _dbContext.BsrvemcoUserBuildingInformationLists.Update(_iUserBuildignInfoModel);

                    ////////////////////         _dbContext.SaveChangesAsync();



                    return Json(new { status = true, Message = "Files Uploaded Successfully!" });


                }


                //////////if (files.Any())
                //////////{

                //////////    string wwwPath = _iEnvironment.WebRootPath;
                //////////    string contentPath = _iEnvironment.ContentRootPath;

                //////////    string path = Path.Combine(_iEnvironment.WebRootPath, "_iUMedia/_iUDocument");
                //////////    if (!Directory.Exists(path))
                //////////    {
                //////////        Directory.CreateDirectory(path);
                //////////    }


                //////////    List<string> uploadedFilesName = new List<string>();
                //////////    //List<string> uploadedFilesTokenID = new List<string> ( );
                //////////    List<string> uploadedFileExtension = new List<string>();
                //////////    List<string> uploadedFileSize = new List<string>();
                //////////    ArrayList _arrTokenList = new ArrayList();

                //////////    _arrTokenList = AppUtility_ListTokenIDManager.ListTokenID_Generate_NewList(files.Count.ToString());



                //////////    foreach (var file in files)
                //////////    {
                //////////        if (file.Length > 0)
                //////////        {
                //////////            //Getting FileName
                //////////            var _xFileName = Path.GetFileName(file.FileName);

                //////////            //Getting file Extension
                //////////            var _iFileExtension = (Path.GetExtension(_xFileName).ToLower().ToString()).Remove(0, 1); ;
                //////////            var _iFileSize = BytesToString(file.Length).ToString();

                //////////            //string fileName = Path.GetFileName ( iDevelomentNew1ViewModel.FUploadBuildingImage.FileName );
                //////////            string _iFileName = "doc_" + _arrTokenList[0] + "." + _iFileExtension;

                //////////            //await using var target = new MemoryStream ( );
                //////////            //await file.CopyToAsync ( target );
                //////////            //var physicalPath = $"{new PhysicalFileProvider ( Path.Combine ( Directory.GetCurrentDirectory ( ) , "wwwroot" , "UploadedFiles" ) ).Root}{$@"{fileName}"}";
                //////////            ////string filePath = $"/UploadedFiles/{fileName}";
                //////////            //await using FileStream fs = System.IO.File.Create ( path );
                //////////            //await file.CopyToAsync ( fs );
                //////////            //fs.Flush ( );

                //////////            using (FileStream stream = new FileStream(Path.Combine(path, _iFileName), FileMode.Create))
                //////////            {
                //////////                file.CopyTo(stream);

                //////////                uploadedFilesName.Add(_xFileName);
                //////////                //uploadedFilesTokenID.Add ( _xFileName );
                //////////                uploadedFileExtension.Add(_iFileExtension);
                //////////                uploadedFileSize.Add(_iFileSize);

                //////////            }



                //////////        }
                //////////    }




                //////////    // Save-Database
                //////////    BsrvemcoUserBuildingDocumentList iInformationDocumentModel;
                //////////    for (int i = 0; i < uploadedFilesName.Count; i++)
                //////////    {
                //////////        iInformationDocumentModel = new BsrvemcoUserBuildingDocumentList()
                //////////        {

                //////////            RowViewTokenId = new Guid(),


                //////////            OwnerUserTokenId = Program.iOwnerModel.OwnerUserTokenID,
                //////////            CompanyTokenId = Program.iOwnerModel.CompanyTokenID,

                //////////            ApptableTokenId = "1689022008239",
                //////////            BuildingTokenId = iBuildingTokenID,
                //////////            AppinformationTokenId = iAppinformationTokenID,
                //////////            InformationTokenId = iInformationTokenID,
                //////////            DocumentTokenId = _arrTokenList[i].ToString(),
                //////////            DocumentName = uploadedFilesName[i].ToString(),//iDevelomentNew1ViewModel.BuildingDate.Day.ToString ( ) ,
                //////////            DocumentTitle = uploadedFilesName[i].ToString(),// iDevelomentNew1ViewModel.BuildingDate.Month.ToString ( ) ,
                //////////            DocumentExtension = uploadedFileExtension[i].ToString(),
                //////////            DocumentCode = uploadedFileExtension[i].ToString(),
                //////////            DocumentType = uploadedFileExtension[i].ToString(),
                //////////            DocumentSize = uploadedFileSize[i].ToString(),//iDevelomentNew1ViewModel.BuildingDate.ToString ( ) ,
                //////////                                                          //FileTokenId = _iImageTokenID ,
                //////////                                                          //FileName = _iImageTokenID ,
                //////////                                                          //FileExtension = _iImageTokenID ,
                //////////                                                          //ImageTokenId = _arrTokenList[ 1 ].ToString ( ) ,
                //////////            TimeoutYearCount = iTimeFrame,
                //////////            UploadDateTimeMilliSec = AppUtility_TimeManager.Time_GetCurrentTimeInMilliSecond(),
                //////////            IsVisible = true,
                //////////            IsActive = true,

                //////////        };


                //////////        _dbContext.BsrvemcoUserBuildingDocumentLists.AddAsync(iInformationDocumentModel);

                //////////        _dbContext.SaveChangesAsync();


                //////////    }



                //////////    //////////         //Update-Scores

                //////////    //////////         string _iDocumentCount = _dbContext.BsrvemcoUserBuildingDocumentLists
                //////////    //////////.Where (
                //////////    //////////    c =>
                //////////    //////////    c.BuildingTokenId == iBuildingTokenID &&
                //////////    //////////    c.InformationTokenId == iInformationTokenID )
                //////////    //////////.Count ( ).ToString ( );


                //////////    //////////         var _iUserBuildignInfoModel = _dbContext.BsrvemcoUserBuildingInformationLists
                //////////    //////////                 .Where ( u =>
                //////////    //////////                 u.BuildingTokenId == iBuildingTokenID &&
                //////////    //////////                 u.InformationTokenId == iInformationTokenID )
                //////////    //////////                 //.Select (u  )
                //////////    //////////                 .FirstOrDefault ( ); // This is what actually executes the request and return a response

                //////////    //////////         _iUserBuildignInfoModel.Score = "3";
                //////////    //////////         _iUserBuildignInfoModel.ScoreOriginal = "3";
                //////////    //////////         _iUserBuildignInfoModel.DocumentCount = _iDocumentCount;


                //////////    //////////         _dbContext.BsrvemcoUserBuildingInformationLists.Update ( _iUserBuildignInfoModel );

                //////////    //////////         _dbContext.SaveChangesAsync ( );


                //////////    //string _iDocumentCount = _dbContext.BsrvemcoUserBuildingDocumentLists
                //////////    //  .Where (
                //////////    //      c =>
                //////////    //      c.BuildingTokenId == iBuildingTokenID &&
                //////////    //      c.InformationTokenId == iInformationTokenID )
                //////////    //  .Count ( ).ToString();


                //////////    return Json(new { status = true, Message = "Files Uploaded Successfully!" });
                //////////}


                return View();



            }
            catch (Exception ex)
            {
                AppUtility_DebugManager.Debug_Get_MessageText(ex.Message.ToString());
                return View();
            }

        }





        public async Task<IActionResult> UploadFiles_NOT_AVAILABLE(
                   string iInformationTokenID,
                   string iBuildingTokenID)
        {

            /* , IFormFile filedata*/


            // Save-Database

            try
            {

                var _arrInfomationDocumentList = _dbContext.BsrvemcoUserBuildingDocumentLists
                                  .Where(u =>
                                  u.BuildingTokenId == iBuildingTokenID &&
                                  u.InformationTokenId == iInformationTokenID &&
                   u.IsVisible ==true)
                                  //.Select (u  )
                                  //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                                  .ToList(); // This is what actually executes the request and return a response

                if (_arrInfomationDocumentList != null)
                {
                    for (int i = 0; i < _arrInfomationDocumentList.Count; i++)
                    {
                        _arrInfomationDocumentList[i].IsVisited= false;
                    }


                    _dbContext.BsrvemcoUserBuildingDocumentLists.UpdateRange(_arrInfomationDocumentList);

                    await _dbContext.SaveChangesAsync();


                }





                // Update-Scores

                //         string _iDocumentCount = _dbContext.BsrvemcoUserBuildingDocumentLists
                //.Where(
                //    c =>
                //    c.BuildingTokenId == iBuildingTokenID &&
                //    c.InformationTokenId == iInformationTokenID &&
                //    c.IsVisible == true)
                //.Count().ToString();


                var _iUserBuildignInfoModel = _dbContext.BsrvemcoUserBuildingInformationLists
                                .Where(u =>
                                u.BuildingTokenId == iBuildingTokenID &&
                                u.InformationTokenId == iInformationTokenID)
                                //.Select (u  )
                                .FirstOrDefault(); // This is what actually executes the request and return a response

                _iUserBuildignInfoModel.Score = "5";
                _iUserBuildignInfoModel.ScoreOriginal = "5";
                _iUserBuildignInfoModel.ScoreAdjusted = "5";
                _iUserBuildignInfoModel.ScoreManaged = "5";
                _iUserBuildignInfoModel.DocumentCount = "0";



                _iUserBuildignInfoModel.IsAnswered = true;
                _iUserBuildignInfoModel.AnswerCode="evidence_null";
                _iUserBuildignInfoModel.AnswerText="Nil return";
                _iUserBuildignInfoModel.AnswerDescription="0";



                _dbContext.BsrvemcoUserBuildingInformationLists.Update(_iUserBuildignInfoModel);

                await _dbContext.SaveChangesAsync();

                return Json(new { status = true, Message = "Files Uploaded Successfully!" });


                //    }
                //    catch (Exception ex)
                //    {
                //        AppUtility_DebugManager.Debug_Get_MessageText(ex.Message.ToString());

                //    }







                //return View();



            }
            catch (Exception ex)
            {
                AppUtility_DebugManager.Debug_Get_MessageText(ex.Message.ToString());
                return View();
            }

        }





















        public async Task saveDatabase_X1(string iAppinformationTokenID, string iInformationTokenID, string iBuildingTokenID, string iTimeFrame,
               List<string> uploadedFilesName,
        List<string> uploadedFileExtension,
        List<string> uploadedFileSize,
        ArrayList _arrTokenList)
        {



            // Save-Database

            //    Task.Run ( async ( ) =>
            //{
            //    await Initialize_AppTranslation ( );
            //} ).Wait ( );


            try
            {

                //await Task.Delay(10000);

                BsrvemcoUserBuildingDocumentList iInformationDocumentModel;
                for (int i = 0; i < uploadedFilesName.Count; i++)
                {
                    iInformationDocumentModel = new BsrvemcoUserBuildingDocumentList()
                    {

                        RowViewTokenId = new Guid(),


                        OwnerUserTokenId = Program.iOwnerModel.OwnerUserTokenID,
                        CompanyTokenId = Program.iOwnerModel.CompanyTokenID,

                        ApptableTokenId = "1689022008239",
                        BuildingTokenId = iBuildingTokenID,
                        AppinformationTokenId = iAppinformationTokenID,
                        InformationTokenId = iInformationTokenID,
                        DocumentTokenId = _arrTokenList[i].ToString(),
                        DocumentName = uploadedFilesName[i].ToString(),//iDevelomentNew1ViewModel.BuildingDate.Day.ToString ( ) ,
                        DocumentTitle = uploadedFilesName[i].ToString(),// iDevelomentNew1ViewModel.BuildingDate.Month.ToString ( ) ,
                        DocumentExtension = uploadedFileExtension[i].ToString(),
                        DocumentCode = uploadedFileExtension[i].ToString(),
                        DocumentType = uploadedFileExtension[i].ToString(),
                        DocumentSize = uploadedFileSize[i].ToString(),//iDevelomentNew1ViewModel.BuildingDate.ToString ( ) ,

                        TimeoutYearCount = iTimeFrame,
                        UploadDateTimeMilliSec = AppUtility_TimeManager.Time_GetCurrentTimeInMilliSecond(),
                        IsVisible = true,
                        IsActive = true,

                    };


                    _dbContext.BsrvemcoUserBuildingDocumentLists.AddAsync(iInformationDocumentModel);

                    _dbContext.SaveChangesAsync();


                }



                // Update-Scores

                string _iDocumentCount = _dbContext.BsrvemcoUserBuildingDocumentLists
       .Where(
           c =>
           c.BuildingTokenId == iBuildingTokenID &&
           c.InformationTokenId == iInformationTokenID &&
           c.IsVisible == true)
       .Count().ToString();


                var _iUserBuildignInfoModel = _dbContext.BsrvemcoUserBuildingInformationLists
                        .Where(u =>
                        u.BuildingTokenId == iBuildingTokenID &&
                        u.InformationTokenId == iInformationTokenID)
                        //.Select (u  )
                        .FirstOrDefault(); // This is what actually executes the request and return a response

                _iUserBuildignInfoModel.Score = "3";
                _iUserBuildignInfoModel.ScoreOriginal = "3";
                _iUserBuildignInfoModel.DocumentCount = _iDocumentCount;


                _dbContext.BsrvemcoUserBuildingInformationLists.Update(_iUserBuildignInfoModel);

                _dbContext.SaveChangesAsync();


                return;

            }
            catch (Exception ex)
            {
                AppUtility_DebugManager.Debug_Get_MessageText(ex.Message.ToString());
                return;

            }


        }



        static String BytesToString(long byteCount)
        {
            string[ ] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB
            if (byteCount == 0)
                return "0" + suf[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() + suf[place];
        }






        public async Task<IActionResult> GetCountDocumentList(string bldtknid, string inftknid)
        {                                    /* bool showPrevious , bool showUpcoming */

            try
            {
                string _iDocumentCount = _dbContext.BsrvemcoUserBuildingDocumentLists
             .Where(
                 c =>
                 c.BuildingTokenId == bldtknid &&
                 c.InformationTokenId == inftknid &&
                 c.IsVisible ==true)
             .Count().ToString();


                //Update-Scores

                //         string _iDocumentCount = _dbContext.BsrvemcoUserBuildingDocumentLists
                //.Where (
                //    c =>
                //    c.BuildingTokenId == bldtknid &&
                //    c.InformationTokenId == inftknid )
                //.Count ( ).ToString ( );


                var _iUserBuildignInfoModel = _dbContext.BsrvemcoUserBuildingInformationLists
                        .Where(u =>
                        u.BuildingTokenId == bldtknid &&
                        u.InformationTokenId == inftknid)
                        //.Select (u  )
                        .FirstOrDefault(); // This is what actually executes the request and return a response



                if (_iDocumentCount == "0")
                {

                    _iUserBuildignInfoModel.Score = "5";
                    _iUserBuildignInfoModel.ScoreOriginal = "5";
                    _iUserBuildignInfoModel.ScoreAdjusted = "5";
                    _iUserBuildignInfoModel.ScoreManaged = "5";
                    _iUserBuildignInfoModel.DocumentCount = "0";



                    _iUserBuildignInfoModel.IsAnswered = false;
                    _iUserBuildignInfoModel.AnswerCode="evidence_default";
                    _iUserBuildignInfoModel.AnswerText="Awaiting Evidence";
                    _iUserBuildignInfoModel.AnswerDescription="You will NOT able to generate a \"Gap Analysis Report\" untill you have responded.";

                }
                else
                {

                    _iUserBuildignInfoModel.Score = "3";
                    _iUserBuildignInfoModel.ScoreOriginal = "3";
                    _iUserBuildignInfoModel.DocumentCount = _iDocumentCount;


                    _iUserBuildignInfoModel.IsAnswered = true;
                    _iUserBuildignInfoModel.AnswerCode="evidence_upload";
                    _iUserBuildignInfoModel.AnswerText="Evidence has been uploaded and is awaiting verification";
                    _iUserBuildignInfoModel.AnswerDescription="0";



                }



                _dbContext.BsrvemcoUserBuildingInformationLists.Update(_iUserBuildignInfoModel);

                await _dbContext.SaveChangesAsync();








                return Json(new { count = _iDocumentCount });
                //   return Json ( new { count = "333" } );

            }
            catch (Exception ex)
            {
                AppUtility_DebugManager.Debug_Get_MessageText(ex.Message.ToString());
                return null;
            }



            //return ViewComponent ( "DocumentList" ,
            //    new { showPrevious = showPrevious , showUpcoming = showUpcoming } );


        }

        #endregion



        #region Building-Delete




        public async Task<IActionResult> Building_Delete_ByBuildingTokenID(string bldtknid)
        {                                    /* bool showPrevious , bool showUpcoming */

            try
            {

                var _iUserBulidingModel = _dbContext.BsrvemcoUserBuildingLists
             .Where(
                 c =>
                 c.BuildingTokenId == bldtknid)
             .FirstOrDefault();


                //Update-Scores
                _iUserBulidingModel.IsVisible = false;

                ////////         string _iDocumentCount = _dbContext.BsrvemcoUserBuildingDocumentLists
                ////////.Where (
                ////////    c =>
                ////////    c.BuildingTokenId == bldtknid &&
                ////////    c.InformationTokenId == inftknid )
                ////////.Count ( ).ToString ( );


                //////var _iUserBuildignInfoModel = _dbContext.BsrvemcoUserBuildingInformationLists
                //////        .Where ( u =>
                //////        u.BuildingTokenId == bldtknid &&
                //////        u.InformationTokenId == inftknid )
                //////        //.Select (u  )
                //////        .FirstOrDefault ( ); // This is what actually executes the request and return a response

                //////_iUserBuildignInfoModel.Score = "3";
                //////_iUserBuildignInfoModel.ScoreOriginal = "3";
                //////_iUserBuildignInfoModel.DocumentCount = _iDocumentCount;


                _dbContext.BsrvemcoUserBuildingLists.Update(_iUserBulidingModel);

                await _dbContext.SaveChangesAsync();


                return Json(new { status = true });

            }
            catch (Exception ex)
            {
                AppUtility_DebugManager.Debug_Get_MessageText(ex.Message.ToString());
                return null;
            }



            //return ViewComponent ( "DocumentList" ,
            //    new { showPrevious = showPrevious , showUpcoming = showUpcoming } );


        }



        #endregion









        #region Document-Delete




        public async Task<IActionResult> Document_Delete_ByDocumentTokenID(string doctknid)
        {                                    /* bool showPrevious , bool showUpcoming */

            try
            {

                var _iUserDocumentModel = _dbContext.BsrvemcoUserBuildingDocumentLists
             .Where(
                 c =>
                 c.DocumentTokenId == doctknid)
             .FirstOrDefault();


                //Update-Scores
                _iUserDocumentModel.IsVisible = false;

                ////////         string _iDocumentCount = _dbContext.BsrvemcoUserBuildingDocumentLists
                ////////.Where (
                ////////    c =>
                ////////    c.BuildingTokenId == bldtknid &&
                ////////    c.InformationTokenId == inftknid )
                ////////.Count ( ).ToString ( );


                //////var _iUserBuildignInfoModel = _dbContext.BsrvemcoUserBuildingInformationLists
                //////        .Where ( u =>
                //////        u.BuildingTokenId == bldtknid &&
                //////        u.InformationTokenId == inftknid )
                //////        //.Select (u  )
                //////        .FirstOrDefault ( ); // This is what actually executes the request and return a response

                //////_iUserBuildignInfoModel.Score = "3";
                //////_iUserBuildignInfoModel.ScoreOriginal = "3";
                //////_iUserBuildignInfoModel.DocumentCount = _iDocumentCount;


                _dbContext.BsrvemcoUserBuildingDocumentLists.Update(_iUserDocumentModel);

                await _dbContext.SaveChangesAsync();


                return Json(new { status = true });

            }
            catch (Exception ex)
            {
                AppUtility_DebugManager.Debug_Get_MessageText(ex.Message.ToString());
                return null;
            }



            //return ViewComponent ( "DocumentList" ,
            //    new { showPrevious = showPrevious , showUpcoming = showUpcoming } );


        }



        #endregion




        #region Document-Update




        public async Task<IActionResult> Document_Update_ByDocumentTokenID(
            string doctknid,
            string iday,
            //string idayname,
            string imonth,
            //string imonthname,
            string iyear,
            string iDateText,
            string idesc,
            string timeframe = "1")
        {


            try
            {

                string[ ] MonthFullName = { "January", "February", "March", "April", "May", "June",
                             "July", "August", "September", "October", "November", "December" };

                string[ ] MonthCode = { "JAN", "FEB", "MAR", "APR", "MAY", "JUN",
                             "JUL", "AUG", "SEP", "OCT", "NOV", "DEC" };

                //                const monthNames = ["January", "February", "March", "April", "May", "June",
                //  "July", "August", "September", "October", "November", "December"
                //];

                //                month_names: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
                //       month_names_short: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']

                //var months[11 ] = {"January", "February", "March", "April", "May", "June",
                //               "July", "August", "September", "October", "November", "December" };


                var _iUserDocumentModel = _dbContext.BsrvemcoUserBuildingDocumentLists
             .Where(
                 c =>
                 c.DocumentTokenId == doctknid)
             .FirstOrDefault();


                //Update-Scores

                string _strDateStartDay,
                    _strDateStartMonth,
                    _strDateStartMonthName,
                    _strDateStartYear,
                    _strDateTextStart,

                    _strDateEndDay,
                    _strDateEndMonth,
                    _strDateEndMonthName,
                    _strDateEndYear,
                    _strDateTextEnd;




                _strDateStartDay = iday.ToString();
                _strDateStartMonth = imonth.ToString();
                _strDateStartMonthName =MonthCode[Int32.Parse(imonth)-1]; //"Feb";
                _strDateStartYear = iyear.ToString();


                _strDateTextStart =   _strDateStartDay + _strDateStartMonthName + ", " + _strDateStartYear;


                //string dateInput = "Jan 1, 2009";
                //  var parsedDate = DateTime.Parse(iDateText);
                //var parsedDate = DateTime.Parse(iDateText);
                //string input = "29/3/2022";

                //string output = DateTime.Parse(input).ToString("ddMMyyyy");
                string day = "6";
                string month = "2";
                string year = "2023";

                DateTime output =
                 DateTime.ParseExact(day + "-" + month + "-" + year, "d-M-yyyy", CultureInfo.InvariantCulture);

                DateTime _valDateEnd = DateTime.Now;

                _valDateEnd = output.AddYears(Int32.Parse(timeframe));

                _strDateEndDay = _valDateEnd.Day.ToString();
                _strDateEndMonth = _valDateEnd.Month.ToString();
                _strDateEndMonthName = MonthCode[_valDateEnd.Month -1]; //"Feb";
                _strDateEndYear = _valDateEnd.Year.ToString();

                _strDateTextEnd = _strDateEndDay + _strDateEndMonthName + ", " + _strDateEndYear;



                _iUserDocumentModel.TimeoutUserUploadStartDay = _strDateStartDay;
                _iUserDocumentModel.TimeoutUserUploadStartMonth = _strDateStartMonth;
                _iUserDocumentModel.TimeoutUserUploadStartYear = _strDateStartYear;
                _iUserDocumentModel.TimeoutUserUploadStartText = _strDateTextStart;

                _iUserDocumentModel.TimeoutUserUploadEndDay = _strDateEndDay;
                _iUserDocumentModel.TimeoutUserUploadEndMonth =_strDateEndMonth;
                _iUserDocumentModel.TimeoutUserUploadEndYear = _strDateEndYear;
                _iUserDocumentModel.TimeoutUserUploadEndText = _strDateTextEnd;

                _iUserDocumentModel.DocumentDescription = idesc;

                //_iUserDocumentModel.IsVisible = false;
                //_iUserDocumentModel.IsVisible = false;
                //_iUserDocumentModel.IsVisible = false;
                //_iUserDocumentModel.IsVisible = false;
                //_iUserDocumentModel.IsVisible = false;
                //_iUserDocumentModel.IsVisible = false;

                ////////         string _iDocumentCount = _dbContext.BsrvemcoUserBuildingDocumentLists
                ////////.Where (
                ////////    c =>
                ////////    c.BuildingTokenId == bldtknid &&
                ////////    c.InformationTokenId == inftknid )
                ////////.Count ( ).ToString ( );


                //////var _iUserBuildignInfoModel = _dbContext.BsrvemcoUserBuildingInformationLists
                //////        .Where ( u =>
                //////        u.BuildingTokenId == bldtknid &&
                //////        u.InformationTokenId == inftknid )
                //////        //.Select (u  )
                //////        .FirstOrDefault ( ); // This is what actually executes the request and return a response

                //////_iUserBuildignInfoModel.Score = "3";
                //////_iUserBuildignInfoModel.ScoreOriginal = "3";
                //////_iUserBuildignInfoModel.DocumentCount = _iDocumentCount;


                _dbContext.BsrvemcoUserBuildingDocumentLists.Update(_iUserDocumentModel);

                await _dbContext.SaveChangesAsync();


                return Json(new { status = true });

            }
            catch (Exception ex)
            {
                AppUtility_DebugManager.Debug_Get_MessageText(ex.Message.ToString());
                return null;
            }



        }



        #endregion


        #region Report



        public IActionResult Report()
        {

            try
            {


                //AppDevelomentInformationReportViewModel 




                string id = Request.Query["bldtknid"].ToString();



                List<BsrvemcoUserBuildingInformationList>? _arrUserBuildingInfomationList = _dbContext.BsrvemcoUserBuildingInformationLists
                    .Where(u =>
                    u.BuildingTokenId == id &&
                    u.ApptableTokenId == "1689022008239" &&
                    //u.DocumentCount
                    u.IsVisible== true)
                     //.Select (u  )
                     //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                     .ToList(); // This is what actually executes the request and return a response







                AppDevelomentInformationReportViewModel iDevelomentInformationReportViewModel = new AppDevelomentInformationReportViewModel();
                List<AppUserBuildingInformationModelManager> _arrBuildingInformationModelList = new List<AppUserBuildingInformationModelManager>();


                AppUserBuildingInformationModelManager _iUserBuildingInformationModel;
                for (int i = 0; i < _arrUserBuildingInfomationList.Count; i++)
                {
                    _iUserBuildingInformationModel = new AppUserBuildingInformationModelManager()
                    {
                        AppTableTokenID = _arrUserBuildingInfomationList[i].ApptableTokenId.ToString(),
                        TableTokenID = _arrUserBuildingInfomationList[i].ApptableTokenId.ToString(),
                        APPInformationTokenID = _arrUserBuildingInfomationList[i].AppinformationTokenId.ToString(),
                        BuildingTokenID = id.ToString(),
                        InformationText = _arrUserBuildingInfomationList[i].InformationText.ToString(),
                        IsAnswered = (bool)_arrUserBuildingInfomationList[i].IsAnswered,
                        AnswerCode = _arrUserBuildingInfomationList[i].AnswerCode.ToString(),
                        AnswerText = _arrUserBuildingInfomationList[i].AnswerText.ToString(),
                        AnswerDescription = _arrUserBuildingInfomationList[i].AnswerDescription.ToString(),
                        //InformationTokenID = _arrUserBuildingInfomationList[i].InformationTokenId.ToString(),
                        //InformationScore = _arrUserBuildingInfomationList[i].Score,
                        //InformationScoreAdjusted = _arrUserBuildingInfomationList[i].ScoreAdjusted,
                        DocumentCount = _arrUserBuildingInfomationList[i].DocumentCount,
                        //TimeFrame = _arrUserBuildingInfomationList[i].TimeoutYearCount
                    };

                    if (_iUserBuildingInformationModel.AnswerCode== "evidence_default")
                    {
                        _iUserBuildingInformationModel.TitleColor="black";
                        _iUserBuildingInformationModel.TextColor="gray";
                        _iUserBuildingInformationModel.TextDescriptionColor="black";

                        _iUserBuildingInformationModel.RowBackgroundColor="white";
                        _iUserBuildingInformationModel.IsViewTooltip=true;
                    }
                    else
                    {

                        _iUserBuildingInformationModel.TitleColor="white";
                        _iUserBuildingInformationModel.TextColor="whitesmoke";
                        _iUserBuildingInformationModel.TextDescriptionColor="whitesmoke";


                        _iUserBuildingInformationModel.RowBackgroundColor="green";
                    }

                    _arrBuildingInformationModelList.Add(_iUserBuildingInformationModel);
                }






                iDevelomentInformationReportViewModel.BuildingInformationList = _arrBuildingInformationModelList;



                return View(iDevelomentInformationReportViewModel);



            }
            catch (Exception ex)
            {
                AppUtility_DebugManager.Debug_Get_MessageText(ex.Message.ToString());
                return null;
            }




        }



        #endregion



        #region Query


        public async Task<IActionResult> Query()
        {



            try
            {

                string id = Request.Query["bldtknid"].ToString();


                List<BsrvemcoUserBuildingQueryInformationTableList>? _arrCheckCountUserBuildingQueryInfomationTableList = _dbContext.BsrvemcoUserBuildingQueryInformationTableLists
                .Where(u =>
                u.BuildingTokenId == id &&
                u.IsVisible == true)
                 //.Select (u  )
                 //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                 .ToList(); // This is what actually executes the request and return a response



                if (_arrCheckCountUserBuildingQueryInfomationTableList.Count == 0)
                {

                    List<BsrvemcoAppBuildingQueryTableList>? _arrAppDevelomentQueryTableList = _dbContext.BsrvemcoAppBuildingQueryTableLists
                         .Where(u => u.AppqueryTableCode == "item")
                         //.Select (u  )
                         //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                         .ToList(); // This is what actually executes the request and return a response


                    ArrayList _arrTokenList = new ArrayList();
                    _arrTokenList = AppUtility_ListTokenIDManager.ListTokenID_Generate_NewList(_arrAppDevelomentQueryTableList.Count.ToString());



                    ////////////////////////////////////////

                    BsrvemcoUserBuildingQueryInformationTableList iBuildingQueryTableModel;

                    for (int i = 0; i < _arrAppDevelomentQueryTableList.Count; i++)
                    {


                        iBuildingQueryTableModel = new BsrvemcoUserBuildingQueryInformationTableList()
                        {

                            RowViewTokenId = new Guid(),


                            OwnerUserTokenId = Program.iOwnerModel.OwnerUserTokenID,
                            CompanyTokenId = Program.iOwnerModel.CompanyTokenID,
                            BuildingTokenId = id,

                            AppqueryTableTokenId = _arrAppDevelomentQueryTableList[i].AppqueryTableTokenId.ToString(),
                            AppqueryTableCode = "item",

                            QueryTableTokenId = _arrTokenList[i].ToString(),

                            QueryTableName = _arrAppDevelomentQueryTableList[i].QueryTableName.ToString(),

                            IsPaging = (bool)_arrAppDevelomentQueryTableList[i].IsPaging,

                            PageSize = _arrAppDevelomentQueryTableList[i].PageSize,
                            PageCount = _arrAppDevelomentQueryTableList[i].PageCount,
                            PageNumber = _arrAppDevelomentQueryTableList[i].PageNumber,


                            IsViewed=false,
                            IsAnswered=false,

                            //TimeoutYearCount=  _arrAppDevelomentQueryTableList[i].TimeoutYearCount.ToString(),

                            //InformationScore = "5",
                            //Score = "5",
                            //ScoreManaged = "5",
                            //ScoreAdjusted = "5",
                            //ScoreOriginal = "5",


                            UploadDateTimeMilliSec = AppUtility_TimeManager.Time_GetCurrentTimeInMilliSecond(),
                            IsVisible = true,
                            IsActive = true,

                        };


                        await _dbContext.BsrvemcoUserBuildingQueryInformationTableLists.AddAsync(iBuildingQueryTableModel);


                        await _dbContext.SaveChangesAsync();


                    }


                }






































                List<BsrvemcoUserBuildingQueryInformationTableList>? _arrUserBuildingInfomationList = _dbContext.BsrvemcoUserBuildingQueryInformationTableLists
                    .Where(u =>
                    u.BuildingTokenId == id &&
                    //u.ApptableTokenId == "1689022008239" &&
                    u.IsVisible == true)
                     //.Select (u  )
                     //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                     .ToList(); // This is what actually executes the request and return a response







                AppDevelomentInformationQueryViewModel iDevelomentNew2ViewModel = new AppDevelomentInformationQueryViewModel();
                List<AppUserBuildingQueryInformationTableModelManager> _arrBuildingInformationModelList = new List<AppUserBuildingQueryInformationTableModelManager>();


                AppUserBuildingQueryInformationTableModelManager _iUserBuildingInformationModel;
                for (int i = 0; i < _arrUserBuildingInfomationList.Count; i++)
                {
                    _iUserBuildingInformationModel = new AppUserBuildingQueryInformationTableModelManager()
                    {
                        AppQueryTableTokenID = _arrUserBuildingInfomationList[i].AppqueryTableTokenId.ToString(),
                        QueryTableTokenID = _arrUserBuildingInfomationList[i].QueryTableTokenId.ToString(),
                        QueryTableName = _arrUserBuildingInfomationList[i].QueryTableName.ToString(),
                        BuildingTokenID = id.ToString(),

                        IsPaging = (bool)_arrUserBuildingInfomationList[i].IsPaging,

                        PageSize = _arrUserBuildingInfomationList[i].PageSize,
                        PageCount = _arrUserBuildingInfomationList[i].PageCount,
                        PageNumber = _arrUserBuildingInfomationList[i].PageNumber,

                        IsViewed = (bool)_arrUserBuildingInfomationList[i].IsViewed,
                        IsAnswered = (bool)_arrUserBuildingInfomationList[i].IsAnswered,

                        // InformationScoreAdjusted = _arrUserBuildingInfomationList[i].ScoreAdjusted,
                        //DocumentCount = _arrUserBuildingInfomationList[i].DocumentCount,
                        //TimeFrame = _arrUserBuildingInfomationList[i].TimeoutYearCount
                    };

                    if (!_iUserBuildingInformationModel.IsViewed)
                    {
                        _iUserBuildingInformationModel.ImageURL="img_circle_black.png";
                        _iUserBuildingInformationModel.FontStyle="bold";
                    }
                    else
                    {
                        _iUserBuildingInformationModel.FontStyle="normal";

                        //_iUserBuildingInformationModel. ImageURL="img_circle_black.png";

                        if (!_iUserBuildingInformationModel.IsAnswered)
                        {
                            _iUserBuildingInformationModel.ImageURL="img_question_circle_black.png";
                        }
                        else
                        {
                            _iUserBuildingInformationModel.ImageURL="img_check_circle_black.png";
                        }

                    }

                    _arrBuildingInformationModelList.Add(_iUserBuildingInformationModel);
                }



                iDevelomentNew2ViewModel.BuildingInformationQueryTableList = _arrBuildingInformationModelList;


                return View(iDevelomentNew2ViewModel);

            }
            catch (Exception ex)
            {
                AppUtility_DebugManager.Debug_Get_MessageText(ex.Message.ToString());
                return null;
            }




            //try
            //{



            //    return View();


            //}
            //catch (Exception ex)
            //{
            //    AppUtility_DebugManager.Debug_Get_MessageText(ex.Message.ToString());
            //    return null;
            //}



        }

        #endregion


        //public IActionResult View ( )
        //{
        //    return View ( );
        //}







        #region ViewComponents




        public IActionResult ReloadDocumentList(string bldtknid, string inftknid)
        {                                    /* bool showPrevious , bool showUpcoming */

            return ViewComponent("DocumentList",
                new
                {
                    bldtknid = bldtknid,
                    inftknid = inftknid
                });



        }





        public IActionResult ReloadQueryDocumentList(string bldtknid, string iqueryinftknid)
        {                                    /* bool showPrevious , bool showUpcoming */

            return ViewComponent("QueryDocumentList",
                new
                {
                    bldtknid = bldtknid,
                    iqueryinftknid = iqueryinftknid
                });

            //return ViewComponent ( "DocumentList" ,
            //    new { showPrevious = showPrevious , showUpcoming = showUpcoming } );


        }




        public IActionResult ReloadQueryFormTableDocumentList(string bldtknid, string iqueryinftknid)
        {                                    /* bool showPrevious , bool showUpcoming */

            return ViewComponent("QueryFormTableDocumentList",
                new
                {
                    bldtknid = bldtknid,
                    iqueryinftknid = iqueryinftknid
                });

            //return ViewComponent ( "DocumentList" ,
            //    new { showPrevious = showPrevious , showUpcoming = showUpcoming } );


        }



        public IActionResult ReloadQueryFormList(string bldtknid, string querytbltknid, string iPageNumber, string blnIsPaging)
        {                                    /* bool showPrevious , bool showUpcoming */

            return ViewComponent("BuildingQueryFormList",
                new
                {
                    bldtknid = bldtknid,
                    querytbltknid = querytbltknid,
                    iPageNumber = iPageNumber,
                    blnIsPaging = Boolean.Parse(blnIsPaging)
                });

            //return ViewComponent ( "DocumentList" ,
            //    new { showPrevious = showPrevious , showUpcoming = showUpcoming } );


        }
        #endregion



        #region QueryForm-Answers


        public async Task<IActionResult> QueryForm_Answer_NULL(
     string iAppQueryTableTokenID,
     string iAppQueryInformationTokenID,
     string iQueryTableTokenID,
     string iQueryInformationTokenID,
     string iBuildingTokenID,
     string iAnswerCode,
     string iAnswerText)
        {

            /* , IFormFile filedata*/


            try
            {


                // Update-Scores

                //         string _iDocumentCount = _dbContext.BsrvemcoUserBuildingDocumentLists
                //.Where(
                //    c =>
                //    c.BuildingTokenId == iBuildingTokenID &&
                //    c.InformationTokenId == iInformationTokenID &&
                //    c.IsVisible == true)
                //.Count().ToString();


                var _iUserBuildignQueryInfoModel = _dbContext.BsrvemcoUserBuildingQueryInformationLists
                        .Where(u =>
                        u.BuildingTokenId == iBuildingTokenID &&
                        u.QueryInformationTokenId == iQueryInformationTokenID)
                        //.Select (u  )
                        .FirstOrDefault(); // This is what actually executes the request and return a response

                _iUserBuildignQueryInfoModel.AnswerCode = "null";
                _iUserBuildignQueryInfoModel.AnswerText = iAnswerText;
                _iUserBuildignQueryInfoModel.InformationDescriptionUser = iAnswerText;



                _iUserBuildignQueryInfoModel.IsViewed = true;
                _iUserBuildignQueryInfoModel.IsVisited = true;
                _iUserBuildignQueryInfoModel.IsOpened = true;
                _iUserBuildignQueryInfoModel.IsAnswered = true;

                //_iUserBuildignQueryInfoModel.ScoreAdjusted = "3";
                //_iUserBuildignQueryInfoModel.ScoreManaged = "3";
                //_iUserBuildignQueryInfoModel.DocumentCount = _iDocumentCount;



                //_iUserBuildignQueryInfoModel.IsAnswered = true;
                //_iUserBuildignQueryInfoModel.AnswerCode="evidence_upload";
                //_iUserBuildignQueryInfoModel.AnswerText="Evidence has been uploaded and is awaiting verification";
                //_iUserBuildignQueryInfoModel.AnswerDescription="0";


                _dbContext.BsrvemcoUserBuildingQueryInformationLists.Update(_iUserBuildignQueryInfoModel);

                await _dbContext.SaveChangesAsync();

                // DELETE ALL LINKS

                var _arrBuildignQueryDocumentList = _dbContext.BsrvemcoUserBuildingQueryDocumentLists
                         .Where(u =>
                                    u.BuildingTokenId == iBuildingTokenID &&
                                    u.QueryInformationTokenId == iQueryInformationTokenID &&
                                    u.IsVisible ==true)
                                    //.Select (u  )
                                    //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                                    .ToList(); // This is what actually executes the request and return a response


                for (int i = 0; i < _arrBuildignQueryDocumentList.Count(); i++)
                {
                    _arrBuildignQueryDocumentList[i].IsVisible = false;
                }

                //_iUserBuildignQueryInfoModel.AnswerCode = "null";
                //_iUserBuildignQueryInfoModel.AnswerText = iAnswerText;
                //_iUserBuildignQueryInfoModel.InformationDescriptionUser = iAnswerText;

                //_iUserBuildignQueryInfoModel.ScoreAdjusted = "3";
                //_iUserBuildignQueryInfoModel.ScoreManaged = "3";
                //_iUserBuildignQueryInfoModel.DocumentCount = _iDocumentCount;



                //_iUserBuildignQueryInfoModel.IsAnswered = true;
                //_iUserBuildignQueryInfoModel.AnswerCode="evidence_upload";
                //_iUserBuildignQueryInfoModel.AnswerText="Evidence has been uploaded and is awaiting verification";
                //_iUserBuildignQueryInfoModel.AnswerDescription="0";


                _dbContext.BsrvemcoUserBuildingQueryDocumentLists.UpdateRange(_arrBuildignQueryDocumentList);

                await _dbContext.SaveChangesAsync();



                return Json(new { status = true, Message = "Files Uploaded Successfully!" });


                //return View();



            }
            catch (Exception ex)
            {
                AppUtility_DebugManager.Debug_Get_MessageText(ex.Message.ToString());
                return View();
            }

        }





        public async Task<IActionResult> QueryForm_Answer_YES_NO(
     string iAppQueryTableTokenID,
     string iAppQueryInformationTokenID,
     string iQueryTableTokenID,
     string iQueryInformationTokenID,
     string iBuildingTokenID,
     string iAnswerCode,
     string iAnswerText)
        {

            /* , IFormFile filedata*/


            try
            {


                // Update-Scores

                //         string _iDocumentCount = _dbContext.BsrvemcoUserBuildingDocumentLists
                //.Where(
                //    c =>
                //    c.BuildingTokenId == iBuildingTokenID &&
                //    c.InformationTokenId == iInformationTokenID &&
                //    c.IsVisible == true)
                //.Count().ToString();


                var _iUserBuildignQueryInfoModel = _dbContext.BsrvemcoUserBuildingQueryInformationLists
                        .Where(u =>
                        u.BuildingTokenId == iBuildingTokenID &&
                        u.QueryInformationTokenId == iQueryInformationTokenID)
                        //.Select (u  )
                        .FirstOrDefault(); // This is what actually executes the request and return a response

                _iUserBuildignQueryInfoModel.AnswerCode = iAnswerCode;


                if (iAnswerText!= "0")
                {

                    _iUserBuildignQueryInfoModel.AnswerText = iAnswerText;
                    _iUserBuildignQueryInfoModel.InformationDescriptionUser = iAnswerText;

                }

                _iUserBuildignQueryInfoModel.IsViewed = true;
                _iUserBuildignQueryInfoModel.IsVisited = true;
                _iUserBuildignQueryInfoModel.IsOpened = true;
                _iUserBuildignQueryInfoModel.IsAnswered = true;



                //_iUserBuildignQueryInfoModel.ScoreAdjusted = "3";
                //_iUserBuildignQueryInfoModel.ScoreManaged = "3";
                //_iUserBuildignQueryInfoModel.DocumentCount = _iDocumentCount;



                //_iUserBuildignQueryInfoModel.IsAnswered = true;
                //_iUserBuildignQueryInfoModel.AnswerCode="evidence_upload";
                //_iUserBuildignQueryInfoModel.AnswerText="Evidence has been uploaded and is awaiting verification";
                //_iUserBuildignQueryInfoModel.AnswerDescription="0";


                _dbContext.BsrvemcoUserBuildingQueryInformationLists.Update(_iUserBuildignQueryInfoModel);

                await _dbContext.SaveChangesAsync();



                return Json(new { status = true, Message = "Files Uploaded Successfully!" });


                //return View();



            }
            catch (Exception ex)
            {
                AppUtility_DebugManager.Debug_Get_MessageText(ex.Message.ToString());
                return View();
            }

        }




        #endregion



    }


}
