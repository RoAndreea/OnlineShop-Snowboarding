using Microsoft.AspNetCore.Mvc;
using ShopSnowboardEquip.Data.interfaces;
using ShopSnowboardEquip.Models;
using ShopSnowboardEquip.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopSnowboardEquip.Controllers
{
	public class EquipmentController : Controller

    {
		private readonly ICategoryRepository _categoryRepository;
		private readonly IEquipmentRepository _equipmentRepository;

		public EquipmentController(ICategoryRepository categoryRepository, IEquipmentRepository equipmentRepository)
		{
			_categoryRepository = categoryRepository;
			_equipmentRepository = equipmentRepository;

		}
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Equipment> equipments;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                equipments = _equipmentRepository.Equipments.OrderBy(p => p.EquipmentId);
                currentCategory = "All equipments";
            }
            else
            {
                if (string.Equals("SnowAccessories", _category, StringComparison.OrdinalIgnoreCase))
                    equipments = _equipmentRepository.Equipments.Where(p => p.Category.CategoryName.Equals("SnowAccessories")).OrderBy(p => p.Name);
                else
                    equipments = _equipmentRepository.Equipments.Where(p => p.Category.CategoryName.Equals("SnowOutfit")).OrderBy(p => p.Name);

                currentCategory = _category;
            }

            return View(new EquipmentListViewModel
            {
                Equipment = equipments,
                CurrentCategory = currentCategory
            });
        }
    }
}