using BSRVemcoCS.DBContext;
using BSRVemcoCS.iApp_Identity;
using BSRVemcoCS.iAppUtility;
using BSRVemcoCS.iAppViewModel;
using BSRVemcoCS.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BSRVemcoCS.Areas.iWebMember.Components
{
    public class QueryFormTableDocumentListViewComponent : ViewComponent
    {
        private readonly BSRDBModelContext _dbContext;


        private readonly UserManager<AppCore_IdentityUser> iUserManager;
        private readonly SignInManager<AppCore_IdentityUser> iSignManager;


        //List<SocialIcon> socialIcons = new List<SocialIcon> ( );
        public QueryFormTableDocumentListViewComponent(BSRDBModelContext dbContext,
            UserManager<AppCore_IdentityUser> iUserManager,
                        SignInManager<AppCore_IdentityUser> iSignManager)
        {
            //socialIcons = SocialIcon.AppSocialIcons ( );
            _dbContext = dbContext;
            this.iUserManager = iUserManager;
            this.iSignManager = iSignManager;

        }

        public async Task<IViewComponentResult> InvokeAsync(string bldtknid, string iqueryinftknid)
        {

            try
            {


                //////////    string bldtknid, string inftknid                    

                var _arrQueryDocumentList = _dbContext.BsrvemcoUserBuildingQueryDocumentLists
                                    .Where(u =>
                                    u.BuildingTokenId == bldtknid &&
                                    u.QueryInformationTokenId == iqueryinftknid &&
                                    u.IsVisible ==true)
                                    //.Select (u  )
                                    //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                                    .ToList(); // This is what actually executes the request and return a response

                AppDevelomentQueryDocumentListViewModel _iPopupDocumtListViewModel = new AppDevelomentQueryDocumentListViewModel();

                List<AppUserBuildingQueryDocumentModelManager> _arrBuildingInformationDocumentList = new List<AppUserBuildingQueryDocumentModelManager>();
                AppUserBuildingQueryDocumentModelManager _iDocumentViewModel;

                //_iPopupDocumtListViewModel.AppInformationTokenID = inftknid;
                _iPopupDocumtListViewModel.QueryInformationTokenID = iqueryinftknid;
                _iPopupDocumtListViewModel.BuildingTokenID = bldtknid;
                //_iPopupDocumtListViewModel.ScoreValueMin = "1";
                //_iPopupDocumtListViewModel.ScoreValueMax = "5";
                //_iPopupDocumtListViewModel.PageHTMLContent = _iBuildingInfomationModel.RiskControlMeasure;

                if (_arrQueryDocumentList != null)
                {
                    for (int i = 0; i < _arrQueryDocumentList.Count; i++)
                    {
                        _iDocumentViewModel = new AppUserBuildingQueryDocumentModelManager()
                        {

                            BuildingTokenID = bldtknid,
                            AppQueryTableTokenID = _arrQueryDocumentList[i].AppqueryTableTokenId,
                            APPQueryInformationTokenID = _arrQueryDocumentList[i].AppqueryInformationTokenId,
                            QueryInformationTokenID = iqueryinftknid,
                            QueryTableTokenID =  _arrQueryDocumentList[i].QueryTableTokenId,
                            DocumentTokenID = _arrQueryDocumentList[i].DocumentTokenId,
                            DocumentWebUrl = _arrQueryDocumentList[i].DocumentWebUrl.ToString().ToLower(),
                            //DocumentName = _arrQueryDocumentList[i].DocumentName,
                            //DocumentCode = _arrQueryDocumentList[i].DocumentCode,
                            //DocumentType = _arrQueryDocumentList[i].DocumentType,
                            //DocumentDescription = _arrQueryDocumentList[i].DocumentDescription,
                            //DocumentSize = _arrQueryDocumentList[i].DocumentSize,
                            //TimeoutUserUploadStartDay = _arrQueryDocumentList[i].TimeoutUserUploadStartDay,
                            //TimeoutUserUploadStartMonth = _arrQueryDocumentList[i].TimeoutUserUploadStartMonth,
                            //TimeoutUserUploadStartYear = _arrQueryDocumentList[i].TimeoutUserUploadStartYear,
                            //TimeoutUserUploadStartText = _arrQueryDocumentList[i].TimeoutUserUploadStartText,
                            //TimeoutYearCount = _arrQueryDocumentList[i].TimeoutYearCount,
                            //TimeoutUserUploadStart = (DateTime)_arrQueryDocumentList[i].TimeoutUserUploadStart,
                        };
                        _arrBuildingInformationDocumentList.Add(_iDocumentViewModel);

                    }

                    _iPopupDocumtListViewModel.BuildingQueryDocumentList = _arrBuildingInformationDocumentList;

                }







                //var model = socialIcons;
                //  return await Task.FromResult ( ( IViewComponentResult ) View ( "Default" , model ) );
                //return await Task.FromResult ( ( IViewComponentResult ) View ( "Default" , null));// await Task.FromResult ( ( IViewComponentResult ) View ( "Default" , model ) );
                return await Task.FromResult((IViewComponentResult)View("Default", _iPopupDocumtListViewModel));


            }
            catch (Exception ex)
            {
                AppUtility_DebugManager.Debug_Get_MessageText(ex.Message.ToString());
                return null;
            }

        }


    }
}
