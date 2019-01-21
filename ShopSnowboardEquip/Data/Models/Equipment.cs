﻿using ShopSnowboardEquip.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSnowboardEquip.Models
{
	public class Equipment
	{
		public int EquipmentId { get; set; }
		public string Name { get; set; }
		public string ShortDescription { get; set; }
		public string LongDescription { get; set; }
		public decimal Price { get; set; }
		public string ImageUrl { get; set; }
		public string ImageThumbnailUrl { get; set; }
		public bool IsPreferredEquipment { get; set; }
		public bool InStock { get; set; }
		public int CategoryId { get; set; }
		public int GenderId { get; set; }
		public virtual Category Category { get; set; }
		public virtual Gender Gender { get; set; }
		
	}
}
