using ClothingStore.DataAccess.Interface;
using ClothingStore.DataAccess.Repositories;
using ClothingStore.Domain.Entities;
using ClothingStore.Service.Interface;
using Moq;

namespace ClothingStore.Service.Test
{
    [TestClass]
    public class PaymentServiceTest
    {
        private IPaymentRepository paymentRepository;
        private Payment paymentTest;

        [TestInitialize]
        public void InitTest()
        {
            var paymentRepositoryMock = new Mock<IPaymentRepository>();

            paymentTest = new Payment
            {
                Id = 1,
                Name = "Test Name"
            };

            var payments = new List<Payment>() { paymentTest };
            paymentRepositoryMock.Setup(x => x.GetAll()).Returns(payments);
            paymentRepository = paymentRepositoryMock.Object;
        }

        [TestMethod]
        public void GetAllPaymentTest()
        {
            var paymentService = new PaymentService(paymentRepository);
            var payments = paymentService.GetAll();
            Assert.AreEqual(1, payments.Count());
        }

        [TestMethod]
        public void GetByIdPaymentTest()
        {
            var paymentRepositoryMock = new Mock<IPaymentRepository>();
            var paymentService = new PaymentService(paymentRepositoryMock.Object);
            paymentRepositoryMock.Setup(repo => repo.GetById(paymentTest.Id)).Returns(paymentTest);
            var result = paymentService.GetById(paymentTest.Id);
            Assert.IsNotNull(result);
            Assert.AreEqual(paymentTest.Id, result.Id);
            Assert.AreEqual(paymentTest.Name, result.Name);
            paymentRepositoryMock.Verify(repo => repo.GetById(paymentTest.Id), Times.Once);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void GetByIdNonExistentPaymentTest()
        {
            var paymentRepositoryMock = new Mock<IPaymentRepository>();
            int nonExistentPaymentId = 12345;
            Payment nullPayment = null;
            paymentRepositoryMock.Setup(repo => repo.GetById(nonExistentPaymentId)).Returns(nullPayment);
            var paymentService = new PaymentService(paymentRepositoryMock.Object);
            var result = paymentService.GetById(nonExistentPaymentId);
            Assert.IsNull(result);
            paymentRepositoryMock.Verify(repo => repo.GetById(nonExistentPaymentId), Times.Once);
        }

        [TestMethod]
        public void GetByNamePaymentTest()
        {
            var paymentRepositoryMock = new Mock<IPaymentRepository>();
            var paymentService = new PaymentService(paymentRepositoryMock.Object);
            paymentRepositoryMock.Setup(repo => repo.GetByName("Test Name")).Returns(new Payment { Id = 1, Name = "Test Name" });
            var result = paymentService.GetByName(paymentTest.Name);
            Assert.IsNotNull(result);
            Assert.AreEqual(paymentTest.Id, result.Id);
            Assert.AreEqual(paymentTest.Name, result.Name);
            paymentRepositoryMock.Verify(repo => repo.GetByName(paymentTest.Name), Times.Once);
        }
    }
}
