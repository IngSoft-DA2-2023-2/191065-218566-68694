using ClothingStore.DataAccess.Interface;
using ClothingStore.DataAccess;
using ClothingStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ClothingStore.DataAccess.Repositories;

namespace ClothingStore.DataAccess.Test
{
    [TestClass]
    public class ProductRepositoryTest
    {
        private IProductRepository productRepository;
   
        private DataContext context;
        private Product testProduct;
        private Brand testBrand;
        private Category testCategory;
        private Color testColor;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: "database_name").Options;
            context = new DataContext(options);
            productRepository = new ProductRepository(context);            

            testBrand = new Brand()
            {
                Id = 1,
                Name = "Test Brand"
            };

            testCategory = new Category()
            {
                Id = 1,
                Name = "Test Category"
            };
            
            testColor = new Color()
            {
                Id = 1,
                Name = "Test Color"
            };

            testProduct = new Product()
            {
                Id = 1,
                Name = "Test Name",
                Price = 100,
                Description = "Test Description",
                Brand = testBrand,
                BrandId = 1,
                Category = testCategory,
                CategoryId = 1,
                Colors = { testColor },
                Stock = 1,
                PromoAvailable = true,
            };

            context.Products.Add(testProduct);
            context.SaveChanges();
        }

        [TestCleanup]
        public void Cleanup()
        {
            context.Database.EnsureDeleted();
        }

        [TestMethod]
        public void CreateProductTest()
        {
            var testProduct2 = new Product()
            {
                Id = 2,
                Name = "Test Name",
                Price = 100,
                Description = "Test Description",
                Brand = testBrand,
                BrandId = 1,
                Category = testCategory,
                CategoryId = 1,
                Colors = { testColor },
                Stock = 1,
                PromoAvailable = true                
            };
            productRepository.Create(testProduct2);
            context.SaveChanges();
            var result = productRepository.GetAll();
            Assert.IsTrue(new List<Product>(result).Contains(testProduct2));
        }

        [TestMethod]
        public void GetByIdProductTest()
        {
            var result = productRepository.GetById(testProduct.Id);
            Assert.IsTrue(testProduct.Equals(result));            
        }

        [TestMethod]
        public void GetByIdNotExistentProductTest()
        {
            var id = 2;
            var result = productRepository.GetById(id);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetByNameProductTest()
        {
            var result = productRepository.GetByName(testProduct.Name);
            Assert.IsTrue(((Product)result.ToArray().GetValue(0)).Name == testProduct.Name);
        }

        [TestMethod]
        public void GetAllProductTest()
        {
            List<Product> result = productRepository.GetAll();
            Assert.IsTrue(result.ToArray().Length > 0);
        }

        [TestMethod]
        public void DeleteProductTest()
        {
            var testProduct3 = new Product()
            {
                Id = 3,
                Name = "Test Name3",
                Price = 103,
                Description = "Test Description3",
                Brand = testBrand,
                Category = testCategory,
                Colors = { testColor },
                PromoAvailable = true,
            };
            productRepository.Create(testProduct3);
            context.SaveChanges();
            productRepository.Delete(testProduct3.Id);
            context.SaveChanges();
            var result = productRepository.GetAll();
            Assert.IsFalse(new List<Product>(result).Contains(testProduct3));
        }

        [TestMethod]
        public void UpdateProductTest()
        {
            testProduct.Name = "New Name";
            productRepository.Update(testProduct);
            context.SaveChanges();
            var result = productRepository.GetAll();
            Assert.IsTrue(((Product)result.ToArray().GetValue(0)).Name == testProduct.Name);
        }

        [TestMethod]
        public void GetByDescriptionProductTest()
        {
            var result = productRepository.GetByDescription(testProduct.Description);
            Assert.IsTrue(((Product)result.ToArray().GetValue(0)).Description == testProduct.Description);
        }
        //public List<Product> GetByDescription(string description);

        [TestMethod]
        public void GetByBrandProductTest()
        {
            var result = productRepository.GetByBrand(testProduct.Brand);
            Assert.IsTrue(new List<Product>(result).Contains(testProduct));
        }

        [TestMethod]
        public void GetByCategoryProductTest()
        {
            var result = productRepository.GetByCategory(testProduct.Category);
            Assert.IsTrue(new List<Product>(result).Contains(testProduct));
        }

        //public List<Product> GetBySearch(string? name, Category? category, Brand? brand);                
        //public void EnableDisablePromotion(Product product);
        //public List<Product> GetByPrice(double startPrice, double endPrice);
    }
}
