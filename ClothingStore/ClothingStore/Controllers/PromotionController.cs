using ClothingStore.Models.DTO.ProductDTOs;
using ClothingStore.Models.DTO.PromotionDTOs;
using ClothingStore.Service;
using ClothingStore.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStore.Controllers
{
    [Route("/api/promotions")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionService promotionService;

        public PromotionController(IPromotionService promotionService)
        {
            this.promotionService = promotionService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(promotionService.GetAll());
        }

        [HttpGet("id/{promotionId}")]
        public IActionResult GetById(int promotionId)
        {
            var promotion = promotionService.GetById(promotionId);
            return Ok(promotion);
        }

        [HttpGet("name/{promotionName}")]
        public IActionResult GetByName(string promotionName)
        {
            var promotion = promotionService.GetByName(promotionName);
            return Ok(promotion);
        }

        [HttpPost]
        public IActionResult Post([FromBody] PromotionRequestDTO promotionRequestDTO)
        {
            promotionService.Create(promotionRequestDTO);
            return Ok("La promocion ha sido creada correctamente");
        }

        [HttpPatch("active/{promoId}")]
        public IActionResult EnablePromotion(int promoId)
        {
            try
            {
                promotionService.EnablePromotion(promoId);
                return Ok("La promocion ha sido habilitada");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //var (statusCode, message) = ExceptionsFilter.HandleException(ex);
                //return StatusCode(statusCode, message);
            }
        }
        [HttpPatch("deactive/{promoId}")]
        public IActionResult DisablePromotion(int promoId)
        {
            try
            {
                promotionService.DisablePromotion(promoId);
                return Ok("La promocion ha sido deshabilitada");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //var (statusCode, message) = ExceptionsFilter.HandleException(ex);
                //return StatusCode(statusCode, message);
            }
        }

    }
}
