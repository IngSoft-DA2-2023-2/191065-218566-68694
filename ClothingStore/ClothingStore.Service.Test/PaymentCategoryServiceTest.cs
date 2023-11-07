using ClothingStore.DataAccess.Interface;
using ClothingStore.DataAccess.Repositories;
using ClothingStore.Domain.Entities;
using ClothingStore.Service.Interface;
using Moq;

namespace ClothingStore.Service.Test
{
    [TestClass]
    public class PaymentCategoryServiceTest
    {
        private IPaymentCategoryRepository paymentCategoryRepository;
        private PaymentCategory paymentCategoryTest;

        [TestInitialize]
        public void InitTest()
        {
            var paymentCategoryRepositoryMock = new Mock<IPaymentCategoryRepository>();

            paymentCategoryTest = new PaymentCategory
            {
                Id = 1,
                Name = "Test Name"
            };

            var paymentCategories = new List<PaymentCategory>() { paymentCategoryTest };
            paymentCategoryRepositoryMock.Setup(x => x.GetAll()).Returns(paymentCategories);
            paymentCategoryRepository = paymentCategoryRepositoryMock.Object;
        }

        [TestMethod]
        public void GetAllPaymentCategoryTest()
        {
            var paymentCategoryService = new PaymentCategoryService(paymentCategoryRepository);
            var paymentCategories = paymentCategoryService.GetAll();
            Assert.AreEqual(1, paymentCategories.Count());
        }

        [TestMethod]
        public void GetByIdPaymentCategoryTest()
        {
            var paymentCategoryRepositoryMock = new Mock<IPaymentCategoryRepository>();
            var paymentCategoryService = new PaymentCategoryService(paymentCategoryRepositoryMock.Object);
            paymentCategoryRepositoryMock.Setup(repo => repo.GetById(paymentCategoryTest.Id)).Returns(paymentCategoryTest);
            var result = paymentCategoryService.GetById(paymentCategoryTest.Id);
            Assert.IsNotNull(result);
            Assert.AreEqual(paymentCategoryTest.Id, result.Id);
            Assert.AreEqual(paymentCategoryTest.Name, result.Name);
            paymentCategoryRepositoryMock.Verify(repo => repo.GetById(paymentCategoryTest.Id), Times.Once);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void GetByIdNonExistentPaymentCategoryTest()
        {
            var paymentCategoryRepositoryMock = new Mock<IPaymentCategoryRepository>();
            int nonExistentPaymentCategoryId = 12345;
            PaymentCategory nullPaymentCategory = null;
            paymentCategoryRepositoryMock.Setup(repo => repo.GetById(nonExistentPaymentCategoryId)).Returns(nullPaymentCategory);
            var paymentCategoryService = new PaymentCategoryService(paymentCategoryRepositoryMock.Object);
            var result = paymentCategoryService.GetById(nonExistentPaymentCategoryId);
            Assert.IsNull(result);
            paymentCategoryRepositoryMock.Verify(repo => repo.GetById(nonExistentPaymentCategoryId), Times.Once);
        }

        [TestMethod]
        public void GetByNamePaymentCategoryTest()
        {
            var paymentCategoryRepositoryMock = new Mock<IPaymentCategoryRepository>();
            var paymentCategoryService = new PaymentCategoryService(paymentCategoryRepositoryMock.Object);
            paymentCategoryRepositoryMock.Setup(repo => repo.GetByName("Test Name")).Returns(new PaymentCategory { Id = 1, Name = "Test Name" });
            var result = paymentCategoryService.GetByName(paymentCategoryTest.Name);
            Assert.IsNotNull(result);
            Assert.AreEqual(paymentCategoryTest.Id, result.Id);
            Assert.AreEqual(paymentCategoryTest.Name, result.Name);
            paymentCategoryRepositoryMock.Verify(repo => repo.GetByName(paymentCategoryTest.Name), Times.Once);
        }

    }
}
