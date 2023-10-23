using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.DataAccess.Interface
{
    public interface IUserRepository
    {
        public void Create(User user);
        public List<User> GetAll();
        public User GetById(int id);
        public User GetByEmail(string email);
        public void Delete(int id);
        public void Update(User user);
        public bool ExistsUser(string email);
        public User ValidUser(string email, string password);
    }
}
