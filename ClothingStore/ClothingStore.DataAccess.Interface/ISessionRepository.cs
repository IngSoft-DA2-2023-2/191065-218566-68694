using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.DataAccess.Interface
{
    public interface ISessionRepository
    {
        public void Create(Session session);
        public List<Session> GetAll();
        public Session GetByToken(string token);
        public void Delete(string token);
        public Session GetSessionByEmail(string email);

    }
}
