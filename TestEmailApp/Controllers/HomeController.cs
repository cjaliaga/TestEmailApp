using System.Web.Mvc;

namespace TestEmailApp.Controllers
{
    using System.Configuration;
    using System.Net.Mail;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendEmail(string email)
        {
            var userName = ConfigurationManager.AppSettings["User"];
            var password = ConfigurationManager.AppSettings["Password"];
            var msg = new MailMessage();
            msg.To.Add(new MailAddress(email));
            msg.From = new MailAddress(userName);
            msg.Subject = "Test Office 365 Account";
            msg.Body = "Testing email using Office 365 account.";
            msg.IsBodyHtml = true;
            var client = new SmtpClient()
            {
                Host = "smtp.office365.com",
                Credentials = new System.Net.NetworkCredential(userName, password),
                Port = 587,
                EnableSsl = true
            };
            client.Send(msg);
            ViewBag.Message = $"Email to {email} sent.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}