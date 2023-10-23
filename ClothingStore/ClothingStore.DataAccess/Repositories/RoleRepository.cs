using ClothingStore.DataAccess.Interface;
using ClothingStore.DataAccess.Repositories;
using ClothingStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.DataAccess.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private DbContext _dbContext;
        private readonly DbSet<Role> roles;
        public RoleRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            roles = _dbContext.Set<Role>();
        }

        public List<Role> GetAll()
        {
            return roles.ToList();
        }

        public Role GetById(int id)
        {
            return roles.Where(r => r.Id == id).FirstOrDefault();
        }

        public Role GetByName(string name)
        {
            return roles.Where(c => c.Name == name).FirstOrDefault();
        }

        public bool ExistsRole(string name)
        {
            return roles.Any(r => r.Name == name);
        }
    }
}
