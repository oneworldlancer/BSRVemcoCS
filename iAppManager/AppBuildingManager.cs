using BSRVemcoCS.DBContext;
using BSRVemcoCS.Models;

namespace BSRVemcoCS.iAppManager
{
    public class AppBuildingManager
    {




        public static async Task<AppUserBuildingStatisticModelManager> Building_Get_BuildingStatisticModel_ByBuildingTokenID (
            BSRDBModelContext _dbContext , string iBuildingTokenID )
        {


            try
            {


                //////AppUserBuildingStatisticModelManager  _arrBuildingInfomationCriterionList = _dbContext.AppUserBuildingStatisticModelManagers
                //////     .Where ( u => u.AppinformationTokenId == AppInformationTokenID )
                //////     //.Select (u  )
                //////     //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                //////     .ToList ( ); // This is what actually executes the request and return a response

                //  AppUserBuildingTableCriterionModelManager  _arrColumnCriterionList = new  AppUserBuildingTableCriterionModelManager  ( );

                AppUserBuildingStatisticModelManager _iUserBuildingStatisticModel = new AppUserBuildingStatisticModelManager ( );

                _iUserBuildingStatisticModel.BuildingTokenID = iBuildingTokenID;



                _iUserBuildingStatisticModel.Table1ScoreCountRow = _dbContext.BsrvemcoUserBuildingInformationLists
                    .Where (
                        c =>
                        c.ApptableTokenId == "1689022008239" &&
                        c.BuildingTokenId == iBuildingTokenID )
                    .Count ( );
                //.Sum ( clmn => Convert.ToDecimal ( clmn.ScoreAdjusted! ) ).ToString ("0.0" );//"60"; //3 * 20 ;



                _iUserBuildingStatisticModel.Table1ScoreTotal = _dbContext.BsrvemcoUserBuildingInformationLists
                    .Where (
                        c =>
                        c.ApptableTokenId == "1689022008239" &&
                        c.BuildingTokenId == iBuildingTokenID )
                    .Sum ( clmn => Convert.ToDecimal ( clmn.ScoreAdjusted! ) ).ToString ( "0.0" );//"60"; //3 * 20 ;




                _iUserBuildingStatisticModel.Table2ScoreCountRow = _dbContext.BsrvemcoUserBuildingInformationLists
                    .Where (
                        c =>
                        c.ApptableTokenId == "1689162197100" &&
                        c.BuildingTokenId == iBuildingTokenID )
                         .Count ( );

                //.Sum ( clmn => Convert.ToDecimal ( clmn.ScoreAdjusted! ) ).ToString ( "0.0" );//"27"; // 3 * 9 ;






                _iUserBuildingStatisticModel.Table2ScoreTotal = _dbContext.BsrvemcoUserBuildingInformationLists
                    .Where (
                        c =>
                        c.ApptableTokenId == "1689162197100" &&
                        c.BuildingTokenId == iBuildingTokenID )
                    .Sum ( clmn => Convert.ToDecimal ( clmn.ScoreAdjusted! ) ).ToString ( "0.0" );//"27"; // 3 * 9 ;










                _iUserBuildingStatisticModel.Table3ScoreCountRow = _dbContext.BsrvemcoUserBuildingInformationLists
                    .Where (
                        c =>
                        c.ApptableTokenId == "1689162201957" &&
                        c.BuildingTokenId == iBuildingTokenID )
                            .Count ( );

                //.Sum ( clmn => Convert.ToDecimal ( clmn.ScoreAdjusted! ) ).ToString ( "0.0" );// "12"; //  4 * 3 ;





                _iUserBuildingStatisticModel.Table3ScoreTotal = _dbContext.BsrvemcoUserBuildingInformationLists
                    .Where (
                        c =>
                        c.ApptableTokenId == "1689162201957" &&
                        c.BuildingTokenId == iBuildingTokenID )
                    .Sum ( clmn => Convert.ToDecimal ( clmn.ScoreAdjusted! ) ).ToString ( "0.0" );// "12"; //  4 * 3 ;





                //////_iUserBuildingStatisticModel.Table4ScoreCountRow = _dbContext.BsrvemcoUserBuildingInformationLists
                //////    .Where (
                //////        c =>
                //////        c.ApptableTokenId == "1689162207917" &&
                //////        c.BuildingTokenId == iBuildingTokenID )
                //////        .Count ( );

                // PointY
                //_iUserBuildingStatisticModel.Table4ScoreAverage = "3.0"; // (3 * 11) / 11  iBuildingTokenID;
                _iUserBuildingStatisticModel.Table4ScoreAverage = _dbContext.BsrvemcoUserBuildingInformationLists
                    .Where (
                        c =>
                        c.ApptableTokenId == "1689162207917" &&
                        c.BuildingTokenId == iBuildingTokenID )
                    .Average ( clmn => Convert.ToDouble ( clmn.ScoreAdjusted! ) ).ToString ( "0.0" );// "3.5"; // (3 * 11) / 11  iBuildingTokenID;

                _iUserBuildingStatisticModel.ScoreTotalQuality = ( Convert.ToDecimal ( _iUserBuildingStatisticModel.Table1ScoreTotal ) + Convert.ToDecimal ( _iUserBuildingStatisticModel.Table2ScoreTotal ) + Convert.ToDecimal ( _iUserBuildingStatisticModel.Table3ScoreTotal ) ).ToString ( "0.0" );  //"99"; // (  tbl1 + tbl2 + tbl3 );

                // PointX
                //_iUserBuildingStatisticModel.ScoreRiskAverage = "3.0"; // ( 99 / ( 20 + 9 + 3)) 
                _iUserBuildingStatisticModel.ScoreRiskAverage = ( Convert.ToDecimal ( _iUserBuildingStatisticModel.ScoreTotalQuality ) /
                    ( _iUserBuildingStatisticModel.Table1ScoreCountRow + _iUserBuildingStatisticModel.Table2ScoreCountRow + _iUserBuildingStatisticModel.Table3ScoreCountRow ) ).ToString ( "0.0" );// "2.5"; // ( 99 / ( 20 + 9 + 3)) 


                //if ( _arrBuildingInfomationCriterionList != null && _arrBuildingInfomationCriterionList.Count > 0 )
                //{
                //    for ( int i = 0 ; i < _arrBuildingInfomationCriterionList.Count ; i++ )
                //    {
                //        _arrColumnCriterionList.Add ( new AppUserBuildingTableCriterionModelManager ( )
                //        {
                //            CriterionToken = "0" ,
                //            CriterionText = _arrBuildingInfomationCriterionList[ i ].CriterionText
                //        } );

                //    }

                //}
                //else
                //{
                //    _arrColumnCriterionList = new List<AppUserBuildingTableCriterionModelManager> ( );
                //}











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

                return await Task.FromResult ( _iUserBuildingStatisticModel );
            }
            catch ( Exception )
            {
                return new AppUserBuildingStatisticModelManager ( ); ;
                throw;
            }


        }












