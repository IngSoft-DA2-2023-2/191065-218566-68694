using ClothingStore.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStore.Controllers
{
    [Route("/api/brands")]
    [ApiController]
    public class BrandController : Controller
    {
        private readonly IBrandService brandService;

        public BrandController(IBrandService brandService)
        {
            this.brandService = brandService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var brands = brandService.GetAll();
            return Ok(brands);
        }

        [HttpGet("{brandId}")]
        public IActionResult GetById(int brandId)
        {
            var brand = brandService.GetById(brandId);
            return Ok(brand);
        }
    }
}
