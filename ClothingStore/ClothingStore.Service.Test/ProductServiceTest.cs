using ClothingStore.DataAccess.Interface;
using ClothingStore.DataAccess.Repositories;
using ClothingStore.Domain.Entities;
using ClothingStore.Models.DTO.ProductDTOs;
using ClothingStore.Service.Interface;
using Moq;

namespace ClothingStore.Service.Test
{
    [TestClass]
    public class ProductServiceTest
    {
        private IProductRepository productRepository;
        private IBrandRepository brandRepository;
        private ICategoryRepository categoryRepository;
        private IColorRepository colorRepository;        
        private Product productTest;
        private Category categoryTest;
        private Brand brandTest;
        private Color colorTest;

        [TestInitialize]
        public void InitTest()
        {
            var productRepositoryMock = new Mock<IProductRepository>();
      
            brandTest = new Brand
            {
                Id = 1,
                Name = "Test Name"
            };
            categoryTest = new Category
            {
                Id = 1,
                Name = "Test Name"
            };
            colorTest = new Color
            {
                Id = 1,
                Name = "Test Name"
            };

            productTest = new Product
            {
                Id = 1,
                Name = "Test Product",
                Price = 100,
                Description = "Test Description",
                Brand = brandTest,
                Category = categoryTest,
                Colors = new List<Color> { colorTest },
                Stock = 10,
                PromoAvailable = true
            };
            var products = new List<Product>() { productTest };
            productRepositoryMock.Setup(x => x.GetAll()).Returns(products);            
            productRepository = productRepositoryMock.Object;
        }

        [TestMethod]
        public void CreateProductTest()
        {
            var productRepositoryMock = new Mock<IProductRepository>();
            var categoryRepositoryMock = new Mock<ICategoryRepository>();
            var brandRepositoryMock = new Mock<IBrandRepository>();
            var colorRepositoryMock = new Mock<IColorRepository>();
            categoryRepositoryMock.Setup(repo => repo.GetById(1)).Returns(new Category());
            brandRepositoryMock.Setup(repo => repo.GetById(1)).Returns(new Brand());            
            colorRepositoryMock.Setup(repo => repo.GetNonExistentColors(It.IsAny<List<string>>())).Returns(new List<string>());
            var productDto = new ProductRequestDTO
            {
                Name = "Test Name",
                Price = 100,
                Description = "Test Description",
                Brand = 1,
                Category = 1,
                Colors = new List<int> { 1 },
                Stock = 10,
                PromoAvailable = true
            };            
            var productService = new ProductService(productRepositoryMock.Object, colorRepositoryMock.Object, categoryRepositoryMock.Object, brandRepositoryMock.Object);
            productService.Create(productDto);            
            productRepositoryMock.Verify(m => m.Create(It.IsAny<Product>()), Times.Once);
        }

        [TestMethod]
        public void GetAllProductTest()
        {            
            var productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock.Setup(repo => repo.GetAll())
            .Returns(new List<Product>
            {
                new Product { Id = 1, Name = "Product 1" },
                new Product { Id = 2, Name = "Product 2" },
            });
            var productService = new ProductService(productRepositoryMock.Object, null, null, null);
            var products = productService.GetAll();
            Assert.IsNotNull(products);
            Assert.AreEqual(2, products.Count());
        }

        [TestMethod]
        public void GetByIdProductTest()
        {
            var productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock.Setup(repo => repo.GetById(productTest.Id)).Returns(productTest);            
            var productService = new ProductService(productRepositoryMock.Object, null, null, null);
            var result = productService.GetById(productTest.Id);
            Assert.IsNotNull(result);
            Assert.AreEqual(productTest.Id, result.Id);
            Assert.AreEqual(productTest.Name, result.Name);
            productRepositoryMock.Verify(repo => repo.GetById(productTest.Id), Times.Once);            
        }

        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void GetByIdNonExistentProductTest()
        {            
            var productRepositoryMock = new Mock<IProductRepository>();
            int nonExistentProductId = 12345;
            Product nullProduct = null;            

            productRepositoryMock.Setup(repo => repo.GetById(nonExistentProductId)).Returns(nullProduct);            
            var productService = new ProductService(productRepositoryMock.Object, null, null, null);
            var result = productService.GetById(nonExistentProductId);
            Assert.IsNull(result);
            productRepositoryMock.Verify(repo => repo.GetById(nonExistentProductId), Times.Once);            
        }

        [TestMethod]
        public void GetByNameProductTest()
        {
            var productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock.Setup(repo => repo.GetByName("Test Product"))
            .Returns(new List<Product>
            {
                new Product { Id = 1, Name = "Test Product" }
            });
            var productService = new ProductService(productRepositoryMock.Object, null, null, null);
            var products = productService.GetByName("Test Product");

            Assert.IsNotNull(products);
            Assert.AreEqual(productTest.Id, products.FirstOrDefault().Id);
            Assert.AreEqual(productTest.Name, products.First().Name);
        }

