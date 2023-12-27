using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BSRVemcoCS.DBContext;
using BSRVemcoCS.iApp_Identity;
using BSRVemcoCS.iAppViewModel;

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Net;
using System.Net.Mail;
using BSRVemcoCS.iAppUtility;
using BSRVemcoCS.DBModels;

using System.Collections;

namespace BSRVemcoCS.Areas.iWebMember.Controllers
{

    [Area("iWebMember")]
    //[Authorize]
    public class BSRVemcoPageComponentController : Controller
    {

        private readonly BSRDBModelContext _dbContext;


        private readonly UserManager<AppCore_IdentityUser> iUserManager;
        private readonly SignInManager<AppCore_IdentityUser> iSignManager;


        //List<SocialIcon> socialIcons = new List<SocialIcon> ( );
        public BSRVemcoPageComponentController(BSRDBModelContext dbContext,
            UserManager<AppCore_IdentityUser> iUserManager,
                        SignInManager<AppCore_IdentityUser> iSignManager)
        {
            //socialIcons = SocialIcon.AppSocialIcons ( );
            _dbContext = dbContext;
            this.iUserManager = iUserManager;
            this.iSignManager = iSignManager;

        }



        public IActionResult PageComponentView_Load_BSRVemcoPagePathName(
            string ParentPageName,
            string ChildPageName,
            string ParentPageNameColorCSS,
            string ChildPageNameColorCSS,
           string ChildPageNameCSS)
        {
            /*string bldtknid, string iPageNumber, string blnIsPaging*/           /* bool showPrevious , bool showUpcoming */

            return ViewComponent("BSRVemcoPagePathName",
                new
                {

                    ParentPageName = ParentPageName,
                    ChildPageName = ChildPageName,
                    ParentPageNameColorCSS = ParentPageNameColorCSS,
                    ChildPageNameColorCSS = ChildPageNameColorCSS,
                    ChildPageNameCSS = ChildPageNameCSS
                });


            //return ViewComponent("BSRVemcoPage_ContactUs",
            //    new
            //    {
            //        //////////bldtknid = bldtknid,
            //        ////////////querytbltknid = querytbltknid,
            //        //////////iPageNumber = iPageNumber,
            //        //////////blnIsPaging = Boolean.Parse(blnIsPaging)
            //    });

            //return ViewComponent ( "DocumentList" ,
            //    new { showPrevious = showPrevious , showUpcoming = showUpcoming } );


        }



        public IActionResult PageComponentView_Load_ContactUsPage()
        {
            /*string bldtknid, string iPageNumber, string blnIsPaging*/           /* bool showPrevious , bool showUpcoming */

            //////////try
            //////////{


            //////////    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            //////////    //MailMessage msg = new MailMessage(
            //////////    //    "BSRHelpDesk@vemcoconsulting.com", "basil.jackson@vemcoconsulting.com",
            //////////    //    "Test E-mail 1101", "Hi there ...");


            //////////    MailMessage msg = new MailMessage(
            //////////        "BSRHelpDesk@vemcoconsulting.com", "oneworldlancer@gmail.com",
            //////////        "Test E-mail 2202", "Hi there ...");

            //////////    ////  SmtpClient smtp = new SmtpClient("vemcoconsulting-com.mail.protection.outlook.com", 25);
            //////////    //  SmtpClient smtp = new SmtpClient("vemcoconsulting-com.mail.protection.outlook.com", 25);
            //////////    SmtpClient smtp = new SmtpClient("smtp.office365.com", 587);

            //////////    smtp.UseDefaultCredentials = false;

            //////////    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            //////////    smtp.EnableSsl = true;

            //////////    smtp.Credentials= new NetworkCredential(
            //////////        "bsrhelpdesk@vemcoconsulting.com", "@goADMIN06021979", "vemcoconsulting.com");

            //////////    smtp.TargetName = "STARTTLS/smtp.office365.com";


            //////////    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            //////////    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            //////////    smtp.Send(msg);


            //////////}
            //////////catch (Exception ex)
            //////////{
            //////////    AppUtility_DebugManager.Debug_Get_MessageText(ex.Message.ToString());
            //////////}

            // Clean up.

            //msg.Dispose();

            return ViewComponent("BSRVemcoPage_ContactUs");


            //return ViewComponent("BSRVemcoPage_ContactUs",
            //    new
            //    {
            //        //////////bldtknid = bldtknid,
            //        ////////////querytbltknid = querytbltknid,
            //        //////////iPageNumber = iPageNumber,
            //        //////////blnIsPaging = Boolean.Parse(blnIsPaging)
            //    });

            //return ViewComponent ( "DocumentList" ,
            //    new { showPrevious = showPrevious , showUpcoming = showUpcoming } );


        }




