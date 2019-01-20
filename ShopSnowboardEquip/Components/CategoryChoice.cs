using Microsoft.AspNetCore.Mvc;
using ShopSnowboardEquip.Data.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSnowboardEquip.Components
{
    public class CategoryChoice: ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryChoice(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryRepository.Categories.OrderBy(p => p.CategoryName);
            return View(categories);
        }
    }
}
