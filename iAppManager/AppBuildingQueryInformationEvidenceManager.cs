using BSRVemcoCS.DBContext;
using BSRVemcoCS.DBModels;
using BSRVemcoCS.Models;

using System.Data.Entity.Core.Mapping;

namespace BSRVemcoCS.iAppManager
{
    public class AppBuildingQueryInformationEvidenceManager
    {




   public static async Task  <List<AppUserBuildingQueryEvidenceModelManager>> getEvidenceList(BSRDBModelContext _dbContext , string AppQueryInformationTokenID )
        {


            try
            {


                List<BsrvemcoAppBuildingQueryInformationEvidenceList >? _arrBuildingInfomationCriterionList = _dbContext.BsrvemcoAppBuildingQueryInformationEvidenceLists
                     .Where ( u => u.AppqueryInformationTokenId == AppQueryInformationTokenID )
                     //.Select (u  )
                     //.SingleOrDefault ( ); // This is what actually executes the request and return a response
                     .ToList ( ); // This is what actually executes the request and return a response

                List<AppUserBuildingQueryEvidenceModelManager> _arrColumnEvidenceList = new List<AppUserBuildingQueryEvidenceModelManager> ( );


                if ( _arrBuildingInfomationCriterionList != null && _arrBuildingInfomationCriterionList.Count > 0 )
                {
                    for ( int i = 0 ; i < _arrBuildingInfomationCriterionList.Count ; i++ )
                    {
                        _arrColumnEvidenceList.Add ( new AppUserBuildingQueryEvidenceModelManager ( )
                        {
                            EvidenceToken = "0" ,
                            EvidenceText = _arrBuildingInfomationCriterionList[ i ].EvidenceText
                        } );

                    }

                }
                else
                {
                    _arrColumnEvidenceList = new List<AppUserBuildingQueryEvidenceModelManager> ( );
                }
 

                return  await Task.FromResult(_arrColumnEvidenceList) ;
            }
            catch ( Exception )
            {
                return new List<AppUserBuildingQueryEvidenceModelManager> ( ); ;
                throw;
            }


        }





   public static async Task<List<AppUserBuildingQueryDocumentModelManager>> GetQueryDocumentList(BSRDBModelContext _dbContext , string bldtknid, string iqueryinftknid)
        {


            try
            {

                //List<AppUserBuildingQueryDocumentModelManager> _arrColumnQueryDocumentList = new List<AppUserBuildingQueryDocumentModelManager>();

                List<BsrvemcoUserBuildingQueryDocumentList>? _arrQueryDocumentList =   _dbContext.BsrvemcoUserBuildingQueryDocumentLists
                                    .Where(u =>
                                    u.BuildingTokenId == bldtknid &&
                                    u.QueryInformationTokenId == iqueryinftknid &&
                                    u.IsVisible ==true)
                                    //.Select (u  )
                                    //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                                    .ToList(); // This is what actually executes the request and return a response



                List<AppUserBuildingQueryDocumentModelManager> _arrBuildingInformationDocumentList = new List<AppUserBuildingQueryDocumentModelManager>();
                AppUserBuildingQueryDocumentModelManager _iDocumentViewModel;


                if (_arrQueryDocumentList != null)
                {
                    for (int i = 0; i < _arrQueryDocumentList.Count; i++)
                    {
                        _iDocumentViewModel = new AppUserBuildingQueryDocumentModelManager()
                        {

                            //BuildingTokenID = bldtknid,
                            //AppQueryTableTokenID = _arrQueryDocumentList[i].AppqueryTableTokenId,
                            //APPQueryInformationTokenID = _arrQueryDocumentList[i].AppqueryInformationTokenId,
                            //QueryInformationTokenID = iqueryinftknid,
                            //QueryTableTokenID =  _arrQueryDocumentList[i].QueryTableTokenId,
                            //DocumentTokenID = _arrQueryDocumentList[i].DocumentTokenId,
                            DocumentWebUrl = _arrQueryDocumentList[i].DocumentWebUrl.ToString().ToLower(),
                            //DocumentName = _arrQueryDocumentList[i].DocumentName,
                            //DocumentCode = _arrQueryDocumentList[i].DocumentCode,
                            //DocumentType = _arrQueryDocumentList[i].DocumentType,
                            //DocumentDescription = _arrQueryDocumentList[i].DocumentDescription,
                            //DocumentSize = _arrQueryDocumentList[i].DocumentSize,
                            //TimeoutUserUploadStartDay = _arrQueryDocumentList[i].TimeoutUserUploadStartDay,
                            //TimeoutUserUploadStartMonth = _arrQueryDocumentList[i].TimeoutUserUploadStartMonth,
                            //TimeoutUserUploadStartYear = _arrQueryDocumentList[i].TimeoutUserUploadStartYear,
                            //TimeoutUserUploadStartText = _arrQueryDocumentList[i].TimeoutUserUploadStartText,
                            //TimeoutYearCount = _arrQueryDocumentList[i].TimeoutYearCount,
                            //TimeoutUserUploadStart = (DateTime)_arrQueryDocumentList[i].TimeoutUserUploadStart,
                        };
                        _arrBuildingInformationDocumentList.Add(_iDocumentViewModel);

                    }
 
                }



                return await Task.FromResult(_arrBuildingInformationDocumentList) ;
            }
            catch ( Exception )
            {
                return new List<AppUserBuildingQueryDocumentModelManager> ( ); ;
                throw;
            }


        }



    }
}
