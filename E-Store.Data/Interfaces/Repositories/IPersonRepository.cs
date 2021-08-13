namespace E_Store.Data.Interfaces.Repositories
{
    using Models;
    public interface IPersonRepository : IRepository<Person>
    {
        Person FindByUserId(string id);
    }
}