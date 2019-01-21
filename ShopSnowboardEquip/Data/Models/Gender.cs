using ShopSnowboardEquip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSnowboardEquip.Data.Models
{
	public class Gender
	{
		public int GenderId { get; set; }
		public string GenderName { get; set; }
		public List<Equipment> Equipments { get; set; }
	}

}
