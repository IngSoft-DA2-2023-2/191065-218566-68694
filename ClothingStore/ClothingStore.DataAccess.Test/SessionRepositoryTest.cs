using ClothingStore.DataAccess.Interface;
using ClothingStore.DataAccess.Repositories;
using ClothingStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.DataAccess.Test
{
    [TestClass]
    public class SessionRepositoryTest
    {
        private ISessionRepository sessionRepository;
        private DataContext context;
        private Session testSession;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: "database_name").Options;
            context = new DataContext(options);
            sessionRepository = new SessionRepository(context);
        }

        [TestCleanup]
        public void Cleanup()
        {
            context.Database.EnsureDeleted();
        }

        
        //public void Create(Session session);
        //public List<Session> GetAll();
        //public Session GetByToken(Guid token);
        //public void Delete(Guid token);

    }
}
