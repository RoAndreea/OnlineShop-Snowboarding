using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using ShopSnowboardEquip.Data.Models;
using ShopSnowboardEquip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSnowboardEquip.Data
{
	public class AppDbContext : DbContext
	
		
{
		public AppDbContext( DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<Equipment> Equipments { get; set; }
		public DbSet<Category> Categories { get; set; }


	}
}