        public IActionResult PageComponentView_Load_WorkFormPage()
        {

            return ViewComponent("BSRVemcoPage_WorkForm");


            //return ViewComponent("BSRVemcoPage_ContactUs",
            //    new
            //    {
            //        //////////bldtknid = bldtknid,
            //        ////////////querytbltknid = querytbltknid,
            //        //////////iPageNumber = iPageNumber,
            //        //////////blnIsPaging = Boolean.Parse(blnIsPaging)
            //    });

            //return ViewComponent ( "DocumentList" ,
            //    new { showPrevious = showPrevious , showUpcoming = showUpcoming } );


        }




        public IActionResult PageComponentView_Load_ContactUsPage_X1()
        {
            /*string bldtknid, string iPageNumber, string blnIsPaging*/           /* bool showPrevious , bool showUpcoming */

            try
            {


                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                //MailMessage msg = new MailMessage(
                //    "BSRHelpDesk@vemcoconsulting.com", "basil.jackson@vemcoconsulting.com",
                //    "Test E-mail 1101", "Hi there ...");


                MailMessage msg = new MailMessage(
                    "BSRHelpDesk@vemcoconsulting.com", "oneworldlancer@gmail.com",
                    "Test E-mail 2202", "Hi there ...");

                ////  SmtpClient smtp = new SmtpClient("vemcoconsulting-com.mail.protection.outlook.com", 25);
                //  SmtpClient smtp = new SmtpClient("vemcoconsulting-com.mail.protection.outlook.com", 25);
                SmtpClient smtp = new SmtpClient("smtp.office365.com", 587);

                smtp.UseDefaultCredentials = false;

                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                smtp.EnableSsl = true;

                smtp.Credentials= new NetworkCredential(
                    "bsrhelpdesk@vemcoconsulting.com", "@goADMIN06021979", "vemcoconsulting.com");

                smtp.TargetName = "STARTTLS/smtp.office365.com";


                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                smtp.Send(msg);


            }
            catch (Exception ex)
            {
                AppUtility_DebugManager.Debug_Get_MessageText(ex.Message.ToString());
            }


            //////////////// MailMessage msg = new MailMessage("BSRHelpDesk@vemcoconsulting.com", "oneworldlancer@gmail.com", "Test E-mail 1101", "Hi there ...");
            ////////////////SmtpClient smtp = new SmtpClient("gator3161.hostgator.com", 25);
            //////////////// // SmtpClient smtp = new SmtpClient("mail.vemcoconsulting.com", 25);
            //////////////// //SmtpClient smtp = new SmtpClient("mail.vemcoconsulting.com", 587);
            //////////////// smtp.UseDefaultCredentials = true;
            //////////////// smtp.Credentials= new NetworkCredential("bsrhelpdesk@vemcoconsulting.com", "@goShaymaaHafez06021979");
            //////////////// //smtp.EnableSsl = true;
            //////////////// //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            //////////////// //smtp.Timeout = 2000000; 

            //////////////// 

            // Clean up.

            //msg.Dispose();

            return ViewComponent("BSRVemcoPage_ContactUs");


            //return ViewComponent("BSRVemcoPage_ContactUs",
            //    new
            //    {
            //        //////////bldtknid = bldtknid,
            //        ////////////querytbltknid = querytbltknid,
            //        //////////iPageNumber = iPageNumber,
            //        //////////blnIsPaging = Boolean.Parse(blnIsPaging)
            //    });

            //return ViewComponent ( "DocumentList" ,
            //    new { showPrevious = showPrevious , showUpcoming = showUpcoming } );


        }






        public IActionResult PageComponentView_Load_TermsPage()
        {
            /*string bldtknid, string iPageNumber, string blnIsPaging*/           /* bool showPrevious , bool showUpcoming */


            var _iCMSPageModel = _dbContext.BsrvemcoAppCmsPageLists
                    .Where(u =>
                    u.PageCode == "terms")
                    //.Select (u  )
                    .FirstOrDefault();




            AppCMSPageViewModel _iCMSPageViewModel = new AppCMSPageViewModel();

            _iCMSPageViewModel.PageCode = "terms";
            _iCMSPageViewModel.PageHTMLContent = _iCMSPageModel.PageHtmlcontent;






            //var model = socialIcons;
            //  return await Task.FromResult ( ( IViewComponentResult ) View ( "Default" , model ) );
            //return await Task.FromResult ( ( IViewComponentResult ) View ( "Default" , null));// await Task.FromResult ( ( IViewComponentResult ) View ( "Default" , model ) );

            /////////////////return await Task.FromResult((IViewComponentResult)View("Default", _iCMSPageViewModel ) );


            //      return new HtmlContentViewComponentResult (
            //new HtmlString (    Task.FromResult ( ( IViewComponentResult ) View ( "Default" , _iCMSPageViewModel ) .ToString() )));


            //            return new HtmlContentViewComponentResult (
            //new HtmlString ( "<ul><li>My HTML code</li></ul>" ) );


            return Content(_iCMSPageViewModel.PageHTMLContent);













            //  return ViewComponent("BSRVemcoPage_Terms" );

            //return ViewComponent("CMS_PageViewHTMLContent",
            //    new
            //    {
            //        iPageCode = "terms"
            //    });


            //return ViewComponent("BSRVemcoPage_",
            //    new
            //    {
            //        //////////bldtknid = bldtknid,
            //        ////////////querytbltknid = querytbltknid,
            //        //////////iPageNumber = iPageNumber,
            //        //////////blnIsPaging = Boolean.Parse(blnIsPaging)
            //    });

            //return ViewComponent ( "DocumentList" ,
            //    new { showPrevious = showPrevious , showUpcoming = showUpcoming } );


        }






