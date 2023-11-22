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
    public class BSRVemcoPage_BuildingEditViewComponent : ViewComponent
    {
        private readonly BSRDBModelContext _dbContext;


        private readonly UserManager<AppCore_IdentityUser> iUserManager;
        private readonly SignInManager<AppCore_IdentityUser> iSignManager;


        //List<SocialIcon> socialIcons = new List<SocialIcon> ( );
        public BSRVemcoPage_BuildingEditViewComponent(BSRDBModelContext dbContext,
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


                var _iUserBuildignModel = _dbContext.BsrvemcoUserBuildingLists
                        .Where(u => u.BuildingTokenId == iBuildingTokenID)
                        //.Select (u  )
                        .FirstOrDefault(); // This is what actually executes the request and return a response

                AppDevelomentEdit1ViewModel _iDevelomentNew1ViewModel = new AppDevelomentEdit1ViewModel()
                {
                    BuildingTokenID = iBuildingTokenID,
                    BuildingName = _iUserBuildignModel.BuildingName,
                    BuildingAddress = _iUserBuildignModel.BuildingAddress,
                    BuildingDateYear = _iUserBuildignModel.BuildingYear,
                    BuildingImageTokenID = _iUserBuildignModel.ImageTokenId
                };


                return await Task.FromResult((IViewComponentResult)View("Default", _iDevelomentNew1ViewModel));
            }
            catch (Exception ex)
            {
                AppUtility_DebugManager.Debug_Get_MessageText(ex.Message.ToString());
                return null;
            }









        }



    }
}
