using BSRVemcoCS.iApp_Identity;
using BSRVemcoCS.iAppViewModel;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;

namespace BSRVemcoCS.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<AppCore_IdentityUser> iUserManager;
        private readonly SignInManager<AppCore_IdentityUser> iSignManager;

        public AccountController (
                        UserManager<AppCore_IdentityUser> iUserManager ,
                        SignInManager<AppCore_IdentityUser> iSignManager )
        {
            this.iUserManager = iUserManager;
            this.iSignManager = iSignManager;
        }















        public IActionResult Index ( )
        {
            return View ( );
        }


        #region Register




        [HttpGet]
        public IActionResult Register ( )
        {
            return View ( );
        }


        [HttpPost]
        public async Task<IActionResult> Register ( AppRegisterViewModel iRegisterModel )
        {


            if ( ModelState.IsValid )
            {

                AppCore_IdentityUser iUser = new AppCore_IdentityUser
                {

                    UserName = iRegisterModel.Email ,
                    Email = iRegisterModel.Email

                };

                var iResult = await iUserManager.CreateAsync ( iUser , iRegisterModel.Password );

                if ( iResult.Succeeded )
                {
                    await iSignManager.SignInAsync ( iUser , true );


                    return RedirectToAction (
                        "Index" ,
                        "Dashboard" ,
                        new { area = "iWebMember" } );

                    //return RedirectToAction ( "Edit" , "Dashboard" ,
                    //    new { id = "1101" , Area = "iWebMember" } );
                }

                foreach ( var iError in iResult.Errors )
                {

                    ModelState.AddModelError ( "iErrorKey" , iError.Description );

                }

            }


            return View ( iRegisterModel );

        }



        #endregion






        #region Login



        //[HttpGet]
        //public IActionResult Login ( )
        //    {



        //    return View ( );
        //    }

        // https://samlearnsazure.blog/2019/07/26/extending-external-authentication-with-google-twitter-and-facebook/
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login ( string returnUrl )
        {

            returnUrl = returnUrl ?? Url.Content ( "~/" );

            AppLoginViewModel _AppLoginViewModel = new AppLoginViewModel
            {
                ReturnUrl = returnUrl ,
                ExternalLogins = ( await iSignManager.GetExternalAuthenticationSchemesAsync ( ) ).ToList ( )
            };

            return View ( _AppLoginViewModel );

        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="iLoginModel"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
		[HttpPost]
        public async Task<IActionResult> Login ( AppLoginViewModel iLoginModel , string returnUrl = null )
        {

            if ( ModelState.IsValid )
            {

                var iResult = await iSignManager.PasswordSignInAsync ( iLoginModel.Email , iLoginModel.Password , iLoginModel.RememberMe , false );

                if ( iResult.Succeeded )
                {

                    if ( !string.IsNullOrEmpty ( returnUrl ) && Url.IsLocalUrl ( returnUrl ) )
                    {
                        return LocalRedirect ( returnUrl );
                    }
                    else
                    {


                        return RedirectToAction (
                            "Index" ,
                            "Dashboard" ,
                            new { area = "iWebMember" } );


                        //  return RedirectToAction ( "Index" , "Home" );

                    }

                }

                ModelState.AddModelError ( "iErrorKey" , "Invalid Login Attempt" );

            }
            return View ( iLoginModel );

        }



        #endregion



        #region Logout

        [HttpPost]
        public async Task<IActionResult> Logout ( )
        {

            await iSignManager.SignOutAsync ( );
            return RedirectToAction ( "Index" , "Home" );

        }




        #endregion




    }
}
