using BSRVemcoCS.DBContext;
using BSRVemcoCS.DBModels;
using BSRVemcoCS.Models;

namespace BSRVemcoCS.iAppManager
{
    public class AppBuildingInformationCriterionManager
    {




   public static async Task  <List<AppUserBuildingTableCriterionModelManager>>   getCriterionList (BSRDBModelContext _dbContext , string AppInformationTokenID )
        {


            try
            {


                List<BsrvemcoAppBuildingInformationCriterionList>? _arrBuildingInfomationCriterionList = _dbContext.BsrvemcoAppBuildingInformationCriterionLists
                     .Where ( u => u.AppinformationTokenId == AppInformationTokenID )
                     //.Select (u  )
                     //.SingleOrDefault ( ); // This is what actually executes the request and return a response
                     .ToList ( ); // This is what actually executes the request and return a response

                List<AppUserBuildingTableCriterionModelManager> _arrColumnCriterionList = new List<AppUserBuildingTableCriterionModelManager> ( );


                if ( _arrBuildingInfomationCriterionList != null && _arrBuildingInfomationCriterionList.Count > 0 )
                {
                    for ( int i = 0 ; i < _arrBuildingInfomationCriterionList.Count ; i++ )
                    {
                        _arrColumnCriterionList.Add ( new AppUserBuildingTableCriterionModelManager ( )
                        {
                            CriterionToken = "0" ,
                            CriterionText = _arrBuildingInfomationCriterionList[ i ].CriterionText
                        } );

                    }

                }
                else
                {
                    _arrColumnCriterionList = new List<AppUserBuildingTableCriterionModelManager> ( );
                }











                //////// ColumnCriterionList = new List<AppUserBuildingTableCriterionModelManager> ( ) 

                //_arrColumnCriterionList.Add ( new AppUserBuildingTableCriterionModelManager ( )
                //{
                //    CriterionToken = "0" ,
                //    CriterionText = "Needs updating"
                //} );

                //_arrColumnCriterionList.Add ( new AppUserBuildingTableCriterionModelManager ( )
                //{
                //    CriterionToken = "0" ,
                //    CriterionText = "No/unknown"
                //} );

                return  await Task.FromResult(_arrColumnCriterionList) ;
            }
            catch ( Exception )
            {
                return new List<AppUserBuildingTableCriterionModelManager> ( ); ;
                throw;
            }


        }





    }
}
