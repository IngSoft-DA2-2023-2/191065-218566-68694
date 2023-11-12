using ClothingStore.DataAccess.Interface;
using ClothingStore.DataAccess.Repositories;
using ClothingStore.Domain.Entities;
using Moq;


namespace ClothingStore.Service.Test
{
    [TestClass]
    public class ColorServiceTest
    {
       /* private IColorRepository colorRepository;
        private Color colorTest;

        [TestInitialize]
        public void InitTest()
        {
            var colorRepositoryMock = new Mock<IColorRepository>();

            colorTest = new Color
            {
                Id = 1,
                Name = "Test Name"
            };

            var colors = new List<Color>() { colorTest };
            colorRepositoryMock.Setup(x => x.GetAll()).Returns(colors);
            colorRepository = colorRepositoryMock.Object;
        }

        [TestMethod]
        public void GetAllColorTest()
        {
            var colorService = new ColorService(colorRepository);
            var colors = colorService.GetAll();
            Assert.AreEqual(1, colors.Count());
        }

        [TestMethod]
        public void GetByIdColorTest()
        {
            var colorRepositoryMock = new Mock<IColorRepository>();
            var colorService = new ColorService(colorRepositoryMock.Object);
            colorRepositoryMock.Setup(repo => repo.GetById(colorTest.Id)).Returns(colorTest);
            var result = colorService.GetById(colorTest.Id);
            Assert.IsNotNull(result);
            Assert.AreEqual(colorTest.Id, result.Id);
            Assert.AreEqual(colorTest.Name, result.Name);
            colorRepositoryMock.Verify(repo => repo.GetById(colorTest.Id), Times.Once);
        }

        //[ExpectedException(typeof(ArgumentException))]        
        [TestMethod]
        public void GetByIdNonExistentColorTest()
        {
            var colorRepositoryMock = new Mock<IColorRepository>();
            int nonExistentColorId = 12345;
            Color nullColor = null;
            colorRepositoryMock.Setup(repo => repo.GetById(nonExistentColorId)).Returns(nullColor);
            var colorService = new ColorService(colorRepositoryMock.Object);
            var result = colorService.GetById(nonExistentColorId);
            Assert.IsNull(result);
            colorRepositoryMock.Verify(repo => repo.GetById(nonExistentColorId), Times.Once);
        }

        [TestMethod]
        public void GetByNameColorTest()
        {
            var colorRepositoryMock = new Mock<IColorRepository>();
            var colorService = new ColorService(colorRepositoryMock.Object);
            colorRepositoryMock.Setup(repo => repo.GetByName("Test Name")).Returns(new Color { Id = 1, Name = "Test Name" });
            var result = colorService.GetByName(colorTest.Name);
            Assert.IsNotNull(result);
            Assert.AreEqual(colorTest.Id, result.Id);
            Assert.AreEqual(colorTest.Name, result.Name);
            colorRepositoryMock.Verify(repo => repo.GetByName(colorTest.Name), Times.Once);
        }*/

    }
}
