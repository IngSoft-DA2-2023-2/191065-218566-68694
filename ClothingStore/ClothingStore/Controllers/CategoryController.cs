using ClothingStore.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStore.Controllers
{
    [Route("/api/categories")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categorys = categoryService.GetAll();
            return Ok(categorys);
        }

        [HttpGet("{categoryId}")]
        public IActionResult GetById(int categoryId)
        {
            var category = categoryService.GetById(categoryId);
            return Ok(category);
        }
    }
}
