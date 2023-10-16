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

        public async Task<IViewComponentResult> InvokeAsync(string bldtknid, string querytbltknid, string iPageNumber, bool blnIsPaging)
        {



            try
            {

                var _iUserBuildignQueryTableModel = _dbContext.BsrvemcoUserBuildingQueryInformationTableLists
                   .Where(u =>
                   u.QueryTableTokenId == querytbltknid &&
                   u.IsVisible == true)
                   //.Select (u  )
                   .FirstOrDefault(); // This is what actually executes the request and return a response





                // string id = HttpContext.Request.RouteValues[ "bldtknid" ].ToString ( );


                List<BsrvemcoUserBuildingQueryInformationList>? _arrCheckCountUserBuildingInfomationList = _dbContext.BsrvemcoUserBuildingQueryInformationLists
                .Where(u =>
                u.BuildingTokenId == bldtknid  &&
                u.QueryTableTokenId == querytbltknid &&
                u.IsVisible == true)
                 //.Select (u  )
                 //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                 .ToList(); // This is what actually executes the request and return a response



                if (_arrCheckCountUserBuildingInfomationList.Count == 0)
                {

                    List<BsrvemcoAppBuildingQueryInformationList>? _arrAppDevelomentInfomationList = _dbContext.BsrvemcoAppBuildingQueryInformationLists
                         .Where(u =>
                         u.AppqueryTableTokenId == _iUserBuildignQueryTableModel.AppqueryTableTokenId && //querytbltknid &&
                         u.IsVisible == true)
                         //.Select (u  )
                         //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                         .ToList(); // This is what actually executes the request and return a response


                    ArrayList _arrTokenList = new ArrayList();
                    _arrTokenList = AppUtility_ListTokenIDManager.ListTokenID_Generate_NewList(_arrAppDevelomentInfomationList.Count.ToString());



                    ////////////////////////////////////////

                    BsrvemcoUserBuildingQueryInformationList iBuildingQueryInformationModel;

                    for (int i = 0; i < _arrAppDevelomentInfomationList.Count; i++)
                    {


                        iBuildingQueryInformationModel = new BsrvemcoUserBuildingQueryInformationList()
                        {

                            RowViewTokenId = new Guid(),



                            OwnerUserTokenId = Program.iOwnerModel.OwnerUserTokenID,
                            CompanyTokenId = Program.iOwnerModel.CompanyTokenID,
                            BuildingTokenId = bldtknid,

                            AppqueryTableTokenId = _arrAppDevelomentInfomationList[i].AppqueryTableTokenId.ToString(),
                            AppqueryInformationTokenId =  _arrAppDevelomentInfomationList[i].AppqueryInformationTokenId.ToString(),
                            QueryTableTokenId = querytbltknid,
                            QueryInformationTokenId = _arrTokenList[i].ToString(),
                            InformationText = _arrAppDevelomentInfomationList[i].InformationText.ToString(),
                            InformationTitle = _arrAppDevelomentInfomationList[i].InformationTitle.ToString(),
                            InformationDescription = _arrAppDevelomentInfomationList[i].InformationDescription.ToString(),
                            InformationTitleSystem = _arrAppDevelomentInfomationList[i].InformationTitle.ToString(),
                            InformationDescriptionSystem = _arrAppDevelomentInfomationList[i].InformationDescription.ToString(),
                            InformationTitleUser = _arrAppDevelomentInfomationList[i].InformationTitle.ToString(),
                            InformationDescriptionUser = _arrAppDevelomentInfomationList[i].InformationDescription.ToString(),
                            EvidenceDescription =  "0",//_arrAppDevelomentInfomationList[i].EvidenceDescription.ToString(),
                            EvidenceLinkDescription = _arrAppDevelomentInfomationList[i].EvidenceLinkDescription.ToString(),

                            //TimeoutYearCount=  _arrAppDevelomentInfomationList[i].TimeoutYearCount.ToString(),

                            //InformationScore = "5",
                            //Score = "5",
                            //ScoreManaged = "5",
                            //ScoreAdjusted = "5",
                            //ScoreOriginal = "5",


                            UploadDateTimeMilliSec = AppUtility_TimeManager.Time_GetCurrentTimeInMilliSecond(),
                            IsVisible = true,
                            IsActive = true,

                        };


                        await _dbContext.BsrvemcoUserBuildingQueryInformationLists.AddAsync(iBuildingQueryInformationModel);


                        await _dbContext.SaveChangesAsync();


                    }


                }






































                List<BsrvemcoUserBuildingQueryInformationList>? _arrUserBuildingQueryInfomationList = _dbContext.BsrvemcoUserBuildingQueryInformationLists
                    .Where(u =>
                    u.BuildingTokenId == bldtknid  &&
                    u.QueryTableTokenId == querytbltknid &&
                    u.IsVisible== true)
                     //.Select (u  )
                     //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                     .ToList(); // This is what actually executes the request and return a response



                List<AppUserBuildingQueryRowModelManager> _iRowContentList = new List<AppUserBuildingQueryRowModelManager>();

                AppUserBuildingQueryRowModelManager iNewQueryDocument;

                for (int i = 0; i < _arrUserBuildingQueryInfomationList.Count; i++)
                {

                    iNewQueryDocument= new AppUserBuildingQueryRowModelManager()
                    {
                        _id = i,

                        AppQueryTableTokenID = _arrUserBuildingQueryInfomationList[i].AppqueryTableTokenId,
                        QueryTableTokenID = _arrUserBuildingQueryInfomationList[i].QueryTableTokenId,

                        AppQueryInformationTokenID = _arrUserBuildingQueryInfomationList[i].AppqueryInformationTokenId,
                        QueryInformationTokenID = _arrUserBuildingQueryInfomationList[i].QueryInformationTokenId,

                        CompanyTokenID = Program.iOwnerModel.CompanyTokenID,
                        BuildingTokenID = bldtknid,

                        InformationText = _arrUserBuildingQueryInfomationList[i].InformationText, //"Fire Strategy" ,

                        InformationTitle = _arrUserBuildingQueryInfomationList[i].InformationTitle, //"Fire Strategy" ,
                        InformationDescription = _arrUserBuildingQueryInfomationList[i].InformationDescription, //"Fire Strategy" ,

                        InformationTitleSystem = _arrUserBuildingQueryInfomationList[i].InformationTitleSystem, //"Fire Strategy" ,
                        InformationDescriptionSystem = _arrUserBuildingQueryInfomationList[i].InformationDescriptionSystem, //"Fire Strategy" ,

                        InformationTitleUser = _arrUserBuildingQueryInfomationList[i].InformationTitleUser, //"Fire Strategy" ,
                        InformationDescriptionUser = _arrUserBuildingQueryInfomationList[i].InformationDescriptionUser, //"Fire Strategy" ,

                        ColumnEvidenceDescription = _arrUserBuildingQueryInfomationList[i].EvidenceDescription, //"Fire Strategy" ,

                        AnswerCode = _arrUserBuildingQueryInfomationList[i].AnswerCode, //"Fire Strategy" ,

                        ColumnCommentary = "0",//_arrUserBuildingQueryInfomationList[i].Commentary,
                        ColumnEvidenceText = "0",


                        ColumnEvideceLink = "0",// _arrUserBuildingQueryInfomationList[i].Score,

                        //ColumnScoreOriginal = _arrUserBuildingQueryInfomationList[i].ScoreOriginal,
                        //ColumnScoreManaged = _arrUserBuildingQueryInfomationList[i].ScoreManaged,
                        //ColumnScoreAdjused = _arrUserBuildingQueryInfomationList[i].ScoreAdjusted,
                        //ColumnRiskControlMeasure = _arrUserBuildingQueryInfomationList[i].RiskControlMeasure,
                        //ColumnTotal = "0",



                        ColumnEvidenceList = await AppBuildingQueryInformationEvidenceManager.getEvidenceList(_dbContext, _arrUserBuildingQueryInfomationList[i].AppqueryInformationTokenId!),

                        ColumnQueryDocumentList = await AppBuildingQueryInformationEvidenceManager.GetQueryDocumentList(_dbContext, _arrUserBuildingQueryInfomationList[i].BuildingTokenId!, _arrUserBuildingQueryInfomationList[i].QueryInformationTokenId),

                    };

                    iNewQueryDocument.DocumentCount=   iNewQueryDocument.ColumnQueryDocumentList.Count().ToString();

                    if (iNewQueryDocument.AnswerCode== "0")
                    {
                        iNewQueryDocument.AnswerYESButtonCSS="btn-outline-secondary";
                        iNewQueryDocument.AnswerNOButtonCSS="btn-outline-secondary";
                        iNewQueryDocument.AnswerNULLButtonCSS="btn-outline-secondary";
                    }
                      if (iNewQueryDocument.AnswerCode== "yes")
                    {
                        iNewQueryDocument.AnswerYESButtonCSS="btn-secondary";
                        iNewQueryDocument.AnswerNOButtonCSS="btn-outline-secondary";
                        iNewQueryDocument.AnswerNULLButtonCSS="btn-outline-secondary";
                    }
                      if (iNewQueryDocument.AnswerCode== "no")
                    {
                        iNewQueryDocument.AnswerYESButtonCSS="btn-outline-secondary";
                        iNewQueryDocument.AnswerNOButtonCSS="btn-secondary";
                        iNewQueryDocument.AnswerNULLButtonCSS="btn-outline-secondary";
                    }
                      if (iNewQueryDocument.AnswerCode== "null")
                    {
                        iNewQueryDocument.AnswerYESButtonCSS="btn-outline-secondary";
                        iNewQueryDocument.AnswerNOButtonCSS="btn-outline-secondary";
                        iNewQueryDocument.AnswerNULLButtonCSS="btn-secondary";
                    
                        iNewQueryDocument.ColumnEvideceLink="N/A";
                   
                    
                    }



                    _iRowContentList.Add(iNewQueryDocument);
                }



                List<AppUserBuildingQueryRowModelManager> _iRowContentPagingList = new List<AppUserBuildingQueryRowModelManager>();

                if (blnIsPaging == false)
                {
                    _iRowContentPagingList= _iRowContentList;
                }
                else
                {
                    if (iPageNumber== "0")
                    {
                        _iRowContentPagingList= _iRowContentList.Take(5).ToList();
                    }

                    else if (iPageNumber== "1")
                    {
                        _iRowContentPagingList= _iRowContentList.Take(5).ToList();
                    }

                    else if (iPageNumber== "2")
                    {
                        _iRowContentPagingList= _iRowContentList
                                                  .Skip(5)
                                                  .Take(5).ToList();
                    }

                    else if (iPageNumber== "3")
                    {
                        _iRowContentPagingList= _iRowContentList
                                                  .Skip(10)
                                                  .Take(5).ToList();
                    }



                }


                AppDevelomentQueryTableViewModel _iDevelomentQueryTableViewModel = new AppDevelomentQueryTableViewModel()
                {
                    TableTitle = "TableTitle",
                    TableDescription = "TableDescription",

                    ColumnDescription = "Description",
                    ColumnCommentary = "Commentary",
                    ColumnCriterion = "Criterion",
                    //ColumnScore = "Score",
                    //ColumnScoreOriginal = "ScoreOriginal",
                    //ColumnScoreManaged = "Score",
                    //ColumnScoreAdjused = "Adjusted Score",
                    ////ColumnRiskControlMeasure = "Risk Control Measure Risk Control Measure" ,
                    //ColumnRiskControlMeasure = "Risk Control Measure",
                    ////ColumnScoreTotal = "333" ,
                    //ColumnScoreTotal = _dbContext.BsrvemcoUserBuildingInformationLists
                    //.Where(
                    //    c =>
                    //    c.ApptableTokenId == "1689022008239" &&
                    //    c.BuildingTokenId == id)
                    //.Sum(clmn => Convert.ToDecimal(clmn.ScoreAdjusted!)).ToString("0.0"),

                    RowContentList = _iRowContentPagingList,
                };


                //return View(_iDevelomentTable1EditModel);

                return await Task.FromResult((IViewComponentResult)View("Default", _iDevelomentQueryTableViewModel));


            }
            catch (Exception ex)
            {
                AppUtility_DebugManager.Debug_Get_MessageText(ex.Message.ToString());
                return null;
            }









        }








    }
}
