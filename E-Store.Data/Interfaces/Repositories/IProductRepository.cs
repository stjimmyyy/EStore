namespace E_Store.Data.Interfaces.Repositories
{
    using System.Collections.Generic;

    using Models;

    public interface IProductRepository : IRepository<Product>
    {
        Product FindByUrl(string url);
        List<Product> FindByCategoryId(int categoryId);
        List<Product> SearchProducts(string searchPhrase);

    }
}