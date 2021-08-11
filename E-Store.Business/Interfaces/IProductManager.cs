using System.Collections.Generic;
using E_Store.Data.Models;
using Microsoft.AspNetCore.Http;

namespace E_Store.Business.Interfaces
{
    public interface IProductManager
    {
        Product FindProductById(int id);
        Product FindProductByUrl(string url);

        void SaveProduct(Product product);

        void SaveProductImages(Product product, List<IFormFile> images, int? oldProductId, int? oldImagesCount);
    }
}