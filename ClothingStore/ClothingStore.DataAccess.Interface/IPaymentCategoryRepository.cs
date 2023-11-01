using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.DataAccess.Interface
{
    public interface IPaymentCategoryRepository
    {
        public List<PaymentCategory> GetAll();
        public PaymentCategory GetById(int id);
        public PaymentCategory GetByName(string name);
    }
}
