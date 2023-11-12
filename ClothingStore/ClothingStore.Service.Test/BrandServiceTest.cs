using ClothingStore.DataAccess.Interface;
using ClothingStore.Domain.Entities;
using Moq;

namespace ClothingStore.Service.Test
{
    [TestClass]
    public class BrandServiceTest
    {
       /* private IBrandRepository brandRepository;
        private Brand brandTest;        

        [TestInitialize]
        public void InitTest()
        {
            var brandRepositoryMock = new Mock<IBrandRepository>();            

            brandTest = new Brand
            {
                Id = 1,
                Name = "Test Name"
            };

            var brands = new List<Brand>() { brandTest };
            brandRepositoryMock.Setup(x => x.GetAll()).Returns(brands);
            brandRepository = brandRepositoryMock.Object;
        }

        [TestMethod]
        public void GetAllBrandTest()
        {
            var brandService = new BrandService(brandRepository);
            var brands = brandService.GetAll();
            Assert.AreEqual(1, brands.Count());
        }

        [TestMethod]
        public void GetByIdBrandTest()
        {
            var brandRepositoryMock = new Mock<IBrandRepository>();
            var brandService = new BrandService(brandRepositoryMock.Object);
            brandRepositoryMock.Setup(repo => repo.GetById(brandTest.Id)).Returns(brandTest);
            var result = brandService.GetById(brandTest.Id);
            Assert.IsNotNull(result);
            Assert.AreEqual(brandTest.Id, result.Id);
            Assert.AreEqual(brandTest.Name, result.Name);
            brandRepositoryMock.Verify(repo => repo.GetById(brandTest.Id), Times.Once);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void GetByIdNonExistentBrandTest()
        {           
            var brandRepositoryMock = new Mock<IBrandRepository>();          
            int nonExistentBrandId = 12345;
            Brand nullBrand = null;
            brandRepositoryMock.Setup(repo => repo.GetById(nonExistentBrandId)).Returns(nullBrand);            
            var brandService = new BrandService(brandRepositoryMock.Object);
            var result = brandService.GetById(nonExistentBrandId);
            Assert.IsNull(result);
            brandRepositoryMock.Verify(repo => repo.GetById(nonExistentBrandId), Times.Once);            
        }

        [TestMethod]
        public void GetByNameBrandTest()
        {
            var brandRepositoryMock = new Mock<IBrandRepository>();
            var brandService = new BrandService(brandRepositoryMock.Object);
            brandRepositoryMock.Setup(repo => repo.GetByName("Test Name")).Returns(new Brand { Id = 1, Name = "Test Name" });
            var result = brandService.GetByName(brandTest.Name);
            Assert.IsNotNull(result);
            Assert.AreEqual(brandTest.Id, result.Id);
            Assert.AreEqual(brandTest.Name, result.Name);
            brandRepositoryMock.Verify(repo => repo.GetByName(brandTest.Name), Times.Once);
        }*/


    }
}