        public IActionResult PageComponentView_Load_WorkPermit()
        {
            /*string bldtknid, string iPageNumber, string blnIsPaging*/           /* bool showPrevious , bool showUpcoming */


            var _iCMSPageModel = _dbContext.BsrvemcoAppCmsPageLists
                    .Where(u =>
                    u.PageCode == "workpermit")
                    //.Select (u  )
                    .FirstOrDefault();




            AppCMSPageViewModel _iCMSPageViewModel = new AppCMSPageViewModel();

            _iCMSPageViewModel.PageCode = "workpermit";
            _iCMSPageViewModel.PageHTMLContent = _iCMSPageModel.PageHtmlcontent;






            //var model = socialIcons;
            //  return await Task.FromResult ( ( IViewComponentResult ) View ( "Default" , model ) );
            //return await Task.FromResult ( ( IViewComponentResult ) View ( "Default" , null));// await Task.FromResult ( ( IViewComponentResult ) View ( "Default" , model ) );

            /////////////////return await Task.FromResult((IViewComponentResult)View("Default", _iCMSPageViewModel ) );


            //      return new HtmlContentViewComponentResult (
            //new HtmlString (    Task.FromResult ( ( IViewComponentResult ) View ( "Default" , _iCMSPageViewModel ) .ToString() )));


            //            return new HtmlContentViewComponentResult (
            //new HtmlString ( "<ul><li>My HTML code</li></ul>" ) );


            return Content(_iCMSPageViewModel.PageHTMLContent);













            //  return ViewComponent("BSRVemcoPage_Terms" );

            //return ViewComponent("CMS_PageViewHTMLContent",
            //    new
            //    {
            //        iPageCode = "terms"
            //    });


            //return ViewComponent("BSRVemcoPage_",
            //    new
            //    {
            //        //////////bldtknid = bldtknid,
            //        ////////////querytbltknid = querytbltknid,
            //        //////////iPageNumber = iPageNumber,
            //        //////////blnIsPaging = Boolean.Parse(blnIsPaging)
            //    });

            //return ViewComponent ( "DocumentList" ,
            //    new { showPrevious = showPrevious , showUpcoming = showUpcoming } );


        }






        public IActionResult PageComponentView_Load_SubscriptionPage()
        {
            /*string bldtknid, string iPageNumber, string blnIsPaging*/           /* bool showPrevious , bool showUpcoming */

            return ViewComponent("BSRVemcoPage_Subscribe");


            //return ViewComponent("BSRVemcoPage_",
            //    new
            //    {
            //        //////////bldtknid = bldtknid,
            //        ////////////querytbltknid = querytbltknid,
            //        //////////iPageNumber = iPageNumber,
            //        //////////blnIsPaging = Boolean.Parse(blnIsPaging)
            //    });

            //return ViewComponent ( "DocumentList" ,
            //    new { showPrevious = showPrevious , showUpcoming = showUpcoming } );


        }






        public IActionResult PageComponentView_Load_ProfilePage()
        {
            /*string bldtknid, string iPageNumber, string blnIsPaging*/           /* bool showPrevious , bool showUpcoming */

            return ViewComponent("BSRVemcoPage_Profile");


            //return ViewComponent("BSRVemcoPage_",
            //    new
            //    {
            //        //////////bldtknid = bldtknid,
            //        ////////////querytbltknid = querytbltknid,
            //        //////////iPageNumber = iPageNumber,
            //        //////////blnIsPaging = Boolean.Parse(blnIsPaging)
            //    });

            //return ViewComponent ( "DocumentList" ,
            //    new { showPrevious = showPrevious , showUpcoming = showUpcoming } );


        }






