using ShopSnowboardEquip.Models;
using System.Collections.Generic;

namespace ShopSnowboardEquip.Data.Models
{
    public class Gender
	{
		public int GenderId { get; set; }
		public string GenderName { get; set; }
		public List<Equipment> Equipments { get; set; }
	}

}
