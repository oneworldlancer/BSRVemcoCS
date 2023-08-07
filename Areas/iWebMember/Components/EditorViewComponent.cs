using BSRVemcoCS.DBContext;
using BSRVemcoCS.iApp_Identity;
using BSRVemcoCS.iAppViewModel;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BSRVemcoCS.Areas.iWebMember.Components
{
    public class EditorViewComponent : ViewComponent
    {
        private readonly BSRDBModelContext _dbContext;


        private readonly UserManager<AppCore_IdentityUser> iUserManager;
        private readonly SignInManager<AppCore_IdentityUser> iSignManager;


        //List<SocialIcon> socialIcons = new List<SocialIcon> ( );
        public EditorViewComponent(BSRDBModelContext dbContext,
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

            //////////    string bldtknid, string inftknid                    

            //////////var _iBuildingInfomationModel = _dbContext.BsrvemcoUserBuildingInformationLists
            //////////                    .Where ( u =>
            //////////                    u.BuildingTokenId == bldtknid &&
            //////////                    u.InformationTokenId == inftknid )
            //////////                    //.Select (u  )
            //////////                    .FirstOrDefault ( ); // This is what actually executes the request and return a response
            //////////                                         // .ToList ( ); // This is what actually executes the request and return a response

            //////////AppPopupEditorViewModel _iPopupEditorViewModel = new AppPopupEditorViewModel ( );

            //////////_iPopupEditorViewModel.InformationTokenID= inftknid;
            //////////_iPopupEditorViewModel.BuildingTokenID = bldtknid;
            //////////_iPopupEditorViewModel.ScoreValueMin = "1";
            //////////_iPopupEditorViewModel.ScoreValueMax = "5";
            //////////_iPopupEditorViewModel.PageHTMLContent = _iBuildingInfomationModel.RiskControlMeasure;

            //var model = socialIcons;
            //  return await Task.FromResult ( ( IViewComponentResult ) View ( "Default" , model ) );
            //return await Task.FromResult ( ( IViewComponentResult ) View ( "Default" , null));// await Task.FromResult ( ( IViewComponentResult ) View ( "Default" , model ) );
            return await Task.FromResult((IViewComponentResult)View("Default"));
        }


    }
}
