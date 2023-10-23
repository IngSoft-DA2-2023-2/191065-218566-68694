using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Models.DTO.ProductDTOs
{
    public class ProductUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public List<string> Colors { get; set; }        
        public int Stock { get; set; }
        public bool PromoAvailable { get; set; }
    }
}
