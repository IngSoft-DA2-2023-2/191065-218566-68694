using ClothingStore.DataAccess.Interface;
using ClothingStore.DataAccess.Repositories;
using ClothingStore.Domain.Entities;
using Moq;

namespace ClothingStore.Service.Test
{
    [TestClass]
    public class CategoryServiceTest
    {
       /* private ICategoryRepository categoryRepository;
        private Category categoryTest;

        [TestInitialize]
        public void InitTest()
        {
            var categoryRepositoryMock = new Mock<ICategoryRepository>();

            categoryTest = new Category
            {
                Id = 1,
                Name = "Test Name"
            };

            var categories = new List<Category>() { categoryTest };
            categoryRepositoryMock.Setup(x => x.GetAll()).Returns(categories);
            categoryRepository = categoryRepositoryMock.Object;
        }

        [TestMethod]
        public void GetAllCategoryTest()
        {
            var categoryService = new CategoryService(categoryRepository);
            var categories = categoryService.GetAll();
            Assert.AreEqual(1, categories.Count());
        }

        [TestMethod]
        public void GetByIdCategoryTest()
        {
            var categoryRepositoryMock = new Mock<ICategoryRepository>();
            var categoryService = new CategoryService(categoryRepositoryMock.Object);
            categoryRepositoryMock.Setup(repo => repo.GetById(categoryTest.Id)).Returns(categoryTest);
            var result = categoryService.GetById(categoryTest.Id);
            Assert.IsNotNull(result);
            Assert.AreEqual(categoryTest.Id, result.Id);
            Assert.AreEqual(categoryTest.Name, result.Name);
            categoryRepositoryMock.Verify(repo => repo.GetById(categoryTest.Id), Times.Once);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void GetByIdNonExistentCategoryTest()
        {
            var categoryRepositoryMock = new Mock<ICategoryRepository>();
            int nonExistentCategoryId = 12345;
            Category nullCategory = null;
            categoryRepositoryMock.Setup(repo => repo.GetById(nonExistentCategoryId)).Returns(nullCategory);
            var categoryService = new CategoryService(categoryRepositoryMock.Object);
            var result = categoryService.GetById(nonExistentCategoryId);
            Assert.IsNull(result);
            categoryRepositoryMock.Verify(repo => repo.GetById(nonExistentCategoryId), Times.Once);
        }

        [TestMethod]
        public void GetByNameCategoryTest()
        {
            var categoryRepositoryMock = new Mock<ICategoryRepository>();
            var categoryService = new CategoryService(categoryRepositoryMock.Object);
            categoryRepositoryMock.Setup(repo => repo.GetByName("Test Name")).Returns(new Category { Id = 1, Name = "Test Name" });
            var result = categoryService.GetByName(categoryTest.Name);
            Assert.IsNotNull(result);
            Assert.AreEqual(categoryTest.Id, result.Id);
            Assert.AreEqual(categoryTest.Name, result.Name);
            categoryRepositoryMock.Verify(repo => repo.GetByName(categoryTest.Name), Times.Once);
        }*/
    }
}
