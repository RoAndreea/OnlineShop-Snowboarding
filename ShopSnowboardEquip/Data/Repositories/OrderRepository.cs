﻿using ShopSnowboardEquip.Data.interfaces;
using ShopSnowboardEquip.Data.Models;
using System;

namespace ShopSnowboardEquip.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;


        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }


        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            _appDbContext.Orders.Add(order);

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = shoppingCartItem.Amount,
                    EquipmentId = shoppingCartItem.Equipment.EquipmentId,
                    OrderId = order.OrderId,
                    Price = shoppingCartItem.Equipment.Price
                };

                _appDbContext.OrderDetails.Add(orderDetail);
            } 

            _appDbContext.SaveChanges();
        }
    }
}
