namespace E_Store.Data.Interfaces.Repositories
{
    using E_Store.Data.Models;

    public interface IProductRepository : IRepository<Product>
    {
        Product FindByUrl(string url);

    }
}