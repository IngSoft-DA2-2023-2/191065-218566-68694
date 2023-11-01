using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Domain.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PaymentCategory PaymentCategory { get; set; }
        public int PaymentCategoryId { get; set; }
        public int Discount { get; set; }
        public List<ShoppingCart> shoppingCarts { get; set; }
    }
}
