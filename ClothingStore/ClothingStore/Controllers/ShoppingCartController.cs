using ClothingStore.Models.DTO.ShoppingCartDTO; 
using ClothingStore.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStore.Controllers
{
    [Route("/api/shoppingCarts")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            this.shoppingCartService = shoppingCartService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(shoppingCartService.GetAll());
        }

        [HttpGet("{shoppingCartId}")]
        public IActionResult GetById(int shoppingCartId)
        {
            var shoppingCart = shoppingCartService.GetById(shoppingCartId);
            return Ok(shoppingCart);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ShoppingCartRequestDTO shoppingCartRequestDTO)
        {
            shoppingCartService.Create(shoppingCartRequestDTO);
            return Ok("El carrito ha sido creado correctamente");
        }

        [HttpPatch("add/{shoppingCartId}")]
        public IActionResult Put(int shoppingCartId, [FromBody] int productId)
        {
            shoppingCartService.AddProductCart(shoppingCartId, productId);
            return Ok("El producto ha sido agregado al carrito");
        }

        [HttpPatch("remove/{shoppingCartId}")]
        public IActionResult Remove(int shoppingCartId, [FromBody] int productId)
        {
            shoppingCartService.RemoveProductCart(shoppingCartId, productId);
            return Ok("El producto ha sido eliminado del carrito");
        }

        [HttpGet("total/{shoppingCartId}")]
        public IActionResult GetTotal(int shoppingCartId)
        {
            var total = shoppingCartService.GetTotal(shoppingCartId);
            return Ok(total);
        }

        [HttpGet("discount/{shoppingCartId}")]
        public IActionResult GetDiscount(int shoppingCartId)
        {
            var discount = shoppingCartService.RunPromotions(shoppingCartId);
            return Ok(discount);
        }

        [HttpPatch("sales/{shoppingCartId}")]
        public IActionResult Sale(int shoppingCartId, [FromBody] int paymentId)
        {
            var order = shoppingCartService.Sale(shoppingCartId, paymentId);
            return Ok(order);
        }

        [HttpGet("sales")]
        public IActionResult GetSales()
        {
            var sales = shoppingCartService.GetSales();
            return Ok(sales);
        }

        [HttpGet("sales/{userId}")]
        public IActionResult GetSalesByUserId(int userId)
        {
            var sales = shoppingCartService.GetSalesByUserId(userId);
            return Ok(sales);
        }
    }

}

