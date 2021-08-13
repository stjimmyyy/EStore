namespace E_Store.Data.Interfaces.Repositories
{
    using Data;
    using Models;
    
    public class PersonDetailRepository : BaseRepository<PersonDetail>, IPersonDetailRepository
    {
        private readonly EStoreDbContext context;
        
        public PersonDetailRepository(EStoreDbContext context) : base(context)
        {
        }
    }
}