using Microsoft.AspNetCore.Builder;
using ShopSnowboardEquip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSnowboardEquip.Data.Models
{
    public class DbInitializer
    {
        public static void Seed(AppDbContext context, IApplicationBuilder applicationBuilder)
        {
            //AppDbContext context =
            //    applicationBuilder.ApplicationServices.GetRequiredService<AppDbContext>();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }

            if (!context.Equipments.Any())
            {
                context.AddRange
                (
                    new Equipment
                    {
                        Name = "Snowboard",
                        Price = 7.95M,
                        ShortDescription = "The most popular snowboard",
                        LongDescription = "Snowboards are boards where both feet are secured to the same board, which are wider than skis, with the ability to glide on snow.",
                        Category = Categories["SnowAccessories"],
                        ImageUrl = "/images/placa1.PNG",
                        InStock = true,
                        IsPreferredEquipment = true,
                        ImageThumbnailUrl = "/images/placa2.PNG",
						Gender = Genders["Unisex"]
                    },
                    new Equipment
                    {
                        Name = "Ski",
                        Price = 12.95M,
                        ShortDescription = "The most popular ski",
                        LongDescription = "A ski is a narrow strip of semi-rigid material worn underfoot to glide over snow.",
                        Category = Categories["SnowAccessories"],
                        ImageUrl = "/images/placa2.PNG",
                        InStock = true,
                        IsPreferredEquipment = false,
                        ImageThumbnailUrl = "/images/placa3.PNG",
						Gender = Genders["Unisex"]

					},
                    new Equipment
                    {
                        Name = "Ski goggles",
                        Price = 12.95M,
                        ShortDescription = "The most popular ski goggles",
                        LongDescription = "Ski goggles are goggles that help protect a skiers' eyes from the sun.",
                        Category = Categories["SnowAccessories"],
                        ImageUrl = "/images/ochelari2.PNG",
                        InStock = true,
                        IsPreferredEquipment = false,
                        ImageThumbnailUrl = "/images/ochelari1.PNG",
						Gender = Genders["Unisex"]
					},
                    new Equipment
                    {
                        Name = "Ski Helmet",
                        Price = 16.75M,
                        ShortDescription = "A very interesting ski helmet",
                        LongDescription = "A ski helmet is a helmet specifically designed and constructed for winter sports.",
                        Category = Categories["SnowAccessories"],
                        ImageUrl = "/images/casca1.PNG",
                        InStock = true,
                        IsPreferredEquipment = false,
                        ImageThumbnailUrl = "/images/casca2.PNG",
						Gender = Genders["Unisex"]
					},
                    new Equipment
                    {
                        Name = "Boots",
                        Price = 7.95M,
                        ShortDescription = "A ski/boot/binding combination",
                        Category = Categories["SnowAccessories"],
                        LongDescription = "Ski boots are footwear used in skiing to provide a way to attach the skier to skis using ski bindings.",
                        ImageUrl = "/images/boots3.PNG",
                        InStock = true,
                        IsPreferredEquipment = false,
                        ImageThumbnailUrl = "/images/boots5.PNG",
						Gender = Genders["Unisex"]
					},
                    new Equipment
                    {
                        Name = "Ski Bindings",
                        Price = 5.95M,
                        ShortDescription = "It holds the boot firmly",
                        LongDescription = "A ski binding is a device that connects a ski boot to the ski.",
                        Category = Categories["SnowAccessories"],
                        ImageUrl = "/images/legaturib1.PNG",
                        InStock = false,
                        IsPreferredEquipment = false,
                        ImageThumbnailUrl = "/images/legaturib2.PNG",
						Gender = Genders["Unisex"]
					},
                    new Equipment
                    {
                        Name = "Ski jacket",
                        Price = 15.95M,
                        ShortDescription = "The most popular outfit",
                        LongDescription = "A ski jacket is a jacket made to be worn over the rest of the clothes when skiing or snowboarding.",
                        Category = Categories["SnowOutfit"],
                        ImageUrl = "/images/geaca2.PNG",
                        InStock = false,
                        IsPreferredEquipment = false,
                        ImageThumbnailUrl = "/images/geaca3.PNG",
						Gender = Genders["Unisex"]
					},
                    new Equipment
                    {
                        Name = "Ski Gloves",
                        Price = 5.95M,
                        ShortDescription = "Ski Gloves are a type of clothing in The Long Dark",
                        LongDescription = "A glove is a garment covering the whole hand. Gloves usually have separate sheaths or openings for each finger and the thumb.",
                        Category = Categories["SnowOutfit"],
                        ImageUrl = "/images/manusib1.PNG",
                        InStock = false,
                        IsPreferredEquipment = true,
                        ImageThumbnailUrl = "/images/manusib2.PNG",
						Gender = Genders["Unisex"]
					},
                    new Equipment
                    {
                        Name = "Ski pants",
                        Price = 15.95M,
                        ShortDescription = "The most popular ski pants",
                        LongDescription = "Ski pants, or salopettes, when part of a two-piece ski suit, is usually made in the same fabric and color as the corresponding ski jacket.",
                        Category = Categories["SnowOutfit"],
                        ImageUrl = "/images/pantb1.PNG",
                        InStock = false,
                        IsPreferredEquipment = false,
                        ImageThumbnailUrl = "/images/pantb2.PNG",
						Gender = Genders["Unisex"]
					},
                    new Equipment
                    {
                        Name = "Ski socks",
                        Price = 3.95M,
                        ShortDescription = "The funniest ski socks",
                        LongDescription = "Modern ski socks have a lot of technical features for warmth, fit and padding to mitigate abrasion and impact.",
                        Category = Categories["SnowOutfit"],
                        ImageUrl = "/images/soseteb1.PNG",
                        InStock = false,
                        IsPreferredEquipment = true,
                        ImageThumbnailUrl = "/images/soseteb2.PNG",
						Gender = Genders["Unisex"]
					}
                );
            }

            context.SaveChanges();
        }

        private static Dictionary<string, Category> categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var genresList = new Category[]
                    {
                        new Category { CategoryName = "SnowAccessories", Description="All accessories for snow sports" },
                        new Category { CategoryName = "SnowOutfit", Description="All snow outfits" }
                    };

                    categories = new Dictionary<string, Category>();

                    foreach (Category genre in genresList)
                    {
                        categories.Add(genre.CategoryName, genre);
                    }
                }

                return categories;
            }
        }

		private static Dictionary<string, Gender> genders;
		public static Dictionary<string, Gender> Genders
		{
			get
			{
				if (genders == null)
				{
					var genresList = new Gender[]
					{
						new Gender { GenderName = "Male" },
						new Gender { GenderName = "Female" },
						new Gender { GenderName = "Unisex"}
					};

					genders = new Dictionary<string, Gender>();

					foreach (Gender genre in genresList)
					{
						genders.Add(genre.GenderName, genre);
					}
				}

				return genders;
			}
		}



	}
}

