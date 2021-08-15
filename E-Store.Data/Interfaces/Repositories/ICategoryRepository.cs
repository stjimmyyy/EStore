namespace E_Store.Data.Interfaces.Repositories
{
    using System.Collections.Generic;

    using Models;

    public interface ICategoryRepository : IRepository<Category>
    {
        List<Category> GetLeaves(bool includeHidden = false);

        List<Category> GetRoots();

        Category GetPaymentCategory();
    }
}