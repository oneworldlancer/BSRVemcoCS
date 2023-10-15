using BSRVemcoCS.DBContext;
using BSRVemcoCS.Models;

namespace BSRVemcoCS.iAppManager
{
    public class AppCMSPageManager
    {

        public static async Task<bool> CMSPage_Update_HTMLContent_ByPageTokenID (
            BSRDBModelContext _dbContext ,
            string iPageTokenID ,
            string iPageCode ,
            string iPageHTMLContent )
        {


            try
            {


  var _iCMSPageModel = _dbContext.BsrvemcoAppCmsPageLists
                      .Where ( u =>
                      u.PageCode == iPageCode)
                      //.Select (u  )
                      .FirstOrDefault ( ); // This is what actually executes the request and return a response
                                            // .ToList ( ); // This is what actually executes the request and return a response



                if ( _iCMSPageModel != null )
                {
                    _iCMSPageModel.PageHtmlcontent = iPageHTMLContent;
                  
                    _dbContext.Update ( _iCMSPageModel );
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



    }
}
