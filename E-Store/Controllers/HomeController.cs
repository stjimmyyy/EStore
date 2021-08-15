using E_Store.Business.Interfaces;
using E_Store.Classes;
using E_Store.Extensions;

namespace E_Store.Controllers
{
    using E_Store.Models.Contact;

    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Models;

    public class HomeController : Controller
    {
        
        private readonly IEmailSender emailSender;

        public HomeController(IEmailSender emailSender)
        {
            this.emailSender = emailSender;
        }

        [HttpGet]
        public IActionResult Contact() => View();

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
                return View(model);
            
            this.emailSender.SendEmail("dafgasg94@gmail.com", model.Subject, model.MessageBody, model.SenderEmail);
            
            this.AddFlashMessage("The message has been sent successfully", FlashMessageType.Success);

            return RedirectToAction("Index");

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}