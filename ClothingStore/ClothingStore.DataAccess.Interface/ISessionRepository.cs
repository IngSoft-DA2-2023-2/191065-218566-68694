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
        public Session GetByToken(Guid token);
        public void Delete(Guid token);

    }
}
