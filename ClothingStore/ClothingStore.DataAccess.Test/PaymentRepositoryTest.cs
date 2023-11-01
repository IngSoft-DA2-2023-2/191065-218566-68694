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
    public class PaymentRepositoryTest
    {
        private IPaymentRepository paymentRepository;
        private DataContext context;
        private Payment testPayment;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: "database_name").Options;
            context = new DataContext(options);
            paymentRepository = new PaymentRepository(context);
            testPayment = new Payment()
            {
                Id = 1,
                Name = "Test Name",
            };
            context.Payments.Add(testPayment);
            context.SaveChanges();
        }

        [TestCleanup]
        public void Cleanup()
        {
            context.Database.EnsureDeleted();
        }

        [TestMethod]
        public void GetAllPaymentTest()
        {
            List<Payment> result = paymentRepository.GetAll();
            Assert.IsTrue(result.ToArray().Length > 0);
        }

        [TestMethod]
        public void GetByIdPaymentTest()
        {
            var result = paymentRepository.GetById(testPayment.Id);
            Assert.IsTrue(testPayment.Equals(result));
        }

        [TestMethod]
        public void GetByIdNotExistsPaymentTest()
        {
            var id = 2;
            var result = paymentRepository.GetById(id);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetByNamePaymentTest()
        {
            var result = paymentRepository.GetByName(testPayment.Name);
            Assert.IsTrue(testPayment.Equals(result));
        }

        [TestMethod]
        public void GetByNameNotExistsPaymentTest()
        {
            var name = "Test name 2";
            var result = paymentRepository.GetByName(name);
            Assert.IsNull(result);
        }
    }
}
