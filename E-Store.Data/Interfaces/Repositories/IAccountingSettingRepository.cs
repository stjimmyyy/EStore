namespace E_Store.Data.Interfaces.Repositories
{
    using System;
    using Models;
    
    public interface IAccountingSettingRepository : IRepository<AccountingSetting>
    {
        AccountingSetting FindSettingByDate(DateTime date);
    }
}