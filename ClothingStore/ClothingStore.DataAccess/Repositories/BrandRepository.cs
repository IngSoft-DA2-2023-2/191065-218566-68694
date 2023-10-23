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
    public class BrandRepository:IBrandRepository
    {
        private DbContext _dbContext;
        private readonly DbSet<Brand> brands;
        public BrandRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            brands = _dbContext.Set<Brand>();
        }

        public List<Brand> GetAll()
        {
            return brands.ToList();
        }

        public Brand GetById(int id)
        {
            return brands.Where(c => c.Id == id).FirstOrDefault();
        }

        public Brand GetByName(string name)
        {
            return brands.Where(c => c.Name == name).FirstOrDefault();
        }

    }
}
