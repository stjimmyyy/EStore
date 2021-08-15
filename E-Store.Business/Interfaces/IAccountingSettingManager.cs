namespace E_Store.Business.Interfaces
{
    using System.Collections.Generic;
    using Data.Models;
    using Microsoft.AspNetCore.Http;
    
    public interface IAccountingSettingManager
    {
        List<AccountingSetting> GetAllSettings();
        AccountingSetting AddSettings(AccountingSetting settings, IFormFile signature);
        void DeleteSetting(int settingsId);
        AccountingSetting GetSetting();
        
        decimal GetCurrentTaxCoefficient();
    }
}