namespace E_Store.Business.Managers
{
    using System.Linq;
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
        private readonly IReviewRepository reviewRepository;

        public ProductManager(IProductRepository productRepository, IReviewRepository reviewRepository)
        {
            this.productRepository = productRepository;
            this.reviewRepository = reviewRepository;
        }

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

           if (oldProduct == null)
               return;
           
           CleanProduct(oldProduct);

           var productReviews = this.reviewRepository.FindByProductId(oldProduct.Id).ToList();

           foreach (var review in productReviews)
           {
               review.ProductId = product.Id;
               this.reviewRepository.Update(review);
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

        public List<Product> FindByCategoryId(int categoryId)
        {
            return this.productRepository.FindByCategoryId(categoryId);
        }

        public List<Product> SearchProducts(string searchPhrase)
        {
            return this.productRepository.SearchProducts(searchPhrase);
        }

        public List<Product> SearchProducts
        (
            string searchPhrase,
            int? categoryId,
            string orderBy = "rating",
            decimal startPrice = 0,
            decimal endPrice = 0,
            bool inStock = false
        )
        {
            var result = SearchProducts(searchPhrase);

            if (categoryId.HasValue)
            {
                result = result
                    .Where(x => x.CategoryProducts
                        .Select(c => c.CategoryId)
                        .Contains(categoryId.Value))
                    .ToList();
            }
            
            if (startPrice > 0)
                result = result.Where(x => x.Price >= startPrice).ToList();

            if (endPrice > 0)
                result = result.Where(x => x.Price <= endPrice).ToList();

            if (inStock)
                result = result.Where(x => x.Stock > 0).ToList();

            result = orderBy.ToLower() switch
            {
                "lowest_price" => result.OrderBy(x => x.Price).ToList(),
                "highest_price" => result.OrderByDescending(x => x.Price).ToList(),
                "newest" => result.OrderByDescending(x => x.Id).ToList(),
                _ => result.OrderByDescending(x => x.Rating).ThenByDescending(x => x.Id).ToList()
            };

            return result;
        }
        public void CleanProduct(Product oldProduct, bool removeImages = false)
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

        public void AddToStock(int productId, int quantity)
        {
            var product = this.productRepository.FindById(productId);

            product.Stock += quantity;
            productRepository.Update(product);
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