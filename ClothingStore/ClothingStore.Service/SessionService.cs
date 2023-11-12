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
        private ITokenService _tokenService;

        public SessionService(ISessionRepository sessionRepository, IUserRepository userRepository, ITokenService tokenService)
        {
            _sessionRepository = sessionRepository;
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public SessionResponseDTO Login(SessionRequestDTO sessionRequestDTO)

        {
            var user = _userRepository.GetByEmail(sessionRequestDTO.Email);
            Session session = new Session();
            if (user == null)
            {
                throw new ArgumentException("El usuario no existe");

            }
            if (user.Password != sessionRequestDTO.Password)
            {
                throw new ArgumentException("Usuario y/o contraseña incorrectos.");
            }
            Session existsSession = _sessionRepository.GetSessionByEmail(sessionRequestDTO.Email);
            var sessionResponseDTO = new SessionResponseDTO();

            if (existsSession != null)
            {
                session.Token = existsSession.Token;
                sessionResponseDTO.Token = existsSession.Token;
            }
            else
            {
                session.Token = _tokenService.GenerateToken(user);
                sessionResponseDTO.Token = session.Token;
            }
            session.User = user;
             _sessionRepository.Create(session);
            sessionResponseDTO.Email = session.User.Email;
            sessionResponseDTO.UserId = session.User.Id;
            return sessionResponseDTO;
        }

        public List<Session> GetAll()
        {
            return _sessionRepository.GetAll();
        }
        public Session GetByToken(string token)
        {
            return _sessionRepository.GetByToken(token);
        }

        public void Logout(string token)
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
