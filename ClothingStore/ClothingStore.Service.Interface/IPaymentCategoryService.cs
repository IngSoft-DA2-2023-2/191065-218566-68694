using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Service.Interface
{
    public interface IPaymentCategoryService
    {
        public List<PaymentCategory> GetAll();
        public PaymentCategory GetById(int id);
        public PaymentCategory GetByName(string name);
    }
}
