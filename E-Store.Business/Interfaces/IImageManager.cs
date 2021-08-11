namespace E_Store.Business.Interfaces
{
    using Classes;
    
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;

    public interface IImageManager
    {
        void SaveImage(IFormFile file, string fileName, ImageExtension extension, int width, int height);

        void ResizeImage(string path, int width, int height);

    }
}