using ClothingStore.DataAccess.Interface;
using ClothingStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace ClothingStore.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private DbContext _dbContext;
        private readonly DbSet<Product> products;

        public ProductRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            products = _dbContext.Set<Product>();
        }

        public void Create(Product product)
        {
            products.Add(product);
            _dbContext.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return products.ToList();
        }

        public Product GetById(int id)
        {            
            var productFull = products.Where(p => p.Id == id).Include(p => p.Colors).FirstOrDefault();
            return productFull;
        }

        public void Delete(int id)
        {
            Product productToDelete = products.Where(x => x.Id == id).FirstOrDefault();
            products.Remove(productToDelete);
            _dbContext.SaveChanges();
        }

        public void Update(Product product)
        {
            var existingProduct = products.FirstOrDefault(u => u.Id == product.Id);
            if (existingProduct != null)
            {
                _dbContext.Entry(existingProduct).CurrentValues.SetValues(product);
                _dbContext.SaveChanges();
            }
        }

        public List<Product> GetBySearch(string? name, Category? category, Brand? brand)
        {            
            return products.Where(p => (p.Name.Contains(name)) || (p.Category == category) || (p.Brand == brand)).ToList();            
        }

        public List<Product> GetByName(string name)
        {
            return products.Where(p => p.Name.Contains(name)).ToList();
        }

        public List<Product> GetByDescription(string description)
        {
            return products.Where(p => p.Name.Contains(description)).ToList();
        }

        public List<Product> GetByBrand(Brand brand)
        {
            return products.Where(p => p.Brand == brand).ToList();
        }

        public List<Product> GetByCategory(Category category)
        {
            return products.Where(p => p.Category == category).ToList();
        }

        public void UpdateStock(List<Product> productsCart)
        {
            foreach (var product in productsCart)
            {
                product.Stock--;
                var existingProduct = products.FirstOrDefault(u => u.Id == product.Id);
                _dbContext.Entry(existingProduct).CurrentValues.SetValues(product);
                _dbContext.SaveChanges();
            }
        }
        public void EnableDisablePromotion(Product product)
        {
            var existingProduct = products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                _dbContext.Entry(existingProduct).CurrentValues.SetValues(product);
                _dbContext.SaveChanges();
            }
        }

        public List<Product> GetByPrice(double startPrice, double endPrice)
        {
            if (endPrice < startPrice)
            {
                double aux = startPrice;                
                startPrice = endPrice;
                endPrice = aux;
            }
            return products.Where(p => p.Price >= startPrice && p.Price <= endPrice).ToList();
        }
    }
}
