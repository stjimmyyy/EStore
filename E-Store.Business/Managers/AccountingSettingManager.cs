
namespace E_Store.Business.Managers
{
    using System;
    using System.Linq;
    using System.IO;
    
    using Classes;
    using E_Store.Data.Interfaces.Repositories;

    using System.Collections.Generic;
    using Interfaces;
    using Data.Models;
    using Microsoft.AspNetCore.Http;
    
    public class AccountingSettingManager : IAccountingSettingManager
    {
        private readonly IAccountingSettingRepository accountingSettingRepository;
        private const string SignatureImagesPath = "wwwroot/images/signatures";
        
        public AccountingSettingManager(IAccountingSettingRepository repository)
            => this.accountingSettingRepository = repository;

        public List<AccountingSetting> GetAllSettings()
            => this.accountingSettingRepository.GetAll();
        public AccountingSetting AddSettings(AccountingSetting settings, IFormFile signature)
        {
            if (signature == null || !signature.ContentType.Contains("image"))
                throw new InvalidDataException("Invalid signature image");
            
            this.accountingSettingRepository.Insert(settings);
            
            new ImageManager(SignatureImagesPath)
                .SaveImage(signature, settings.AccountantDetailId.ToString(),
                    ImageExtension.Png,
                    260, 260);

            return settings;
        }
        public void DeleteSetting(int settingsId)
        {
            var path = SignatureImagesPath + settingsId + "png";
            
            if(File.Exists(path))
                File.Delete(path);
            
            this.accountingSettingRepository.Delete(settingsId);
        }

        public AccountingSetting GetSetting() => GetSetting(DateTime.Now);

        public AccountingSetting GetSetting(DateTime date)
        {
            date = date.Date;

            var settings = GetAllSettings().SingleOrDefault(x => x.ValidFrom <= date && x.ValidTo >= date);

            return settings ?? throw new Exception("No settings in the Db");
        }

        public decimal GetCurrentTaxCoefficient()
        {
            var currentSetting = GetSetting();

            return string.IsNullOrEmpty(currentSetting.Seller.PersonDetail.TaxNumber)
                ? 1
                : (decimal) (1 + currentSetting.Vat / 100.0);
        }
    }
}