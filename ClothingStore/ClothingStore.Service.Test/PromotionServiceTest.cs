using ClothingStore.DataAccess.Interface;
using ClothingStore.Domain.Entities;
using ClothingStore.Models.DTO.PromotionDTOs;
using Moq;

namespace ClothingStore.Service.Test
{
    [TestClass]
    public class PromotionServiceTest
    {
        private IPromotionRepository promotionRepository;
        private Promotion promotionTest;

        [TestInitialize]
        public void InitTest()
        {
            var promotionRepositoryMock = new Mock<IPromotionRepository>();

            promotionTest = new Promotion
            {
                Id = 1,
                Name = "Test Name",                
                Description = "Test Name",                
                Available = true
            };
            var promotions = new List<Promotion>() { promotionTest };
            promotionRepositoryMock.Setup(x => x.GetAll()).Returns(promotions);
            promotionRepository = promotionRepositoryMock.Object;
        }

        [TestMethod]
        public void CreatePromotionTest()
        {
            var promotionRepositoryMock = new Mock<IPromotionRepository>();          
            
            var promotionDto = new PromotionRequestDTO
            {
                Name = "Test Name",                
                Description = "Test Description",                
            };
            var promotionService = new PromotionService(promotionRepositoryMock.Object);
            promotionService.Create(promotionDto);
            promotionRepositoryMock.Verify(m => m.Create(It.IsAny<Promotion>()), Times.Once);
        }

        [TestMethod]
        public void GetAllPromotionTest()
        {
            var promotionRepositoryMock = new Mock<IPromotionRepository>();
            promotionRepositoryMock.Setup(repo => repo.GetAll())
            .Returns(new List<Promotion>
            {
                new Promotion { Id = 1, Name = "Promo 1" },
                new Promotion { Id = 2, Name = "Promo 2" },
            });
            var promotionService = new PromotionService(promotionRepositoryMock.Object);
            var promotions = promotionService.GetAll();
            Assert.IsNotNull(promotions);
            Assert.AreEqual(2, promotions.Count());
        }

        [TestMethod]
        public void GetByIdPromotionTest()
        {
            var promotionRepositoryMock = new Mock<IPromotionRepository>();
            promotionRepositoryMock.Setup(repo => repo.GetById(promotionTest.Id)).Returns(promotionTest);
            var promotionService = new PromotionService(promotionRepositoryMock.Object);
            var result = promotionService.GetById(promotionTest.Id);
            Assert.IsNotNull(result);
            Assert.AreEqual(promotionTest.Id, result.Id);
            Assert.AreEqual(promotionTest.Name, result.Name);
            promotionRepositoryMock.Verify(repo => repo.GetById(promotionTest.Id), Times.Once);
        }

        [TestMethod]
        public void GetByNamePromotionTest()
        {
            var promotionRepositoryMock = new Mock<IPromotionRepository>();
            promotionRepositoryMock.Setup(repo => repo.GetByName(promotionTest.Name)).Returns(promotionTest);
            var promotionService = new PromotionService(promotionRepositoryMock.Object);
            var result = promotionService.GetByName("Test Name");

            Assert.AreEqual(promotionTest.Id, result.Id);
            Assert.AreEqual(promotionTest.Name, result.Name);
            promotionRepositoryMock.Verify(repo => repo.GetByName(promotionTest.Name), Times.Once);
        }
    }
}


//public List<Promotion> GetAllAvailable();
//public void EnablePromotion(int promotionId);
//public void DisablePromotion(int promotionId);