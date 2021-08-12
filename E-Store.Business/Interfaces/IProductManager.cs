namespace E_Store.Business.Interfaces
{
    using System.Collections.Generic;
    using Data.Models;
    using Microsoft.AspNetCore.Http;
    public interface IProductManager
    {
        Product FindProductById(int id);
        Product FindProductByUrl(string url);
        void SaveProduct(Product product);
        void SaveProductImages(Product product, List<IFormFile> images, int? oldProductId, int? oldImagesCount);
        void RemoveProductImage(int productId, int imageIndex);
        List<Product> FindByCategoryId(int categoryId);
        List<Product> SearchProducts
        (
            string searchPhrase,
            int? categoryId,
            string orderBy = "rating",
            decimal startPrice = 0,
            decimal endPrice = 0,
            bool inStock = false
        );
        List<Product> SearchProducts(string searchPhrase);
        void CleanProduct(Product oldProduct, bool removeImages = false);

        void AddToStock(int productId, int quantity);
    }
}