using ShopSnowboardEquip.Data.interfaces;
using ShopSnowboardEquip.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShopSnowboardEquip.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
	{
		private readonly AppDbContext _appDbContext;
		public CategoryRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}
		public IEnumerable<Category> Categories => _appDbContext.Categories;

        public void CreateCategory(Category category)
        {
            _appDbContext.Categories.Add(category);
            _appDbContext.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            _appDbContext.Categories.Remove(category);
            _appDbContext.SaveChanges();
        }

        public void EditCategory(Category category)
        {
            _appDbContext.Categories.Update(category);
            _appDbContext.SaveChanges();
        }

        public Category GetCategoryById(int categoryId) => _appDbContext.Categories.FirstOrDefault(p => p.CategoryId == categoryId);
    }
}
