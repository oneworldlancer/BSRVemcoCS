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
    public class BSRVemcoPage_ProfileViewComponent : ViewComponent
    {
        private readonly BSRDBModelContext _dbContext;


        private readonly UserManager<AppCore_IdentityUser> iUserManager;
        private readonly SignInManager<AppCore_IdentityUser> iSignManager;


        //List<SocialIcon> socialIcons = new List<SocialIcon> ( );
        public BSRVemcoPage_ProfileViewComponent(BSRDBModelContext dbContext,
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


                AppProfileViewModel _iBSRVemcoPageViewModel = new AppProfileViewModel();

                _iBSRVemcoPageViewModel.CompanyName=Program.iOwnerModel.CompanyName;
                _iBSRVemcoPageViewModel.FirstName=Program.iOwnerModel.FirstName;
                _iBSRVemcoPageViewModel.LastName=Program.iOwnerModel.LastName;
                _iBSRVemcoPageViewModel.EmailAddress=User.Identity.Name;//Program.iOwnerModel.EmailAddress;
                _iBSRVemcoPageViewModel.MobileNumberE164="+xx xxx xxxx";


                return await Task.FromResult((IViewComponentResult)View("Default", _iBSRVemcoPageViewModel));
            }
            catch (Exception ex)
            {
                AppUtility_DebugManager.Debug_Get_MessageText(ex.Message.ToString());
                return null;
            }









        }








    }
}
