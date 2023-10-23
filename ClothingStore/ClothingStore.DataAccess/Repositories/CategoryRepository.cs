using ClothingStore.DataAccess.Interface;
using ClothingStore.DataAccess.Repositories;
using ClothingStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClothingStore.DataAccess.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private DbContext _dbContext;
        private readonly DbSet<Category> categories;
        public CategoryRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            categories = _dbContext.Set<Category>();
        }

        public List<Category> GetAll()
        {
            return categories.ToList();
        }

        public Category GetById(int id)
        {
            return categories.Where(c => c.Id == id).FirstOrDefault();
        }

        public Category GetByName(string name)
        {
            return categories.Where(c => c.Name == name).FirstOrDefault();
        }
    }
}
