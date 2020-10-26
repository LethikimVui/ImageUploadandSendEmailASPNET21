using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using SharedObjects.Models;
using SharedObjects.ViewModels;

namespace ImageUploadASPNET21.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImageServices imageService;
        private readonly ISendMailService sendMailService;

        public ImageController(IImageServices imageService, ISendMailService sendMailService)
        {
            this.imageService = imageService;
            this.sendMailService = sendMailService;
        }
        public async Task<IActionResult> GetAll()
        {
            var images = await imageService.GetAll();
            return View(images);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add( AddImageViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = await UploadedFileAsync(model);

                IImages image = new IImages
                {
                    Id = model.Id,
                    Link = uniqueFileName,
                };
                var result = await imageService.AddImage(image);
                if (result.StatusCode == 200)
                {
                    //await SendEmail();
                    return Redirect("/Image/GetAll");
                }
                else
                {
                   
                    return View(model);
                }
            }
            return View(model);
        }

        private async Task<string> UploadedFileAsync(AddImageViewModel model)
        {
            string fileName;
            try
            {
                var extension = "." + model.Link.FileName.Split('.')[model.Link.FileName.Split('.').Length - 1];
                fileName = Guid.NewGuid().ToString() + extension; //Create a new Name for the file due to security reasons.
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);

                using (var bits = new FileStream(path, FileMode.Create))
                {
                    await model.Link.CopyToAsync(bits);
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return fileName;
        }
        private async Task<string> SendEmail(List<string> tos, string subject, string bodyContent)
        {
            string to = null;
            foreach (var item in tos)
            {
                to += item + ";";
            }
            MailContent content = new MailContent
            {

                To = to,//"vui.spk@gmail.com",
                Subject = subject , //"Kiểm tra thử",
                Body = bodyContent //"<p><strong>Xin chào xuanthulab.net</strong></p>"
            };

            await sendMailService.SendMail(content);
            //await context.Response.WriteAsync("Send mail");
            return "ok";
        }
    }
}
