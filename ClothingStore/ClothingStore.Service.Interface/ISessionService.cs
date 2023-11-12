using ClothingStore.Domain.Entities;
using ClothingStore.Models.DTO.SessionDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Service.Interface
{
    public interface ISessionService
    {
        public SessionResponseDTO Login (SessionRequestDTO sessionRequestDTO);
        public List<Session> GetAll();
        public Session GetByToken(string token);
        public void Logout(string token);
    }
}
