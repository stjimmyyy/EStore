namespace E_Store.Data.Interfaces.Repositories
{
    using System;
    using System.Linq;

    using Data;
    using Models;
    
    public class AccountingSettingRepository : BaseRepository<AccountingSetting>, IAccountingSettingRepository
    {
        public AccountingSettingRepository(EStoreDbContext context) : base(context)
        {
        }

        public AccountingSetting FindSettingByDate(DateTime date)
        {
            try
            {
                return GetAll()
                    .SingleOrDefault(x => 
                        x.ValidFrom.Date <= date.Date && x.ValidTo.Date >= date.Date);
            }
            catch
            {
                return null;
            }
        }
    }
}