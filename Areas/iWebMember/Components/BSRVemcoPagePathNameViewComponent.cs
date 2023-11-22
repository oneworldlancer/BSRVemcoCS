using BSRVemcoCS.DBContext;
using BSRVemcoCS.iApp_Identity;
using BSRVemcoCS.iAppViewModel;

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace BSRVemcoCS.Areas.iWebMember.Components
{
    public class BSRVemcoPagePathNameViewComponent : ViewComponent
    {
        private readonly BSRDBModelContext _dbContext;


        private readonly UserManager<AppCore_IdentityUser> iUserManager;
        private readonly SignInManager<AppCore_IdentityUser> iSignManager;


        //List<SocialIcon> socialIcons = new List<SocialIcon> ( );
        public BSRVemcoPagePathNameViewComponent(BSRDBModelContext dbContext,
            UserManager<AppCore_IdentityUser> iUserManager,
                        SignInManager<AppCore_IdentityUser> iSignManager)
        {
            //socialIcons = SocialIcon.AppSocialIcons ( );
            _dbContext = dbContext;
            this.iUserManager = iUserManager;
            this.iSignManager = iSignManager;

        }

        public async Task<IViewComponentResult> InvokeAsync(
            string ParentPageName,
            string ChildPageName,
            string ParentPageNameColorCSS,
            string ChildPageNameColorCSS,
           string ChildPageNameCSS)
        {

            //var _iCMSPageModel = _dbContext.BsrvemcoAppCmsPageLists
            //                    .Where ( u =>
            //                    u.PageCode == iPageCode )
            //                    //.Select (u  )
            //                    .SingleOrDefault ( );




            AppPagePathNameViewModel _iPagePathNameViewModel = new AppPagePathNameViewModel ( );

            _iPagePathNameViewModel.ParentPageName = ParentPageName;
            _iPagePathNameViewModel.ChildPageName = ChildPageName;
           
            _iPagePathNameViewModel.ParentPageNameColorCSS =ParentPageNameColorCSS;
            _iPagePathNameViewModel.ChildPageNameColorCSS = ChildPageNameColorCSS;
            
            _iPagePathNameViewModel.ChildPageNameCSS = ChildPageNameCSS;






            //var model = socialIcons;
         
            return await Task.FromResult ( ( IViewComponentResult ) View ( "Default" , _iPagePathNameViewModel) );
         
            //return await Task.FromResult ( ( IViewComponentResult ) View ( "Default" , null));// await Task.FromResult ( ( IViewComponentResult ) View ( "Default" , model ) );

            /////////////////return await Task.FromResult((IViewComponentResult)View("Default", _iCMSPageViewModel ) );


            //      return new HtmlContentViewComponentResult (
            //new HtmlString (    Task.FromResult ( ( IViewComponentResult ) View ( "Default" , _iCMSPageViewModel ) .ToString() )));


//            return new HtmlContentViewComponentResult (
//new HtmlString ( "<ul><li>My HTML code</li></ul>" ) );

           
//            return new HtmlContentViewComponentResult (
//new HtmlString ( _iCMSPageViewModel.PageHTMLContent ) );







        }


    }
}