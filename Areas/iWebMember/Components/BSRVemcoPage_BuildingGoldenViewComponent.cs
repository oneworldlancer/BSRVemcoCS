using BSRVemcoCS.DBContext;
using BSRVemcoCS.DBModels;
using BSRVemcoCS.iApp_Identity;
using BSRVemcoCS.iAppManager;
using BSRVemcoCS.iAppUtility;
using BSRVemcoCS.iAppViewModel;
using BSRVemcoCS.Models;

using DocumentFormat.OpenXml.Office2010.Excel;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;

using System.Collections;

namespace BSRVemcoCS.Areas.iWebMember.Components
{
    public class BSRVemcoPage_BuildingGoldenViewComponent : ViewComponent
    {
        private readonly BSRDBModelContext _dbContext;


        private readonly UserManager<AppCore_IdentityUser> iUserManager;
        private readonly SignInManager<AppCore_IdentityUser> iSignManager;


        //List<SocialIcon> socialIcons = new List<SocialIcon> ( );
        public BSRVemcoPage_BuildingGoldenViewComponent(BSRDBModelContext dbContext,
            UserManager<AppCore_IdentityUser> iUserManager,
                        SignInManager<AppCore_IdentityUser> iSignManager)
        {
            //socialIcons = SocialIcon.AppSocialIcons ( );
            _dbContext = dbContext;
            this.iUserManager = iUserManager;
            this.iSignManager = iSignManager;

        }

