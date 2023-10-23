using ClothingStore.DataAccess.Interface;
using ClothingStore.DataAccess.Repositories;
using ClothingStore.Domain.Entities;
using ClothingStore.Models.DTO.ProductDTOs;
using ClothingStore.Models.DTO.PromotionDTOs;
using ClothingStore.Models.DTO.ShoppingCartDTO;
using ClothingStore.Service.Interface;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClothingStore.Service
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPromotionRepository _promotionRepository;

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository ,IProductRepository productRepository, IUserRepository userRepository, IPromotionRepository promotionRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _productRepository = productRepository;            
            _userRepository = userRepository;   
            _promotionRepository = promotionRepository; 
        }
        
        public void Create(ShoppingCartRequestDTO shoppingCartRequestDTO)
        {
            var user = _userRepository.GetByEmail(shoppingCartRequestDTO.Email);
            if (user == null)
            {
                throw new ArgumentException($"No existe el usuario.");
            }
            var shoppingCart = new ShoppingCart();
            var promotionDefault = _promotionRepository.GetByName("Sin Promo"); 
            shoppingCart.Promotion = promotionDefault;
            shoppingCart.User = user;
            
            _shoppingCartRepository.Create(shoppingCart);
        }

        public List<ShoppingCart> GetAll()
        {
            List<ShoppingCart> shoppingCarts = _shoppingCartRepository.GetAll();
            return shoppingCarts;
        }
        
        public ShoppingCartResponseDTO GetById(int id)
        {
            ShoppingCart shoppingCart = _shoppingCartRepository.GetById(id);
            if (shoppingCart == null)
            {
                throw new ArgumentException($"No se puede obtener el carrito");
            }
            var shoppingCartResponseDTO = new ShoppingCartResponseDTO();
            shoppingCartResponseDTO.Id = shoppingCart.Id;
            shoppingCartResponseDTO.UserId = shoppingCart.UserId;
            shoppingCartResponseDTO.Email = shoppingCart.User.Email;
            shoppingCartResponseDTO.CartDate = shoppingCart.CartDate;
            shoppingCartResponseDTO.SubTotal = shoppingCart.SubTotal;
            shoppingCartResponseDTO.Discount = shoppingCart.Discount;
            shoppingCartResponseDTO.Total = shoppingCart.Total;
            foreach (var product in shoppingCart.Products)
            {
                var productInCartDTO = new ProductInCartDTO();
                productInCartDTO.Id = product.Id;
                productInCartDTO.Name = product.Name;
                shoppingCartResponseDTO.Products.Add(productInCartDTO);
            }
            return shoppingCartResponseDTO;
        }

        public void AddProductCart(int shoppingCartId, int productId)
        {
            ShoppingCart shoppingCart = _shoppingCartRepository.GetById(shoppingCartId);
            if (shoppingCart == null)
            {
                throw new ArgumentException($"No se puede obtener el carrito");
            }
            Product product = _productRepository.GetById(productId);
            if (product == null)
            {
                throw new ArgumentException($"No se puede obtener el producto");
            }
            if (product.Stock == 0)
            {
                throw new ArgumentException($"No hay stock del producto");
            }
            shoppingCart.Products.Add(product);
            _shoppingCartRepository.Update(shoppingCart);
        }

        public void RemoveProductCart(int shoppingCartId, int productId)
        {
            ShoppingCart shoppingCart = _shoppingCartRepository.GetById(shoppingCartId);
            if (shoppingCart == null)
            {
                throw new ArgumentException($"No se puede obtener el carrito");
            }
            Product product = _productRepository.GetById(productId);
            if (product == null)
            {
                throw new ArgumentException($"No se puede obtener el producto");
            }
            shoppingCart.Products.Remove(product);
            _shoppingCartRepository.Update(shoppingCart);
        }

        public double GetTotal(int ShoppingCartId)
        {
            double total = 0;
            ShoppingCart shoppingCart = _shoppingCartRepository.GetById(ShoppingCartId);
            foreach (var product in shoppingCart.Products)
            {
                total = total + product.Price;
            }
            return total;
        }

        public PromotionDiscountDTO RunPromotions(int shoppingCartId)
        {
            var shoppingCart = _shoppingCartRepository.GetById(shoppingCartId);
            var promotions = _promotionRepository.GetAllAvailable();
            double discount = 0;
            double result;
            string promo = "Sin Promo";

            PromotionDiscountDTO promotionDiscount = new PromotionDiscountDTO();

            foreach (var promotion in promotions)
            {
                switch (promotion.Name)
                {
                    case "Promo20Off":                        
                        result = Promo20Off(shoppingCart);
                        if (result > discount)
                        {
                            discount = result;
                            promo = "Promo20Off";
                            result = 0;
                        }
                        break;
                    case "Promo3x2":
                        result = Promo3x2(shoppingCart);                        
                        if (result > discount)
                        {
                            discount = result;
                            promo = "Promo3x2";
                            result = 0;
                        }
                        break;
                    case "PromoTotalLook":
                        result = PromoTotalLook(shoppingCart);
                        if (result > discount)
                        {
                            discount = result;
                            promo = "PromoTotalLook";
                            result = 0;
                        }
                        break;
                    case "Promo3x1Fidelidad":
                        result = Promo3x1Fidelidad(shoppingCart);
                        if (result > discount)
                        {
                            discount = result;
                            promo = "Promo3x1Fidelidad";
                            result = 0;
                        }
                        break;
                        
                    default:                        
                        break;
                }
            }
            promotionDiscount.Discount = discount;
            promotionDiscount.PromotionName = promo;
            return promotionDiscount;
        }

        public double Promo20Off(ShoppingCart shoppingCart)
        {
            if (shoppingCart.Products.Count <= 1)
            {
                return 0;
            }
            else
            {
                //Product product1 = shoppingCart.Products.First();
                //double mayor = product1.Price;
                double mayor = 0;
                int productPromoAvailableQuantity = 0;
                foreach (var product in shoppingCart.Products)
                {
                    if (product.PromoAvailable)
                    {
                        productPromoAvailableQuantity++;
                        if (product.Price > mayor)
                        {
                            mayor = product.Price;
                        }
                    }                    
                }             
                if (productPromoAvailableQuantity >= 2)
                {
                    return (mayor * 0.2);
                }
                else
                {
                    return 0;
                }

                
            }
        }

        public double Promo3x2(ShoppingCart shoppingCart)
        {
            double minor = 0;
            if (shoppingCart.Products.Count <= 2)
            {
                return 0;
            }
            else
            {
                var groupByCategory =
                    from product in shoppingCart.Products
                    where product.PromoAvailable == true
                    group product by product.CategoryId into totals
                    select new {
                        Category = totals.Key,
                        Quantity = totals.Count(),
                        Min = totals.Min(p => p.Price)
                    };

                foreach (var categoryProduct in groupByCategory)
                {
                    if (categoryProduct.Quantity > 2)
                    {   
                        if (categoryProduct.Min > minor)
                        {
                            minor = categoryProduct.Min;
                        }
                    }
                }
                return minor;
            }
        }
     
       
        public double PromoTotalLook(ShoppingCart shoppingCart)
        {
            if (shoppingCart.Products.Count <= 2)
            {
                return 0;
            }
            else
            {                
                double montomayor = 0;
                var groupByColor =
                   from product in shoppingCart.Products
                   where product.PromoAvailable == true
                   orderby product.Price descending
                   group product by product.Colors into totals //no parece agrupar por colores
                   select new
                   {
                       Color = totals.Key,
                       Quantity = totals.Count(),                       
                   };
                if (groupByColor != null)
                {
                    foreach (var product in groupByColor)
                    {
                        Console.WriteLine("Entra");
                        Console.WriteLine($"{product.Quantity} {product.Color}");
                    }
                } else
                {
                    Console.WriteLine("Vacio");
                }                
                return montomayor;
            }            
        }

        public double Promo3x1Fidelidad(ShoppingCart shoppingCart)
        {
            double discount = 0;
            double temp = 0;
            if (shoppingCart.Products.Count <= 2)
            {
                return 0;
            }
            else
            {
                var groupByBrand =
                    from product in shoppingCart.Products
                    where product.PromoAvailable == true
                    orderby product.Price
                    group product by product.BrandId into totals
                    select new
                    {
                        Brand = totals.Key,
                        Quantity = totals.Count(),
                        Price = totals.Take(2)
                    };

                foreach (var product in groupByBrand)
                {
                    if (product.Quantity > 2)
                    {
                        temp = product.Price.First().Price + product.Price.Last().Price;
                        Console.WriteLine($"{product.Brand} {product.Quantity} {product.Price.First().Price}");
                        Console.WriteLine($"{product.Brand} {product.Quantity} {product.Price.Last().Price}");
                        Console.WriteLine("suma de los menores: " + temp);
                        if (temp > discount)
                        {
                            discount = temp;
                            temp = 0;
                        }
                    }
                }
                return discount;
            }
        }

        public ShoppingCartSaleDTO Sale(int shoppingCartId)
        {
            var shoppingCart = _shoppingCartRepository.GetById(shoppingCartId);
            shoppingCart = VerifyStock(shoppingCart);            

            shoppingCart.SubTotal = GetTotal(shoppingCartId);
            var promotionDiscount = RunPromotions(shoppingCartId);
            shoppingCart.Discount = promotionDiscount.Discount;
            var promotionApplied = _promotionRepository.GetByName(promotionDiscount.PromotionName);
            shoppingCart.Promotion = promotionApplied;
            shoppingCart.PromotionId = promotionApplied.Id;
            shoppingCart.Total = shoppingCart.SubTotal - shoppingCart.Discount;
            shoppingCart.CartDate = DateTime.Now;
            shoppingCart.StateOrder = Domain.Enums.StateOrder.Finished;
            
            _shoppingCartRepository.Update(shoppingCart);
            _productRepository.UpdateStock(shoppingCart.Products);
            
            _shoppingCartRepository.GetById(shoppingCartId);

            var shoppingCartSaleDTO = new ShoppingCartSaleDTO();
            shoppingCartSaleDTO.Id = shoppingCart.Id;
            shoppingCartSaleDTO.UserId = shoppingCart.UserId;
            shoppingCartSaleDTO.Email = shoppingCart.User.Email;
            shoppingCartSaleDTO.CartDate = shoppingCart.CartDate;
            shoppingCartSaleDTO.SubTotal = shoppingCart.SubTotal;
            shoppingCartSaleDTO.Discount = shoppingCart.Discount;
            shoppingCartSaleDTO.Total = shoppingCart.Total;
            shoppingCartSaleDTO.PromotionApplied = promotionDiscount.PromotionName;

            foreach (var product in shoppingCart.Products)
            {
                var productInCartDTO = new ProductInCartDTO();
                productInCartDTO.Id = product.Id;
                productInCartDTO.Name = product.Name;
                shoppingCartSaleDTO.Products.Add(productInCartDTO);
            }
            return shoppingCartSaleDTO;
        }

        public List<ShoppingCart> GetSales()
        {
            List<ShoppingCart> shoppingCarts = _shoppingCartRepository.GetSales();
            return shoppingCarts;
        }

        public List<ShoppingCartSaleDTO> GetSalesByUserId(int userId)
        {
            List<ShoppingCart> shoppingCarts = _shoppingCartRepository.GetSalesByUserId(userId);
            List<ShoppingCartSaleDTO> shoppingCartsSaleDTO = new List<ShoppingCartSaleDTO>();
            foreach (var shoppingCart in shoppingCarts)
            {
                var shoppingCartSaleDTO = new ShoppingCartSaleDTO();
                shoppingCartSaleDTO.Id = shoppingCart.Id;
                shoppingCartSaleDTO.UserId = shoppingCart.UserId;
                shoppingCartSaleDTO.Email = _userRepository.GetById(userId).Email;
                shoppingCartSaleDTO.CartDate = shoppingCart.CartDate;
                shoppingCartSaleDTO.SubTotal = shoppingCart.SubTotal;
                shoppingCartSaleDTO.Discount = shoppingCart.Discount;
                shoppingCartSaleDTO.Total = shoppingCart.Total;
                shoppingCartSaleDTO.PromotionApplied = _promotionRepository.GetById(shoppingCart.PromotionId).Name;

                foreach (var product in shoppingCart.Products)
                {
                    var productInCartDTO = new ProductInCartDTO();
                    productInCartDTO.Id = product.Id;
                    productInCartDTO.Name = product.Name;
                    shoppingCartSaleDTO.Products.Add(productInCartDTO);
                }
                shoppingCartsSaleDTO.Add(shoppingCartSaleDTO);
            }
            return shoppingCartsSaleDTO;
        }

        public ShoppingCart VerifyStock(ShoppingCart shoppingCart)
        {
            foreach (var product in shoppingCart.Products)
            {
                if (product.Stock == 0)
                {
                    RemoveProductCart(shoppingCart.Id, product.Id);
                }
            }
            return shoppingCart;
        }


    }
}
