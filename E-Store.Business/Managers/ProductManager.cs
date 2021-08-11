namespace E_Store.Business.Managers
{
    using System.IO;
    using System;
    using System.Collections.Generic;
    
    using Classes;
    using E_Store.Data.Interfaces.Repositories;
    using Data.Models;
    using Interfaces;
    
    using Microsoft.AspNetCore.Http;

    
    public class ProductManager : IProductManager
    {
        private const string ProductImagesPath = "wwwroot/images/products";
        private readonly IImageManager imageManager = new ImageManager(ProductImagesPath);
        private const int ProductImageMaxHeight = 400;
        private const int ProductThumbnailSize = 320;
        
        private readonly IProductRepository productRepository;

        public ProductManager(IProductRepository productRepository) 
            => this.productRepository = productRepository;

        public Product FindProductById(int id)
        {
            return this.productRepository.FindById(id);
        }
        public Product FindProductByUrl(string url)
        {
            return this.productRepository.FindByUrl(url);
        }
        public void SaveProduct(Product product)
        {
            var oldProduct = this.productRepository.FindById(product.Id);
            product.Id = 0;
            this.productRepository.Insert(product);

            if (oldProduct != null)
            {
                CleanProduct(oldProduct);
            }
        }

        public void SaveProductImages(Product product, List<IFormFile> images, int? oldProductId, int? oldImagesCount)
        {
            int imagesCount = 0;

            if (oldProductId.HasValue)
            {
                imagesCount = oldImagesCount.Value;
                RenameProductImages(oldProductId.Value, product.Id, imagesCount);
            }

            if (images == null)
            {
                throw new Exception("Image upload failed!");
            }

            for (int i = 0; i < images.Count; i++)
            {
                if (images[i] == null ||
                    !images[i].ContentType.ToLower().Contains("image"))
                    continue;

                this.imageManager.SaveImage(images[i],
                    GetImageFileName(product.Id, imagesCount, full: false),
                    ImageExtension.Jpeg,
                    width: 0,
                    height: ProductImageMaxHeight);

                if (imagesCount == 0)
                {
                    this.imageManager
                        .SaveImage(images[i],
                            GetThumbnailFileName(product.Id, false),
                            ImageExtension.Png,
                            ProductThumbnailSize,
                            height: 0);
                }

                imagesCount++;
            }

            product.ImagesCount = imagesCount;
            productRepository.Update(product);
        }

        public void RemoveProductImage(int productId, int imageIndex)
        {
            var product = this.productRepository.FindById(productId);

            if (imageIndex == 0)
            {
                RemoveThumbnailFile(productId);
                var secondImagePath = GetImageFileName(productId, 1);

                if (File.Exists(secondImagePath))
                {
                    var thumbFileName = GetThumbnailFileName(product.Id);
                    this.imageManager.ResizeImage(thumbFileName, ProductThumbnailSize, height:0);
                }
            }
            
            RemoveImageFile(productId, imageIndex);

            for (int i = imageIndex + 1; i < product.ImagesCount; i++)
            {
                RenameImage(productId, i, productId, i - 1);
            }

            product.ImagesCount--;
            this.productRepository.Update(product);
        }
        private void CleanProduct(Product oldProduct, bool removeImages = false)
        {
            try
            {
                this.productRepository.Delete(oldProduct.Id);
            }
            catch (Exception)
            {
                oldProduct.CategoryProducts.Clear();
                oldProduct.Hidden = true;
                productRepository.Update(oldProduct);
            }

            if (removeImages)
            {
                int imagesCount = oldProduct.ImagesCount;
                RemoveThumbnailFile(oldProduct.Id);

                for (int i = 0; i < imagesCount; i++)
                {
                    RemoveImageFile(oldProduct.Id, i);
                }
            }
        }
        private string GetImageFileName(int productId, int imageIndex, bool full = true)
        {
            var result = $"{productId}_{imageIndex}";

            if (full)
            {
                result = ProductImagesPath + result + ".jpeg";
            }

            return result;
        }
        private string GetThumbnailFileName(int productId, bool full = true)
        {
            var result = $"{productId}_thumb";

            if (full)
            {
                result = ProductImagesPath + result + ".png";
            }

            return result;
        }
        private void RemoveImageFile(int productId, int imageIndex)
        {
            var fileName = GetImageFileName(productId, imageIndex);
            
            if(File.Exists(fileName))
                File.Delete(fileName);
        }
        private void RemoveThumbnailFile(int productId)
        {
            var thumbFileName = GetThumbnailFileName(productId);

            if (File.Exists(thumbFileName))
            {
                File.Delete(thumbFileName);
            }
        }
        private void RenameImage(int oldProductId, int oldImageIndex, int productId, int imageIndex)
        {
            var oldPath = GetImageFileName(oldProductId, oldImageIndex);
            var newPath = GetImageFileName(productId, imageIndex);

            if (File.Exists(oldPath))
            {
                File.Move(oldPath, newPath);
            }
        }
        private void RenameProductImages(int oldProductId, int productId, int imagesCount)
        {
            if (imagesCount == 0)
                return;

            var oldThumbnailPath = GetThumbnailFileName(oldProductId);
            var newThumbnailPath = GetThumbnailFileName(productId);

            if (File.Exists(oldThumbnailPath))
            {
                File.Move(oldThumbnailPath, newThumbnailPath);
            }

            for (int i = 0; i < imagesCount; i++)
            {
                RenameImage(oldProductId, i, productId, i);
            }
        }
    }
}