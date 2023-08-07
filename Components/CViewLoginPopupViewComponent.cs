using BSRVemcoCS.DBContext;
using BSRVemcoCS.iApp_Identity;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BSRVemcoCS.Components
{
    public class CViewLoginPopupViewComponent : ViewComponent
    {
        private readonly BSRDBModelContext _dbContext;


        private readonly UserManager<AppCore_IdentityUser> iUserManager;
        private readonly SignInManager<AppCore_IdentityUser> iSignManager;


        //List<SocialIcon> socialIcons = new List<SocialIcon> ( );
        public CViewLoginPopupViewComponent ( BSRDBModelContext dbContext ,
            UserManager<AppCore_IdentityUser> iUserManager ,
                        SignInManager<AppCore_IdentityUser> iSignManager )
        {
            //socialIcons = SocialIcon.AppSocialIcons ( );
            _dbContext = dbContext;
            this.iUserManager = iUserManager;
            this.iSignManager = iSignManager;

        }

        public async Task<IViewComponentResult> InvokeAsync ( )
        {
            //var model = socialIcons;
            //  return await Task.FromResult ( ( IViewComponentResult ) View ( "Default" , model ) );
            //return await Task.FromResult ( ( IViewComponentResult ) View ( "Default" , null));// await Task.FromResult ( ( IViewComponentResult ) View ( "Default" , model ) );
            return await Task.FromResult ( ( IViewComponentResult ) View ( "Default"  ) );
        }


    }
}
