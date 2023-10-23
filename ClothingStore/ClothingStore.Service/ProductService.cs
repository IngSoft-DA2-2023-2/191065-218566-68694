using ClothingStore.DataAccess.Interface;
using ClothingStore.DataAccess.Repositories;
using ClothingStore.Domain.Entities;
using ClothingStore.Models.DTO.ProductDTOs;
using ClothingStore.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace ClothingStore.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IColorRepository _colorRepository;

        public ProductService(IProductRepository productRepository, IColorRepository colorRepository,ICategoryRepository categoryRepository  ,IBrandRepository brandRepository)
        {
            _productRepository = productRepository;
            _colorRepository = colorRepository;
            _categoryRepository = categoryRepository;
            _brandRepository = brandRepository;
        }

        public void Create(ProductRequestDTO productRequestDTO)
        {
            var category = _categoryRepository.GetById(productRequestDTO.Category);
            var brand = _brandRepository.GetById(productRequestDTO.Brand);

            if (category == null)
            {
                throw new ArgumentException($"La categoría ingresada no es válida.");
            }
            else if (brand == null)
            {
                throw new ArgumentException($"La marca ingresada no es válida.");
            }
            else 
            {
                var product = productRequestDTO.ToEntity();
                foreach (var colorId in productRequestDTO.Colors)
                {
                    var existingColor = _colorRepository.GetById(colorId);
                    if (existingColor != null)
                    {
                        product.Colors.Add(existingColor);
                    }                        
                }
                _productRepository.Create(product);
            }
        }

        public void Update(ProductUpdateDTO productDto)
        {
            var existingProduct = _productRepository.GetById(productDto.Id);
            if (existingProduct == null)
            {
                throw new ArgumentException($"No se puede actualizar el producto con ID {productDto.Id} porque no existe.");
            }
            else
            {
                existingProduct.Name = productDto.Name;
                existingProduct.Description = productDto.Description;
                existingProduct.Price = productDto.Price;
                var categoryUpdate = _categoryRepository.GetByName(productDto.Category);
                if (categoryUpdate != null)
                {
                    existingProduct.Category =categoryUpdate;
                }
                var brandUpdate = _brandRepository.GetByName(productDto.Brand);
                if (brandUpdate != null)
                {
                    existingProduct.Brand =brandUpdate;
                }
                existingProduct.Stock = productDto.Stock;
                existingProduct.PromoAvailable = productDto.PromoAvailable;
                _productRepository.Update(existingProduct);
            }        
        }

        public void Delete(int id)
        {
            var existingProduct = _productRepository.GetById(id);
            if (existingProduct == null)
            {
                throw new ArgumentException($"No se puede eliminar el producto con ID {id} porque no existe.");
            }
            _productRepository.Delete(id);
        }

        public List<Product> GetAll()
        {
            List<Product> products = _productRepository.GetAll();
            return products;
        }
        
        public List<Product> GetByBrand(string brandName)
        {
            var brand = _brandRepository.GetByName(brandName);
            if (brand == null)
            {
                throw new ArgumentException($"La marca ingresada no es válida.");
            }
            else
            {
                return _productRepository.GetByBrand(brand);
            }            
        }       

        public List<Product> GetByCategory(string categoryName)
        {
            var category = _categoryRepository.GetByName(categoryName);
            if (category == null)
            {
                throw new ArgumentException($"La categoría ingresada no es válida.");
            }
            else
            {
                return _productRepository.GetByCategory(category);
            }
        }

        public List<Product> GetByDescription(string description)
        {
            return _productRepository.GetByDescription(description);
        }

        public Product GetById(int id)
        {
            Product product = _productRepository.GetById(id);
            if (product == null)
            {
                throw new ArgumentException($"No se puede obtener el product con ID {product.Id}.");
            }                        
            return product;
        }

        public List<Product> GetByName(string name)
        {
            return _productRepository.GetByName(name);
        }       

        public List<Product> GetBySearch(string? name, string? categoryName, string? brandName)
        {
            var brand = _brandRepository.GetByName(brandName);
            var category = _categoryRepository.GetByName(categoryName); 
            return _productRepository.GetBySearch(name, category, brand);
        }

        public void EnableProductPromotion(int productId)
        {
            var product = _productRepository.GetById(productId);
            if (product == null)
            {
                throw new ArgumentException($"No se puede obtener el producto.");
            }
            product.PromoAvailable = true;
            _productRepository.EnableDisablePromotion(product);
        }

        public void DisableProductPromotion(int productId)
        {
            var product = _productRepository.GetById(productId);
            if (product == null)
            {
                throw new ArgumentException($"No se puede obtener el producto.");
            }
            product.PromoAvailable = false;
            _productRepository.EnableDisablePromotion(product);
        }

        public List<Product> GetByPrice(double startPrice, double endPrice)
        {
            return _productRepository.GetByPrice(startPrice, endPrice);
        }
    }
}
