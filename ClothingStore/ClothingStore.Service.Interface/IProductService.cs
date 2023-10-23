using ClothingStore.Domain.Entities;
using ClothingStore.Models.DTO.ProductDTOs;

namespace ClothingStore.Service.Interface
{
    public interface IProductService
    {
        public void Create(ProductRequestDTO productRequestDTO);
        public void Delete(int id);
        public void Update(ProductUpdateDTO productDto);
        public List<Product> GetAll();
        public Product GetById(int id);
        public List<Product> GetBySearch(string? name, string? category, string? brand);
        public List<Product> GetByName(string name);
        public List<Product> GetByDescription(string description);
        public List<Product> GetByBrand(string brandName);
        public List<Product> GetByCategory(string catgoryName);
        public void EnableProductPromotion(int productId);
        public void DisableProductPromotion(int productId);
        public List<Product> GetByPrice(double startPrice, double endPrice);

    }
}