namespace E_Store.Data.Interfaces.Repositories
{
    using System.Collections.Generic;

    using Models;

    public interface ICategoryRepository : IRepository<Category>
    {
        List<Category> GetLeaves();

        List<Category> GetRoots();

    }
}