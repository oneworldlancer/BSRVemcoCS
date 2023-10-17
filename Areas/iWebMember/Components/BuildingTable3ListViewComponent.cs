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
    public class BuildingTable3ListViewComponent : ViewComponent
    {
        private readonly BSRDBModelContext _dbContext;


        private readonly UserManager<AppCore_IdentityUser> iUserManager;
        private readonly SignInManager<AppCore_IdentityUser> iSignManager;


        //List<SocialIcon> socialIcons = new List<SocialIcon> ( );
        public BuildingTable3ListViewComponent(BSRDBModelContext dbContext,
            UserManager<AppCore_IdentityUser> iUserManager,
                        SignInManager<AppCore_IdentityUser> iSignManager)
        {
            //socialIcons = SocialIcon.AppSocialIcons ( );
            _dbContext = dbContext;
            this.iUserManager = iUserManager;
            this.iSignManager = iSignManager;

        }

        public async Task<IViewComponentResult> InvokeAsync(string bldtknid, string iPageNumber, bool blnIsPaging)
        {



            try
            {



                List<BsrvemcoUserBuildingInformationList>? _arrUserBuildingInfomationList = _dbContext.BsrvemcoUserBuildingInformationLists
                             .Where(u =>
                             u.ApptableTokenId == "1689162201957" &&
                             u.BuildingTokenId == bldtknid &&
                             u.IsVisible == true)
                             //.Select (u  )
                             //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                             .ToList(); // This is what actually executes the request and return a response

                List<AppUserBuildingTableRowModelManager> _iRowContentList = new List<AppUserBuildingTableRowModelManager>();

                for (int i = 0; i < _arrUserBuildingInfomationList.Count; i++)
                {
                    _iRowContentList
                  .Add(new AppUserBuildingTableRowModelManager()
                  {

                      _id = i,

                      AppTableTokenID = _arrUserBuildingInfomationList[i].ApptableTokenId,
                      TableTokenID = _arrUserBuildingInfomationList[i].ApptableTokenId,

                      AppInformationTokenID = _arrUserBuildingInfomationList[i].AppinformationTokenId,
                      InformationTokenID = _arrUserBuildingInfomationList[i].InformationTokenId,

                      CompanyTokenID = Program.iOwnerModel.CompanyTokenID,
                      BuildingTokenID = bldtknid,

                      ColumnDescription = _arrUserBuildingInfomationList[i].InformationText, //"Fire Strategy" ,
                      ColumnCommentary = _arrUserBuildingInfomationList[i].Commentary,
                      ColumnCriterion = "0",
















                      //AppTableTokenID = "X1AppTableTokenID" ,
                      //TableTokenID = "X1TableTokenID" ,

                      //AppInformationTokenID = "X1AppInformationTokenID" ,
                      //InformationTokenID = "X1InformationTokenID" ,

                      //CompanyTokenID = "X1CompanyTokenID" ,
                      //BuildingTokenID = "X1BuildingTokenID" ,

                      //ColumnDescription = _arrBuildingInfomationList[ i ].InformationText , //"Fire Strategy" ,
                      //ColumnCommentary = _arrBuildingInfomationList[ i ].Commentary ,
                      //ColumnCriterion = "0" ,

                      ColumnScore = _arrUserBuildingInfomationList[i].Score,
                      ColumnScoreOriginal = _arrUserBuildingInfomationList[i].ScoreOriginal,
                      ColumnScoreManaged = _arrUserBuildingInfomationList[i].ScoreManaged,
                      ColumnScoreAdjused = _arrUserBuildingInfomationList[i].ScoreAdjusted,
                      ColumnRiskControlMeasure = _arrUserBuildingInfomationList[i].RiskControlMeasure,
                      ColumnTotal = "0",




                      //ColumnScore = "5" ,
                      //ColumnScoreOriginal = "5" ,
                      //ColumnScoreManaged = "5" ,
                      //ColumnScoreAdjused = "5" ,
                      //ColumnRiskControlMeasure = "" ,
                      //ColumnTotal = "5" ,

                      ColumnCriterionList = await AppBuildingInformationCriterionManager.getCriterionList(_dbContext, _arrUserBuildingInfomationList[i].AppinformationTokenId!)

                  });
                }



                AppDevelomentTable1EditViewModel _iDevelomentTable1EditModel = new AppDevelomentTable1EditViewModel()
                {
                    BuildingTokenID = bldtknid,
                    TableTitle = "TableTitle",
                    TableDescription = "TableDescription",

                    ColumnDescription = "Description",
                    ColumnCommentary = "Commentary",
                    ColumnCriterion = "Criterion",
                    ColumnScore = "Score",
                    ColumnScoreOriginal = "ScoreOriginal",
                    ColumnScoreManaged = "Score",
                    ColumnScoreAdjused = "Adjusted Score",
                    //ColumnRiskControlMeasure = "Risk Control Measure Risk Control Measure" ,
                    ColumnRiskControlMeasure = "Risk Control Measure",

                    //ColumnScoreTotal = "333" ,
                    ColumnScoreTotal = _dbContext.BsrvemcoUserBuildingInformationLists
                    .Where(
                        c =>
                        c.ApptableTokenId == "1689162201957" &&
                        c.BuildingTokenId == bldtknid)
                    .Sum(clmn => Convert.ToDecimal(clmn.ScoreAdjusted!)).ToString("0.0"),


                    RowContentList = _iRowContentList,
                };





























                ////////////////////////////////////////// 




                List<AppUserBuildingTableRowModelManager> _iRowContentPagingList = new List<AppUserBuildingTableRowModelManager>();

             
                    if (iPageNumber== "0")
                    {
                        _iRowContentPagingList= _iRowContentList.Take(10).ToList();
                    }

                    else if (iPageNumber== "1")
                    {
                        _iRowContentPagingList= _iRowContentList.Take(10).ToList();
                    }

                    else if (iPageNumber== "2")
                    {
                        _iRowContentPagingList= _iRowContentList
                                                  .Skip(10)
                                                  .Take(10).ToList();
                    }

                    else if (iPageNumber== "3")
                    {
                        _iRowContentPagingList= _iRowContentList
                                                  .Skip(20)
                                                  .Take(10).ToList();
                    }
                       else if (iPageNumber== "4")
                    {
                        _iRowContentPagingList= _iRowContentList
                                                  .Skip(30)
                                                  .Take(2).ToList();
                    }


                _iDevelomentTable1EditModel.RowContentList=_iRowContentPagingList;

                return await Task.FromResult((IViewComponentResult)View("Default", _iDevelomentTable1EditModel));

            }
            catch (Exception ex)
            {
                AppUtility_DebugManager.Debug_Get_MessageText(ex.Message.ToString());
                return null;
            }









        }








    }
}
