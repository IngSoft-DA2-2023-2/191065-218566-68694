using ClothingStore.Domain.Entities;
using ClothingStore.Models.DTO.UserDTOs;
using ClothingStore.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Data;

namespace ClothingStore.Controllers
{
    [Route("/api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
           return Ok(userService.GetAll());           
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(userService.GetById(id));
         
        }

        [HttpGet("byEmail/{email}")]
        public IActionResult GetByEmail(string email)
        {
            return Ok(userService.GetByEmail(email));
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserRequestDTO userDTO)
        {
            userService.Create(userDTO);
            return Ok("El usuario ha sido creado correctamente");         
        }

        [HttpPatch]
        public IActionResult Put([FromBody] User user)
        {
            userService.Update(user);
            return Ok("El usuario ha sido actualizado correctamente");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            userService.Delete(id);
            return Ok("El usuario ha sido borrado correctamente");
        }
        
    }


}
