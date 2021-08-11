namespace E_Store.Business.Interfaces
{
    using System.Collections.Generic;
    using Data.Models;

    public interface ICategoryManager
    {
        List<Category> GetLeaves();

        void UpdateProductCategories(int productId, int[] categories);
    }
}