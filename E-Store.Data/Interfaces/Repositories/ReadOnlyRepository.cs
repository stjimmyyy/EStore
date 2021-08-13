namespace E_Store.Data.Interfaces.Repositories
{
    using System.Linq;
    using System.Collections.Generic;
    
    using Data;
    using Models;
    
    public class ReadOnlyRepository : IReadOnlyRepository
    {
        private readonly EStoreDbContext context;

        public ReadOnlyRepository(EStoreDbContext context) => this.context = context;

        public List<Country> GetCountries()
            => this.context.Countries.ToList();

        public List<Bank> GetBanks()
            => this.context.Banks.ToList();
    }
}