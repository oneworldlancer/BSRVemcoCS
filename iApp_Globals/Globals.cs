using BSRVemcoCS.Models;

namespace BSRVemcoCS.iApp_Globals
{
    public static class Globals
    {
        public static string dbConnection_BSRVEMCODB { get; set; } = Program.iConfig[ "ConnectionStrings:BSRVEMCODB" ].ToString ( );

        public static AppUserOwnerModelManager iOwnerModel { get; set; }  
    }
}
