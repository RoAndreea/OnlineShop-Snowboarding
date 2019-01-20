using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopSnowboardEquip.Data.interfaces;
using ShopSnowboardEquip.Data.Models;
using ShopSnowboardEquip.ViewModels;

namespace ShopSnowboardEquip.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IEquipmentRepository equipmentRepository, ShoppingCart shoppingCart)
        {
            _equipmentRepository = equipmentRepository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int equipmentId)
        {
            var selectedEquipment = _equipmentRepository.Equipments.FirstOrDefault(p => p.EquipmentId == equipmentId);
            if (selectedEquipment != null)
            {
                _shoppingCart.AddToCart(selectedEquipment, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int equipmentId)
        {
            var selectedEquipment = _equipmentRepository.Equipments.FirstOrDefault(p => p.EquipmentId == equipmentId);
            if (selectedEquipment != null)
            {
                _shoppingCart.RemoveFromCart(selectedEquipment);
            }
            return RedirectToAction("Index");
        }
    }
}