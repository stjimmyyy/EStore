namespace E_Store.Business.Managers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    using Interfaces;
    using Data.Models;
    using E_Store.Data.Interfaces.Repositories;

    using Microsoft.Extensions.Caching.Memory;

    public class CategoryManager : ICategoryManager
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IProductRepository productRepository;
        private readonly IMemoryCache memoryCache;

        public CategoryManager(ICategoryRepository categoryRepository,
            IProductRepository productRepository, 
            IMemoryCache memoryCache)
        {
            this.categoryRepository = categoryRepository;
            this.productRepository = productRepository;
            this.memoryCache = memoryCache;
        }
        
        public List<Category> GetLeaves(bool includeHidden = false)
        {
            return this.categoryRepository.GetLeaves();
        }

        public void UpdateProductCategories(int productId, int[] categories)
        {
            var product = productRepository.FindById(productId)
                          ?? throw new ArgumentNullException($"The {productId} product was not found");

            var currentCategories = product.CategoryProducts
                .Select(cp => cp.CategoryId);

            var removeCategories = currentCategories.Except(categories).ToList();

            var addCategories = categories.Except(currentCategories).ToList();

            foreach (var categoryId in removeCategories)
            {
                var toRemove = product.CategoryProducts
                    .SingleOrDefault(cp => cp.CategoryId == categoryId);

                product.CategoryProducts.Remove(toRemove);
            }

            foreach (var categoryId in addCategories)
            {
                var toAdd = new CategoryProduct()
                {
                    CategoryId = categoryId,
                    ProductId = productId
                };
                
                product.CategoryProducts.Add(toAdd);
            }
            
            productRepository.Update(product);
        }
        public List<Category> GetRoots()
        {
            if (!this.memoryCache.TryGetValue("CategoryRoots", out List<Category> result))
            {
                result = categoryRepository.GetRoots().ToList();
                this.memoryCache.Set("CategoryRoots", result,
                    new DateTimeOffset(DateTime.Now.AddHours(1)));
            }

            return result;
        }
    }
}