        public IActionResult PageComponentView_Load_InvitePage()
        {
            /*string bldtknid, string iPageNumber, string blnIsPaging*/           /* bool showPrevious , bool showUpcoming */

            return ViewComponent("BSRVemcoPage_InviteUser");


            //return ViewComponent("BSRVemcoPage_",
            //    new
            //    {
            //        //////////bldtknid = bldtknid,
            //        ////////////querytbltknid = querytbltknid,
            //        //////////iPageNumber = iPageNumber,
            //        //////////blnIsPaging = Boolean.Parse(blnIsPaging)
            //    });

            //return ViewComponent ( "DocumentList" ,
            //    new { showPrevious = showPrevious , showUpcoming = showUpcoming } );


        }






        public IActionResult PageComponentView_Load_PasswordPage()
        {
            /*string bldtknid, string iPageNumber, string blnIsPaging*/           /* bool showPrevious , bool showUpcoming */

            return ViewComponent("BSRVemcoPage_Password");


            //return ViewComponent("BSRVemcoPage_",
            //    new
            //    {
            //        //////////bldtknid = bldtknid,
            //        ////////////querytbltknid = querytbltknid,
            //        //////////iPageNumber = iPageNumber,
            //        //////////blnIsPaging = Boolean.Parse(blnIsPaging)
            //    });

            //return ViewComponent ( "DocumentList" ,
            //    new { showPrevious = showPrevious , showUpcoming = showUpcoming } );


        }






        public IActionResult PageComponentView_Load_BulidingNewPage()
        {
            /*string bldtknid, string iPageNumber, string blnIsPaging*/           /* bool showPrevious , bool showUpcoming */

            return ViewComponent("BSRVemcoPage_BuildingNew");


            //return ViewComponent("BSRVemcoPage_",
            //    new
            //    {
            //        //////////bldtknid = bldtknid,
            //        ////////////querytbltknid = querytbltknid,
            //        //////////iPageNumber = iPageNumber,
            //        //////////blnIsPaging = Boolean.Parse(blnIsPaging)
            //    });

            //return ViewComponent ( "DocumentList" ,
            //    new { showPrevious = showPrevious , showUpcoming = showUpcoming } );


        }






        public IActionResult PageComponentView_Load_BulidingEditPage(string iBuildingTokenID)
        {
            /*string bldtknid, string iPageNumber, string blnIsPaging*/           /* bool showPrevious , bool showUpcoming */

            //  string id = Request.Query["bldtknid"].ToString();


            //  string state = "edit";









            return ViewComponent("BSRVemcoPage_BuildingEdit",
                new
                {
                    iBuildingTokenID = iBuildingTokenID
                });


            //return ViewComponent("BSRVemcoPage_",
            //    new
            //    {
            //        //////////bldtknid = bldtknid,
            //        ////////////querytbltknid = querytbltknid,
            //        //////////iPageNumber = iPageNumber,
            //        //////////blnIsPaging = Boolean.Parse(blnIsPaging)
            //    });

            //return ViewComponent ( "DocumentList" ,
            //    new { showPrevious = showPrevious , showUpcoming = showUpcoming } );


        }






        public IActionResult PageComponentView_Load_BulidingListPage()
        {
            /*string bldtknid, string iPageNumber, string blnIsPaging*/           /* bool showPrevious , bool showUpcoming */



            return ViewComponent("BSRVemcoPage_BuildingList");


            //return ViewComponent("BSRVemcoPage_",
            //    new
            //    {
            //        //////////bldtknid = bldtknid,
            //        ////////////querytbltknid = querytbltknid,
            //        //////////iPageNumber = iPageNumber,
            //        //////////blnIsPaging = Boolean.Parse(blnIsPaging)
            //    });

            //return ViewComponent ( "DocumentList" ,
            //    new { showPrevious = showPrevious , showUpcoming = showUpcoming } );


        }






        public IActionResult PageComponentView_Load_BulidingSummaryPage(string iBuildingTokenID)
        {
            /*string bldtknid, string iPageNumber, string blnIsPaging*/           /* bool showPrevious , bool showUpcoming */

            return ViewComponent("BSRVemcoPage_BuildingSummary",
                new
                {
                    iBuildingTokenID = iBuildingTokenID
                });


            //return ViewComponent("BSRVemcoPage_",
            //    new
            //    {
            //        //////////bldtknid = bldtknid,
            //        ////////////querytbltknid = querytbltknid,
            //        //////////iPageNumber = iPageNumber,
            //        //////////blnIsPaging = Boolean.Parse(blnIsPaging)
            //    });

            //return ViewComponent ( "DocumentList" ,
            //    new { showPrevious = showPrevious , showUpcoming = showUpcoming } );


        }






        public IActionResult PageComponentView_Load_BulidingGoldenPage(string iBuildingTokenID)
        {
            /*string bldtknid, string iPageNumber, string blnIsPaging*/           /* bool showPrevious , bool showUpcoming */

            return ViewComponent("BSRVemcoPage_BuildingGolden",
                new
                {
                    iBuildingTokenID = iBuildingTokenID
                });


            //return ViewComponent("BSRVemcoPage_",
            //    new
            //    {
            //        //////////bldtknid = bldtknid,
            //        ////////////querytbltknid = querytbltknid,
            //        //////////iPageNumber = iPageNumber,
            //        //////////blnIsPaging = Boolean.Parse(blnIsPaging)
            //    });

            //return ViewComponent ( "DocumentList" ,
            //    new { showPrevious = showPrevious , showUpcoming = showUpcoming } );


        }






