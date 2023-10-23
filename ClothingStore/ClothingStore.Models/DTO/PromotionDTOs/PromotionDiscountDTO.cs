using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Models.DTO.PromotionDTOs
{
    public class PromotionDiscountDTO
    {
        public double Discount { get; set; } = 0;
        public string PromotionName { get; set; }
    }
}
