using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopSnowboardEquip.Data.interfaces;
using ShopSnowboardEquip.Models;
using ShopSnowboardEquip.ViewModels;

namespace ShopSnowboardEquip.Controllers
{
	public class HomeController : Controller
	{
        private readonly IEquipmentRepository _equipmentRepository;
        public HomeController(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public ViewResult Index()
		{
            var homeViewModel = new HomeViewModel
            {
                PreferredEquipments = _equipmentRepository.PreferredEquipments
            };

            return View(homeViewModel);
        }

		public IActionResult About()
		{
			ViewData["Message"] = "Your application description page.";

			return View();
		}

		public IActionResult Contact()
		{
			ViewData["Message"] = "Your contact page.";

			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
