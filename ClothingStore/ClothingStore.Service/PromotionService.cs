using ClothingStore.DataAccess.Interface;
using ClothingStore.DataAccess.Repositories;
using ClothingStore.Domain.Entities;
using ClothingStore.Models.DTO.PromotionDTOs;
using ClothingStore.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Service
{
    public class PromotionService : IPromotionService
    {
        private readonly IPromotionRepository _promotionRepository;        

        public PromotionService(IPromotionRepository promotionRepository)
        {
            _promotionRepository = promotionRepository;            
        }
        public void Create(PromotionRequestDTO promotionRequestDTO)
        {
            var promotion = promotionRequestDTO.ToEntity();
            _promotionRepository.Create(promotion);
        }

        public List<Promotion> GetAll()
        {
            List<Promotion> promotions = _promotionRepository.GetAll();
            return promotions;
        }
        public List<Promotion> GetAllAvailable()
        {
            List<Promotion> promotions = _promotionRepository.GetAllAvailable();
            return promotions;
        }

        public Promotion GetById(int id)
        {
            Promotion promotion = _promotionRepository.GetById(id);
            if (promotion == null)
            {
                throw new ArgumentException($"No se puede obtener la promocion.");
            }
            return promotion;
        }
        public Promotion GetByName(string name)
        {
            Promotion promotion = _promotionRepository.GetByName(name);
            if (promotion == null)
            {
                throw new ArgumentException($"No se puede obtener la promocion.");
            }
            return promotion;
        }

        public void EnablePromotion(int promotionId)
        {
            var promotion = _promotionRepository.GetById(promotionId);
            if ( promotion == null)
            {
                throw new ArgumentException($"No se puede obtener la promocion.");
            }
            promotion.Available = true;
            _promotionRepository.EnableDisablePromotion(promotion);
        }
        public void DisablePromotion(int promotionId)
        {
            var promotion = _promotionRepository.GetById(promotionId);
            if (promotion == null)
            {
                throw new ArgumentException($"No se puede obtener la promocion.");
            }
            promotion.Available = false;
            _promotionRepository.EnableDisablePromotion(promotion);
        }

    }
}
