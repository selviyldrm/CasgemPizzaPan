using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using PizzaPan.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPan.PresentationLayer.Controllers
{
    public class SendMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        } 
        [HttpPost]
        public IActionResult Index(MailRequest mailRequest)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin","selviyldrm96@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User",mailRequest.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = mailRequest.MessageContent;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = mailRequest.Subject;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com",587,false);
            smtpClient.Authenticate("selviyldrm96@gmail.com", "xlepvhflvxwxkvpn");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);
            return View();
        }
    }
}
