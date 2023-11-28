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
    public class BSRVemcoPage_BuildingGapViewComponent : ViewComponent
    {
        private readonly BSRDBModelContext _dbContext;


        private readonly UserManager<AppCore_IdentityUser> iUserManager;
        private readonly SignInManager<AppCore_IdentityUser> iSignManager;


        //List<SocialIcon> socialIcons = new List<SocialIcon> ( );
        public BSRVemcoPage_BuildingGapViewComponent(BSRDBModelContext dbContext,
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



                List<BsrvemcoUserBuildingInformationList>? _arrUserBuildingInfomationList = _dbContext.BsrvemcoUserBuildingInformationLists
                    .Where(u =>
                    u.BuildingTokenId == iBuildingTokenID &&
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
                        BuildingTokenID = iBuildingTokenID,
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
                iDevelomentInformationReportViewModel.BuildingInformationList1 = _arrBuildingInformationModelList.Take(11).ToList();
                iDevelomentInformationReportViewModel.BuildingInformationList2 = _arrBuildingInformationModelList.Skip(11).Take(9).ToList();


                return await Task.FromResult((IViewComponentResult)View("Default", iDevelomentInformationReportViewModel));

            }
            catch (Exception ex)
            {
                AppUtility_DebugManager.Debug_Get_MessageText(ex.Message.ToString());
                return null;
            }









        }



    }
}
