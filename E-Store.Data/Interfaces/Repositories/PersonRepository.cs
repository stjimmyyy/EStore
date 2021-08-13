namespace E_Store.Data.Interfaces.Repositories
{
    using System.Linq;
    using Models;
    using Data;

    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        private readonly EStoreDbContext context;
        
        public PersonRepository(EStoreDbContext context) : base(context)
        {
        }

        public Person FindByUserId(string id)
            => this.dbSet.Single(person => person.User.Id == id);
    } 
}