using ClothingStore.Domain.Entities;
using ClothingStore.Migrations;
using ClothingStore.Models.DTO.SessionDTOs;
using ClothingStore.Service;
using ClothingStore.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStore.Controllers
{
    [Route("/api/sessions")]
    [ApiController]       
    public class SessionController : ControllerBase
    {
        private readonly ISessionService sessionService;

        public SessionController(ISessionService sessionService)
        {
            this.sessionService = sessionService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] SessionRequestDTO sessionRequestDTO)
        {            
            return Ok(sessionService.Create(sessionRequestDTO));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(sessionService.GetAll());
        }

        [HttpGet("{token}")]
        public IActionResult GetByToken(Guid token)
        {
            var session = sessionService.GetByToken(token);
            return Ok(session);
        }

        [HttpDelete("{token}")]
        public IActionResult Delete(Guid token)
        {
            try
            {
                sessionService.Delete(token);
                return Ok("Usuario logout");
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

