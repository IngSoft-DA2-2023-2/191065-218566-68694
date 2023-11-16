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
        }

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
    }
}
