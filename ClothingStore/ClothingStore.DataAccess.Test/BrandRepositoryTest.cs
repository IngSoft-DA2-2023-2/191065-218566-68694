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
    public class BrandRepositoryTest
    {
        private IBrandRepository brandRepository;
        private DataContext context;
        private Brand testBrand;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: "database_name").Options;
            context = new DataContext(options);
            brandRepository = new BrandRepository(context);
            testBrand = new Brand()
            {
                Id = 1,
                Name = "Test Name",
            };
            context.Brands.Add(testBrand);
            context.SaveChanges();
        }

        [TestCleanup]
        public void Cleanup()
        {
            context.Database.EnsureDeleted();
        }

        [TestMethod]
        public void GetAllBrandTest()
        {
            List<Brand> result = brandRepository.GetAll();
            Assert.IsTrue(result.ToArray().Length > 0);
        }

        [TestMethod]
        public void GetByIdBrandTest()
        {
            var result = brandRepository.GetById(testBrand.Id);
            Assert.IsTrue(testBrand.Equals(result));
        }

        [TestMethod]
        public void GetByIdNotExistsBrandTest()
        {
            var id = 2;
            var result = brandRepository.GetById(id);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetByNameBrandTest()
        {
            var result = brandRepository.GetByName(testBrand.Name);
            Assert.IsTrue(testBrand.Equals(result));
        }

        [TestMethod]
        public void GetByNameNotExistsBrandTest()
        {
            var name = "Test name 2";
            var result = brandRepository.GetByName(name);
            Assert.IsNull(result);
        }
    }
}
