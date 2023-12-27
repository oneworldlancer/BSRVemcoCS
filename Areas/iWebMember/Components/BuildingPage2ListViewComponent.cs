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
    public class BuildingPage2ListViewComponent : ViewComponent
    {
        private readonly BSRDBModelContext _dbContext;


        private readonly UserManager<AppCore_IdentityUser> iUserManager;
        private readonly SignInManager<AppCore_IdentityUser> iSignManager;


        //List<SocialIcon> socialIcons = new List<SocialIcon> ( );
        public BuildingPage2ListViewComponent(BSRDBModelContext dbContext,
            UserManager<AppCore_IdentityUser> iUserManager,
                        SignInManager<AppCore_IdentityUser> iSignManager)
        {
            //socialIcons = SocialIcon.AppSocialIcons ( );
            _dbContext = dbContext;
            this.iUserManager = iUserManager;
            this.iSignManager = iSignManager;

        }

        public async Task<IViewComponentResult> InvokeAsync(string bldtknid, string iPageNumber, bool blnIsPaging)
        {



            try
            {






                // Golden-Thread-Documents
                List<BsrvemcoUserBuildingInformationList>? _arrUserBuildingInfomationList = _dbContext.BsrvemcoUserBuildingInformationLists
                    .Where(u =>
                    u.BuildingTokenId == bldtknid
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
                        BuildingTokenID = bldtknid.ToString(),
                        InformationText = _arrUserBuildingInfomationList[i].InformationText.ToString(),
                        InformationTokenID = _arrUserBuildingInfomationList[i].InformationTokenId.ToString(),
                        InformationScore = _arrUserBuildingInfomationList[i].Score,
                        InformationScoreAdjusted = _arrUserBuildingInfomationList[i].ScoreAdjusted,
                        DocumentCount = _arrUserBuildingInfomationList[i].DocumentCount,
                        TimeFrameYear = _arrUserBuildingInfomationList[i].TimeframeYearCount,
                        TimeFrameMonth = _arrUserBuildingInfomationList[i].TimeframeMonthCount,
                        //TimeFrameYear = _arrUserBuildingInfomationList[i].Ti
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
                     u.BuildingTokenId == bldtknid &&
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
                        BuildingTokenID = bldtknid,
                        InformationText = _arrUserBuildingTable2_InfomationList[i].InformationText.ToString(),
                        InformationTokenID = _arrUserBuildingTable2_InfomationList[i].InformationTokenId.ToString(),
                        InformationScore = _arrUserBuildingTable2_InfomationList[i].Score,
                        InformationScoreAdjusted = _arrUserBuildingTable2_InfomationList[i].ScoreAdjusted,
                        DocumentCount = _arrUserBuildingTable2_InfomationList[i].DocumentCount,
                        TimeFrameYear = _arrUserBuildingTable2_InfomationList[i].TimeframeYearCount,
                        TimeFrameMonth = _arrUserBuildingTable2_InfomationList[i].TimeframeMonthCount,

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







                /////////////////////////////////////////

                List<AppUserBuildingInformationModelManager> _iRowContentPagingList = new List<AppUserBuildingInformationModelManager>();



                if (iPageNumber== "0")
                {
                    _iRowContentPagingList= _arrBuildingInformationModelList.Take(10).ToList();
                }

                else if (iPageNumber== "1")
                {
                    _iRowContentPagingList= _arrBuildingInformationModelList.Take(10).ToList();
                }

                else if (iPageNumber== "2")
                {
                    _iRowContentPagingList= _arrBuildingInformationModelList
                                              .Skip(10)
                                              .Take(10).ToList();
                }

                else if (iPageNumber== "3")
                {
                    _iRowContentPagingList= _arrBuildingInformationModelList
                                              .Skip(20)
                                              .Take(9).ToList();
                }




                iDevelomentNew2ViewModel.BuildingTokenID = bldtknid;
                iDevelomentNew2ViewModel.BuildingInformationList = _iRowContentPagingList;










                /////////////////////////////////////////






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
