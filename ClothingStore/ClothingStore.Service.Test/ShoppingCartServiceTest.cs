using ClothingStore.DataAccess.Interface;
using ClothingStore.DataAccess.Repositories;
using ClothingStore.Domain.Entities;
using ClothingStore.Domain.Enums;
using ClothingStore.Models.DTO.PromotionDTOs;
using ClothingStore.Models.DTO.ShoppingCartDTO;
using Moq;
using System.ComponentModel.DataAnnotations;

namespace ClothingStore.Service.Test
{
    [TestClass]
    public class ShoppingCartServiceTest
    {
        private IShoppingCartRepository shoppingCartRepository;

        private ShoppingCart shoppingCartTest;
        private Role roleTest;
        private User userTest;
        private Promotion promotionTest;
        private Payment paymentTest;
        private PaymentCategory paymentCategoryTest;
    

        [TestInitialize]
        public void InitTest()
        {
            var shoppingCartRepositoryMock = new Mock<IShoppingCartRepository>();

            roleTest = new Role
            {
                Id = 1,
                Name = "Admin"
            };
            userTest = new User
            {
                Id = 1,
                Email = "Test Email",
                Password = "Test Password",
                Address = "Test Address",
                Roles = new List<Role> { roleTest },
            };
            promotionTest = new Promotion
            {
                Id = 1,
                Name = "Test Promo",
                Description = "Test Description",
                Available = true
            };
            paymentCategoryTest = new PaymentCategory
            {
                Id = 1,
                Name = "Test Name"
            };
            paymentTest = new Payment
            {
                Id = 1,
                Name = "Test Payment",
                PaymentCategory = paymentCategoryTest,
                PaymentCategoryId = 1,
                Discount = 0
            };       
            shoppingCartTest = new ShoppingCart
            {
                Id = 1,
                SubTotal = 0,
                Discount = 0,
                Total = 0,
                CartDate = DateTime.Now,                
                User = userTest,
                UserId = 1,
                Promotion = promotionTest,
                PromotionId = 1,
                StateOrder = StateOrder.Pending,
                Payment = paymentTest,
                PaymentId = 1
            };      
            var shoppingCarts = new List<ShoppingCart>() { shoppingCartTest };
            shoppingCartRepositoryMock.Setup(x => x.GetAll()).Returns(shoppingCarts);
            shoppingCartRepository = shoppingCartRepositoryMock.Object;
        }

        [TestMethod]
        public void CreateShoppingCartTest()
        {
            var shoppingCartRepositoryMock = new Mock<IShoppingCartRepository>();
            var productRepositoryMock = new Mock<IProductRepository>();
            var promotionRepositoryMock = new Mock<IPromotionRepository>();
            var paymentRepositoryMock = new Mock<IPaymentRepository>();
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.GetByEmail("userTest")).Returns(userTest);            
            var shoppingCartDto = new ShoppingCartRequestDTO
            {
               Email = "userTest"
            };
            var shoppingCartService = new ShoppingCartService(null,shoppingCartRepositoryMock.Object, productRepositoryMock.Object, userRepositoryMock.Object,promotionRepositoryMock.Object,paymentRepositoryMock.Object);
            shoppingCartService.Create(shoppingCartDto);
            shoppingCartRepositoryMock.Verify(m => m.Create(It.IsAny<ShoppingCart>()), Times.Once);
        }

        [TestMethod]
        public void GetAllProductTest()
        {
            var shoppingCartRepositoryMock = new Mock<IShoppingCartRepository>();
            var productRepositoryMock = new Mock<IProductRepository>();
            var promotionRepositoryMock = new Mock<IPromotionRepository>();
            var paymentRepositoryMock = new Mock<IPaymentRepository>();
            var userRepositoryMock = new Mock<IUserRepository>();
            shoppingCartRepositoryMock.Setup(repo => repo.GetAll())
            .Returns(new List<ShoppingCart>
            { new ShoppingCart 
                {
                    Id = 1,
                    SubTotal = 0,
                    Discount = 0,
                    Total = 0,
                    CartDate = DateTime.Now,
                    User = userTest,
                    UserId = 1,
                    Promotion = promotionTest,
                    PromotionId = 1,
                    StateOrder = StateOrder.Pending,
                    Payment = paymentTest,
                    PaymentId = 1 
                }                
            });
            var shoppingCartService = new ShoppingCartService(null,shoppingCartRepositoryMock.Object, null, null, null,null);
            var shoppingCarts = shoppingCartService.GetAll();
            Assert.IsNotNull(shoppingCarts);
            Assert.AreEqual(1, shoppingCarts.Count());
        }

        [TestMethod]
        public void GetByIdShoppingCartTest()
        {
            var shoppingCartRepositoryMock = new Mock<IShoppingCartRepository>();
            shoppingCartRepositoryMock.Setup(repo => repo.GetById(shoppingCartTest.Id)).Returns(shoppingCartTest);
            var shoppingCartService = new ShoppingCartService(null,shoppingCartRepositoryMock.Object, null, null, null, null);
            var result = shoppingCartService.GetById(shoppingCartTest.Id);
            Assert.IsNotNull(result);
            Assert.AreEqual(shoppingCartTest.Id, result.Id);            
            shoppingCartRepositoryMock.Verify(repo => repo.GetById(shoppingCartTest.Id), Times.Once);
        }



    }
}

//public void AddProductCart(int shoppingCartId, int productId);
//public void RemoveProductCart(int shoppingCartId, int productId);
//public double GetTotal(int ShoppingCartId);
//public PromotionDiscountDTO RunPromotions(int shoppingCartId);
//public ShoppingCartSaleDTO Sale(int shoppingCartId, int paymentId);
//public List<ShoppingCart> GetSales();
//public List<ShoppingCartSaleDTO> GetSalesByUserId(int userId);
//public ShoppingCart VerifyStock(ShoppingCart shoppingCart);