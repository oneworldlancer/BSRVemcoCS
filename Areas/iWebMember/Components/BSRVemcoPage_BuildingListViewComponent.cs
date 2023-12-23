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
using System.Linq;

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

                //List<BsrvemcoUserBuildingList>? _arrDevelomentList = new List<BsrvemcoUserBuildingList>();

                List<BsrvemcoUserBuildingList>? _arrDevelomentList_New = _dbContext.BsrvemcoUserBuildingLists
          .Where(u =>
          u.CompanyTokenId == Program.iOwnerModel.CompanyTokenID &&
          u.IsNew ==true &&
          u.IsVisible ==true)
          .OrderBy(x => x.BuildingName)
          //.Select (u  )
          //.FirstOrDefault ( ); // This is what actually executes the request and return a response
          .ToList(); // This is what actually executes the request and return a response



                List<BsrvemcoUserBuildingList>? _arrDevelomentList_Old = _dbContext.BsrvemcoUserBuildingLists
                     .Where(u =>
                     u.CompanyTokenId == Program.iOwnerModel.CompanyTokenID &&
                       u.IsNew ==false &&
                     u.IsVisible ==true)
                     .OrderBy(x => x.BuildingName)
                     //.Select (u  )
                     //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                     .ToList(); // This is what actually executes the request and return a response




                //  AppUserBuildingModelManager iDevelomentNew2ViewModel = new AppUserBuildingModelManager ( );
                List<AppUserBuildingModelManager> _arrBuildingList = new List<AppUserBuildingModelManager>();
                List<AppUserBuildingModelManager> _arrBuildingList_New = new List<AppUserBuildingModelManager>();
                List<AppUserBuildingModelManager> _arrBuildingList_Old = new List<AppUserBuildingModelManager>();


                AppUserBuildingModelManager _iUserBuildingModel;
                for (int i = 0; i < _arrDevelomentList_New.Count; i++)
                {
                    _iUserBuildingModel = new AppUserBuildingModelManager()
                    {
                        BuildingName = _arrDevelomentList_New[i].BuildingName.ToString()!,
                        BuildingTokenID = _arrDevelomentList_New[i].BuildingTokenId.ToString()!,
                        BuildingNameCSS ="bold"
                        //InformationText = _arrDevelomentInfomationList[ i ].InformationText.ToString ( ) ,

                    };

                    //if (_arrDevelomentList_New[i].IsNew == true)
                    //{
                    //    _iUserBuildingModel. BuildingNameCSS ="bold";
                    //}
                    //else
                    //{
                    //    _iUserBuildingModel. BuildingNameCSS ="normal";
                    //}

                    _arrBuildingList_New.Add(_iUserBuildingModel);
                }


                ////

                for (int i = 0; i < _arrDevelomentList_Old.Count; i++)
                {
                    _iUserBuildingModel = new AppUserBuildingModelManager()
                    {
                        BuildingName = _arrDevelomentList_Old[i].BuildingName.ToString()!,
                        BuildingTokenID = _arrDevelomentList_Old[i].BuildingTokenId.ToString()!,
                        BuildingNameCSS ="normal"
                        //InformationText = _arrDevelomentInfomationList[ i ].InformationText.ToString ( ) ,

                    };

                    //if (_arrDevelomentList_New[i].IsNew == true)
                    //{
                    //    _iUserBuildingModel. BuildingNameCSS ="bold";
                    //}
                    //else
                    //{
                    //    _iUserBuildingModel. BuildingNameCSS ="normal";
                    //}

                    _arrBuildingList_Old.Add(_iUserBuildingModel);
                }


                _arrBuildingList.AddRange(_arrBuildingList_New);
                _arrBuildingList.AddRange(_arrBuildingList_Old);


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
