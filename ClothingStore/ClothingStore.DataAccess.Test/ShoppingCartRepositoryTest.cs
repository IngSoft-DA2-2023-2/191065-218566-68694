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
    public class ShoppingCartRepositoryTest
    {
        private IShoppingCartRepository scRepository;
        private DataContext context;
        private ShoppingCart testCart;
        private Product testProduct;
        private Category testCategory;
        private Brand testBrand;
        private Color testColor;
        private User testUser;
        private Role testRole;


        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: "database_name").Options;
            context = new DataContext(options);
            scRepository = new ShoppingCartRepository(context);
            testCategory = new Category()
            {
                Id = 1,
                Name = "Test Category",
            };
            testBrand = new Brand()
            {
                Id = 1,
                Name = "Test Brand",
            };
            testColor = new Color()
            {
                Id = 1,
                Name = "Test Color",
            };
            testProduct = new Product()
            {   
                Id = 1,
                Name = "Test Product",
                Price = 100,
                Description = "Test Description",
                Brand = testBrand,
                Category = testCategory,
                Colors = new List<Color> { testColor },          
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

        //public void Create(ShoppingCart shoppingCart);
        //public List<ShoppingCart> GetAll();
        //public ShoppingCart GetById(int id);
        //public void Update(ShoppingCart shoppingCart);
        //public List<ShoppingCart> GetSales();
        //public List<ShoppingCart> GetSalesByUserId(int userId);
    }
}
