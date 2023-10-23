using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Models.DTO.ProductDTOs
{
    public class ProductRequestDTO
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int Brand { get; set; }
        public int Category { get; set; }
        public List<int> Colors { get; set; }
        public int Stock { get; set; }
        public bool PromoAvailable { get; set; }


        public Product ToEntity()
        {
            return new Product()
            {
                Name = Name,
                Price = Price,
                Description = Description,
                BrandId = Brand,
                CategoryId = Category,
                Stock = Stock,
                PromoAvailable = PromoAvailable,
            };
        }
    }
}
