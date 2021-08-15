namespace E_Store.Business.Interfaces
{
    using System.Collections.Generic;
    using Data.Models;

    public interface ICategoryManager
    {
        List<Category> GetLeaves(bool includeHidden = false);
        void UpdateProductCategories(int productId, int[] categories);

        List<Category> GetRoots();
    }
}