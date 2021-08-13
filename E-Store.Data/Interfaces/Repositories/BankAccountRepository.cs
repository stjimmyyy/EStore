namespace E_Store.Data.Interfaces.Repositories
{
    using Data;
    using Models;

    public class BankAccountRepository : BaseRepository<BankAccount>, IBankAccountRepository
    {
        public BankAccountRepository(EStoreDbContext context) : base(context)
        {
        }
    }
}