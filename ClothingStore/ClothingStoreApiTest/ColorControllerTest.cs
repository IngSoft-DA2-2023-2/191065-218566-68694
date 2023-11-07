using ClothingStore.Domain.Entities;
using ClothingStore.Service.Interface;
using ClothingStore.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ClothingStoreApiTest
{
    [TestClass]
    public class ColorControllerTest
    {
        private Mock<IColorService> mock;
        private ColorController api;
        private Color testColor;
        private List<Color> colors;

        [TestInitialize]
        public void InitTest()
        {
            mock = new Mock<IColorService>(MockBehavior.Strict);
            api = new ColorController(mock.Object);
            testColor = new Color()
            {
                Id = 1,
                Name = "Color1"
            };
            colors = new List<Color>() { testColor };
        }

        [TestMethod]
        public void GetAllColorTest()
        {
            mock.Setup(x => x.GetAll()).Returns(colors);
            var result = api.GetAll();
            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;
            mock.VerifyAll();
            Assert.AreEqual(200, statusCode);
        }

        [TestMethod]
        public void GetByIdColorTest()
        {
            mock.Setup(x => x.GetById(It.IsAny<int>())).Returns(It.IsAny<Color>());            
            var result = api.GetById(testColor.Id);
            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;
            mock.VerifyAll();
            Assert.AreEqual(200, statusCode);
        }
    }
}
