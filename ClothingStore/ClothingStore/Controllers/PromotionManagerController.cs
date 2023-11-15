using ClothingStore.Models.DTO.ProductDTOs;
using ClothingStore.Models.DTO.PromotionDTOs;
using ClothingStore.Service;
using ClothingStore.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStore.Controllers
{
    [Route("/api/promotionmanager")]
    [ApiController]
    public class PromotionManagerController : ControllerBase
    {
        private readonly IPromotionManagerService promotionManagerService;

        public PromotionManagerController(IPromotionManagerService promotionManagerService)
        {
            this.promotionManagerService = promotionManagerService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(promotionManagerService.GetPromotionList());
        }/*

        [HttpGet("id/{promotionId}")]
        public IActionResult GetById(int promotionId)
        {
            var promotion = promotionManagerService.GetById(promotionId);
            return Ok(promotion);
        }

        [HttpGet("name/{promotionName}")]
        public IActionResult GetByName(string promotionName)
        {
            var promotion = promotionService.GetByName(promotionName);
            return Ok(promotion);
        }*/

        [HttpPost]
        public IActionResult Post([FromBody] string filePathToLoadDLL)
        {
            promotionManagerService.PromotionDllLoad(filePathToLoadDLL);
            return Ok("La promocion ha sido cargada correctamente");
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] string filePathToUnloadDLL)
        {
            promotionManagerService.PromotionDllUnload(filePathToUnloadDLL);
            return Ok("La promocion ha sido eliminada correctamente");
        }
        /*

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
        }*/

    }
}
