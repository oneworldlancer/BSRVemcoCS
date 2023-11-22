using BSRVemcoCS.AppEnumManager;
using BSRVemcoCS.DBContext;
using BSRVemcoCS.DBModels;
using BSRVemcoCS.iApp_Identity;
using BSRVemcoCS.iAppUtility;
using BSRVemcoCS.iAppViewModel;
using BSRVemcoCS.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using System.Collections;
using System.Security.Claims;
//using BSRVemcoCS.DBContext;

namespace BSRVemcoCS.Controllers
{
    public class AccountController : Controller
    {

        private readonly BSRDBModelContext _dbContext;


        private readonly UserManager<AppCore_IdentityUser> iUserManager;
        private readonly SignInManager<AppCore_IdentityUser> iSignManager;

        public AccountController(
                      BSRDBModelContext dbContext,
            UserManager<AppCore_IdentityUser> iUserManager,
                        SignInManager<AppCore_IdentityUser> iSignManager)
        {
            _dbContext = dbContext;
            this.iUserManager = iUserManager;
            this.iSignManager = iSignManager;
        }















        public IActionResult Index()
        {
            return View();
        }


        #region Register




        [HttpGet]
        public async Task<IActionResult> Register()
        {

            try
            {

                await iSignManager.SignOutAsync();


                return View();

            }
            catch (Exception ex)
            {
                AppUtility_DebugManager.Debug_Get_MessageText(ex.Message.ToString());

                return View();
            }




        }


