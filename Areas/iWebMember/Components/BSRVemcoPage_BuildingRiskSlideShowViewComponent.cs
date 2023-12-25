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
    public class BSRVemcoPage_BuildingRiskSlideShowViewComponent : ViewComponent
    {
        private readonly BSRDBModelContext _dbContext;


        private readonly UserManager<AppCore_IdentityUser> iUserManager;
        private readonly SignInManager<AppCore_IdentityUser> iSignManager;


        //List<SocialIcon> socialIcons = new List<SocialIcon> ( );
        public BSRVemcoPage_BuildingRiskSlideShowViewComponent(BSRDBModelContext dbContext,
            UserManager<AppCore_IdentityUser> iUserManager,
                        SignInManager<AppCore_IdentityUser> iSignManager)
        {
            //socialIcons = SocialIcon.AppSocialIcons ( );
            _dbContext = dbContext;
            this.iUserManager = iUserManager;
            this.iSignManager = iSignManager;

        }

        public async Task<IViewComponentResult> InvokeAsync(
            string iBuildingTokenID,
            string iInformationCode)
        {

            //string bldtknid,  string querytbltknid, string iPageNumber, bool blnIsPaging

            try
            {

                // string id = Request.Query["bldtknid"].ToString();

                string str_TableTitle = "0";

                if (iInformationCode ==   "fireperformance")
                {
                    str_TableTitle= "Fire performance Descriptor";
                }

                else if (iInformationCode ==   "configuration")
                {
                    str_TableTitle=  "Façade configuration Description";
                }

                else if (iInformationCode ==   "firestrategy")
                {
                    str_TableTitle=  "Fire strategy Descriptor";
                }

                /*
                 1- 
                 */
                List<BsrvemcoUserBuildingInformationList>? _arrUserBuildingInfomationList_1 = _dbContext.BsrvemcoUserBuildingInformationLists
                     .Where(u =>
                     u.ApptableTokenId == "1689162207917" &&
                     u.BuildingTokenId == iBuildingTokenID &&
                     u.InformationCode ==  iInformationCode &&  //"fireperformance"
                     u.IsVisible == true)
                     //.Select (u  )
                     //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                     .ToList(); // This is what actually executes the request and return a response



                List<AppUserBuildingTableRowModelManager> _iRowContentList_1 = new List<AppUserBuildingTableRowModelManager>();

                for (int i = 0; i < _arrUserBuildingInfomationList_1.Count; i++)
                {
                    _iRowContentList_1
                  .Add(new AppUserBuildingTableRowModelManager()
                  {

                      _id = i,

                      AppTableTokenID = _arrUserBuildingInfomationList_1[i].ApptableTokenId,
                      TableTokenID = _arrUserBuildingInfomationList_1[i].ApptableTokenId,

                      AppInformationTokenID = _arrUserBuildingInfomationList_1[i].AppinformationTokenId,
                      InformationTokenID = _arrUserBuildingInfomationList_1[i].InformationTokenId,

                      CompanyTokenID = Program.iOwnerModel.CompanyTokenID,
                      BuildingTokenID = iBuildingTokenID,

                      //ColumnDescription = _arrUserBuildingInfomationList_1[i].InformationText, //"Fire Strategy" ,
                      ColumnDescription = _arrUserBuildingInfomationList_1[i].InformationTitle, //"Fire Strategy" ,
                      //ColumnCommentary = _arrUserBuildingInfomationList_1[i].Commentary,
                      //ColumnCriterion = "0",









                      //AppTableTokenID = "X1AppTableTokenID" ,
                      //TableTokenID = "X1TableTokenID" ,

                      //AppInformationTokenID = "X1AppInformationTokenID" ,
                      //InformationTokenID = "X1InformationTokenID" ,

                      //CompanyTokenID = "X1CompanyTokenID" ,
                      //BuildingTokenID = "X1BuildingTokenID" ,

                      //ColumnDescription = _arrBuildingInfomationList[ i ].InformationText , //"Fire Strategy" ,
                      //ColumnCommentary = _arrBuildingInfomationList[ i ].Commentary ,
                      //ColumnCriterion = "0" ,

                      //ColumnScore = _arrUserBuildingInfomationList_1[i].Score,
                      //ColumnScoreOriginal = _arrUserBuildingInfomationList_1[i].ScoreOriginal,
                      //ColumnScoreManaged = _arrUserBuildingInfomationList_1[i].ScoreManaged,
                      //ColumnScoreAdjused = _arrUserBuildingInfomationList_1[i].ScoreAdjusted,
                      //ColumnRiskControlMeasure = _arrUserBuildingInfomationList_1[i].RiskControlMeasure,
                      //ColumnTotal = "0",

                      InformationButtonText =  _arrUserBuildingInfomationList_1[i].InformationButtonText,
                      InformationButtonStyleCSS= _arrUserBuildingInfomationList_1[i].InformationButtonStyleCss,


                      //ColumnScore = "5" ,
                      //ColumnScoreOriginal = "5" ,
                      //ColumnScoreManaged = "5" ,
                      //ColumnScoreAdjused = "5" ,
                      //ColumnRiskControlMeasure = "" ,
                      //ColumnTotal = "5" ,



                      //ColumnCriterionList = await AppBuildingInformationCriterionManager.getCriterionList(_dbContext, _arrUserBuildingInfomationList_1[i].AppinformationTokenId!)

                  });
                }


                //////////////////////////////////////

                //////////////////////////////////////







                List<AppDevelomentTable1EditViewModel> arr_AppDevelomentTable1Model = new List<AppDevelomentTable1EditViewModel>();



                AppDevelomentTable1EditViewModel _iDevelomentTable1EditModel_1 = new AppDevelomentTable1EditViewModel()
                {
                    TableTitle = str_TableTitle,
                    ////////////////////TableDescription = "TableDescription",

                    ////////////////////ColumnDescription = "Descriptor",

                    ////////////////////ColumnVePlus = "+ve (1)",
                    ////////////////////ColumnVeMinus = "-ve (5)",
                    ////////////////////ColumnNeutral = "Neutral (3)",

                    ////////////////////ColumnCommentary = "Commentary",
                    ////////////////////ColumnCriterion = "Criterion",
                    ////////////////////ColumnScore = "Score",
                    ////////////////////ColumnScoreOriginal = "ScoreOriginal",
                    ////////////////////ColumnScoreManaged = "Score",
                    ////////////////////ColumnScoreAdjused = "Adjusted Score",
                    //////////////////////ColumnRiskControlMeasure = "Risk Control Measure Risk Control Measure" ,
                    ////////////////////ColumnRiskControlMeasure = "Risk Control Measure",
                    //////////////////////ColumnScoreAverage = "2.5" ,
                    ////////////////////ColumnScoreTotal = "0",



                    //ColumnScoreAverage = _dbContext.BsrvemcoUserBuildingInformationLists
                    //.Where(
                    //    c =>
                    //    c.ApptableTokenId == "1689162207917" &&
                    //    c.InformationCode == "fireperformance" &&
                    //    c.BuildingTokenId == iBuildingTokenID)
                    //.Average(clmn => Convert.ToDouble(clmn.ScoreAdjusted!)).ToString("0.0"),



                    RowContentList = _iRowContentList_1,
                };


                arr_AppDevelomentTable1Model.Add(_iDevelomentTable1EditModel_1);

                return await Task.FromResult((IViewComponentResult)View("Default", arr_AppDevelomentTable1Model));
            }
            catch (Exception ex)
            {
                AppUtility_DebugManager.Debug_Get_MessageText(ex.Message.ToString());
                return null;
            }









        }



    }
}
