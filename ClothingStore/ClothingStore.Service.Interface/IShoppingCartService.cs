﻿using ClothingStore.Domain.Entities;
using ClothingStore.Models.DTO.PromotionDTOs;
using ClothingStore.Models.DTO.ShoppingCartDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Service.Interface
{
    public interface IShoppingCartService
    {
        public int Create(ShoppingCartRequestDTO ShoppingCartRequestDTO);
        public List<ShoppingCart> GetAll();        
        public ShoppingCartResponseDTO GetById(int id);
        public void AddProductCart(int shoppingCartId, int productId);
        public void RemoveProductCart(int shoppingCartId, int productId);
        public double GetTotal(int ShoppingCartId);
        public PromotionDiscountDTO RunPromotions(int shoppingCartId);
        public ShoppingCartSaleDTO Sale(int shoppingCartId, int paymentId);
        public List<ShoppingCartSaleDTO> GetSales();
        public List<ShoppingCartSaleDTO> GetSalesByUserId(int userId);
        public ShoppingCart VerifyStock(ShoppingCart shoppingCart);
       public List<ShoppingCartResponseDTO> GetShoppingCartByUserId(int id);
    }
}
