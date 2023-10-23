using ClothingStore.Domain.Entities;
using ClothingStore.Models.DTO.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Models.DTO.ShoppingCartDTO
{
    public class ShoppingCartResponseDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public double SubTotal { get; set; } = 0;
        public double Discount { get; set; } = 0;
        public double Total { get; set; } = 0;
        public DateTime CartDate { get; set; } = DateTime.Now;
        public List<ProductInCartDTO> Products { get; set; }

        public ShoppingCartResponseDTO()
        {
            Products = new List<ProductInCartDTO>();
        }
    }



}
