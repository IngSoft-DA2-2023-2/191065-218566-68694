using ClothingStore.Domain.Entities;
using ClothingStore.Models.DTO.PromotionDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Service.Interface
{
    public interface IPromotionService
    {
        public void Create(PromotionRequestDTO promotionRequestDTO);
        public List<Promotion> GetAll();
        public List<Promotion> GetAllAvailable();
        public Promotion GetById(int id);
        public Promotion GetByName(string name);
        public void EnablePromotion(int promotionId);
        public void DisablePromotion(int promotionId);
    }
}
