using ClothingStore.Domain.Entities;
using ClothingStore.Service.Interface;
using ClothingStore.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ClothingStore.Models.DTO.ShoppingCartDTO;
using ClothingStore.Domain.Enums;
using ClothingStore.Models.DTO.ProductDTOs;

namespace ClothingStoreApiTest
{
    [TestClass]
    public class ShoppingCartControllerTest
    {
        private Mock<IShoppingCartService> mock;
        private ShoppingCartController api;
        private ShoppingCart testShoppingCart;
        private Product testProduct;                
        private User testUser;
        private Promotion testPromotion;
        private Payment testPayment;
        private List<ShoppingCart> shoppingCarts;
        private ShoppingCartRequestDTO testShoppingCartRequestDTO;
        private ShoppingCartResponseDTO testShoppingCartResponseDTO;
        private ShoppingCartSaleDTO testShoppingCartSaleDTO;
        private ProductInCartDTO testProductInCartDTO;

        [TestInitialize]
        public void InitTest()
        {
            mock = new Mock<IShoppingCartService>(MockBehavior.Strict);
            api = new ShoppingCartController(mock.Object);           

            testProduct = new Product()
            {
                Id = 1,
                Name = "Test Name",
                Price = 100,
                Stock = 10,
                PromoAvailable = true,
            };
            testUser = new User()
            {
                Id = 1,
                Email = "Test Email"
            };
            testPromotion = new Promotion()
            {
                Id = 1,
                Name = "Test Promotion"
            };
            testPayment = new Payment()
            {
                Id = 1,
                Name = "Test Payment",
                Discount = 0,
            };
            testShoppingCart = new ShoppingCart()
            {
                Id = 1,
                SubTotal = 0,
                Discount = 0,
                Total = 0,
                CartDate = DateTime.Now,
                User = testUser,
                UserId = testUser.Id,
                Products = new List<Product> { testProduct },
                Promotion = testPromotion,
                PromotionId = testPromotion.Id,
                StateOrder = StateOrder.Pending,
                Payment = testPayment,
                PaymentId = testPayment.Id,
            };
            testShoppingCartRequestDTO = new ShoppingCartRequestDTO()
            {
                Email = "Test Email"
            };
            testProductInCartDTO = new ProductInCartDTO()
            {
                Id = 1,
                Name = "Test Name",
            };
            testShoppingCartResponseDTO = new ShoppingCartResponseDTO()
            {
                Id = 1,
                UserId = 1,
                Email  = "Test Mail",
                SubTotal = 0,
                Discount = 0,
                Total = 0,
                CartDate = DateTime.Now,
                Products = new List<ProductInCartDTO> { testProductInCartDTO }        
            };

            shoppingCarts = new List<ShoppingCart> { testShoppingCart };            
        }

        [TestMethod]
        public void GetAllShoppingCartOkTest()
        {
            mock.Setup(x => x.GetAll()).Returns(shoppingCarts);
            var result = api.GetAll();
            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;
            mock.VerifyAll();
            Assert.AreEqual(200, statusCode);
        }

        [TestMethod]
        public void PostShoppingCartOkTest()
        {
            mock.Setup(x => x.Create(It.IsAny<ShoppingCartRequestDTO>())).Verifiable();
            var result = api.Post(testShoppingCartRequestDTO);
            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;
            mock.VerifyAll();
            Assert.AreEqual(200, statusCode);
        }

    

    }
}

//cambio
//public IActionResult Put(int shoppingCartId, [FromBody] int productId)
//public IActionResult Remove(int shoppingCartId, [FromBody] int productId)
//public IActionResult GetTotal(int shoppingCartId)
//public IActionResult GetDiscount(int shoppingCartId)
//public IActionResult Sale(int shoppingCartId, [FromBody] int paymentId)
//public IActionResult GetSales()
//public IActionResult GetSalesByUserId(int userId)