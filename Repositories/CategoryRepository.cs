using System;
using System.Collections.Generic;
using System.Linq;
using shop.Data;
using shop.Models;

namespace shop.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private ShopContext _context;

        public CategoryRepository(ShopContext context)
        {
            this._context = context;
        }

        public IEnumerable<Category> GetCategories()
        {
            return this._context.Categories.ToList();
        }

        public bool InsertCategory(Category category)
        {
            try
            {
                this._context.Add(category);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteCategory(Category category)
        {
            try
            {
                this._context.Remove(category);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Category GetCategoryById(int id)
        {
            return this._context.Categories.Find(id);
        }

        public bool IsExistingByName(string name)
        {
            return this._context.Categories.Any(x => x.Name == name);
        }

        public bool IsExistingByName(string name, int id)
        {
            return this._context.Categories.Any(x => x.Name == name && x.Id != id);
        }

        public bool UpdateCategory(Category category)
        {
            try
            {
                this._context.Update(category);
                int rowEffected = this._context.SaveChanges();
                return rowEffected == 1;
            }
            catch (Exception)
            {
                return false;
            }


        }
    }
}