        [TestMethod]
        public void GetByDescriptionProductTest()
        {
            var productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock.Setup(repo => repo.GetByDescription("Test Description"))
            .Returns(new List<Product>
            {
                new Product { Id = 1, Description = "Test Description" }
            });
            var productService = new ProductService(productRepositoryMock.Object, null, null, null);
            var products = productService.GetByDescription("Test Description");

            Assert.IsNotNull(products);
            Assert.AreEqual(productTest.Id, products.FirstOrDefault().Id);
            Assert.AreEqual(productTest.Description, products.First().Description);
        }

        [TestMethod]
        public void GetByBrandProductTest()
        {           
            var productRepositoryMock = new Mock<IProductRepository>();            
            productRepositoryMock.Setup(repo => repo.GetByBrand(brandTest))
            .Returns(new List<Product>
            {
                new Product { Id = 1, Brand = brandTest }
            });
            var brandRepositoryMock = new Mock<IBrandRepository>();
            brandRepositoryMock.Setup(repo => repo.GetByName("Test Name")).Returns(brandTest);

            var productService = new ProductService(productRepositoryMock.Object, null, null, brandRepositoryMock.Object);
            var products = productService.GetByBrand("Test Name");

            Assert.IsNotNull(products);
            Assert.AreEqual(productTest.Id, products.FirstOrDefault().Id);
            Assert.AreEqual(productTest.Brand, products.First().Brand);
        }

        [TestMethod]
        public void GetByCategoryProductTest()
        {
            var productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock.Setup(repo => repo.GetByCategory(categoryTest))
            .Returns(new List<Product>
            {
                new Product { Id = 1, Category = categoryTest }
            });
            var categoryRepositoryMock = new Mock<ICategoryRepository>();
            categoryRepositoryMock.Setup(repo => repo.GetByName("Test Name")).Returns(categoryTest);
            var productService = new ProductService(productRepositoryMock.Object, null, categoryRepositoryMock.Object, null);
            var products = productService.GetByCategory("Test Name");

            Assert.IsNotNull(products);
            Assert.AreEqual(productTest.Id, products.FirstOrDefault().Id);
            Assert.AreEqual(productTest.Category, products.First().Category);
        }

        [TestMethod]
        public void DeleteProductTest()
        {            
            var productRepositoryMock = new Mock<IProductRepository>();
            int productId = 1;
            productRepositoryMock.Setup(x => x.GetById(productId)).Returns(new Product());
            var productService = new ProductService(productRepositoryMock.Object, null, null, null);
            productService.Delete(productId);
            productRepositoryMock.Verify(x => x.GetById(productId), Times.Once);
            productRepositoryMock.Verify(x => x.Delete(productId), Times.Once);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void DeleteNonExistentProductTest()
        {            
            var productRepositoryMock = new Mock<IProductRepository>();
            int productId = 999;
            productRepositoryMock.Setup(x => x.Delete(productId)).Throws(new ArgumentException());
            var productService = new ProductService(productRepositoryMock.Object, null, null, null);
            productService.Delete(productId);
            productRepositoryMock.Verify(x => x.Delete(productId), Times.Once);
        }

        [TestMethod]
        public void UpdateProductTest()
        {
            var productRepositoryMock = new Mock<IProductRepository>();
            var categoryRepositoryMock = new Mock<ICategoryRepository>();
            var brandRepositoryMock = new Mock<IBrandRepository>();
            var colorRepositoryMock = new Mock<IColorRepository>();

            int productId = 1;
            var productService = new ProductService(productRepositoryMock.Object, colorRepositoryMock.Object, categoryRepositoryMock.Object, brandRepositoryMock.Object);            
            var existingProduct = new Product
            {
                Id = productId,
                Name = "Test Product",
                Price = 100,
                Description = "Test Description",
                Brand = brandTest,
                Category = categoryTest,
                Colors = new List<Color> { colorTest },
                Stock = 10,
                PromoAvailable = true
            };               
            
            var updatedProduct = new ProductUpdateDTO 
            {
                Id = productId,
                Name = "Test Change",
                Price = 101,
                Description = "Test Change",
                Brand = "Test Change",
                Category = "Test Change",
                Colors = new List<String> { "Test Change" },
                Stock=11,
                PromoAvailable = false
            };
            productRepositoryMock.Setup(x => x.GetById(productId)).Returns(existingProduct);
            productService.Update(updatedProduct);
            productRepositoryMock.Verify(x => x.GetById(productId), Times.Once);
            productRepositoryMock.Verify(x => x.Update(It.IsAny<Product>()), Times.Once);
        }
        //public void Update(ProductUpdateDTO productDto);

        //public List<Product> GetBySearch(string? name, string? category, string? brand);


        //public void EnableProductPromotion(int productId);
        //public void DisableProductPromotion(int productId);
        //public List<Product> GetByPrice(double startPrice, double endPrice);

    }
}
