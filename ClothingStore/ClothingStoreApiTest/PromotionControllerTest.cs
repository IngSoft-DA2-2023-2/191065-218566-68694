using ClothingStore.Domain.Entities;
using ClothingStore.Service.Interface;
using ClothingStore.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ClothingStore.Models.DTO.PromotionDTOs;


namespace ClothingStoreApiTest
{
    [TestClass]
    public class PromotionControllerTest
    {
        private Mock<IPromotionService> mock;
        private PromotionController api;
        private Promotion testPromotion;
        private PromotionRequestDTO testPromotionRequestDTO;                
        private List<Promotion> promotions;

        [TestInitialize]
        public void InitTest()
        {
            mock = new Mock<IPromotionService>(MockBehavior.Strict);
            api = new PromotionController(mock.Object); 
            testPromotionRequestDTO = new PromotionRequestDTO();

            testPromotion = new Promotion()
            {
                Id = 1,
                Name = "Test Name",                
                Description = "Test Description",                
                Available = true,
            };

            testPromotionRequestDTO = new PromotionRequestDTO()
            {
                Name = "Test Name",                
                Description = "Test Description",
            };            
            
            promotions = new List<Promotion>() { testPromotion };
        }

        [TestMethod]
        public void GetAllPromotionOkTest()
        {
            mock.Setup(x => x.GetAll()).Returns(promotions);
            var result = api.GetAll();
            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;
            mock.VerifyAll();
            Assert.AreEqual(200, statusCode);
        }

        [TestMethod]
        public void GetByIdPromotionOkTest()
        {
            mock.Setup(x => x.GetById(It.IsAny<int>())).Returns(It.IsAny<Promotion>());
            var result = api.GetById(testPromotion.Id);
            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;
            mock.VerifyAll();
            Assert.AreEqual(200, statusCode);
        }

        [TestMethod]
        public void PostPromotionOkTest()
        {
            mock.Setup(x => x.Create(It.IsAny<PromotionRequestDTO>())).Verifiable();
            var result = api.Post(testPromotionRequestDTO);
            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;
            mock.VerifyAll();
            Assert.AreEqual(200, statusCode);
        }


    }
}

//public IActionResult GetByName(string promotionName)
//public IActionResult EnablePromotion(int promoId)
//public IActionResult DisablePromotion(int promoId)