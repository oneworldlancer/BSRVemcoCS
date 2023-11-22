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
    public class BSRVemcoPage_BuildingResidentViewComponent : ViewComponent
    {
        private readonly BSRDBModelContext _dbContext;


        private readonly UserManager<AppCore_IdentityUser> iUserManager;
        private readonly SignInManager<AppCore_IdentityUser> iSignManager;


        //List<SocialIcon> socialIcons = new List<SocialIcon> ( );
        public BSRVemcoPage_BuildingResidentViewComponent(BSRDBModelContext dbContext,
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


                List<BsrvemcoUserBuildingQueryInformationTableList>? _arrCheckCountUserBuildingQueryInfomationTableList = _dbContext.BsrvemcoUserBuildingQueryInformationTableLists
                .Where(u =>
                u.BuildingTokenId == iBuildingTokenID &&
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
                            BuildingTokenId = iBuildingTokenID,

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
                    u.BuildingTokenId == iBuildingTokenID &&
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
                        BuildingTokenID = iBuildingTokenID,

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
