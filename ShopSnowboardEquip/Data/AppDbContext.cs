﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopSnowboardEquip.Data.Models;
using ShopSnowboardEquip.Models;

namespace ShopSnowboardEquip.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>


	{
		public AppDbContext( DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<Equipment> Equipments { get; set; }
		public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
		public DbSet<Gender> Genders { get; set; }
    }
}

