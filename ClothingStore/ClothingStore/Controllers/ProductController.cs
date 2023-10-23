using ClothingStore.DataAccess;
using ClothingStore.Models.DTO.ProductDTOs;
using ClothingStore.Domain.Entities;
using ClothingStore.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using ClothingStore.Service;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace ClothingStore.Controllers
{
    [Route("/api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {        
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(productService.GetAll());
        }

        [HttpGet("{productId}")]
        public IActionResult GetById(int productId)
        {
            try
            {
                var product = productService.GetById(productId);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //var (statusCode, message) = ExceptionsFilter.HandleException(ex);
                //return StatusCode(statusCode, message);
            }
        }
      
        [HttpPost]
        public IActionResult Post([FromBody] ProductRequestDTO productRequestDTO)
        {
            try
            {
                productService.Create(productRequestDTO);
                return Ok("El producto ha sido creado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //var (statusCode, message) = ExceptionsFilter.HandleException(ex);
                //return StatusCode(statusCode, message);
            }
        }

        [HttpPatch]
        public IActionResult Put([FromBody] ProductUpdateDTO product)
        {
            try
            {
                productService.Update(product);
                return Ok("El producto ha sido actualizado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
                //var (statusCode, message) = ExceptionsFilter.HandleException(ex);
                //return StatusCode(statusCode, message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                productService.Delete(id);
                return Ok("El producto ha sido borrado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //var (statusCode, message) = ExceptionsFilter.HandleException(ex);
                //return StatusCode(statusCode, message);
            }
        }

        [HttpGet("name/{name}")]
        public IActionResult GetByName(string name)
        {
            try
            {                
                List<Product> products = productService.GetByName(name);                
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //var (statusCode, message) = ExceptionsFilter.HandleException(ex);
                //return StatusCode(statusCode, message);
            }
        }

        [HttpGet("description/{description}")]
        public IActionResult GetByDescription(string description)
        {
            try
            {
                List<Product> products = productService.GetByDescription(description);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //var (statusCode, message) = ExceptionsFilter.HandleException(ex);
                //return StatusCode(statusCode, message);
            }
        }

        [HttpGet("brand/{brandName}")]
        public IActionResult GetByBrand(string brandName)
        {
            try
            {
                List<Product> products = productService.GetByBrand(brandName);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //var (statusCode, message) = ExceptionsFilter.HandleException(ex);
                //return StatusCode(statusCode, message);
            }
        }

        [HttpGet("category/{categoryName}")]
        public IActionResult GetByCategory(string categoryName)
        {
            try
            {
                List<Product> products = productService.GetByCategory(categoryName);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //var (statusCode, message) = ExceptionsFilter.HandleException(ex);
                //return StatusCode(statusCode, message);
            }
        }

        [HttpGet("search")]
        public IActionResult GetBySearch(string? name, string? category, string? brand)
        {
            try
            {
                List<Product> products = productService.GetBySearch(name, category, brand);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //var (statusCode, message) = ExceptionsFilter.HandleException(ex);
                //return StatusCode(statusCode, message);
            }
        }

        [HttpPatch("active/{productId}")]
        public IActionResult Enable(int productId)
        {
            try
            {
                productService.EnableProductPromotion(productId);
                return Ok("El producto ha sido habilitado para promociones");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //var (statusCode, message) = ExceptionsFilter.HandleException(ex);
                //return StatusCode(statusCode, message);
            }
        }

        [HttpPatch("deactive/{productId}")]
        public IActionResult DisablePromotion(int productId)
        {
            try
            {
                productService.DisableProductPromotion(productId);
                return Ok("El producto ha sido deshabilitado para promociones");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //var (statusCode, message) = ExceptionsFilter.HandleException(ex);
                //return StatusCode(statusCode, message);
            }
        }

        [HttpGet("price")]
        public IActionResult GetByPrice(double startPrice, double endPrice)
        {
            try
            {
                List<Product> products = productService.GetByPrice(startPrice,endPrice);
                return Ok(products);
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