        [HttpPost]
        public async Task<IActionResult> Register(AppRegisterViewModel iRegisterModel)
        {


            if (ModelState.IsValid)
            {

                AppCore_IdentityUser iUser = new AppCore_IdentityUser
                {

                    UserName = iRegisterModel.Email,
                    Email = iRegisterModel.Email

                };

                var iResult = await iUserManager.CreateAsync(iUser, iRegisterModel.Password);

                if (iResult.Succeeded)
                {

                    // Get List-TokenID
                    ArrayList _arrTokenList = new ArrayList();
                    _arrTokenList = AppUtility_ListTokenIDManager.ListTokenID_Generate_NewList("2");



                    //   Register User-List


                    BsrvemcoUserList iUserModel = new BsrvemcoUserList()
                    {

                        RowViewTokenId = new Guid(),


                        OwnerUserTokenId = _arrTokenList[0]!.ToString(),
                        CompanyTokenId = _arrTokenList[1].ToString(),
                        CompanyName = iRegisterModel.CompanyName.ToString(),

                        FirstName = iRegisterModel.FirstName.ToString(),
                        FirstNameLower = iRegisterModel.FirstName.ToString().ToLower(),

                        LastName = iRegisterModel.LastName.ToString(),
                        LastNameLower = iRegisterModel.LastName.ToString().ToLower(),

                        Email = iRegisterModel.Email.ToString().ToLower(),
                        EmailAddress = iRegisterModel.Email.ToString().ToLower(),

                        AppRoleTokenId = IEnum_AppRole.Role_PRIMARY_TOKENID,
                        AppRoleCode = IEnum_AppRole.Role_PRIMARY_CODE,
                        AppRoleName = IEnum_AppRole.Role_PRIMARY_NAME,


                        RoleTokenId = IEnum_AppRole.Role_PRIMARY_TOKENID,
                        RoleCode = IEnum_AppRole.Role_PRIMARY_CODE,
                        RoleName = IEnum_AppRole.Role_PRIMARY_NAME,

                        UploadDateTimeMilliSec = AppUtility_TimeManager.Time_GetCurrentTimeInMilliSecond(),
                        IsVisible = true,
                        IsActive = true,

                    };


                    await _dbContext.BsrvemcoUserLists.AddAsync(iUserModel);

                    await _dbContext.SaveChangesAsync();



                    // Role-List

                    BsrvemcoUserRoleList iUserRoleModel = new BsrvemcoUserRoleList()
                    {

                        RowViewTokenId = new Guid(),


                        OwnerUserTokenId = _arrTokenList[0]!.ToString(),

                        AppRoleTokenId = IEnum_AppRole.Role_PRIMARY_TOKENID,
                        AppRoleCode = IEnum_AppRole.Role_PRIMARY_CODE,
                        AppRoleName = IEnum_AppRole.Role_PRIMARY_NAME,

                        UserRole = IEnum_AppRole.Role_PRIMARY_NAME,
                        RoleCode = IEnum_AppRole.Role_PRIMARY_CODE,
                        RoleValue = IEnum_AppRole.Role_PRIMARY_CODE,
                        RoleName = IEnum_AppRole.Role_PRIMARY_NAME,
                        RoleTitle = IEnum_AppRole.Role_PRIMARY_NAME,


                        //  UploadDateTimeMilliSec = AppUtility_TimeManager.Time_GetCurrentTimeInMilliSecond ( ) ,
                        // IsVisible = true ,
                        IsActive = true,

                    };



                    await _dbContext.BsrvemcoUserRoleLists.AddAsync(iUserRoleModel);

                    await _dbContext.SaveChangesAsync();



                    // Company-List


                    BsrvemcoUserCompanyList iUserCompanyModel = new BsrvemcoUserCompanyList()
                    {

                        RowViewTokenId = new Guid(),


                        OwnerUserTokenId = _arrTokenList[0]!.ToString(),

                        CompanyTokenId = _arrTokenList[1].ToString(),
                        CompanyName = iRegisterModel.CompanyName.ToString(),

                        UploadDateTimeMilliSec = AppUtility_TimeManager.Time_GetCurrentTimeInMilliSecond(),
                        IsVisible = true,
                        IsActive = true,

                    };


                    await _dbContext.BsrvemcoUserCompanyLists.AddAsync(iUserCompanyModel);

                    await _dbContext.SaveChangesAsync();



                    await iSignManager.SignInAsync(iUser, true);

                    ////////////////////


                    var _iUserOwnerModel = _dbContext.BsrvemcoUserLists
                            .Where(u => u.Email == iRegisterModel.Email.ToString().ToLower())
                            //.Select ( u => u.RoleName )
                            .SingleOrDefault(); // This is what actually executes the request and return a response

                    if (_iUserOwnerModel != null)
                    {
                        //////var _iUserRoleName = _dbContext.BsrvemcoUserRoleLists
                        ////// .Where ( u => u.OwnerUserTokenId == _iUserOwnerModel!.OwnerUserTokenId )
                        ////// .Select ( u => u.RoleName )
                        ////// .SingleOrDefault ( ); // This is what actually executes the request and return a response

                        //////var _iUserCompanyModel = _dbContext.BsrvemcoUserCompanyLists
                        //////     .Where ( u => u.OwnerUserTokenId == _iUserOwnerModel!.OwnerUserTokenId )
                        //////     //.Select ( u => u.RoleName )
                        //////     .SingleOrDefault ( ); // This is what actually executes the request and return a response


                        AppUserOwnerModelManager _xOwnerModel = new AppUserOwnerModelManager
                        {
                            OwnerUserTokenID = _iUserOwnerModel!.OwnerUserTokenId,
                            FirstName = _iUserOwnerModel!.FirstName,
                            LastName = _iUserOwnerModel!.LastName,
                            FullName = _iUserOwnerModel!.FirstName + " " + _iUserOwnerModel!.LastName,
                            EmailAddress = iRegisterModel.Email.ToString().ToLower(),
                            CompanyTokenID = _iUserOwnerModel!.CompanyTokenId,
                            CompanyName = _iUserOwnerModel!.CompanyName,
                            RoleTokenID = _iUserOwnerModel!.AppRoleTokenId,
                            RoleCode = _iUserOwnerModel!.AppRoleCode,
                            RoleName = _iUserOwnerModel!.AppRoleName
                        };

                        //iApp_Globals.Globals.iOwnerModel = _iOwnerModel;

                        Program.iOwnerModel = _xOwnerModel;

                        TempData["iOwnerModel"] = JsonConvert.SerializeObject(_xOwnerModel);



                        return RedirectToAction(
                        "Index",
                        "Dashboard",
                        new { area = "iWebMember" });

                    }

                    //return RedirectToAction ( "Edit" , "Dashboard" ,
                    //    new { id = "1101" , Area = "iWebMember" } );
                }

                foreach (var iError in iResult.Errors)
                {

                    ModelState.AddModelError("iErrorKey", iError.Description);

                }

            }


            return View(iRegisterModel);

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
        public async Task<IActionResult> Login(string? returnUrl = null)
        {

            try
            {
                await iSignManager.SignOutAsync();

                returnUrl = returnUrl ?? Url.Content("~/");

                AppLoginViewModel _AppLoginViewModel = new AppLoginViewModel
                {
                    ReturnUrl = returnUrl,
                    ExternalLogins = (await iSignManager.GetExternalAuthenticationSchemesAsync()).ToList()
                };

                return View(_AppLoginViewModel);

            }
            catch (Exception ex)
            {
                AppUtility_DebugManager.Debug_Get_MessageText(ex.Message.ToString());
                return View();
            }




        }



        AppUserOwnerModelManager _iOwnerModel = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iLoginModel"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
		[HttpPost]
        public async Task<IActionResult> Login(AppLoginViewModel iLoginModel, string? returnUrl = null)
        {

            if (ModelState.IsValid)
            {

                var iResult = await iSignManager.PasswordSignInAsync(
                    iLoginModel.Email, iLoginModel.Password,
                    iLoginModel.RememberMe, false);

                if (iResult.Succeeded)
                {

                    //string? _iUserEmail = User.Identity!.Name;

                    var _iUserOwnerModel = _dbContext.BsrvemcoUserLists
                            .Where(u => u.Email == iLoginModel.Email!.ToLower().ToString())
                            //.Select ( u => u.RoleName )
                            .SingleOrDefault(); // This is what actually executes the request and return a response

                    if (_iUserOwnerModel != null)
                    {
                        //////var _iUserRoleName = _dbContext.BsrvemcoUserRoleLists
                        ////// .Where ( u => u.OwnerUserTokenId == _iUserOwnerModel!.OwnerUserTokenId )
                        ////// .Select ( u => u.RoleName )
                        ////// .SingleOrDefault ( ); // This is what actually executes the request and return a response

                        //////var _iUserCompanyModel = _dbContext.BsrvemcoUserCompanyLists
                        //////     .Where ( u => u.OwnerUserTokenId == _iUserOwnerModel!.OwnerUserTokenId )
                        //////     //.Select ( u => u.RoleName )
                        //////     .SingleOrDefault ( ); // This is what actually executes the request and return a response


                        _iOwnerModel = new AppUserOwnerModelManager
                        {
                            OwnerUserTokenID = _iUserOwnerModel!.OwnerUserTokenId,
                            FirstName = _iUserOwnerModel!.FirstName,
                            LastName = _iUserOwnerModel!.LastName,
                            FullName = _iUserOwnerModel!.FirstName + " " + _iUserOwnerModel!.LastName,
                            EmailAddress = iLoginModel.Email!.ToLower().ToString(),
                            CompanyTokenID = _iUserOwnerModel!.CompanyTokenId,
                            CompanyName = _iUserOwnerModel!.CompanyName,
                            RoleTokenID = _iUserOwnerModel!.AppRoleTokenId,
                            RoleCode = _iUserOwnerModel!.AppRoleCode,
                            RoleName = _iUserOwnerModel!.AppRoleName

                        };

                        //iApp_Globals.Globals.iOwnerModel = _iOwnerModel;

                        Program.iOwnerModel = _iOwnerModel;

                        TempData["iOwnerModel"] = JsonConvert.SerializeObject(_iOwnerModel);


                        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        {
                            return LocalRedirect(returnUrl);
                        }
                        else
                        {


                            return RedirectToAction(
                                "Index",
                                "Dashboard",
                                new { area = "iWebMember" });

                        }


                    }

                    ModelState.AddModelError("iErrorKey", "Invalid Login Attempt");

                    return View(iLoginModel);

                }


                //return RedirectToAction ( "Index" , "Home" );


                ModelState.AddModelError("iErrorKey", "Invalid Login Attempt");

            }
            return View(iLoginModel);

        }



        #endregion



        #region Logout

        [HttpPost]
        public async Task<IActionResult> Logout()
        {

            await iSignManager.SignOutAsync();
            return RedirectToAction("Index", "Home");

        }




        #endregion




    }
}
