using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace TestEmailSendingFunctionality.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendEmail()
        {
            return View();
        }
        
        public JsonResult SendEmailToUser(string emailContent)
        {
            bool Result = false;
            Result = sendEmail1("jerrinvarghese2008@gmail.com", "Testing Email Sending", "<p>Hi Jerrin,    <br />    This is just a test email, no need to worry!    <br />    Regards,    <br />    Innovation Team.</p>");
            return Json(Result, JsonRequestBehavior.AllowGet);
        }

        public bool sendEmail1(string toEmail, string subject,string EmailBody)
        {
            try
            {
                string senderEmail = System.Configuration.ConfigurationManager.AppSettings["SenderEmail"].ToString();
                string senderPassword = System.Configuration.ConfigurationManager.AppSettings["SenderPassword"].ToString();
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(senderEmail, senderPassword);

                MailMessage mailMessage = new MailMessage(senderEmail, toEmail, subject, EmailBody);
                mailMessage.IsBodyHtml = true;
                mailMessage.BodyEncoding = UTF8Encoding.UTF8;

                client.Send(mailMessage);


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public ActionResult CheckingLog4Net()
        {
            log4net.ILog logger = log4net.LogManager.GetLogger(typeof(HomeController));
            try
            {
                int x = 5;
                int y = 0;
                int z = x / y;
            }

            catch (Exception ex)
            {
                logger.Error(ex.ToString());
            }
            return RedirectToAction("SendEmail");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}