using ClothingStore.DataAccess.Interface;
using ClothingStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.DataAccess.Repositories
{
    public class SessionRepository: ISessionRepository
    {
        private DbContext _dbContext;
        private readonly DbSet<Session> sessions;

        public SessionRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            sessions = _dbContext.Set<Session>();
        }

        public void Create(Session session)
        {
            sessions.Add(session);
            _dbContext.SaveChanges();
        }
        public List<Session> GetAll()
        {
            return sessions.ToList();
        }

        public Session GetByToken(string token)
        {
            var session = sessions.Where(s => s.Token == token).Include(s => s.User).FirstOrDefault();
            return session;
        }

        public void Delete(string token)
        {
            Session sessionToDelete = sessions.Where(s => s.Token == token).FirstOrDefault();
            sessions.Remove(sessionToDelete);
            _dbContext.SaveChanges();
        }

        public Session GetSessionByEmail(string email)
        {
            return sessions.FirstOrDefault(s => s.User.Email == email);
        }

    }
}
