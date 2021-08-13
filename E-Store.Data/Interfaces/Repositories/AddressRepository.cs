namespace E_Store.Data.Interfaces.Repositories
{
    using Data;
    using Models;

    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        private readonly EStoreDbContext context;
        
        public AddressRepository(EStoreDbContext context) : base(context)
        {
            
        }
    }
}