using BSRVemcoCS.DBContext;
using BSRVemcoCS.iApp_Identity;
using BSRVemcoCS.iAppViewModel;
using BSRVemcoCS.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BSRVemcoCS.Areas.iWebMember.Components
{
    public class BuildingGapAnalysisListViewComponent : ViewComponent
    {
        private readonly BSRDBModelContext _dbContext;


        private readonly UserManager<AppCore_IdentityUser> iUserManager;
        private readonly SignInManager<AppCore_IdentityUser> iSignManager;


        //List<SocialIcon> socialIcons = new List<SocialIcon> ( );
        public BuildingGapAnalysisListViewComponent(BSRDBModelContext dbContext,
            UserManager<AppCore_IdentityUser> iUserManager,
                        SignInManager<AppCore_IdentityUser> iSignManager)
        {
            //socialIcons = SocialIcon.AppSocialIcons ( );
            _dbContext = dbContext;
            this.iUserManager = iUserManager;
            this.iSignManager = iSignManager;

        }

        public async Task<IViewComponentResult> InvokeAsync(string bldtknid, string inftknid)
        {

            //////////    string bldtknid, string inftknid                    

            var _arrInfomationDocumentList = _dbContext.BsrvemcoUserBuildingDocumentLists
                                .Where(u =>
                                u.BuildingTokenId == bldtknid &&
                                u.InformationTokenId == inftknid &&
                 u.IsVisible ==true)
                                //.Select (u  )
                                //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                                .ToList(); // This is what actually executes the request and return a response

            AppDevelomentDocumentListViewModel _iPopupDocumtListViewModel = new AppDevelomentDocumentListViewModel();

            List<AppUserBuildingInformationDocumentModelManager> _arrBuildingInformationDocumentList = new List<AppUserBuildingInformationDocumentModelManager>();
            AppUserBuildingInformationDocumentModelManager _iDocumentViewModel;

            //_iPopupDocumtListViewModel.AppInformationTokenID = inftknid;
            _iPopupDocumtListViewModel.InformationTokenID = inftknid;
            _iPopupDocumtListViewModel.BuildingTokenID = bldtknid;
            //_iPopupDocumtListViewModel.ScoreValueMin = "1";
            //_iPopupDocumtListViewModel.ScoreValueMax = "5";
            //_iPopupDocumtListViewModel.PageHTMLContent = _iBuildingInfomationModel.RiskControlMeasure;

            if (_arrInfomationDocumentList != null)
            {
                for (int i = 0; i < _arrInfomationDocumentList.Count; i++)
                {
                    _iDocumentViewModel = new AppUserBuildingInformationDocumentModelManager()
                    {

                        BuildingTokenID = bldtknid,
                        AppTableTokenID = _arrInfomationDocumentList[i].ApptableTokenId,
                        APPInformationTokenID = _arrInfomationDocumentList[i].AppinformationTokenId,
                        InformationTokenID = inftknid,
                        DocumentTokenID = _arrInfomationDocumentList[i].DocumentTokenId,
                        DocumentName = _arrInfomationDocumentList[i].DocumentName,
                        DocumentCode = _arrInfomationDocumentList[i].DocumentCode,
                        DocumentType = _arrInfomationDocumentList[i].DocumentType,
                        DocumentDescription = _arrInfomationDocumentList[i].DocumentDescription,
                        DocumentSize = _arrInfomationDocumentList[i].DocumentSize,
                        TimeoutUserUploadStartDay = _arrInfomationDocumentList[i].TimeoutUserUploadStartDay,
                        TimeoutUserUploadStartMonth = _arrInfomationDocumentList[i].TimeoutUserUploadStartMonth,
                        TimeoutUserUploadStartYear = _arrInfomationDocumentList[i].TimeoutUserUploadStartYear,
                        TimeoutUserUploadStartText = _arrInfomationDocumentList[i].TimeoutUserUploadStartText,
                        TimeframeYear = _arrInfomationDocumentList[i].TimeframeYearCount,
                        TimeoutUserUploadStart = (DateTime)_arrInfomationDocumentList[i].TimeoutUserUploadStart,
                    };
                    _arrBuildingInformationDocumentList.Add(_iDocumentViewModel);

                }

                _iPopupDocumtListViewModel.BuildingInformationDocumentList = _arrBuildingInformationDocumentList;

            }







            //var model = socialIcons;
            //  return await Task.FromResult ( ( IViewComponentResult ) View ( "Default" , model ) );
            //return await Task.FromResult ( ( IViewComponentResult ) View ( "Default" , null));// await Task.FromResult ( ( IViewComponentResult ) View ( "Default" , model ) );
            return await Task.FromResult((IViewComponentResult)View("Default", _iPopupDocumtListViewModel));
        }


    }
}
