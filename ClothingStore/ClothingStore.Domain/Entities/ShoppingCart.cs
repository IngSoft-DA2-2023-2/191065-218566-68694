using ClothingStore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Domain.Entities
{
    public  class ShoppingCart
    {
        public int Id { get; set; }                        
        public double SubTotal { get; set; } = 0;
        public double Discount { get; set; } = 0;
        public double Total { get; set; } = 0;
        public DateTime CartDate { get; set; } = DateTime.Now;
        public User User { get; set; }
        public int UserId { get; set; }
        public List<Product> Products { get; set; }
        public Promotion Promotion { get; set; } 
        public int PromotionId { get; set; }        
        public StateOrder StateOrder { get; set; } = StateOrder.Pending;
        public Payment Payment { get; set; }
        public int PaymentId { get; set; }
        
        
        public ShoppingCart()
        {
            Products = new List<Product>();            
        }
        
    }

    


}
