using ClothingStore.DataAccess.Interface;
using ClothingStore.Domain.Entities;
using ClothingStore.Models.DTO.SessionDTOs;
using Moq;

namespace ClothingStore.Service.Test
{
    [TestClass]
    public class SessionServiceTest
    {
        private ISessionRepository sessionRepository;
        private Session sessionTest;

        [TestInitialize]
        public void InitTest()
        {
            
        }

    }
}
//Entity
//public int Id { get; set; }
//public Guid Token { get; set; }
//public User User { get; set; }
//public int UserId { get; set; }

//DTo
//public string Email { get; set; }
//public string Password { get; set; }

//Metodos a probar
//public Guid Create(SessionRequestDTO sessionRequestDTO);
//public List<Session> GetAll();
//public Session GetByToken(Guid token);
//public void Delete(Guid token);
