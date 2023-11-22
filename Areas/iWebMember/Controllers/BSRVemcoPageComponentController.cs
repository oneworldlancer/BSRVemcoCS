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



            ////////////////////System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            ////////////////////MailMessage msg = new MailMessage(
            ////////////////////    "BSRHelpDesk@vemcoconsulting.com", "oneworldlancer@gmail.com",
            ////////////////////    "Test E-mail 1101", "Hi there ...");

            //////////////////////  SmtpClient smtp = new SmtpClient("vemcoconsulting-com.mail.protection.outlook.com", 25);
            //////////////////////  SmtpClient smtp = new SmtpClient("vemcoconsulting-com.mail.protection.outlook.com", 25);
            ////////////////////SmtpClient smtp = new SmtpClient("smtp.office365.com", 25);

            ////////////////////smtp.UseDefaultCredentials = false;
            ////////////////////smtp.EnableSsl = true;
            ////////////////////smtp.Credentials= new NetworkCredential(
            ////////////////////    "bsrhelpdesk@vemcoconsulting.com", "@Laq43362", "vemcoconsulting.com");

            ////////////////////smtp.TargetName = "STARTTLS/smtp.office365.com";


            ////////////////////smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            ////////////////////smtp.Send(msg);



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
                new {
                    iBuildingTokenID= iBuildingTokenID
                }) ;


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
