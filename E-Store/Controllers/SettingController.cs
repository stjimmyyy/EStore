namespace E_Store.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using Classes;
    using Extensions;
    using Models.Setting;
    using E_Store.Data.Models;
    using Business.Interfaces;
    
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    public class SettingController : Controller
    {
        private readonly IAccountingSettingManager settingManager;
        private readonly IPersonManager personManager;
        private readonly IEnumerable<ApplicationUser> admins;

        public SettingController(
            
            IAccountingSettingManager manager, 
            UserManager<ApplicationUser> user, 
            IPersonManager personManager)
        {
            this.admins = user.GetUsersInRoleAsync("Admin").Result;
            this.settingManager = manager;
            this.personManager = personManager;
        }
        public IActionResult Index()
        {
            var model = new SettingViewModel
            {
                Sellers = new SelectList(this.admins, "Id", "UserName"),
                Accountants = new SelectList(this.admins.Select(x => x.Person.PersonDetail), "Id", "FullName"),
                AllSettings = this.settingManager.GetAllSettings(),
                Entity = new AccountingSetting()
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Create(SettingViewModel setting)
        {
            if (ModelState.IsValid)
            {
                setting.Entity.SellerId = this.personManager.FindByUserId(setting.SellerId).Id;
                this.settingManager.AddSettings(setting.Entity, setting.UploadedImage);
                this.AddFlashMessage(new FlashMessage("The setting has been successfully added", FlashMessageType.Success));

                return RedirectToAction("Index");
            }

            setting.Sellers = new SelectList(admins, "Id", "UserName");
            setting.Accountants = new SelectList(this.admins.Select(x => x.Person.PersonDetail), "Id", "FullName");
            setting.AllSettings = this.settingManager.GetAllSettings();

            return View("Index", setting);
        }

        public IActionResult Delete(int id)
        {
            this.settingManager.DeleteSetting(id);
            this.AddFlashMessage(new FlashMessage("The setting was deleted", FlashMessageType.Success));
            return RedirectToAction("Index");
        }
    }
}