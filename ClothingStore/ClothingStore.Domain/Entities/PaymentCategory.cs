using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Domain.Entities
{
    public class PaymentCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Payment> Payments { get; set; }
    }
}
