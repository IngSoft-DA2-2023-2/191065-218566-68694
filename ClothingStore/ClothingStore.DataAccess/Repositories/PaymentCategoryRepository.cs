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
    public class PaymentCategoryRepository: IPaymentCategoryRepository
    {
        private DbContext _dbContext;
        private readonly DbSet<PaymentCategory> paymentCategories;
        public PaymentCategoryRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            paymentCategories = _dbContext.Set<PaymentCategory>();
        }

        public List<PaymentCategory> GetAll()
        {
            return paymentCategories.ToList();
        }

        public PaymentCategory GetById(int id)
        {
            return paymentCategories.Where(c => c.Id == id).FirstOrDefault();
        }

        public PaymentCategory GetByName(string name)
        {
            return paymentCategories.Where(c => c.Name == name).FirstOrDefault();
        }

    }
}
