using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.DataAccess.Interface
{
    public interface IPromotionRepository
    {
        public void Create(Promotion promotion);
        public List<Promotion> GetAll();
        public List<Promotion> GetAllAvailable();
        public Promotion GetById(int id);
        public Promotion GetByName(string name);
        public void EnableDisablePromotion(Promotion promotion);
    }
}
