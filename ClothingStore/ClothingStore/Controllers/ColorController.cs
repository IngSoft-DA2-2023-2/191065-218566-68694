using ClothingStore.Models.DTO.ProductDTOs;
using ClothingStore.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStore.Controllers
{
    [Route("/api/colors")]
    [ApiController]
    public class ColorController : Controller
    {
        private readonly IColorService colorService;

        public ColorController(IColorService colorService)
        {
            this.colorService = colorService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var colors = colorService.GetAll();
            return Ok(colors);
        }

        [HttpGet("{colorId}")]
        public IActionResult GetById(int colorId)
        {
            var color = colorService.GetById(colorId);
            return Ok(color);
        }
    }
}