        public IActionResult PageComponentView_Load_BulidingResidentPage(string iBuildingTokenID)
        {
            /*string bldtknid, string iPageNumber, string blnIsPaging*/           /* bool showPrevious , bool showUpcoming */

            return ViewComponent("BSRVemcoPage_BuildingResident",
                new
                {
                    iBuildingTokenID = iBuildingTokenID
                });


            //return ViewComponent("BSRVemcoPage_",
            //    new
            //    {
            //        //////////bldtknid = bldtknid,
            //        ////////////querytbltknid = querytbltknid,
            //        //////////iPageNumber = iPageNumber,
            //        //////////blnIsPaging = Boolean.Parse(blnIsPaging)
            //    });

            //return ViewComponent ( "DocumentList" ,
            //    new { showPrevious = showPrevious , showUpcoming = showUpcoming } );


        }






        public IActionResult PageComponentView_Load_BulidingGapPage(string iBuildingTokenID)
        {
            /*string bldtknid, string iPageNumber, string blnIsPaging*/           /* bool showPrevious , bool showUpcoming */

            return ViewComponent("BSRVemcoPage_BuildingGap",
                new
                {
                    iBuildingTokenID = iBuildingTokenID
                });


            //return ViewComponent("BSRVemcoPage_",
            //    new
            //    {
            //        //////////bldtknid = bldtknid,
            //        ////////////querytbltknid = querytbltknid,
            //        //////////iPageNumber = iPageNumber,
            //        //////////blnIsPaging = Boolean.Parse(blnIsPaging)
            //    });

            //return ViewComponent ( "DocumentList" ,
            //    new { showPrevious = showPrevious , showUpcoming = showUpcoming } );


        }






        public IActionResult PageComponentView_Load_BulidingReportPage(string iBuildingTokenID)
        {
            /*string bldtknid, string iPageNumber, string blnIsPaging*/           /* bool showPrevious , bool showUpcoming */

            return ViewComponent("BSRVemcoPage_BuildingReport",
                new
                {
                    iBuildingTokenID = iBuildingTokenID
                });


            //return ViewComponent("BSRVemcoPage_",
            //    new
            //    {
            //        //////////bldtknid = bldtknid,
            //        ////////////querytbltknid = querytbltknid,
            //        //////////iPageNumber = iPageNumber,
            //        //////////blnIsPaging = Boolean.Parse(blnIsPaging)
            //    });

            //return ViewComponent ( "DocumentList" ,
            //    new { showPrevious = showPrevious , showUpcoming = showUpcoming } );


        }






        public IActionResult PageComponentView_Load_BulidingSafetyPage(string iBuildingTokenID)
        {
            /*string bldtknid, string iPageNumber, string blnIsPaging*/           /* bool showPrevious , bool showUpcoming */

            return ViewComponent("BSRVemcoPage_BuildingSafety",
                new
                {
                    iBuildingTokenID = iBuildingTokenID
                });


            //return ViewComponent("BSRVemcoPage_",
            //    new
            //    {
            //        //////////bldtknid = bldtknid,
            //        ////////////querytbltknid = querytbltknid,
            //        //////////iPageNumber = iPageNumber,
            //        //////////blnIsPaging = Boolean.Parse(blnIsPaging)
            //    });

            //return ViewComponent ( "DocumentList" ,
            //    new { showPrevious = showPrevious , showUpcoming = showUpcoming } );


        }






        public IActionResult PageComponentView_Load_BulidingSystemPage(string iBuildingTokenID)
        {
            /*string bldtknid, string iPageNumber, string blnIsPaging*/           /* bool showPrevious , bool showUpcoming */

            return ViewComponent("BSRVemcoPage_BuildingSystem",
                new
                {
                    iBuildingTokenID = iBuildingTokenID
                });


            //return ViewComponent("BSRVemcoPage_",
            //    new
            //    {
            //        //////////bldtknid = bldtknid,
            //        ////////////querytbltknid = querytbltknid,
            //        //////////iPageNumber = iPageNumber,
            //        //////////blnIsPaging = Boolean.Parse(blnIsPaging)
            //    });

            //return ViewComponent ( "DocumentList" ,
            //    new { showPrevious = showPrevious , showUpcoming = showUpcoming } );


        }






