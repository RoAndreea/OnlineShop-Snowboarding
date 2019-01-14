using ShopSnowboardEquip.Data.interfaces;
using ShopSnowboardEquip.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSnowboardEquip.Data.mocks
{
	public class MockCategoryRepository:ICategoryRepository
	
	{
			public IEnumerable<Category> Categories
			{
				get
				{
					return new List<Category>
					 {
						 new Category { CategoryName = "SnowboardAccesory", Description = "All snowboard accesories and protection" },
						 new Category { CategoryName = "SnowboardClothes", Description = "All snowboard type of clothes" },
						 new Category { CategoryName = "SnowboardEquipment", Description = "All snowboard equipment: boots and boards" }
					 };
				}
			}
	}
	
}
