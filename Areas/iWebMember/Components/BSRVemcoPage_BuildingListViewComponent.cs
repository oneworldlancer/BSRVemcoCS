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
    public class BSRVemcoPage_BuildingListViewComponent : ViewComponent
    {
        private readonly BSRDBModelContext _dbContext;


        private readonly UserManager<AppCore_IdentityUser> iUserManager;
        private readonly SignInManager<AppCore_IdentityUser> iSignManager;


        //List<SocialIcon> socialIcons = new List<SocialIcon> ( );
        public BSRVemcoPage_BuildingListViewComponent(BSRDBModelContext dbContext,
            UserManager<AppCore_IdentityUser> iUserManager,
                        SignInManager<AppCore_IdentityUser> iSignManager)
        {
            //socialIcons = SocialIcon.AppSocialIcons ( );
            _dbContext = dbContext;
            this.iUserManager = iUserManager;
            this.iSignManager = iSignManager;

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

//string bldtknid,  string querytbltknid, string iPageNumber, bool blnIsPaging

            try
            {


                //List<AppUserBuildingModelManager> _arrBuildingList = new List<AppUserBuildingModelManager>();



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





                return await Task.FromResult((IViewComponentResult)View("Default", _arrBuildingList));
            }
            catch (Exception ex)
            {
                AppUtility_DebugManager.Debug_Get_MessageText(ex.Message.ToString());
                return null;
            }









        }



    }
}
