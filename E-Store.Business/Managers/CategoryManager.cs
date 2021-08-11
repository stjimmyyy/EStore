namespace E_Store.Business.Managers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    using Interfaces;
    using Data.Models;
    using E_Store.Data.Interfaces.Repositories;

    public class CategoryManager : ICategoryManager
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IProductRepository productRepository;

        public CategoryManager(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            this.categoryRepository = categoryRepository;
            this.productRepository = productRepository;
        }
        
        public List<Category> GetLeaves()
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
    }
}