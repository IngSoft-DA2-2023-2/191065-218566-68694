using ClothingStore.DataAccess.Interface;
using ClothingStore.DataAccess.Repositories;
using ClothingStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.DataAccess.Test
{
    [TestClass]
    public class CategoryRepositoryTest
    {
        private ICategoryRepository categoryRepository;
        private DataContext context;
        private Category testCategory;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: "database_name").Options;
            context = new DataContext(options);
            categoryRepository = new CategoryRepository(context);
            testCategory = new Category()
            {
                Id = 1,
                Name = "Test Name",
            };
            context.Categories.Add(testCategory);
            context.SaveChanges();
        }

        [TestCleanup]
        public void Cleanup()
        {
            context.Database.EnsureDeleted();
        }

        [TestMethod]
        public void GetAllCategoryTest()
        {
            List<Category> result = categoryRepository.GetAll();
            Assert.IsTrue(result.ToArray().Length > 0);
        }

        [TestMethod]
        public void GetByIdCategoryTest()
        {
            var result = categoryRepository.GetById(testCategory.Id);
            Assert.IsTrue(testCategory.Equals(result));
        }

        [TestMethod]
        public void GetByIdNotExistsCategoryTest()
        {
            var id = 2;
            var result = categoryRepository.GetById(id);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetByNameCategoryTest()
        {
            var result = categoryRepository.GetByName(testCategory.Name);
            Assert.IsTrue(testCategory.Equals(result));
        }

        [TestMethod]
        public void GetByNameNotExistsCategoryTest()
        {
            var name = "Test name 2";
            var result = categoryRepository.GetByName(name);
            Assert.IsNull(result);
        }      
    }
}
