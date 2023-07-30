using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using PizzaPan.EntityLayer.Concrete;
using PizzaPan.PresentationLayer.Models;
using System;
using System.Threading.Tasks;

namespace Pizzapan.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel model)
        {
            Random rnd = new Random();
            int x = rnd.Next(100000, 1000000);

            AppUser appUser = new AppUser()
            {
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                UserName = model.Username,
                ConfirmCode = x
            };
            var result = await _userManager.CreateAsync(appUser, model.Password);

            if (result.Succeeded)
            {
                #region
                MimeMessage mimeMessage = new MimeMessage();
                MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "selviyldrm96@gmail.com");
                mimeMessage.From.Add(mailboxAddressFrom);

                MailboxAddress mailboxAddressTo = new MailboxAddress("User", model.Email);
                mimeMessage.To.Add(mailboxAddressTo);

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.TextBody = "Giriş yapabilmek için onaylama kodunuz:" + x;
                mimeMessage.Body = bodyBuilder.ToMessageBody();

                mimeMessage.Subject = "Doğrulama Kodu";

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Connect("smtp.gmail.com", 587, false);
                smtpClient.Authenticate("selviyldrm96@gmail.com", "kcwzmavehalbssyp");
                smtpClient.Send(mimeMessage);
                smtpClient.Disconnect(true);
                #endregion
                TempData["Username"] = appUser.UserName;
                return RedirectToAction("Index", "ConfirmCode");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View();
        }
    }
}
