using ShopSnowboardEquip.Data.Models;
using System.Collections.Generic;

namespace ShopSnowboardEquip.Data.interfaces
{
    public interface ICategoryRepository
	{
		IEnumerable<Category> Categories { get; }
        Category GetCategoryById(int categoryId);
        void CreateCategory(Category category);
        void DeleteCategory(Category category);
        void EditCategory(Category category);
    }
}
