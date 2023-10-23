using ClothingStore.DataAccess.Interface;
using ClothingStore.DataAccess.Repositories;
using ClothingStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.DataAccess.Repositories
{
    public class PromotionRepository : IPromotionRepository
    {
        private DbContext _dbContext;
        private readonly DbSet<Promotion> promotions;

        public PromotionRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            promotions = _dbContext.Set<Promotion>();
        }
        public void Create(Promotion promotion)
        {
            promotions.Add(promotion);
            _dbContext.SaveChanges();
        }        

        public List<Promotion> GetAll()
        {
            return promotions.ToList();
        }
        public List<Promotion> GetAllAvailable()
        {
            var promotionsAvailable = promotions.Where(promotion => promotion.Available).ToList();
            return promotionsAvailable;
        }

        public Promotion GetById(int id)
        {
            var promotion = promotions.Where(p => p.Id == id).FirstOrDefault();
            return promotion;
        }
        public Promotion GetByName(string name)
        {
            var promotion = promotions.Where(p => p.Name == name).FirstOrDefault();
            return promotion;
        }

        public void EnableDisablePromotion(Promotion promotion)
        {
            var existingPromotion = promotions.FirstOrDefault(p => p.Id == promotion.Id);
            if (existingPromotion != null)
            {
                _dbContext.Entry(existingPromotion).CurrentValues.SetValues(promotion);
                _dbContext.SaveChanges();
            }
        }
    }
}
