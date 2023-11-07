using ClothingStore.Domain.Entities;
using ClothingStore.Service.Interface;
using ClothingStore.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ClothingStore.Models.DTO.ProductDTOs;

namespace ClothingStoreApiTest
{
    [TestClass]
    public class ProductControllerTest
    {
        private Mock<IProductService> mock;
        private ProductController api;
        private Product testProduct;
        private Color testColor;
        private Brand testBrand;
        private Category testCategory;
        private ProductRequestDTO testProductRequestDTO;        
        private ProductUpdateDTO testProductUpdateDTO;
        private List<ProductRequestDTO> productsRequestDTO;
        private List<Product> productsResponseDTO;

        [TestInitialize]
        public void InitTest()
        {
            mock = new Mock<IProductService>(MockBehavior.Strict);
            api = new ProductController(mock.Object);
            testProductRequestDTO = new ProductRequestDTO();

            testColor = new Color()
            {
                Id = 1,
                Name = "Test Name"
            };
            testBrand = new Brand()
            {
                Id = 1,
                Name = "Test Name"
            };
            testCategory = new Category()
            {
                Id = 1,
                Name = "Test Name"
            };

            testProduct = new Product()
            {
                Id = 1,
                Name = "Test Name",
                Price = 100,
                Description = "Test Description",
                Brand = testBrand,
                Category = testCategory,
                Colors = new List<Color> { testColor },
                Stock = 10,
                PromoAvailable = true,
            };
            testProductRequestDTO = new ProductRequestDTO()
            {
                Name = "Test Name",
                Price = 100,
                Description = "Test Description",
                Brand = 1,
                Category = 1,
                Colors = new List<int> { 1 },
                Stock = 10,
                PromoAvailable= true,
            };        
            testProductUpdateDTO = new ProductUpdateDTO()
            {
                Id = 1,
                Name = "Test Name",
                Price = 100,
                Description = "Test Description",
                Brand = "Test Brand",
                Category = "Test Color",
                Colors = new List<string> { "Test Color" },
                Stock = 11,
                PromoAvailable = true,
            };
        
            productsRequestDTO = new List<ProductRequestDTO>() { testProductRequestDTO };
            //productsResponseDTO = new List<ProductResponseDTO>() { testProductResponseDTO };
        }

        [TestMethod]
        public void GetAllProductOkTest()
        {
            mock.Setup(x => x.GetAll()).Returns(productsResponseDTO);
            var result = api.GetAll();
            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;
            mock.VerifyAll();
            Assert.AreEqual(200, statusCode);
        }

        [TestMethod]
        public void GetByIdProductOkTest()
        {
            mock.Setup(x => x.GetById(It.IsAny<int>())).Returns(It.IsAny<Product>());
            var result = api.GetById(testProduct.Id);
            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;
            mock.VerifyAll();
            Assert.AreEqual(200, statusCode);
        }

        [TestMethod]
        public void PostProductOkTest()
        {
            mock.Setup(x => x.Create(It.IsAny<ProductRequestDTO>())).Verifiable();
            var result = api.Post(testProductRequestDTO);
            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;
            mock.VerifyAll();
            Assert.AreEqual(200, statusCode);
        }

        [TestMethod]
        public void DeleteProductOkTest()
        {
            mock.Setup(x => x.Delete(It.IsAny<int>())).Verifiable();
            var result = api.Delete(testProduct.Id);
            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;
            mock.VerifyAll();
            Assert.AreEqual(200, statusCode);
        }

        [TestMethod]
        public void GetByIdProductFailTest()
        {
            mock.Setup(x => x.GetById(It.IsAny<int>())).Throws(new Exception());
            var result = api.GetById(testProduct.Id);
            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;
            mock.VerifyAll();
            Assert.AreEqual(400, statusCode);
        }

        [TestMethod]
        public void PostProductBadRequestTest()
        {
            mock.Setup(x => x.Create(It.IsAny<ProductRequestDTO>())).Throws(new ArgumentException());
            var result = api.Post(It.IsAny<ProductRequestDTO>());
            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;
            mock.VerifyAll();
            Assert.AreEqual(400, statusCode);
        }

        [TestMethod]
        public void PostProductFailTest()
        {
            mock.Setup(x => x.Create(It.IsAny<ProductRequestDTO>())).Throws(new Exception());
            var result = api.Post(It.IsAny<ProductRequestDTO>());
            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;
            mock.VerifyAll();
            Assert.AreEqual(400, statusCode);
        }

        [TestMethod]
        public void DeleteProductTest()
        {
            mock.Setup(x => x.Delete(It.IsAny<int>())).Verifiable();
            var result = api.Delete(testProduct.Id);
            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;
            mock.VerifyAll();
            Assert.AreEqual(200, statusCode);
        }

        [TestMethod]
        public void DeleteProductBadRequestTest()
        {
            mock.Setup(x => x.Delete(It.IsAny<int>())).Throws(new ArgumentException());
            var result = api.Delete(It.IsAny<int>());
            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;
            mock.VerifyAll();
            Assert.AreEqual(400, statusCode);
        }

        [TestMethod]
        public void DeleteProductNotFoundTest()
        {
            mock.Setup(x => x.Delete(It.IsAny<int>())).Throws(new NullReferenceException());
            var result = api.Delete(It.IsAny<int>());
            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;
            mock.VerifyAll();
            Assert.AreEqual(400, statusCode);
        }
        
        [TestMethod]
        public void DeleteProductFailTest()
        {
            mock.Setup(x => x.Delete(It.IsAny<int>())).Throws(new Exception());
            var result = api.Delete(1);
            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;
            mock.VerifyAll();
            Assert.AreEqual(400, statusCode);
        }

        [TestMethod]
        public void PutProductOkTest()
        {
            mock.Setup(x => x.Update(It.IsAny<ProductUpdateDTO>())).Verifiable();
            var result = api.Put(testProductUpdateDTO);
            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;
            mock.VerifyAll();
            Assert.AreEqual(200, statusCode);
        }

        [TestMethod]
        public void PutProductBadRequestTest()
        {
            mock.Setup(x => x.Update(It.IsAny<ProductUpdateDTO>())).Throws(new ArgumentException());
            var result = api.Put(testProductUpdateDTO);
            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;
            mock.VerifyAll();
            Assert.AreEqual(400, statusCode);
        }

        [TestMethod]
        public void PutProductNotFoundTest()
        {
            mock.Setup(x => x.Update(It.IsAny<ProductUpdateDTO>())).Throws(new NullReferenceException());
            var result = api.Put(It.IsAny<ProductUpdateDTO>());
            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;
            mock.VerifyAll();
            Assert.AreEqual(400, statusCode);
        }

        [TestMethod]
        public void PutUserFailTest()
        {
            mock.Setup(x => x.Update(It.IsAny<ProductUpdateDTO>())).Throws(new Exception());
            var result = api.Put(It.IsAny<ProductUpdateDTO>());
            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;
            mock.VerifyAll();
            Assert.AreEqual(400, statusCode);
        }        
    }
}

//public IActionResult GetByName(string name)
//public IActionResult GetByDescription(string description)
//public IActionResult GetByBrand(string brandName)
//public IActionResult GetByCategory(string categoryName)
//public IActionResult GetBySearch(string? name, string? category, string? brand)
//public IActionResult EnableProductPromotion(int productId)
//public IActionResult DisableProductPromotion(int productId)
//public IActionResult GetByPrice(double startPrice, double endPrice)