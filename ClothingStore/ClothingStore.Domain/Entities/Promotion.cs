using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Domain.Entities
{
    public class Promotion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Available { get; set; } = true;
        public List<ShoppingCart> ShoppingCarts { get; set; }

        public Promotion()
        {
            ShoppingCarts = new List<ShoppingCart>();
        }

        
    }
}
