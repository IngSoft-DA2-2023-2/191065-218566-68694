using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Service.Interface
{
    public interface IPaymentService
    {
        public List<Payment> GetAll();
        public Payment GetById(int id);
        public Payment GetByName(string name);
    }
}