        public IActionResult PageComponentView_Load_BulidingRiskPage(string iBuildingTokenID)
        {
            /*string bldtknid, string iPageNumber, string blnIsPaging*/           /* bool showPrevious , bool showUpcoming */

            return ViewComponent("BSRVemcoPage_BuildingRisk",
                new
                {
                    iBuildingTokenID = iBuildingTokenID
                });


            //return ViewComponent("BSRVemcoPage_",
            //    new
            //    {
            //        //////////bldtknid = bldtknid,
            //        ////////////querytbltknid = querytbltknid,
            //        //////////iPageNumber = iPageNumber,
            //        //////////blnIsPaging = Boolean.Parse(blnIsPaging)
            //    });

            //return ViewComponent ( "DocumentList" ,
            //    new { showPrevious = showPrevious , showUpcoming = showUpcoming } );


        }





        public IActionResult PageComponentView_ActionSubmit_ContactUsPage()
        {
            /*string bldtknid, string iPageNumber, string blnIsPaging*/           /* bool showPrevious , bool showUpcoming */


            ////////////MailMessage msg = new MailMessage("BSRHelpDesk@vemcoconsulting.com", "oneworldlancer@gmail.com", "Test E-mail 1101", "Hi there ...");
            ////////////SmtpClient smtp = new SmtpClient("gator3161.hostgator.com", 465);
            ////////////smtp.UseDefaultCredentials = false;
            ////////////smtp.Credentials= new NetworkCredential("bsrhelpdesk@vemcoconsulting.com", "@goShaymaaHafez06021979");

            return ViewComponent("BSRVemcoPage_ContactUsPage");


            //return ViewComponent("BSRVemcoPage_",
            //    new
            //    {
            //        //////////bldtknid = bldtknid,
            //        ////////////querytbltknid = querytbltknid,
            //        //////////iPageNumber = iPageNumber,
            //        //////////blnIsPaging = Boolean.Parse(blnIsPaging)
            //    });

            //return ViewComponent ( "DocumentList" ,
            //    new { showPrevious = showPrevious , showUpcoming = showUpcoming } );


        }







        public IActionResult PageComponentView_POST_ContactUsPage(
            string iFullName,
            string iEmailAddress,
            string iMobilenumber,
            string iMessageText)
        {                                    /* bool showPrevious , bool showUpcoming */

            try
            {


                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                //MailMessage msg = new MailMessage(
                //    "BSRHelpDesk@vemcoconsulting.com", "basil.jackson@vemcoconsulting.com",
                //    "Test E-mail 1101", "Hi there ...");
                //
                string emailToList = "oneworldlancer@gmail.com,basil.jackson@vemcoconsulting.com" + "," + iEmailAddress;

                MailMessage msg = new MailMessage(
                    "BSRHelpDesk@vemcoconsulting.com",
                    emailToList,
                    "Contact us - Ticket ID# " +   AppUtility_TimeManager.Time_GetCurrentTimeInMilliSecond().ToString(), iMessageText);


                //MailMessage msg = new MailMessage(
                //    "BSRHelpDesk@vemcoconsulting.com",
                //    "shaymaa.hafez@yahoo.fr,oneworldlancer@gmail.com,hoby333@hotmail.com,oneworldlancer@oneworldlancer.onmicrosoft.com",
                //    "Test E-mail 8808", "Hi there 8808 ...");

                //MailMessage msg = new MailMessage(
                //        "BSRHelpDesk@vemcoconsulting.com",
                //        "oneworldlancer@gmail.com,hoby333@yahoo.com,oneworldlancer@yahoo.com",
                //        "Test E-mail 6606", "Hi there ...");

                //msg.Bcc.Add("oneworldlancer@yahoo.com");
                //msg.CC.Add("shaymaa.hafez@yahoo.fr");

                //msg.To.Add("hoby333@yahoo.com,oneworldlancer@yahoo.com");

                SmtpClient smtp = new SmtpClient("smtp.office365.com", 587);

                smtp.UseDefaultCredentials = false;

                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                smtp.EnableSsl = true;

                smtp.Credentials= new NetworkCredential(
                    "bsrhelpdesk@vemcoconsulting.com", "@goADMIN06021979", "vemcoconsulting.com");

                smtp.TargetName = "STARTTLS/smtp.office365.com";


                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                smtp.Send(msg);

                //Clean up.

                msg.Dispose();


            }
            catch (Exception ex)
            {
                AppUtility_DebugManager.Debug_Get_MessageText(ex.Message.ToString());
            }


            return ViewComponent("BSRVemcoPage_ContactUs");




            //return ViewComponent("QueryFormTableDocumentList",
            //    new
            //    {
            //        bldtknid = bldtknid,
            //        iqueryinftknid = iqueryinftknid
            //    });



            //return ViewComponent ( "DocumentList" ,
            //    new { showPrevious = showPrevious , showUpcoming = showUpcoming } );


        }









