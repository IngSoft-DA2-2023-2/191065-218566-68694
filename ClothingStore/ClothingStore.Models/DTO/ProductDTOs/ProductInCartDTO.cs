using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClothingStore.Models.DTO.ProductDTOs
{
    public class ProductInCartDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }   
        public double Price { get; set; }
    }
}
