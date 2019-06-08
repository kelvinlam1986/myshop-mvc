using System.Collections.Generic;
using shop.Models;

namespace shop.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();
        bool InsertCategory(Category category);
        bool IsExistingByName(string name);
        bool IsExistingByName(string name, int id);
        bool DeleteCategory(Category category);
        Category GetCategoryById(int id);
        bool UpdateCategory(Category category);
    }
}