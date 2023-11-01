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
    public class PaymentCategoryRepositoryTest
    {
        private IPaymentCategoryRepository paymentCategoryRepository;
        private DataContext context;
        private PaymentCategory testPaymentCategory;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: "database_name").Options;
            context = new DataContext(options);
            paymentCategoryRepository = new PaymentCategoryRepository(context);
            testPaymentCategory = new PaymentCategory()
            {
                Id = 1,
                Name = "Test Name",
            };
            context.PaymentCategories.Add(testPaymentCategory);
            context.SaveChanges();
        }

        [TestCleanup]
        public void Cleanup()
        {
            context.Database.EnsureDeleted();
        }

        [TestMethod]
        public void GetAllPaymentCategoryTest()
        {
            List<PaymentCategory> result = paymentCategoryRepository.GetAll();
            Assert.IsTrue(result.ToArray().Length > 0);
        }

        [TestMethod]
        public void GetByIdPaymentCategoryTest()
        {
            var result = paymentCategoryRepository.GetById(testPaymentCategory.Id);
            Assert.IsTrue(testPaymentCategory.Equals(result));
        }

        [TestMethod]
        public void GetByIdNotExistsPaymentCategoryTest()
        {
            var id = 2;
            var result = paymentCategoryRepository.GetById(id);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetByNamePaymentCategoryTest()
        {
            var result = paymentCategoryRepository.GetByName(testPaymentCategory.Name);
            Assert.IsTrue(testPaymentCategory.Equals(result));
        }

        [TestMethod]
        public void GetByNameNotExistsPaymentCategoryTest()
        {
            var name = "Test name 2";
            var result = paymentCategoryRepository.GetByName(name);
            Assert.IsNull(result);
        }
    }
}
