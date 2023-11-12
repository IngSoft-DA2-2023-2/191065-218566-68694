using ClothingStore.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStore.Controllers
{
    [Route("/api/roles")]
    [ApiController]
    public class RoleController : Controller
    {
        private readonly IRoleService roleService;

        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var roles = roleService.GetAll();
            return Ok(roles);
        }
    }
}
