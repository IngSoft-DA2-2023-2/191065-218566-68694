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
        public Guid Create (SessionRequestDTO sessionRequestDTO);
        public List<Session> GetAll();
        public Session GetByToken(Guid token);
        public void Delete(Guid token);
    }
}
