using ShopSnowboardEquip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSnowboardEquip.ViewModels
{
	public class EquipmentListViewModel
	{
		public IEnumerable<Equipment> Equipment { get; set; }
		public string CurrentCategory { get; set; }
	}
}
