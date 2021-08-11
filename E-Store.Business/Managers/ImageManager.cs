namespace E_Store.Business.Managers
{
    using System.IO;

    using Classes;
    using Interfaces;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;

    using SixLabors.ImageSharp;
    using SixLabors.ImageSharp.PixelFormats;
    using SixLabors.ImageSharp.Processing;
    using SixLabors.ImageSharp.Formats;
    using SixLabors.ImageSharp.Formats.Bmp;
    using SixLabors.ImageSharp.Formats.Gif;
    using SixLabors.ImageSharp.Formats.Jpeg;
    using SixLabors.ImageSharp.Formats.Png;
    using SixLabors.ImageSharp.Web.DependencyInjection;
    
    public class ImageManager : IImageManager
    {
        public string OutputDirectoryPath { get; set; }

        public ImageManager(string outputDirectoryPath) =>
            this.OutputDirectoryPath = outputDirectoryPath;
        
        public void SaveImage(IFormFile file, string fileName, ImageExtension extension, int width = 0, int height = 0)
        {
            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);

                var img = Image.Load(stream.ToArray());
                
                ResizeImage(img, width, height);

                IImageEncoder encoder;

                switch (extension)
                {
                    case ImageExtension.Bmp:
                        encoder = new BmpEncoder();
                        fileName += ".bmp";
                        break;
                    case ImageExtension.Gif:
                        encoder = new GifEncoder();
                        fileName += ".gif";
                        break;
                    case ImageExtension.Jpeg:
                        encoder = new JpegEncoder();
                        fileName += ".jpeg";
                        break;
                    case ImageExtension.Png:
                        encoder = new PngEncoder();
                        fileName += ".png";
                        break;
                    default:
                        return;
                }
                
                img.Save(OutputDirectoryPath + fileName, encoder);
            }
        }
        private Image<Rgba32> ResizeImage(Image<Rgba32> image, int width = 0, int height = 0)
        {
            if (width > 0 || height > 0)
            {
                image.Mutate(x => x.Resize(
                    new ResizeOptions()
                    {
                        Size = new Size(width, height)
                    }));
            }

            return image;
        }
        
        public void ResizeImage(string path, int width, int height)
        {
            ResizeImage((Image<Rgba32>) Image.Load(path), width, height).Save(path);
        }

        public static IServiceCollection ConfigureImageProcessingMiddleware(IServiceCollection services)
        {
            services.AddImageSharp();
            return services;
        }
    }
}