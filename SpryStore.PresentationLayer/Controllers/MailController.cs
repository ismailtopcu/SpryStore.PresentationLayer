using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SpryStore.PresentationLayer.Models;

namespace SpryStore.PresentationLayer.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(MailRequestViewModel mailRequestViewModel)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin","ismailtopcu92@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);
            MailboxAddress mailboxAddressTo = new MailboxAddress("User",mailRequestViewModel.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody= mailRequestViewModel.Body;
            mimeMessage.Body= bodyBuilder.ToMessageBody();
            mimeMessage.Subject=mailRequestViewModel.Subject;
            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com",587,false);
            client.Authenticate("ismailtopcu92@gmail.com","bsoqrkheuasmwyeo");
            client.Send(mimeMessage);
            client.Disconnect(true);
            return View();
        }
    }
}
