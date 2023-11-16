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
    public class UserRepository : IUserRepository
    {
        private DbContext _dbContext;
        private readonly DbSet<User> users;

        public UserRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            users = _dbContext.Set<User>();
        }

        public void Create(User user)
        {
            users.Add(user);
            _dbContext.SaveChanges();
        }

        public List<User> GetAll()
        {
            return users.Include(u => u.Roles).ToList();
        }

        public User GetById(int id)
        {            
            var userFull = users.Where(u => u.Id == id).Include(u => u.Roles).FirstOrDefault();
            return userFull;
        }

        public User GetByEmail(string email)
        {
            return users.Where(u => u.Email == email).Include(u => u.Roles).FirstOrDefault();
        }

        public void Delete(int id)
        {
            User userToDelete = users.Where(x => x.Id == id).FirstOrDefault();
            users.Remove(userToDelete);
            _dbContext.SaveChanges();
        }

        public void Update(User user)
        {
            var existingUser = users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser != null)
            {
                _dbContext.Entry(existingUser).CurrentValues.SetValues(user);
                _dbContext.SaveChanges();
            }
        }

        public bool ExistsUser(string email)
        {
            return users.Any(u => u.Email == email);
        }

        public User ValidUser(string email, string password)
        {
            var user = users.Where(u => u.Email == email && u.Password == password).FirstOrDefault();
            return user;
        }
    }
    
}