        public async Task<IViewComponentResult> InvokeAsync(string iBuildingTokenID)
        {

            //string bldtknid,  string querytbltknid, string iPageNumber, bool blnIsPaging

            try
            {



                //string id = Request.Query["bldtknid"].ToString();



                // string id = HttpContext.Request.RouteValues[ "bldtknid" ].ToString ( );


                List<BsrvemcoUserBuildingInformationList>? _arrCheckCountUserBuildingInfomationList = _dbContext.BsrvemcoUserBuildingInformationLists
                .Where(u =>
                u.BuildingTokenId == iBuildingTokenID &&
                u.ApptableTokenId == "1689022008239" &&
                u.IsVisible == true)
                 //.Select (u  )
                 //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                 .ToList(); // This is what actually executes the request and return a response


                // Fill Database- InfoList
                if (_arrCheckCountUserBuildingInfomationList.Count == 0)
                {

                    List<BsrvemcoAppBuildingInformationList>? _arrAppDevelomentInfomationList = _dbContext.BsrvemcoAppBuildingInformationLists
                        .Where ( u => u.IsVisible == true )
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
                            BuildingTokenId = iBuildingTokenID,

                            ApptableTokenId = _arrAppDevelomentInfomationList[i].ApptableTokenId.ToString(),
                            AppinformationTokenId = _arrAppDevelomentInfomationList[i].AppinformationTokenId.ToString(),
                            InformationTokenId = _arrTokenList[i].ToString(),
                            
                            InformationCode= _arrAppDevelomentInfomationList[i].InformationCode.ToString(),
                            InformationType= _arrAppDevelomentInfomationList[i].InformationType.ToString(),
                          
                            InformationName= _arrAppDevelomentInfomationList[i].InformationName.ToString(),
                            InformationText = _arrAppDevelomentInfomationList[i].InformationText.ToString(),
                            InformationTitle = _arrAppDevelomentInfomationList[i].InformationTitle.ToString(),
                            InformationDescription = _arrAppDevelomentInfomationList[i].InformationDescription.ToString(),

                            AppqueryTableTokenId= _arrAppDevelomentInfomationList[i].AppqueryTableTokenId.ToString(),
                            AppqueryInformationTokenId= _arrAppDevelomentInfomationList[i].AppqueryInformationTokenId.ToString(),
                            QueryInformationTokenId = _arrTokenList[i].ToString(),

                            //InformationTextSystem = _arrAppDevelomentInfomationList[i].InformationText.ToString(),
                            //InformationTitleSystem = _arrAppDevelomentInfomationList[i].InformationTitle.ToString(),
                            //InformationDescriptionSystem = _arrAppDevelomentInfomationList[i].InformationDescription.ToString(),



                            //InformationTextUser = _arrAppDevelomentInfomationList[i].InformationTextUser.ToString(),
                            //InformationTitleUser = _arrAppDevelomentInfomationList[i].InformationTitle.ToString(),
                            //InformationDescriptionUser = _arrAppDevelomentInfomationList[i].InformationDescriptionUser.ToString(),



                            Commentary = _arrAppDevelomentInfomationList[i].Commentary.ToString(),


                            TimeframeYearCount=  _arrAppDevelomentInfomationList[i].TimeframeYearCount.ToString(),
                            TimeframeMonthCount=  _arrAppDevelomentInfomationList[i].TimeframeMonthCount.ToString(),
                         
                            IsWithSurvey=  _arrAppDevelomentInfomationList[i].IsWithSurvey,
                            IsCheckOneTime=  _arrAppDevelomentInfomationList[i].IsCheckOneTime,

                            InformationButtonText="Negative",
                            InformationButtonStyleCss="red",

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





























                //         return ViewComponent("BuildingPage2List",
                //new
                //{
                //    bldtknid = id,
                //    iPageNumber = "0",
                //    blnIsPaging = true
                //});



                /////////////////////////////////////////////////////



                //////////// Golden-Thread-Documents
                //////////List<BsrvemcoUserBuildingInformationList>? _arrUserBuildingInfomationList = _dbContext.BsrvemcoUserBuildingInformationLists
                //////////    .Where(u =>
                //////////    u.BuildingTokenId == id
                //////////    && u.ApptableTokenId == "1689022008239" &&
                //////////    u.IsVisible== true)
                //////////     //.Select (u  )
                //////////     //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                //////////     .ToList(); // This is what actually executes the request and return a response







                AppDevelomentNew2ViewModel iDevelomentNew2ViewModel = new AppDevelomentNew2ViewModel();
                //////////List<AppUserBuildingInformationModelManager> _arrBuildingInformationModelList = new List<AppUserBuildingInformationModelManager>();


                //////////AppUserBuildingInformationModelManager _iUserBuildingInformationModel;
                //////////for (int i = 0; i < _arrUserBuildingInfomationList.Count; i++)
                //////////{
                //////////    _iUserBuildingInformationModel = new AppUserBuildingInformationModelManager()
                //////////    {
                //////////        AppTableTokenID = _arrUserBuildingInfomationList[i].ApptableTokenId.ToString(),
                //////////        TableTokenID = _arrUserBuildingInfomationList[i].ApptableTokenId.ToString(),
                //////////        APPInformationTokenID = _arrUserBuildingInfomationList[i].AppinformationTokenId.ToString(),
                //////////        BuildingTokenID = id.ToString(),
                //////////        InformationText = _arrUserBuildingInfomationList[i].InformationText.ToString(),
                //////////        InformationTokenID = _arrUserBuildingInfomationList[i].InformationTokenId.ToString(),
                //////////        InformationScore = _arrUserBuildingInfomationList[i].Score,
                //////////        InformationScoreAdjusted = _arrUserBuildingInfomationList[i].ScoreAdjusted,
                //////////        DocumentCount = _arrUserBuildingInfomationList[i].DocumentCount,
                //////////        TimeFrame = _arrUserBuildingInfomationList[i].TimeoutYearCount
                //////////    };



                //////////    if (_arrUserBuildingInfomationList[i].AnswerCode == "evidence_null")
                //////////    {
                //////////        _iUserBuildingInformationModel.AnswerNULLButtonCSS="btn-secondary";
                //////////    }
                //////////    else
                //////////    {
                //////////        _iUserBuildingInformationModel.AnswerNULLButtonCSS="btn-outline-secondary";
                //////////    }


                //////////    _arrBuildingInformationModelList.Add(_iUserBuildingInformationModel);
                //////////}








                ///////////////////////////////////////////////////
                //////////// Table-2

                //////////List<BsrvemcoUserBuildingInformationList>? _arrUserBuildingTable2_InfomationList = _dbContext.BsrvemcoUserBuildingInformationLists
                //////////     .Where(u =>
                //////////     u.ApptableTokenId == "1689162197100" &&
                //////////     u.BuildingTokenId == id &&
                //////////     u.IsVisible == true)
                //////////     //.Select (u  )
                //////////     //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                //////////     .ToList(); // This is what actually executes the request and return a response




                //////////for (int i = 0; i < _arrUserBuildingTable2_InfomationList.Count; i++)
                //////////{
                //////////    _iUserBuildingInformationModel = new AppUserBuildingInformationModelManager()
                //////////    {
                //////////        AppTableTokenID = _arrUserBuildingTable2_InfomationList[i].ApptableTokenId.ToString(),
                //////////        TableTokenID = _arrUserBuildingTable2_InfomationList[i].ApptableTokenId.ToString(),
                //////////        APPInformationTokenID = _arrUserBuildingTable2_InfomationList[i].AppinformationTokenId.ToString(),
                //////////        BuildingTokenID = id.ToString(),
                //////////        InformationText = _arrUserBuildingTable2_InfomationList[i].InformationText.ToString(),
                //////////        InformationTokenID = _arrUserBuildingTable2_InfomationList[i].InformationTokenId.ToString(),
                //////////        InformationScore = _arrUserBuildingTable2_InfomationList[i].Score,
                //////////        InformationScoreAdjusted = _arrUserBuildingTable2_InfomationList[i].ScoreAdjusted,
                //////////        DocumentCount = _arrUserBuildingTable2_InfomationList[i].DocumentCount,
                //////////        TimeFrame = _arrUserBuildingTable2_InfomationList[i].TimeoutYearCount
                //////////    };


                //////////    if (_arrUserBuildingTable2_InfomationList[i].AnswerCode == "evidence_null")
                //////////    {
                //////////        _iUserBuildingInformationModel.AnswerNULLButtonCSS="btn-secondary";
                //////////    }
                //////////    else
                //////////    {
                //////////        _iUserBuildingInformationModel.AnswerNULLButtonCSS="btn-outline-secondary";
                //////////    }

                //////////    _arrBuildingInformationModelList.Add(_iUserBuildingInformationModel);
                //////////}






                //////////iDevelomentNew2ViewModel.BuildingInformationList = _arrBuildingInformationModelList;

                iDevelomentNew2ViewModel.BuildingTokenID= iBuildingTokenID;

                return await Task.FromResult((IViewComponentResult)View("Default", iDevelomentNew2ViewModel));
            }
            catch (Exception ex)
            {
                AppUtility_DebugManager.Debug_Get_MessageText(ex.Message.ToString());
                return null;
            }









        }



    }
}
