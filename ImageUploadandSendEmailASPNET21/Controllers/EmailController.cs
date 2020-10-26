using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using SharedObjects.Models;
using SharedObjects.ViewModels;

namespace ImageUploadandSendEmailASPNET21.Controllers
{
    public class EmailController : Controller
    {
        private readonly ISendMailService sendMailService;

        public EmailController(ISendMailService sendMailService)
        {
            this.sendMailService = sendMailService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<string> SendEmail()
        {
            MailContent content = new MailContent
            {
                To = "vui_le@jabil.com",
                Subject = "Kiểm tra thử",
                Body = "<p><strong>Xin chào xuanthulab.net</strong></p>"
            };

            await sendMailService.SendMail(content);
            return "ok";
        }
    }
}