        public async Task<IActionResult> PageComponentView_POST_BuildingNewPage(
            string iBuildingName,
            string iBuildingAddress,
            string iBuildingDateYear,
            string iImageServerURL)
        {                                    /* bool showPrevious , bool showUpcoming */

            try
            {


                string iBuildingTokenID = AppUtility_TimeManager.Time_GetCurrentTimeInMilliSecond().ToString();

                BsrvemcoUserBuildingList iBuildingModel = new BsrvemcoUserBuildingList()
                {

                    RowViewTokenId = new Guid(),


                    OwnerUserTokenId = Program.iOwnerModel.OwnerUserTokenID,
                    CompanyTokenId = Program.iOwnerModel.CompanyTokenID,

                    BuildingTokenId =iBuildingTokenID,

                    BuildingName = iBuildingName,
                    BuildingAddress = iBuildingAddress,
                    BuildingDay = "0",//iDevelomentNew1ViewModel.BuildingDate.Day.ToString ( ) ,
                    BuildingMonth = "0",// iDevelomentNew1ViewModel.BuildingDate.Month.ToString ( ) ,
                    BuildingYear = iBuildingDateYear.ToString(),
                    BuildingDate = "0",//iDevelomentNew1ViewModel.BuildingDate.ToString ( ) ,
                    //FileTokenId = _iImageTokenID ,
                    //FileName = _iImageTokenID ,
                    //FileExtension = _iImageTokenID ,
                    ImageTokenId = "0",//_arrTokenList[1].ToString(),
                    ImageServerUrl  = iImageServerURL.ToLower().ToString(),//_arrTokenList[1].ToString(),
                    UploadDateTimeMilliSec = AppUtility_TimeManager.Time_GetCurrentTimeInMilliSecond(),

                    IsNew = true,
                    IsVisible = true,
                    IsActive = true,

                };


                await _dbContext.BsrvemcoUserBuildingLists.AddAsync(iBuildingModel);


                await _dbContext.SaveChangesAsync();

                ///////////////////////

                // Populate Info-List
                List<BsrvemcoUserBuildingInformationList>? _arrCheckCountUserBuildingInfomationList = _dbContext.BsrvemcoUserBuildingInformationLists
                .Where(u =>
                u.BuildingTokenId == iBuildingTokenID &&
                u.ApptableTokenId == "1689022008239" &&
                u.IsVisible == true)
                 //.Select (u  )
                 //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                 .ToList(); // This is what actually executes the request and return a response


                // Fill Database- InfoList
                if (_arrCheckCountUserBuildingInfomationList.Count == 0)
                {

                    List<BsrvemcoAppBuildingInformationList>? _arrAppDevelomentInfomationList = _dbContext.BsrvemcoAppBuildingInformationLists
                        .Where(u => u.IsVisible == true)
                         //.Select (u  )
                         //.FirstOrDefault ( ); // This is what actually executes the request and return a response
                         .ToList(); // This is what actually executes the request and return a response


                    ArrayList _arrTokenList = new ArrayList();
                    _arrTokenList = AppUtility_ListTokenIDManager.ListTokenID_Generate_NewList(_arrAppDevelomentInfomationList.Count.ToString());



                    ////////////////////////////////////////

                    BsrvemcoUserBuildingInformationList iBuildingInformationModel;

                    for (int i = 0; i < _arrAppDevelomentInfomationList.Count; i++)
                    {


                        iBuildingInformationModel = new BsrvemcoUserBuildingInformationList()
                        {

                            RowViewTokenId = new Guid(),



                            OwnerUserTokenId = Program.iOwnerModel.OwnerUserTokenID,
                            CompanyTokenId = Program.iOwnerModel.CompanyTokenID,
                            BuildingTokenId = iBuildingTokenID,

                            ApptableTokenId = _arrAppDevelomentInfomationList[i].ApptableTokenId.ToString(),
                            AppinformationTokenId = _arrAppDevelomentInfomationList[i].AppinformationTokenId.ToString(),
                            InformationTokenId = _arrTokenList[i].ToString(),

                            InformationCode= _arrAppDevelomentInfomationList[i].InformationCode.ToString(),
                            InformationType= _arrAppDevelomentInfomationList[i].InformationType.ToString(),

                            InformationName= _arrAppDevelomentInfomationList[i].InformationName.ToString(),
                            InformationText = _arrAppDevelomentInfomationList[i].InformationText.ToString(),
                            InformationTitle = _arrAppDevelomentInfomationList[i].InformationTitle.ToString(),
                            InformationDescription = _arrAppDevelomentInfomationList[i].InformationDescription.ToString(),

                            AppqueryTableTokenId= _arrAppDevelomentInfomationList[i].AppqueryTableTokenId.ToString(),
                            AppqueryInformationTokenId= _arrAppDevelomentInfomationList[i].AppqueryInformationTokenId.ToString(),
                            QueryInformationTokenId = _arrTokenList[i].ToString(),

                            //InformationTextSystem = _arrAppDevelomentInfomationList[i].InformationText.ToString(),
                            //InformationTitleSystem = _arrAppDevelomentInfomationList[i].InformationTitle.ToString(),
                            //InformationDescriptionSystem = _arrAppDevelomentInfomationList[i].InformationDescription.ToString(),



                            //InformationTextUser = _arrAppDevelomentInfomationList[i].InformationTextUser.ToString(),
                            //InformationTitleUser = _arrAppDevelomentInfomationList[i].InformationTitle.ToString(),
                            //InformationDescriptionUser = _arrAppDevelomentInfomationList[i].InformationDescriptionUser.ToString(),



                            Commentary = _arrAppDevelomentInfomationList[i].Commentary.ToString(),


                            TimeframeYearCount=  _arrAppDevelomentInfomationList[i].TimeframeYearCount.ToString(),
                            TimeframeMonthCount=  _arrAppDevelomentInfomationList[i].TimeframeMonthCount.ToString(),

                            IsWithSurvey=  _arrAppDevelomentInfomationList[i].IsWithSurvey,
                            IsCheckOneTime=  _arrAppDevelomentInfomationList[i].IsCheckOneTime,

                            InformationButtonText="Negative",
                            InformationButtonStyleCss="red",

                            InformationScore = "5",
                            Score = "5",
                            ScoreManaged = "5",
                            ScoreAdjusted = "5",
                            ScoreOriginal = "5",


                            IsAnswered = false,
                            AnswerCode="evidence_default",
                            AnswerText="Awaiting Evidence",
                            AnswerDescription="You will NOT able to generate a \"Gap Analysis Report\" untill you have responded.",

                            UploadDateTimeMilliSec = AppUtility_TimeManager.Time_GetCurrentTimeInMilliSecond(),
                            IsVisible = true,
                            IsActive = true,

                        };


                        await _dbContext.BsrvemcoUserBuildingInformationLists.AddAsync(iBuildingInformationModel);


                        await _dbContext.SaveChangesAsync();


                    }


                }



                //////////////////////////////////////////



                return ViewComponent("BSRVemcoPage_BuildingList");





                //return ViewComponent("QueryFormTableDocumentList",
                //    new
                //    {
                //        bldtknid = bldtknid,
                //        iqueryinftknid = iqueryinftknid
                //    });



                //return ViewComponent ( "DocumentList" ,
                //    new { showPrevious = showPrevious , showUpcoming = showUpcoming } );


            }
            catch (Exception ex)
            {
                AppUtility_DebugManager.Debug_Get_MessageText(ex.Message.ToString());
            }


            return ViewComponent("BSRVemcoPage_ContactUs");


        }






