using Microsoft.AspNetCore.Mvc;
using ShopSnowboardEquip.Data.interfaces;
using ShopSnowboardEquip.ViewModels;

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
        public ViewResult List()
        {
			ViewBag.Name = "DotNet, How?";
			EquipmentListViewModel vm = new EquipmentListViewModel();
			vm.Equipment = _equipmentRepository.Equipments;
			vm.CurrentCategory = "EquipmentCategory";
			return View(vm);
        }
    }
}