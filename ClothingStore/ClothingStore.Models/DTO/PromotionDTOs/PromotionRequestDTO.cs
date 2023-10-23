using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Models.DTO.PromotionDTOs
{
    public class PromotionRequestDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Promotion ToEntity()
        {
            return new Promotion()
            {
                Name = Name,                
                Description = Description
            };
        }

    }
}