        public static async Task<bool> Building_Update_BuildingInformationScore_ByInformationTokenID (
            BSRDBModelContext _dbContext ,
            string iBuildingTokenID ,
            string iInformationTokenID ,
            string iScoreAdjusted = "0" ,
            string iRiskControlMeasure = "0" )
        {


            try
            {

  var _iBuildingInfomationModel = _dbContext.BsrvemcoUserBuildingInformationLists
                      .Where ( u =>
                      u.BuildingTokenId == iBuildingTokenID &&
                      u.InformationTokenId == iInformationTokenID )
                      //.Select (u  )
                      .FirstOrDefault ( ); // This is what actually executes the request and return a response
                                           // .ToList ( ); // This is what actually executes the request and return a response



                if ( _iBuildingInfomationModel != null )
                {
                    _iBuildingInfomationModel.ScoreAdjusted = iScoreAdjusted;
                    _iBuildingInfomationModel.RiskControlMeasure = iRiskControlMeasure;

                    _dbContext.Update ( _iBuildingInfomationModel );
                    await _dbContext.SaveChangesAsync ( );
                }

                return await Task.FromResult ( true );
            }
            catch ( Exception ex)
            {
                iAppUtility.AppUtility_DebugManager.Debug_Get_MessageText ( ex.Message);
                   return await Task.FromResult ( false ); 
                // return new AppUserBuildingStatisticModelManager ( ); ;
               // throw;
            }


        }














        public static async Task<AppUserBuildingStatisticModelManager> Building_Get_BuildingStatisticModel_ByBuildingTokenID_X1 (
            BSRDBModelContext _dbContext , string iBuildingTokenID )
        {


            try
            {


                //////AppUserBuildingStatisticModelManager  _arrBuildingInfomationCriterionList = _dbContext.AppUserBuildingStatisticModelManagers
                //////     .Where ( u => u.AppinformationTokenId == AppInformationTokenID )
                //////     //.Select (u  )
                //////     //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                //////     .ToList ( ); // This is what actually executes the request and return a response

                //  AppUserBuildingTableCriterionModelManager  _arrColumnCriterionList = new  AppUserBuildingTableCriterionModelManager  ( );

                AppUserBuildingStatisticModelManager _iUserBuildingStatisticModel = new AppUserBuildingStatisticModelManager ( );

                _iUserBuildingStatisticModel.BuildingTokenID = iBuildingTokenID;

                _iUserBuildingStatisticModel.Table1ScoreTotal = "60"; //3 * 20 ;
                _iUserBuildingStatisticModel.Table2ScoreTotal = "27"; // 3 * 9 ;
                _iUserBuildingStatisticModel.Table3ScoreTotal = "12"; //  4 * 3 ;


                // PointY
                //_iUserBuildingStatisticModel.Table4ScoreAverage = "3.0"; // (3 * 11) / 11  iBuildingTokenID;
                _iUserBuildingStatisticModel.Table4ScoreAverage = "3.5"; // (3 * 11) / 11  iBuildingTokenID;

                _iUserBuildingStatisticModel.ScoreTotalQuality = "99"; // (  tbl1 + tbl2 + tbl3 );

                // PointX
                //_iUserBuildingStatisticModel.ScoreRiskAverage = "3.0"; // ( 99 / ( 20 + 9 + 3)) 
                _iUserBuildingStatisticModel.ScoreRiskAverage = "2.5"; // ( 99 / ( 20 + 9 + 3)) 


                //if ( _arrBuildingInfomationCriterionList != null && _arrBuildingInfomationCriterionList.Count > 0 )
                //{
                //    for ( int i = 0 ; i < _arrBuildingInfomationCriterionList.Count ; i++ )
                //    {
                //        _arrColumnCriterionList.Add ( new AppUserBuildingTableCriterionModelManager ( )
                //        {
                //            CriterionToken = "0" ,
                //            CriterionText = _arrBuildingInfomationCriterionList[ i ].CriterionText
                //        } );

                //    }

                //}
                //else
                //{
                //    _arrColumnCriterionList = new List<AppUserBuildingTableCriterionModelManager> ( );
                //}











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

                return await Task.FromResult ( _iUserBuildingStatisticModel );
            }
            catch ( Exception )
            {
                return new AppUserBuildingStatisticModelManager ( ); ;
                throw;
            }


        }




    }
}