        public async Task<IActionResult> PageComponentView_POST_BuildingEditPage(
            string iBuildingTokenID,
            string iBuildingName,
            string iBuildingAddress,
            string iBuildingDateYear,
            string iImageServerURL)
        {                                    /* bool showPrevious , bool showUpcoming */

            try
            {


                var _iUserBuildignModel = _dbContext.BsrvemcoUserBuildingLists
                        .Where(u => u.BuildingTokenId == iBuildingTokenID)
                        //.Select (u  )
                        .FirstOrDefault(); // This is what actually executes the request and return a response



                // Update IsNew == false

                if (_iUserBuildignModel != null)
                {
                    _iUserBuildignModel.IsNew = false;
                    _iUserBuildignModel.BuildingName = iBuildingName;
                    _iUserBuildignModel.BuildingAddress = iBuildingAddress;
                    _iUserBuildignModel.BuildingYear = iBuildingDateYear;
                    _iUserBuildignModel.ImageServerUrl = iImageServerURL;

                    _dbContext.BsrvemcoUserBuildingLists.Update(_iUserBuildignModel);

                    await _dbContext.SaveChangesAsync();


                }


                return ViewComponent("BSRVemcoPage_BuildingSummary",
                    new
                    {
                        iBuildingTokenID = iBuildingTokenID
                    });





            }
            catch (Exception ex)
            {
                AppUtility_DebugManager.Debug_Get_MessageText(ex.Message.ToString());
            }


            return ViewComponent("BSRVemcoPage_ContactUs");


        }





        //public IActionResult Index ( )
        //{
        //    return View ( );
        //}

        //public IActionResult About ( )
        //{
        //    return View ( );
        //}

        //public IActionResult Subscription ( )
        //{
        //    return View ( );
        //}

        //public IActionResult Terms ( )
        //{
        //    return View ( );
        //}


        //public IActionResult FAQ ( )
        //{
        //    return View ( );
        //}


        //public IActionResult ContactUs ( )
        //{
        //    return View ( );
        //}

        //public IActionResult SaltWater ( )
        //{
        //    return View ( );
        //}



    }
}
