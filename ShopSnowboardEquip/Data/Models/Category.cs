using ShopSnowboardEquip.Models;
using System.Collections.Generic;

namespace ShopSnowboardEquip.Data.Models
{
    public class Category
	{
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
		public string Description { get; set; }
		public List<Equipment> Equipments { get; set; }
	}
}
