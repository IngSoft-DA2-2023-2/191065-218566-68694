using ClothingStore.DataAccess.Interface;
using ClothingStore.Domain.Entities;
using ClothingStore.Models.DTO.SessionDTOs;
using ClothingStore.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Service
{
    public class SessionService: ISessionService
    {
        private readonly ISessionRepository _sessionRepository;
        private readonly IUserRepository _userRepository;

        public SessionService(ISessionRepository sessionRepository, IUserRepository userRepository)
        {
            _sessionRepository = sessionRepository;
            _userRepository = userRepository;
        }

        public Guid Create(SessionRequestDTO sessionRequestDTO)
        {
            var user = _userRepository.ValidUser(sessionRequestDTO.Email, sessionRequestDTO.Password);
            if (user == null)
            {
                throw new ArgumentException("Credenciales no válidas");
            }
            var session = new Session();
            session.User = user;
            session.UserId = user.Id;
            _sessionRepository.Create(session);
            return session.Token;
        }

        public List<Session> GetAll()
        {
            return _sessionRepository.GetAll();
        }
        public Session GetByToken(Guid token)
        {
            return _sessionRepository.GetByToken(token);
        }

        public void Delete(Guid token)
        {
            var session = _sessionRepository.GetByToken(token);
            if (session == null)
            {
                throw new ArgumentException("Credenciales no válidas");
            }
            _sessionRepository.Delete(token);
        }
    }
}
