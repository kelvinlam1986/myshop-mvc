using System.Collections.Generic;

namespace shop.ViewModels.Category
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            CategoriesGrid = new List<CategoryDTO>();
            InputCategory = new CategoryDTO();
        }

        public IEnumerable<CategoryDTO> CategoriesGrid { get; set; }
        public CategoryDTO InputCategory { get; set; }
    }
}