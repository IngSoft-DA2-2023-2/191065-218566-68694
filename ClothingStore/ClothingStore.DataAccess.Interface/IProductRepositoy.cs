using ClothingStore.Domain.Entities;

namespace ClothingStore.DataAccess.Interface
{
    public interface IProductRepository
    {
        public void Create(Product product);
        public void Delete(int id);
        public void Update(Product product);
        public List<Product> GetAll();
        public Product GetById(int id);       
        public List<Product> GetBySearch(string? name, Category? category, Brand? brand);
        public List<Product> GetByName(string name);
        public List<Product> GetByDescription(string description);
        public List<Product> GetByBrand(Brand brand);
        public List<Product> GetByCategory(Category category);
        public void UpdateStock(List<Product> products);
        public void EnableDisablePromotion(Product product);
        public List<Product> GetByPrice(double startPrice, double endPrice);
        

    }
}