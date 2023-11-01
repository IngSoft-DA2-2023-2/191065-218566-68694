using ClothingStore.DataAccess.Interface;
using ClothingStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.DataAccess.Repositories
{
    public class PaymentRepository:IPaymentRepository
    {
        private DbContext _dbContext;
        private readonly DbSet<Payment> payments;
        public PaymentRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            payments = _dbContext.Set<Payment>();
        }

        public List<Payment> GetAll()
        {
            return payments.ToList();
        }

        public Payment GetById(int id)
        {
            return payments.Where(c => c.Id == id).FirstOrDefault();
        }

        public Payment GetByName(string name)
        {
            return payments.Where(c => c.Name == name).FirstOrDefault();
        }
    }
}
